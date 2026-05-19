using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByHotel;

public sealed class GetHabitacionesByHotelHandler(
    IHabitacionRepository habitacionRepository,
    IMapper mapper) : IRequestHandler<GetHabitacionesByHotelQuery, IReadOnlyList<HabitacionDto>>
{
    public async Task<IReadOnlyList<HabitacionDto>> Handle(GetHabitacionesByHotelQuery request, CancellationToken cancellationToken)
    {
        var items = await habitacionRepository.GetByHotelAsync(request.IdHotel, cancellationToken);
        return items.Select(mapper.Map<HabitacionDto>).ToList();
    }
}
