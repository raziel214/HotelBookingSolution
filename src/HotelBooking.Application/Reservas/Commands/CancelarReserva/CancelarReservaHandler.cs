using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Reservas;

namespace HotelBooking.Application.Reservas.Commands.CancelarReserva;

public sealed class CancelarReservaHandler(
    IReservaRepository reservaRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CancelarReservaCommand>
{
    public async Task Handle(CancelarReservaCommand request, CancellationToken cancellationToken)
    {
        var reserva = await reservaRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Reserva), request.Id);

        reserva.Cancelar();
        reservaRepository.Update(reserva);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
