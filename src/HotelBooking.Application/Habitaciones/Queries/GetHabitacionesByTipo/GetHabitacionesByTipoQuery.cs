using MediatR;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByTipo;

public sealed record GetHabitacionesByTipoQuery(int IdTipoHabitacion) : IRequest<IReadOnlyList<HabitacionDto>>;
