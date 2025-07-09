using CsvHelper;
using EnsekReader.API.Helpers;
using EnsekReader.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EnsekReader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
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
                var records = csvReader.GetRecords<MeterReading>().ToList();

                // To Do process them :)
            }
            catch (Exception ex)
            {
                // Log it
            }
        }
    }
}
