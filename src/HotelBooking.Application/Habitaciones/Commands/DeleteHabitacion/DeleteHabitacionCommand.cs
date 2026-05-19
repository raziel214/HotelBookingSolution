using MediatR;

namespace HotelBooking.Application.Habitaciones.Commands.DeleteHabitacion;

public sealed record DeleteHabitacionCommand(int Id) : IRequest;
