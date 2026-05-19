using MediatR;
using HotelBooking.Application.Roles.Common;

namespace HotelBooking.Application.Roles.Queries.GetRoleById;

public sealed record GetRoleByIdQuery(int Id) : IRequest<RoleDto>;
