using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_versioning_demo.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/user")]
    public class UserV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("User from V2 controller.");
        }
    }
}
