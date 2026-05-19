using MediatR;
using HotelBooking.Application.Users.Common;

namespace HotelBooking.Application.Users.Commands.Register;

public sealed record RegisterUserCommand(
    string Nombre,
    string Apellido,
    int Documento,
    string TipoDocumento,
    string Email,
    string Password,
    int IdRol,
    string Genero,
    string Telefono) : IRequest<UserDto>;
