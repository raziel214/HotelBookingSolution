using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Reservas;

namespace HotelBooking.Application.Reservas.Commands.UpdateReserva;

public sealed class UpdateReservaHandler(
    IReservaRepository reservaRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateReservaCommand>
{
    public async Task Handle(UpdateReservaCommand request, CancellationToken cancellationToken)
    {
        var reserva = await reservaRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Reserva), request.Id);

        reserva.Update(request.FechaInicio, request.FechaFin);
        reservaRepository.Update(reserva);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
