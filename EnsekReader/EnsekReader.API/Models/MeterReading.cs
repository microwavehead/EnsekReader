using System.ComponentModel.DataAnnotations;

namespace EnsekReader.API.Models
{
    public class MeterReading
    {
        [Key]
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }
    }
}
