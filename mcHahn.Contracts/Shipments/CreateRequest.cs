namespace mcHahn.Contracts.Shipments
{
    public record struct CreateRequest { 
        public DetailRequest Detail { get; init; }
        public string CreatedAt { get; init; }
    };
}
