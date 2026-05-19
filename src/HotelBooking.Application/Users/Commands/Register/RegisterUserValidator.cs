using FluentValidation;

namespace HotelBooking.Application.Users.Commands.Register;

public sealed class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Apellido).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Documento).GreaterThan(0);
        RuleFor(x => x.TipoDocumento).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(200);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(100);
        RuleFor(x => x.IdRol).GreaterThan(0);
        RuleFor(x => x.Genero).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Telefono).NotEmpty().MaximumLength(30);
    }
}
