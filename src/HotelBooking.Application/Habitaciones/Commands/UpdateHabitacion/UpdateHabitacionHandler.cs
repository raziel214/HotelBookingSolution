using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Application.Habitaciones.Commands.UpdateHabitacion;

public sealed class UpdateHabitacionHandler(
    IHabitacionRepository habitacionRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateHabitacionCommand>
{
    public async Task Handle(UpdateHabitacionCommand request, CancellationToken cancellationToken)
    {
        var habitacion = await habitacionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Habitacion), request.Id);

        habitacion.Update(
            request.IdHotel, request.NumeroHabitacion, request.IdTipoHabitacion,
            request.CostoBase, request.Estado, request.CantidadPersonas);

        habitacionRepository.Update(habitacion);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
