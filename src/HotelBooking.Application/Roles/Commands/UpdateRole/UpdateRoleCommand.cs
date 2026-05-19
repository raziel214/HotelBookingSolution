using MediatR;

namespace HotelBooking.Application.Roles.Commands.UpdateRole;

public sealed record UpdateRoleCommand(int Id, string Nombre, string Codigo) : IRequest;
