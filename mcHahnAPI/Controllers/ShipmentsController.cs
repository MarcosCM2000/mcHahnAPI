using mcHahn.Contracts.Shipments;
using Microsoft.AspNetCore.Mvc;

namespace mcHahnAPI.Controllers
{
    [ApiController]
    [Route("shipments")]
    public class ShipmentsController : ControllerBase
    {
        public ShipmentsController() { 
            
        }
        [HttpGet("all")] 
        public IActionResult GetAllShipments() {
            Console.WriteLine("GetAllShipments");
            var resp = new ShipmentResponse(
                Id: new Random().Next(1,100),
                Created_at: new DateTime(),
                ShipmentDetail: new ShipmentDetailResponse(Address: "", Weight: 0, Length: 0, Width: 0, Height:0));
            return Ok(resp);
        }
        [HttpPost("add")]
        public IActionResult CreateShipment(CreateRequest request)
        {
            Console.WriteLine("CreateShipment");
            var resp = new ShipmentResponse(
                Id: new Random().Next(1, 100),
                Created_at: new DateTime(),
                ShipmentDetail: new ShipmentDetailResponse(Address: "", Weight: 0, Length: 0, Width: 0, Height: 0));
            return Ok(resp);
        }
        [HttpPatch("edit")]
        public IActionResult EditShipment(EditRequest request)
        {
            Console.WriteLine("EditShipment");
            /*var resp = new ShipmentResponse(
                Id: new Random().Next(1, 100),
                Created_at: new DateTime(),
                ShipmentDetail: new ShipmentDetailResponse(Address: "", Weight: 0, Length: 0, Width: 0, Height: 0));*/
            return Ok();
        }
        [HttpPost("delete")]
        public IActionResult DeleteShipment(DeleteRequest request)
        {
            Console.WriteLine("DeleteShipment");
            /*var resp = new ShipmentResponse(
                Id: new Random().Next(1, 100),
                Created_at: new DateTime(),
                ShipmentDetail: new ShipmentDetailResponse(Address: "", Weight: 0, Length: 0, Width: 0, Height: 0));*/
            return Ok();
        }
        [HttpPost("delete-all")]
        public IActionResult DeleteAllShipments()
        {
            Console.WriteLine("DeleteAllShipments");
            /*var resp = new ShipmentResponse(
                Id: new Random().Next(1, 100),
                Created_at: new DateTime(),
                ShipmentDetail: new ShipmentDetailResponse(Address: "", Weight: 0, Length: 0, Width: 0, Height: 0));*/
            return Ok();
        }
    }
}
