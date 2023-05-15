using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_versioning_demo.Controllers
{
    [ApiVersion("2.0")]
    //[Route("api/{v:apiVersion}/user")]
    [Route("api/user")]
    [ApiController]
    public class UserV2Controller : ControllerBase
    {
        [HttpGet("us-currency")]
        public IActionResult Get()
        {
            return Ok("Your currency will be in $s.");
        }
    }
}
