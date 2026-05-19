using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Application.TiposHabitaciones.Commands.DeleteTipoHabitacion;

public sealed class DeleteTipoHabitacionHandler(
    ITipoHabitacionRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteTipoHabitacionCommand>
{
    public async Task Handle(DeleteTipoHabitacionCommand request, CancellationToken cancellationToken)
    {
        var tipo = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(TipoHabitacion), request.Id);

        repository.Remove(tipo);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
