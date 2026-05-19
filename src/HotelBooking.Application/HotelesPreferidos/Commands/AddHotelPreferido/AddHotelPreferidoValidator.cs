using FluentValidation;

namespace HotelBooking.Application.HotelesPreferidos.Commands.AddHotelPreferido;

public sealed class AddHotelPreferidoValidator : AbstractValidator<AddHotelPreferidoCommand>
{
    public AddHotelPreferidoValidator()
    {
        RuleFor(x => x.IdUsuario).GreaterThan(0);
        RuleFor(x => x.IdHotel).GreaterThan(0);
    }
}
