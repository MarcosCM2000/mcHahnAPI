namespace mcHahn.Contracts.Shipments
{
    public record CreateRequest(
        DateTime CreatedAt,
        DetailRequest Detail
    );
}
