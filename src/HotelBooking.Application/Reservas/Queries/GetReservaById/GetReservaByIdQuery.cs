using MediatR;
using HotelBooking.Application.Reservas.Common;

namespace HotelBooking.Application.Reservas.Queries.GetReservaById;

public sealed record GetReservaByIdQuery(int Id) : IRequest<ReservaDto>;
