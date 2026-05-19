using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetAllHabitaciones;

public sealed class GetAllHabitacionesHandler(
    IHabitacionRepository habitacionRepository,
    IMapper mapper) : IRequestHandler<GetAllHabitacionesQuery, IReadOnlyList<HabitacionDto>>
{
    public async Task<IReadOnlyList<HabitacionDto>> Handle(GetAllHabitacionesQuery request, CancellationToken cancellationToken)
    {
        var items = await habitacionRepository.GetAllAsync(cancellationToken);
        return items.Select(mapper.Map<HabitacionDto>).ToList();
    }
}
