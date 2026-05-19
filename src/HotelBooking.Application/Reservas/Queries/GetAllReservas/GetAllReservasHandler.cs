using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Reservas.Common;

namespace HotelBooking.Application.Reservas.Queries.GetAllReservas;

public sealed class GetAllReservasHandler(
    IReservaRepository reservaRepository,
    IMapper mapper) : IRequestHandler<GetAllReservasQuery, IReadOnlyList<ReservaDto>>
{
    public async Task<IReadOnlyList<ReservaDto>> Handle(GetAllReservasQuery request, CancellationToken cancellationToken)
    {
        var items = await reservaRepository.GetAllAsync(cancellationToken);
        return items.Select(mapper.Map<ReservaDto>).ToList();
    }
}
