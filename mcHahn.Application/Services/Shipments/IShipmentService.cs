namespace mcHahn.Application.Services.Shipments
{
    public interface IShipmentService
    {
        ShipmentResult GetAllShipments();
        ShipmentResult CreateShipment(DateTime createdAt, object detail);
        ShipmentResult EditShipment(int id, DateTime createdAt, object detail);
        ShipmentResult DeleteShipment(int id);
        ShipmentResult DeleteAllShipments();
    }
}
