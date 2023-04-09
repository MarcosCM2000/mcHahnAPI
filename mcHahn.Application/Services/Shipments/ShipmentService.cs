using mcHahn.Application.Common.Interfaces.Persistance;

namespace mcHahn.Application.Services.Shipments
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }
        public ShipmentResult CreateShipment(DateTime createdAt, object detail)
        {
            throw new NotImplementedException();
        }

        public ShipmentResult DeleteAllShipments()
        {
            throw new NotImplementedException();
        }

        public ShipmentResult DeleteShipment(int id)
        {
            throw new NotImplementedException();
        }

        public ShipmentResult EditShipment(int id, DateTime createdAt, object detail)
        {
            throw new NotImplementedException();
        }

        public ShipmentResult GetAllShipments()
        {
            throw new NotImplementedException();
        }
    }
}
