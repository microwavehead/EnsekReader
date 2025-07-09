using CsvHelper.Configuration;
using EnsekReader.API.Models;

namespace EnsekReader.API.Helpers
{
    public class MeterReadingMapping : ClassMap<MeterReading>
    {
        public MeterReadingMapping()
        {
            Map(m => m.MeterReadValue);
            Map(m => m.AccountId);
            Map(m => m.MeterReadingDateTime).TypeConverterOption.Format("dd/MM/yyyy HH:mm");
        }
    }
}
