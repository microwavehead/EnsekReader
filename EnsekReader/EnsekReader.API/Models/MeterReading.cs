using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EnsekReader.API.Models
{
    [PrimaryKey(nameof(AccountId), nameof(MeterReadingDateTime))]
    public class MeterReading
    {
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }
    }
}
