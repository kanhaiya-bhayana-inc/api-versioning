using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_versioning_demo.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/user")]
    public class UserV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("User from V1 controller");
        }
    }
}
