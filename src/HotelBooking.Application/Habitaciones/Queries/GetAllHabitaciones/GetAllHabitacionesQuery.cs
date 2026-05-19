using MediatR;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetAllHabitaciones;

public sealed record GetAllHabitacionesQuery : IRequest<IReadOnlyList<HabitacionDto>>;
