using FluentValidation;

namespace HotelBooking.Application.Roles.Commands.CreateRole;

public sealed class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Codigo).NotEmpty().MaximumLength(50);
    }
}
