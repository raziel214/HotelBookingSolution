using MediatR;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Queries.GetHabitacionById;

public sealed record GetHabitacionByIdQuery(int Id) : IRequest<HabitacionDto>;
