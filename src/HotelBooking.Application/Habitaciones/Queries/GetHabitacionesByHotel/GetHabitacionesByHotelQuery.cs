using MediatR;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByHotel;

public sealed record GetHabitacionesByHotelQuery(int IdHotel) : IRequest<IReadOnlyList<HabitacionDto>>;
