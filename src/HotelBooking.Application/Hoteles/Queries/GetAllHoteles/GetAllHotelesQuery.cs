using MediatR;
using HotelBooking.Application.Hoteles.Common;

namespace HotelBooking.Application.Hoteles.Queries.GetAllHoteles;

public sealed record GetAllHotelesQuery : IRequest<IReadOnlyList<HotelDto>>;
