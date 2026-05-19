using MediatR;

namespace HotelBooking.Application.Roles.Commands.DeleteRole;

public sealed record DeleteRoleCommand(int Id) : IRequest;
