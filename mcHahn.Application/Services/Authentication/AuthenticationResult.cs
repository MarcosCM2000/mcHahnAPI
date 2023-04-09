using mcHahn.Domain.Entities;

namespace mcHahn.Application.Services.Authentication
{
    public record AuthenticationResult(
    
        User user,
        string token
    );
}
