using mcHahn.Application.Common.Interfaces.Persistance;
using mcHahn.Domain.Entities;

namespace mcHahn.Application.Services.Shipments
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }
        public ShipmentResult CreateShipment(DateTime createdAt, string address, int weight, int length, int width, int height)
        {
            var newShipmentDetail = new ShipmentDetail(address, weight, length, width, height);
            var newShipment = new Shipment(createdAt, newShipmentDetail);
            _shipmentRepository.Add(newShipment);
            return new ShipmentResult(newShipment);
        }

        public bool DeleteAllShipments()
        {
            throw new NotImplementedException();
        }

        public bool DeleteShipment(int id)
        {
            throw new NotImplementedException();
        }

        public ShipmentResult EditShipment(int id, DateTime createdAt, object detail)
        {
            throw new NotImplementedException();
        }

        public List<ShipmentResult> GetAllShipments()
        {
            var shipments = _shipmentRepository.GetAll();
            var result = new List<ShipmentResult>();
            shipments.ForEach((shipment) => result.Add(new ShipmentResult(shipment)));
            
            return result;
        }
    }
}
