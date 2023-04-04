using mcHahn.Application.Services.Authentication;
using mcHahn.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace mcHahnAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.name, request.email, request.password);
            //  map values
            var resp = new AuthenticationResponse(authResult.id, authResult.name, authResult.email, authResult.token);
            return Ok(resp);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.email, request.password);
            //  map values
            var resp = new AuthenticationResponse(authResult.id, authResult.name, authResult.email, authResult.token);
            return Ok(resp);
        }
    }
}
