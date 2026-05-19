using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Hoteles.Common;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Application.Hoteles.Queries.GetHotelById;

public sealed class GetHotelByIdHandler(
    IHotelRepository hotelRepository,
    IMapper mapper) : IRequestHandler<GetHotelByIdQuery, HotelDto>
{
    public async Task<HotelDto> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Hotel), request.Id);
        return mapper.Map<HotelDto>(hotel);
    }
}
