using FluentValidation;

namespace HotelBooking.Application.Reservas.Commands.CreateReserva;

public sealed class CreateReservaValidator : AbstractValidator<CreateReservaCommand>
{
    public CreateReservaValidator()
    {
        RuleFor(x => x.IdUsuario).GreaterThan(0);
        RuleFor(x => x.IdHabitacion).GreaterThan(0);
        RuleFor(x => x.FechaInicio).NotEmpty();
        RuleFor(x => x.FechaFin).NotEmpty().GreaterThan(x => x.FechaInicio);
    }
}
