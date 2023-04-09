using mcHahn.Application.Common.Interfaces.Authentication;
using mcHahn.Application.Common.Interfaces.Persistance;
using mcHahn.Domain.Entities;

namespace mcHahn.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Login(string email, string password)
        {
            //  .Check that user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("Account with those credentials does not exists.");
            }
            //  .Validate password
            if (user.Password != password)
            {
                throw new Exception("Invalid password.");
            }
            //  .Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string name, string email, string password)
        {
            //. Check if user already exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("Email already exists.");
            }
            var user = new User { Name = name, Email = email, Password = password };
            _userRepository.Add(user);
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
