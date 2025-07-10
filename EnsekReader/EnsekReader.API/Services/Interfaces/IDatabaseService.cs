using EnsekReader.API.Models;

namespace EnsekReader.API.Services.Interfaces
{
    public interface IDatabaseService
    {
        DatabaseResponse InsertMeterReadings(List<MeterReading> readings);
        IEnumerable<MeterReading> GetMeterReadings();
    }
}
