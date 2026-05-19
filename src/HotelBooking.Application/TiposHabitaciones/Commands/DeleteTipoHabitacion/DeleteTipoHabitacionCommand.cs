using MediatR;

namespace HotelBooking.Application.TiposHabitaciones.Commands.DeleteTipoHabitacion;

public sealed record DeleteTipoHabitacionCommand(int Id) : IRequest;
