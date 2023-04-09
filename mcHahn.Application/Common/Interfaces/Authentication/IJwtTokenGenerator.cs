using mcHahn.Domain.Entities;

namespace mcHahn.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
