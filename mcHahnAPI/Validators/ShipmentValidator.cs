using FluentValidation;
using mcHahn.Domain.Entities;

namespace mcHahnAPI.Validators
{
    public class ShipmentValidator: AbstractValidator<Shipment>
    {
        public ShipmentValidator()
        {
            RuleFor(shipment => shipment.Id).NotNull().NotEmpty();
            RuleFor(shipment => shipment.Created_at).NotNull();
            RuleFor(shipment => shipment.Detail.Address).NotEmpty();
            RuleFor(shipment => shipment.Detail.Weight).GreaterThan(0);
            RuleFor(shipment => shipment.Detail.Length).GreaterThan(0);
            RuleFor(shipment => shipment.Detail.Width).GreaterThan(0);
            RuleFor(shipment => shipment.Detail.Height).GreaterThan(0);
        }
    }
}
