using MediatR;
using HotelBooking.Application.HotelesPreferidos.Common;

namespace HotelBooking.Application.HotelesPreferidos.Queries.GetHotelesPreferidosByUser;

public sealed record GetHotelesPreferidosByUserQuery(int IdUsuario) : IRequest<IReadOnlyList<HotelPreferidoDto>>;
