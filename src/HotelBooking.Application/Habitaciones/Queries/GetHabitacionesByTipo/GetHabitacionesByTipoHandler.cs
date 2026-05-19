using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByTipo;

public sealed class GetHabitacionesByTipoHandler(
    IHabitacionRepository habitacionRepository,
    IMapper mapper) : IRequestHandler<GetHabitacionesByTipoQuery, IReadOnlyList<HabitacionDto>>
{
    public async Task<IReadOnlyList<HabitacionDto>> Handle(GetHabitacionesByTipoQuery request, CancellationToken cancellationToken)
    {
        var items = await habitacionRepository.GetByTipoAsync(request.IdTipoHabitacion, cancellationToken);
        return items.Select(mapper.Map<HabitacionDto>).ToList();
    }
}
