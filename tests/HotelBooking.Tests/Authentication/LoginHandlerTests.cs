using FluentAssertions;
using Moq;
using HotelBooking.Application.Authentication.Commands.Login;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Users;

namespace HotelBooking.Tests.Authentication;

public class LoginHandlerTests
{
    private readonly Mock<IUserRepository> _userRepo = new();
    private readonly Mock<IPasswordHasher> _hasher = new();
    private readonly Mock<ITokenService> _tokenService = new();

    private LoginHandler CreateSut() => new(_userRepo.Object, _hasher.Object, _tokenService.Object);

    [Fact]
    public async Task Handle_Returns_Token_When_Credentials_Are_Valid()
    {
        var user = User.Create("Juan", "Perez", 12345678, "CC", "juan@test.com", "hashedpwd", 1, "M", "3000000000");
        _userRepo.Setup(r => r.GetByEmailAsync("juan@test.com", It.IsAny<CancellationToken>())).ReturnsAsync(user);
        _hasher.Setup(h => h.Verify("plain", "hashedpwd")).Returns(true);
        _tokenService.Setup(t => t.GenerateToken(user)).Returns("jwt.token.value");

        var result = await CreateSut().Handle(new LoginCommand("juan@test.com", "plain"), CancellationToken.None);

        result.Token.Should().Be("jwt.token.value");
        result.Email.Should().Be("juan@test.com");
    }

    [Fact]
    public async Task Handle_Throws_When_User_Not_Found()
    {
        _userRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((User?)null);

        var act = () => CreateSut().Handle(new LoginCommand("missing@test.com", "x"), CancellationToken.None);

        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }

    [Fact]
    public async Task Handle_Throws_When_Password_Is_Invalid()
    {
        var user = User.Create("Juan", "Perez", 12345678, "CC", "juan@test.com", "hashedpwd", 1, "M", "3000000000");
        _userRepo.Setup(r => r.GetByEmailAsync("juan@test.com", It.IsAny<CancellationToken>())).ReturnsAsync(user);
        _hasher.Setup(h => h.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

        var act = () => CreateSut().Handle(new LoginCommand("juan@test.com", "wrong"), CancellationToken.None);

        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
