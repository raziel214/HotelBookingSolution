using MediatR;

namespace HotelBooking.Application.HotelesPreferidos.Commands.RemoveHotelPreferido;

public sealed record RemoveHotelPreferidoCommand(int Id) : IRequest;
