using mcHahn.Application.Common.Interfaces.Authentication;
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
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationController(IAuthenticationService authenticationService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authenticationService = authenticationService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Console.WriteLine("---Register---");
            //TODO
            //1. Check if user already exists
            //2. If not: Create user (generate ID)
            //3. Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(new Random().Next(1, 10), request.name);

            var authResult = _authenticationService.Register(request.name, request.email, request.password);
            //  map values
            var resp = new AuthenticationResponse(authResult.id, authResult.name, authResult.email, token);
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
            var resp = new AuthenticationResponse(authResult.id, authResult.name, authResult.email, authResult.token);
            Console.WriteLine(resp);
            return Ok(resp);
        }
    }
}
