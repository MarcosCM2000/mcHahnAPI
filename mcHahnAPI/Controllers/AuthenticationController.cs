using mcHahn.Application.Services.Authentication;
using mcHahn.Contracts.Authentication;
using mcHahnAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace mcHahnAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    //  [ErrorHandlingFilter]
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
            Console.WriteLine("---Register---");

            var authResult = _authenticationService.Register(request.name, request.email, request.password);
            //  map values
            var resp = new AuthenticationResponse(authResult.user.Id, authResult.user.Name, authResult.user.Email, authResult.token);
            Console.WriteLine(resp);
            return Ok(resp);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            Console.WriteLine("---Login---");
            /*try {
                //  const [request, error] = login (request);
                _authenticationService.Login(request.email, request.password);
            } catch (Exception ex) {
            
            }*/
            Console.WriteLine(request);
            var authResult = _authenticationService.Login(request.email, request.password);
            //  map values
            var resp = new AuthenticationResponse(authResult.user.Id, authResult.user.Name, authResult.user.Email, authResult.token);
            Console.WriteLine(resp);
            return Ok(resp);
        }
    }
}
