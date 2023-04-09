using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcHahn.Contracts.Shipments
{
    public record ShipmentResponse(
        int Id,
        DateTime Created_at,
        ShipmentDetailResponse ShipmentDetail
    );
}
