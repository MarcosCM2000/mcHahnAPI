namespace mcHahn.Contracts.Authentication
{
    public record RegisterRequest(
        string name,
        string email,
        string password
    );
}
