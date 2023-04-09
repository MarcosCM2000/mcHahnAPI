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

        public void DeleteAllShipments()
        {
            _shipmentRepository.DeleteAll();
        }

        public bool DeleteShipment(int id)
        {
            //  Check if id exists
            if (_shipmentRepository.GetShipmentById(id) is null)
            {
                throw new Exception("Id does not exists.");                
            }
            _shipmentRepository.Delete(id);
            return true;
        }

        public ShipmentResult EditShipment(int id, DateTime createdAt, string address, int weight, int length, int width, int height)
        {
            //  Check if id exists
            if (_shipmentRepository.GetShipmentById(id) is null)
            {
                throw new Exception("Id does not exists.");
            }
            var editedShipmentDetail = new ShipmentDetail(address, weight, length, width, height);
            var editedShipment = new Shipment(createdAt, editedShipmentDetail);
            editedShipment.Id = id;
            _shipmentRepository.Edit(editedShipment);
            return new ShipmentResult(editedShipment);
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
