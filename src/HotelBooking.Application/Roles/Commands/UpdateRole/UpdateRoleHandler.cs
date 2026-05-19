using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Roles;

namespace HotelBooking.Application.Roles.Commands.UpdateRole;

public sealed class UpdateRoleHandler(
    IRoleRepository roleRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateRoleCommand>
{
    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Role), request.Id);

        role.Update(request.Nombre, request.Codigo);
        roleRepository.Update(role);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
