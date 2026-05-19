using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Application.TiposHabitaciones.Commands.UpdateTipoHabitacion;

public sealed class UpdateTipoHabitacionHandler(
    ITipoHabitacionRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateTipoHabitacionCommand>
{
    public async Task Handle(UpdateTipoHabitacionCommand request, CancellationToken cancellationToken)
    {
        var tipo = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(TipoHabitacion), request.Id);

        tipo.Update(request.Nombre, request.Descripcion);
        repository.Update(tipo);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
