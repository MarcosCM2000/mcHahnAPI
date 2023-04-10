using mcHahn.Application.Services.Shipments;
using mcHahn.Contracts.Shipments;
using mcHahn.Domain.Entities;
using mcHahnAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace mcHahnAPI.Controllers
{
    [ApiController]
    [Route("shipments")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        public ShipmentsController(IShipmentService shipmentService) { 
            _shipmentService = shipmentService;
        }
        [HttpGet("all")] 
        public IActionResult GetAllShipments() {
            Console.WriteLine("GetAllShipments");
            var resp = _shipmentService.GetAllShipments();
            return Ok(resp);
        }
        [HttpPost("add")]
        public IActionResult CreateShipment(CreateRequest request)
        {
            Console.WriteLine("CreateShipment");
            Console.WriteLine(request.CreatedAt);
            //  Fluent Validation
            var validatedShipmentDetail = new ShipmentDetail(
                address: request.Detail.Address,
                weight: request.Detail.Weight,
                length: request.Detail.Length,
                width: request.Detail.Width,
                height: request.Detail.Height);
            var validatedShipment = new Shipment(createdAt: request.CreatedAt, detail: validatedShipmentDetail);
            var validator = new ShipmentValidator();
            var results = validator.Validate(validatedShipment);
            if (!results.IsValid)
            {
                return BadRequest("Error on entered inputs. Please validate.");
            }
            var resp = _shipmentService.CreateShipment(
                request.CreatedAt, request.Detail.Address, request.Detail.Weight,
                request.Detail.Length, request.Detail.Width, request.Detail.Height);
            return Ok(resp);
        }
        [HttpPatch("edit")]
        public IActionResult EditShipment(EditRequest request)
        {
            Console.WriteLine("EditShipment");
            //  Fluent Validation
            var validatedShipmentDetail = new ShipmentDetail(
                address: request.Detail.Address,
                weight: request.Detail.Weight,
                length: request.Detail.Length,
                width: request.Detail.Width,
                height: request.Detail.Height);
            var validatedShipment = new Shipment(createdAt: request.CreatedAt, detail: validatedShipmentDetail);
            validatedShipment.Id = request.Id;

            var validator = new ShipmentValidator();
            var results = validator.Validate(validatedShipment);
            if (!results.IsValid)
            {
                return BadRequest("Error on entered inputs. Please validate.");
            }
            var resp = _shipmentService.EditShipment(
                request.Id, request.CreatedAt, request.Detail.Address, request.Detail.Weight,
                request.Detail.Length, request.Detail.Width, request.Detail.Height);
            return Ok(resp);
        }
        [HttpPost("delete")]
        public IActionResult DeleteShipment(DeleteRequest request)
        {
            Console.WriteLine("DeleteShipment");
            if (!_shipmentService.DeleteShipment(request.Id))
            {
                return NoContent();
            }
            return Ok();
        }
        [HttpPost("delete-all")]
        public IActionResult DeleteAllShipments()
        {
            Console.WriteLine("DeleteAllShipments");
            _shipmentService.DeleteAllShipments();
            return Ok();
        }
    }
}
