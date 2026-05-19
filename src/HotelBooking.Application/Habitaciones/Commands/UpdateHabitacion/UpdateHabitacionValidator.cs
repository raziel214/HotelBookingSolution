using FluentValidation;

namespace HotelBooking.Application.Habitaciones.Commands.UpdateHabitacion;

public sealed class UpdateHabitacionValidator : AbstractValidator<UpdateHabitacionCommand>
{
    public UpdateHabitacionValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.IdHotel).GreaterThan(0);
        RuleFor(x => x.NumeroHabitacion).GreaterThan(0);
        RuleFor(x => x.IdTipoHabitacion).GreaterThan(0);
        RuleFor(x => x.CostoBase).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CantidadPersonas).GreaterThan(0);
    }
}
