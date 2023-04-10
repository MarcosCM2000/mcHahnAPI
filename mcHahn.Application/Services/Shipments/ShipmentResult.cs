using mcHahn.Domain.Entities;

namespace mcHahn.Application.Services.Shipments
{
    public record ShipmentResult(
        //  Shipment Shipment
        int Id,
        DateTime Created_at,
        ShipmentDetail Detail
    );
}
