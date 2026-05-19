using FluentValidation;

namespace HotelBooking.Application.Habitaciones.Commands.CreateHabitacion;

public sealed class CreateHabitacionValidator : AbstractValidator<CreateHabitacionCommand>
{
    public CreateHabitacionValidator()
    {
        RuleFor(x => x.IdHotel).GreaterThan(0);
        RuleFor(x => x.NumeroHabitacion).GreaterThan(0);
        RuleFor(x => x.IdTipoHabitacion).GreaterThan(0);
        RuleFor(x => x.CostoBase).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CantidadPersonas).GreaterThan(0);
    }
}
