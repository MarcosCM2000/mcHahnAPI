namespace mcHahn.Contracts.Authentication
{
    public record AuthenticationResponse(
        int id,
        string name,
        string email,
        string token
    );
}
