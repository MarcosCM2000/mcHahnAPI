using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcHahn.Domain.Entities
{
    public class ShipmentDetail
    {
        public string Address { get; set; } = null!;
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ShipmentDetail(string address, int weight, int length, int width, int height)
        {
            Address = address;
            Weight = weight;
            Length = length;
            Width = width;
            Height = height;
        }
    }
}
