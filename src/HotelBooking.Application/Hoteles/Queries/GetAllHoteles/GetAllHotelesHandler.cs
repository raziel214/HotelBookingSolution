using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Hoteles.Common;

namespace HotelBooking.Application.Hoteles.Queries.GetAllHoteles;

public sealed class GetAllHotelesHandler(
    IHotelRepository hotelRepository,
    IMapper mapper) : IRequestHandler<GetAllHotelesQuery, IReadOnlyList<HotelDto>>
{
    public async Task<IReadOnlyList<HotelDto>> Handle(GetAllHotelesQuery request, CancellationToken cancellationToken)
    {
        var hoteles = await hotelRepository.GetAllAsync(cancellationToken);
        return hoteles.Select(mapper.Map<HotelDto>).ToList();
    }
}
