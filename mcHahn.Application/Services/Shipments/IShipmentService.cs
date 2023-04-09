using mcHahn.Domain.Entities;

namespace mcHahn.Application.Services.Shipments
{
    public interface IShipmentService
    {
        List<ShipmentResult> GetAllShipments();
        ShipmentResult CreateShipment(DateTime createdAt, string address, int weight, int length, int width, int height);
        ShipmentResult EditShipment(int id, DateTime createdAt, object detail);
        bool DeleteShipment(int id);
        bool DeleteAllShipments();
    }
}
