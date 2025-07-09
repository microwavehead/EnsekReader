using Microsoft.AspNetCore.Mvc;

namespace EnsekReader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("Upload")]
        public void Upload()
        { }
    }
}
