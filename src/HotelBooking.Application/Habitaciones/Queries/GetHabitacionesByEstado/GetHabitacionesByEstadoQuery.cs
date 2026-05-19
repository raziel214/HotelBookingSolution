using MediatR;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByEstado;

public sealed record GetHabitacionesByEstadoQuery(int Estado) : IRequest<IReadOnlyList<HabitacionDto>>;
