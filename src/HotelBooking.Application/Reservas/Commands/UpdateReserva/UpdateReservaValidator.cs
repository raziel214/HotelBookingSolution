using FluentValidation;

namespace HotelBooking.Application.Reservas.Commands.UpdateReserva;

public sealed class UpdateReservaValidator : AbstractValidator<UpdateReservaCommand>
{
    public UpdateReservaValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.FechaFin).GreaterThan(x => x.FechaInicio);
    }
}
