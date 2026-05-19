using MediatR;

namespace HotelBooking.Application.TiposHabitaciones.Commands.UpdateTipoHabitacion;

public sealed record UpdateTipoHabitacionCommand(int Id, string Nombre, string Descripcion) : IRequest;
