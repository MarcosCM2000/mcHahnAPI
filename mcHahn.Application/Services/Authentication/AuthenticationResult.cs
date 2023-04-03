namespace mcHahn.Application.Services.Authentication
{
    public record AuthenticationResult(
    
        int id,
        string email,
        string token
    );
}
