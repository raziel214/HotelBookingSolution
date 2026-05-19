using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Hoteles.Common;

namespace HotelBooking.Application.Hoteles.Queries.GetHotelesByEstado;

public sealed class GetHotelesByEstadoHandler(
    IHotelRepository hotelRepository,
    IMapper mapper) : IRequestHandler<GetHotelesByEstadoQuery, IReadOnlyList<HotelDto>>
{
    public async Task<IReadOnlyList<HotelDto>> Handle(GetHotelesByEstadoQuery request, CancellationToken cancellationToken)
    {
        var hoteles = await hotelRepository.GetByEstadoAsync(request.Estado, cancellationToken);
        return hoteles.Select(mapper.Map<HotelDto>).ToList();
    }
}
