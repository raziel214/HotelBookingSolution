using FluentAssertions;
using Moq;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Roles.Commands.CreateRole;
using HotelBooking.Application.Roles.Common;
using HotelBooking.Tests.TestHelpers;

namespace HotelBooking.Tests.Roles;

public class CreateRoleHandlerTests
{
    private readonly Mock<IRoleRepository> _roleRepo = new();
    private readonly Mock<IUnitOfWork> _uow = new();
    private readonly AutoMapper.IMapper _mapper = MapperFactory.Create<RoleMapping>();

    [Fact]
    public async Task Handle_Persists_Role_And_Returns_Dto()
    {
        var sut = new CreateRoleHandler(_roleRepo.Object, _uow.Object, _mapper);

        var result = await sut.Handle(new CreateRoleCommand("Administrador", "ADMIN"), CancellationToken.None);

        result.Nombre.Should().Be("Administrador");
        result.Codigo.Should().Be("ADMIN");
        _roleRepo.Verify(r => r.AddAsync(It.IsAny<Domain.Roles.Role>(), It.IsAny<CancellationToken>()), Times.Once);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
