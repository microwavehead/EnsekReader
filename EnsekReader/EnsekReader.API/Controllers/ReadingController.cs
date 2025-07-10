using CsvHelper;
using EnsekReader.API.Helpers;
using EnsekReader.API.Models;
using EnsekReader.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EnsekReader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController (IDatabaseService _databaseService, ILogger<FileController> _logger) : ControllerBase
    {
        [HttpGet("meter-readings")]
        public IEnumerable<MeterReading> MeterReadingUpload()
            => _databaseService.GetMeterReadings();

        [HttpPost("meter-readings-clear")]
        public void ClearMeterReadings()
            => _databaseService.ClearMeterReadings();
    }
}
