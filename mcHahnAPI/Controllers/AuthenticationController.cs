﻿using mcHahn.Application.Services.Authentication;
using mcHahn.Contracts.Authentication;
using mcHahn.Domain.Entities;
using mcHahnAPI.Filters;
using mcHahnAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
            //  Fluent Validation
            var validatedUser = new User { Name = request.name, Email = request.email, Password = request.password };
            var validator = new UserValidator();
            var results = validator.Validate(validatedUser);
            if (!results.IsValid)
            {
                return BadRequest("Error on entered inputs. Please validate.");
            }
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
            //  Fluent Validation
            var validatedUser = new User { Name = "", Email = request.email, Password = request.password };
            var validator = new UserValidator();
            var results = validator.Validate(validatedUser);
            if (!results.IsValid)
            {
                return BadRequest("Error on entered inputs. Please validate.");
            }
            var authResult = _authenticationService.Login(request.email, request.password);
            //  map values
            var resp = new AuthenticationResponse(authResult.user.Id, authResult.user.Name, authResult.user.Email, authResult.token);
            Console.WriteLine(resp);
            return Ok(resp);
        }
    }
}
