using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Reservas.Common;
using HotelBooking.Domain.Reservas;

namespace HotelBooking.Application.Reservas.Queries.GetReservaById;

public sealed class GetReservaByIdHandler(
    IReservaRepository reservaRepository,
    IMapper mapper) : IRequestHandler<GetReservaByIdQuery, ReservaDto>
{
    public async Task<ReservaDto> Handle(GetReservaByIdQuery request, CancellationToken cancellationToken)
    {
        var reserva = await reservaRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Reserva), request.Id);
        return mapper.Map<ReservaDto>(reserva);
    }
}
