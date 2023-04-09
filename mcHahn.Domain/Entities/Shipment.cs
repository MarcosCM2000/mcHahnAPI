using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcHahn.Domain.Entities
{
    public class Shipment
    {
        public int Id { get; set; } = new Random().Next(1, 100);
        public DateTime Created_at { get; set; }
        public ShipmentDetail Detail { get; set; }

        public Shipment(DateTime createdAt, ShipmentDetail detail)
        {
            Created_at = createdAt;
            Detail = detail;
        }
    }
}
