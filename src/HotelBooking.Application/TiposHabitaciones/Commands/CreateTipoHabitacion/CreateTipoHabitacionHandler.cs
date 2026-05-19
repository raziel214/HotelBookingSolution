using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.TiposHabitaciones.Common;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Application.TiposHabitaciones.Commands.CreateTipoHabitacion;

public sealed class CreateTipoHabitacionHandler(
    ITipoHabitacionRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateTipoHabitacionCommand, TipoHabitacionDto>
{
    public async Task<TipoHabitacionDto> Handle(CreateTipoHabitacionCommand request, CancellationToken cancellationToken)
    {
        var tipo = TipoHabitacion.Create(request.Nombre, request.Descripcion);
        await repository.AddAsync(tipo, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<TipoHabitacionDto>(tipo);
    }
}
