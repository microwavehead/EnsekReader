using EnsekReader.API.Models;
using EnsekReader.API.Models.Database;
using EnsekReader.API.Services.Interfaces;

namespace EnsekReader.API.Services
{
    public class DatabaseService(EnsekDbContext _context) : IDatabaseService
    {
        public DatabaseResponse InsertMeterReadings(List<MeterReading> readings)
        {
            var response = new DatabaseResponse();
            foreach (var reading in readings)
            {
                try
                {
                    _context.MeterReadings.Add(reading);
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

        public IEnumerable<MeterReading> GetMeterReadings()
            => _context.MeterReadings.ToList();
    }
}
