using mcHahn.Application.Common.Interfaces.Persistance;
using mcHahn.Domain.Entities;

namespace mcHahn.Infrastructure.Persistance
{
    public class ShipmentRepository : IShipmentRepository
    {
        private static List<Shipment> _shipments = new();

        public void Add(Shipment shipment)
        {
            _shipments.Add(shipment);
        }

        public void Delete(int id)
        {
            _shipments  =  _shipments.FindAll(s=> s.Id != id);
        }

        public void DeleteAll()
        {
            _shipments.Clear();
        }

        public void Edit(Shipment shipment)
        {
            var index = _shipments.FindIndex(s => s.Id == shipment.Id);
            _shipments[index] = shipment;
        }

        public List<Shipment> GetAll()
        {
            return _shipments;
        }

        public Shipment? GetShipmentById(int id)
        {
            return _shipments.SingleOrDefault(s => s.Id == id);
        }
    }
}
