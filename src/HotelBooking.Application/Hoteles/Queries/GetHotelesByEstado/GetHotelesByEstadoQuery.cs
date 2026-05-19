using MediatR;
using HotelBooking.Application.Hoteles.Common;

namespace HotelBooking.Application.Hoteles.Queries.GetHotelesByEstado;

public sealed record GetHotelesByEstadoQuery(short Estado) : IRequest<IReadOnlyList<HotelDto>>;
