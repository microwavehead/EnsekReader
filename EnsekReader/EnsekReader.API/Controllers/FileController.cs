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
    public class FileController (IDatabaseService _databaseService, ILogger<FileController> _logger) : ControllerBase
    {        
        [HttpPost("meter-reading-uploads")]
        public void MeterReadingUpload(IFormFile file)
        { 
            try
            {
                using var readStream = file.OpenReadStream();
                using var reader = new StreamReader(readStream);
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                csvReader.Context.RegisterClassMap<MeterReadingMapping>();

                _databaseService.InsertMeterReadings(csvReader.GetRecords<MeterReading>().ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading Csv");
            }
        }
    }
}
