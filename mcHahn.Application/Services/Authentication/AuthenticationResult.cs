namespace mcHahn.Application.Services.Authentication
{
    public record AuthenticationResult(
    
        int id,
        string name,
        string email,
        string token
    );
}
