using MediatR;

namespace HotelBooking.Application.Reservas.Commands.CancelarReserva;

public sealed record CancelarReservaCommand(int Id) : IRequest;
