using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Roles.Common;
using HotelBooking.Domain.Roles;

namespace HotelBooking.Application.Roles.Commands.CreateRole;

public sealed class CreateRoleHandler(
    IRoleRepository roleRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateRoleCommand, RoleDto>
{
    public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = Role.Create(request.Nombre, request.Codigo);
        await roleRepository.AddAsync(role, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<RoleDto>(role);
    }
}
