using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Habitaciones.Common;
using HotelBooking.Domain.Habitaciones;
using HotelBooking.Domain.Hoteles;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Application.Habitaciones.Commands.CreateHabitacion;

public sealed class CreateHabitacionHandler(
    IHabitacionRepository habitacionRepository,
    IHotelRepository hotelRepository,
    ITipoHabitacionRepository tipoRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateHabitacionCommand, HabitacionDto>
{
    public async Task<HabitacionDto> Handle(CreateHabitacionCommand request, CancellationToken cancellationToken)
    {
        _ = await hotelRepository.GetByIdAsync(request.IdHotel, cancellationToken)
            ?? throw new NotFoundException(nameof(Hotel), request.IdHotel);

        _ = await tipoRepository.GetByIdAsync(request.IdTipoHabitacion, cancellationToken)
            ?? throw new NotFoundException(nameof(TipoHabitacion), request.IdTipoHabitacion);

        var habitacion = Habitacion.Create(
            request.IdHotel, request.NumeroHabitacion, request.IdTipoHabitacion,
            request.CostoBase, request.Estado, request.CantidadPersonas);

        await habitacionRepository.AddAsync(habitacion, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<HabitacionDto>(habitacion);
    }
}
