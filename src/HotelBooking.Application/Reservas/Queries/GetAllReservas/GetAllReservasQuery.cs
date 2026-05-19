using MediatR;
using HotelBooking.Application.Reservas.Common;

namespace HotelBooking.Application.Reservas.Queries.GetAllReservas;

public sealed record GetAllReservasQuery : IRequest<IReadOnlyList<ReservaDto>>;
