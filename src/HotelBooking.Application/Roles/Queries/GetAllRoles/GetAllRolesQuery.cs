using MediatR;
using HotelBooking.Application.Roles.Common;

namespace HotelBooking.Application.Roles.Queries.GetAllRoles;

public sealed record GetAllRolesQuery : IRequest<IReadOnlyList<RoleDto>>;
