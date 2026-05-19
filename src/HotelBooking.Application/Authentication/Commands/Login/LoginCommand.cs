using MediatR;

namespace HotelBooking.Application.Authentication.Commands.Login;

public sealed record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

public sealed record LoginResponse(string Token, int UserId, string Email, string Nombre);
