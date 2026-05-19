using MediatR;
using HotelBooking.Application.Common.Ports;

namespace HotelBooking.Application.Authentication.Commands.Login;

public sealed class LoginHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken)
            ?? throw new UnauthorizedAccessException("Credenciales inválidas.");

        if (!passwordHasher.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Credenciales inválidas.");

        var token = tokenService.GenerateToken(user);
        return new LoginResponse(token, user.Id, user.Email, user.Nombre);
    }
}
