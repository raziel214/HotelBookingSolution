using MediatR;
using HotelBooking.Application.HotelesPreferidos.Common;

namespace HotelBooking.Application.HotelesPreferidos.Queries.GetAllHotelesPreferidos;

public sealed record GetAllHotelesPreferidosQuery : IRequest<IReadOnlyList<HotelPreferidoDto>>;
