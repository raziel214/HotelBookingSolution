using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Users.Common;
using HotelBooking.Domain.Common;
using HotelBooking.Domain.Users;

namespace HotelBooking.Application.Users.Commands.Register;

public sealed class RegisterUserHandler(
    IUserRepository userRepository,
    IRoleRepository roleRepository,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<RegisterUserCommand, UserDto>
{
    public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetByIdAsync(request.IdRol, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Roles.Role), request.IdRol);

        if (await userRepository.ExistsByEmailAsync(request.Email, cancellationToken))
            throw new DomainException("Ya existe un usuario con ese email.");

        var hash = passwordHasher.Hash(request.Password);

        var user = User.Create(
            request.Nombre, request.Apellido, request.Documento, request.TipoDocumento,
            request.Email, hash, role.Id, request.Genero, request.Telefono);

        await userRepository.AddAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}
