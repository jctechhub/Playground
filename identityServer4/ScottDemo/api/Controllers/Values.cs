using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Values: ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Hello World");
            
        }
    }
}