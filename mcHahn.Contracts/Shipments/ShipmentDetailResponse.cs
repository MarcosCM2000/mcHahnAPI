using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mcHahn.Contracts.Shipments
{
    public record ShipmentDetailResponse(
        string Address,
        int Weight,
        int Length,
        int Width,
        int Height
    );
}
