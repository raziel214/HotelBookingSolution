using MediatR;
using HotelBooking.Application.Reservas.Common;

namespace HotelBooking.Application.Reservas.Commands.CreateReserva;

public sealed record CreateReservaCommand(
    int IdUsuario,
    int IdHabitacion,
    DateTime FechaInicio,
    DateTime FechaFin) : IRequest<ReservaDto>;
