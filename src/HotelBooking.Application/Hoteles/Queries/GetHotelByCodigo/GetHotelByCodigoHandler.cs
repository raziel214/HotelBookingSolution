using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Hoteles.Common;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Application.Hoteles.Queries.GetHotelByCodigo;

public sealed class GetHotelByCodigoHandler(
    IHotelRepository hotelRepository,
    IMapper mapper) : IRequestHandler<GetHotelByCodigoQuery, HotelDto>
{
    public async Task<HotelDto> Handle(GetHotelByCodigoQuery request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByCodigoAsync(request.Codigo, cancellationToken)
            ?? throw new NotFoundException(nameof(Hotel), request.Codigo);
        return mapper.Map<HotelDto>(hotel);
    }
}
