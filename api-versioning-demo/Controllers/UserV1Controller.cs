using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_versioning_demo.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class UserV1Controller : ControllerBase
    {
        [HttpGet("in-currency")]
        public IActionResult Get()
        {
            return Ok("Your currency will be in Rs.");
        }

        [HttpGet("sign-up")]
        public IActionResult SignUp(int id)
        {
            return Ok($"Sign Up Sucessfully with the id {id}");
        }
    }
}
