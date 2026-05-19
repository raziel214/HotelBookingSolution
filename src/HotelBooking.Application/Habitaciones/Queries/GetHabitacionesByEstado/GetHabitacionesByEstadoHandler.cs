using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByEstado;

public sealed class GetHabitacionesByEstadoHandler(
    IHabitacionRepository habitacionRepository,
    IMapper mapper) : IRequestHandler<GetHabitacionesByEstadoQuery, IReadOnlyList<HabitacionDto>>
{
    public async Task<IReadOnlyList<HabitacionDto>> Handle(GetHabitacionesByEstadoQuery request, CancellationToken cancellationToken)
    {
        var items = await habitacionRepository.GetByEstadoAsync(request.Estado, cancellationToken);
        return items.Select(mapper.Map<HabitacionDto>).ToList();
    }
}
