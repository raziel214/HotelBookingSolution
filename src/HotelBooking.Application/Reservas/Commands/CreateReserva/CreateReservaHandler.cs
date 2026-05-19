using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Reservas.Common;
using HotelBooking.Domain.Habitaciones;
using HotelBooking.Domain.Reservas;
using HotelBooking.Domain.Users;

namespace HotelBooking.Application.Reservas.Commands.CreateReserva;

public sealed class CreateReservaHandler(
    IReservaRepository reservaRepository,
    IUserRepository userRepository,
    IHabitacionRepository habitacionRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateReservaCommand, ReservaDto>
{
    public async Task<ReservaDto> Handle(CreateReservaCommand request, CancellationToken cancellationToken)
    {
        _ = await userRepository.GetByIdAsync(request.IdUsuario, cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.IdUsuario);

        _ = await habitacionRepository.GetByIdAsync(request.IdHabitacion, cancellationToken)
            ?? throw new NotFoundException(nameof(Habitacion), request.IdHabitacion);

        var reserva = Reserva.Create(request.IdUsuario, request.IdHabitacion, request.FechaInicio, request.FechaFin);
        await reservaRepository.AddAsync(reserva, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<ReservaDto>(reserva);
    }
}
