namespace HotelBooking.Application.Users.Common;

public sealed record UserDto(
    int Id,
    string Nombre,
    string Apellido,
    int Documento,
    string TipoDocumento,
    string Email,
    int IdRol,
    string Genero,
    string Telefono);
