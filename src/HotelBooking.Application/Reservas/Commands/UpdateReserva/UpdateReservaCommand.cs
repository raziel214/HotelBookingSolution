using MediatR;

namespace HotelBooking.Application.Reservas.Commands.UpdateReserva;

public sealed record UpdateReservaCommand(int Id, DateTime FechaInicio, DateTime FechaFin) : IRequest;
