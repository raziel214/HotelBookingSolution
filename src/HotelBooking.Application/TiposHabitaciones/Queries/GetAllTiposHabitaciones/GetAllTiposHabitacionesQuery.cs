using MediatR;
using HotelBooking.Application.TiposHabitaciones.Common;

namespace HotelBooking.Application.TiposHabitaciones.Queries.GetAllTiposHabitaciones;

public sealed record GetAllTiposHabitacionesQuery : IRequest<IReadOnlyList<TipoHabitacionDto>>;
