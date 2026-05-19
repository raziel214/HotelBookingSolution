using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Roles.Common;
using HotelBooking.Domain.Roles;

namespace HotelBooking.Application.Roles.Queries.GetRoleById;

public sealed class GetRoleByIdHandler(
    IRoleRepository roleRepository,
    IMapper mapper) : IRequestHandler<GetRoleByIdQuery, RoleDto>
{
    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Role), request.Id);
        return mapper.Map<RoleDto>(role);
    }
}
