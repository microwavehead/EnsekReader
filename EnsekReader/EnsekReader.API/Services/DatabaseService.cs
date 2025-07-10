using EnsekReader.API.Models;
using EnsekReader.API.Models.Database;
using EnsekReader.API.Services.Interfaces;

namespace EnsekReader.API.Services
{
    public class DatabaseService(EnsekDbContext _context) : IDatabaseService
    {
        public bool InsertMeterReadings(List<MeterReading> readings)
        {
            foreach (var reading in readings)
            {
                _context.MeterReadings.Add(reading);
            }

            _context.SaveChanges();
            return false;
        }
    }
}
