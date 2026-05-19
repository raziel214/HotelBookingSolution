using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.TiposHabitaciones.Common;

namespace HotelBooking.Application.TiposHabitaciones.Queries.GetAllTiposHabitaciones;

public sealed class GetAllTiposHabitacionesHandler(
    ITipoHabitacionRepository repository,
    IMapper mapper) : IRequestHandler<GetAllTiposHabitacionesQuery, IReadOnlyList<TipoHabitacionDto>>
{
    public async Task<IReadOnlyList<TipoHabitacionDto>> Handle(GetAllTiposHabitacionesQuery request, CancellationToken cancellationToken)
    {
        var tipos = await repository.GetAllAsync(cancellationToken);
        return tipos.Select(mapper.Map<TipoHabitacionDto>).ToList();
    }
}
