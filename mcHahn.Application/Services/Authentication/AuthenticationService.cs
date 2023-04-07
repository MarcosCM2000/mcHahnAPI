namespace mcHahn.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(new Random().Next(1, 100), "name", email, "token");
        }

        public AuthenticationResult Register(string name, string email, string password)
        {
            return new AuthenticationResult(new Random().Next(1, 100), name, email, "token");
        }
    }
}
