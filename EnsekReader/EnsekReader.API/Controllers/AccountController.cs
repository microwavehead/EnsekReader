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
    public class AccountController (IDatabaseService _databaseService, ILogger<FileController> _logger) : ControllerBase
    {        
        [HttpPost("account-uploads")]
        public DatabaseResponse AccountUpload(IFormFile file)
        { 
            try
            {
                using var readStream = file.OpenReadStream();
                using var reader = new StreamReader(readStream);
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                csvReader.Context.RegisterClassMap<MeterReadingMapping>();

                return _databaseService.InsertAccounts(csvReader.GetRecords<Account>().ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading Csv");
            }

            return new DatabaseResponse();
        }
    }
}
