using EnsekReader.API.Models;
using EnsekReader.API.Models.Database;
using EnsekReader.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Security.Cryptography;

namespace EnsekReader.API.Services
{
    public class DatabaseService(IDbContextFactory<EnsekDbContext> _contextFactory, EnsekDbContext _context, ILogger<DatabaseService> _logger) : IDatabaseService
    {
        public DatabaseResponse InsertMeterReadings(List<MeterReading> readings)
        {
            var successful = 0;

            readings = readings.OrderBy(r => r.MeterReadValue).ToList();
            Parallel.ForEach(readings, reading =>
            {
                try
                {
                    var context = _contextFactory.CreateDbContext();

                    if (context.MeterReadings.Any(mr => mr.MeterReadingDateTime > reading.MeterReadingDateTime && mr.AccountId == reading.AccountId))
                        return;

                    context.MeterReadings.Add(reading);
                    context.SaveChanges();
                    Interlocked.Increment(ref successful);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error saving meter reading to database");
                }
            });

            return new DatabaseResponse()
            {
                Successful = successful,
                Failures = readings.Count - successful
            };
        }

        public IEnumerable<MeterReading> GetMeterReadings()
            => _context.MeterReadings.ToList();

        public void ClearMeterReadings()
        {
            _context.MeterReadings.RemoveRange(_context.MeterReadings);
            _context.SaveChanges();
        }

        public DatabaseResponse InsertAccounts(List<Account> accounts)
        {
            var response = new DatabaseResponse();
            foreach (var account in accounts)
            {
                try
                {
                    _context.Accounts.Add(account);
                    _context.SaveChanges();
                    response.Successful++;
                }
                catch
                {
                    _context.ChangeTracker.Clear();
                    response.Failures++;
                }
            }

            return response;
        }

    }
}
