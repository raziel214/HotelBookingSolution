using FluentValidation;

namespace HotelBooking.Application.TiposHabitaciones.Commands.UpdateTipoHabitacion;

public sealed class UpdateTipoHabitacionValidator : AbstractValidator<UpdateTipoHabitacionCommand>
{
    public UpdateTipoHabitacionValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(500);
    }
}
