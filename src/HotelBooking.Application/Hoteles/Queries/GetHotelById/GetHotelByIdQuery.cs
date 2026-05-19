using MediatR;
using HotelBooking.Application.Hoteles.Common;

namespace HotelBooking.Application.Hoteles.Queries.GetHotelById;

public sealed record GetHotelByIdQuery(int Id) : IRequest<HotelDto>;
