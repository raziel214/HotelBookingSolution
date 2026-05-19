using MediatR;
using HotelBooking.Application.HotelesPreferidos.Common;

namespace HotelBooking.Application.HotelesPreferidos.Commands.AddHotelPreferido;

public sealed record AddHotelPreferidoCommand(int IdUsuario, int IdHotel) : IRequest<HotelPreferidoDto>;
