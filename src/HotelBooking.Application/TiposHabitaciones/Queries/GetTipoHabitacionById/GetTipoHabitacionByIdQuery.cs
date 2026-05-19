using MediatR;
using HotelBooking.Application.TiposHabitaciones.Common;

namespace HotelBooking.Application.TiposHabitaciones.Queries.GetTipoHabitacionById;

public sealed record GetTipoHabitacionByIdQuery(int Id) : IRequest<TipoHabitacionDto>;
