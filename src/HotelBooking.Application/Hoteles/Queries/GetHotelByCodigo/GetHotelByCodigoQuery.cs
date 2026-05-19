using MediatR;
using HotelBooking.Application.Hoteles.Common;

namespace HotelBooking.Application.Hoteles.Queries.GetHotelByCodigo;

public sealed record GetHotelByCodigoQuery(string Codigo) : IRequest<HotelDto>;
