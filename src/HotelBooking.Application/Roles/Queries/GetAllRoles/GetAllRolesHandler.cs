using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Roles.Common;

namespace HotelBooking.Application.Roles.Queries.GetAllRoles;

public sealed class GetAllRolesHandler(
    IRoleRepository roleRepository,
    IMapper mapper) : IRequestHandler<GetAllRolesQuery, IReadOnlyList<RoleDto>>
{
    public async Task<IReadOnlyList<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await roleRepository.GetAllAsync(cancellationToken);
        return roles.Select(mapper.Map<RoleDto>).ToList();
    }
}
