using FluentValidation;

namespace HotelBooking.Application.TiposHabitaciones.Commands.CreateTipoHabitacion;

public sealed class CreateTipoHabitacionValidator : AbstractValidator<CreateTipoHabitacionCommand>
{
    public CreateTipoHabitacionValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(500);
    }
}
