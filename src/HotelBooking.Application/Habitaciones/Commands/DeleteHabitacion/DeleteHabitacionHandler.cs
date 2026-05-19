using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Application.Habitaciones.Commands.DeleteHabitacion;

public sealed class DeleteHabitacionHandler(
    IHabitacionRepository habitacionRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteHabitacionCommand>
{
    public async Task Handle(DeleteHabitacionCommand request, CancellationToken cancellationToken)
    {
        var habitacion = await habitacionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Habitacion), request.Id);

        habitacionRepository.Remove(habitacion);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
