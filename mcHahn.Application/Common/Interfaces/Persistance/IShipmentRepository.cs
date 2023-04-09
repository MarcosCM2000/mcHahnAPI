using mcHahn.Domain.Entities;

namespace mcHahn.Application.Common.Interfaces.Persistance
{
    public interface IShipmentRepository
    {
        Shipment? GetShipmentById(int id);
        void Add(Shipment shipment);
        void Delete(int id);
        void DeleteAll();
        void Edit(Shipment shipment);
    }
}
