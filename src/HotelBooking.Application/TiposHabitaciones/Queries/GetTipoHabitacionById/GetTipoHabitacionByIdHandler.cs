using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.TiposHabitaciones.Common;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Application.TiposHabitaciones.Queries.GetTipoHabitacionById;

public sealed class GetTipoHabitacionByIdHandler(
    ITipoHabitacionRepository repository,
    IMapper mapper) : IRequestHandler<GetTipoHabitacionByIdQuery, TipoHabitacionDto>
{
    public async Task<TipoHabitacionDto> Handle(GetTipoHabitacionByIdQuery request, CancellationToken cancellationToken)
    {
        var tipo = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(TipoHabitacion), request.Id);
        return mapper.Map<TipoHabitacionDto>(tipo);
    }
}
