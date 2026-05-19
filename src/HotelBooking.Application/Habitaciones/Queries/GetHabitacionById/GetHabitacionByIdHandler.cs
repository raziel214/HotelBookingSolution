using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Habitaciones.Common;
using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionById;

public sealed class GetHabitacionByIdHandler(
    IHabitacionRepository habitacionRepository,
    IMapper mapper) : IRequestHandler<GetHabitacionByIdQuery, HabitacionDto>
{
    public async Task<HabitacionDto> Handle(GetHabitacionByIdQuery request, CancellationToken cancellationToken)
    {
        var habitacion = await habitacionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Habitacion), request.Id);
        return mapper.Map<HabitacionDto>(habitacion);
    }
}
