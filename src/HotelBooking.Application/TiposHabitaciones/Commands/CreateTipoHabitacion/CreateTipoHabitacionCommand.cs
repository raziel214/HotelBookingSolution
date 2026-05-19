using MediatR;
using HotelBooking.Application.TiposHabitaciones.Common;

namespace HotelBooking.Application.TiposHabitaciones.Commands.CreateTipoHabitacion;

public sealed record CreateTipoHabitacionCommand(string Nombre, string Descripcion) : IRequest<TipoHabitacionDto>;
