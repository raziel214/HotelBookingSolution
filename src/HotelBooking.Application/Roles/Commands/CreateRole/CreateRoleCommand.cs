using MediatR;
using HotelBooking.Application.Roles.Common;

namespace HotelBooking.Application.Roles.Commands.CreateRole;

public sealed record CreateRoleCommand(string Nombre, string Codigo) : IRequest<RoleDto>;
