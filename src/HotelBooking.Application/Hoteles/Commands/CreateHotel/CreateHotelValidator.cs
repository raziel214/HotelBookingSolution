using FluentValidation;

namespace HotelBooking.Application.Hoteles.Commands.CreateHotel;

public sealed class CreateHotelValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Codigo).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Ubicacion).NotEmpty().MaximumLength(200);
    }
}
