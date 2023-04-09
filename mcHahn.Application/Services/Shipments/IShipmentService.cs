namespace mcHahn.Application.Services.Shipments
{
    public interface IShipmentService
    {
        List<ShipmentResult> GetAllShipments();
        ShipmentResult CreateShipment(DateTime createdAt, object detail);
        ShipmentResult EditShipment(int id, DateTime createdAt, object detail);
        bool DeleteShipment(int id);
        bool DeleteAllShipments();
    }
}
