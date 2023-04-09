namespace mcHahn.Contracts.Shipments
{
    public record EditRequest(
        int Id,
        DateTime CreatedAt,
        DetailRequest Detail
    );
}
