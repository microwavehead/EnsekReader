using EnsekReader.API.Models;

namespace EnsekReader.API.Services.Interfaces
{
    public interface IDatabaseService
    {
        bool InsertMeterReadings(List<MeterReading> readings);
    }
}
