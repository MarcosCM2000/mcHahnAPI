namespace mcHahn.Contracts.Shipments
{
    public record DetailRequest(
        string Address,
        int Weight,
        int Length,
        int Width,
        int Height
    );
}
