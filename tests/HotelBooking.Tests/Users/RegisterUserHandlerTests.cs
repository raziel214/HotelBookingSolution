using FluentAssertions;
using Moq;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Users.Commands.Register;
using HotelBooking.Application.Users.Common;
using HotelBooking.Domain.Common;
using HotelBooking.Domain.Roles;
using HotelBooking.Tests.TestHelpers;

namespace HotelBooking.Tests.Users;

public class RegisterUserHandlerTests
{
    private readonly Mock<IUserRepository> _userRepo = new();
    private readonly Mock<IRoleRepository> _roleRepo = new();
    private readonly Mock<IPasswordHasher> _hasher = new();
    private readonly Mock<IUnitOfWork> _uow = new();
    private readonly AutoMapper.IMapper _mapper = MapperFactory.Create<UserMapping>();

    private RegisterUserHandler CreateSut() => new(_userRepo.Object, _roleRepo.Object, _hasher.Object, _uow.Object, _mapper);

    private static RegisterUserCommand ValidCommand() =>
        new("Ana", "Lopez", 87654321, "CC", "ana@test.com", "secret1", 1, "F", "3001111111");

    [Fact]
    public async Task Handle_Creates_User_When_Valid()
    {
        _roleRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(Role.Create("admin", "ADM"));
        _userRepo.Setup(r => r.ExistsByEmailAsync("ana@test.com", It.IsAny<CancellationToken>())).ReturnsAsync(false);
        _hasher.Setup(h => h.Hash("secret1")).Returns("hashedsecret");

        var result = await CreateSut().Handle(ValidCommand(), CancellationToken.None);

        result.Email.Should().Be("ana@test.com");
        _userRepo.Verify(r => r.AddAsync(It.IsAny<Domain.Users.User>(), It.IsAny<CancellationToken>()), Times.Once);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Throws_NotFound_When_Role_Missing()
    {
        _roleRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((Role?)null);

        var act = () => CreateSut().Handle(ValidCommand(), CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task Handle_Throws_DomainException_When_Email_Already_Exists()
    {
        _roleRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(Role.Create("admin", "ADM"));
        _userRepo.Setup(r => r.ExistsByEmailAsync("ana@test.com", It.IsAny<CancellationToken>())).ReturnsAsync(true);

        var act = () => CreateSut().Handle(ValidCommand(), CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>();
    }
}
