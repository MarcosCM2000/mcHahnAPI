using mcHahn.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace mcHahnAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Console.WriteLine(request);
            return Ok(request);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            Console.WriteLine(request);
            return Ok(request);
        }
    }
}
