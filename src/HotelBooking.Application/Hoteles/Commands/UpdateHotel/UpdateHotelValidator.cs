using FluentValidation;

namespace HotelBooking.Application.Hoteles.Commands.UpdateHotel;

public sealed class UpdateHotelValidator : AbstractValidator<UpdateHotelCommand>
{
    public UpdateHotelValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Codigo).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Ubicacion).NotEmpty().MaximumLength(200);
    }
}
