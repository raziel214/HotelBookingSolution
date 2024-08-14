using Domain.Repository;
using Application.Service.Roles;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Roles;
using Castle.Components.DictionaryAdapter.Xml;
using AutoMapper;

namespace Tests
{
    public class RoleServiceTests
    {
        private readonly RoleService _roleService;
        private readonly Mock<IRolRepository> _rolRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public RoleServiceTests()
        {
            // Configuramos el mock del repositorio
            _rolRepositoryMock = new Mock<IRolRepository>();

            // Configuramos el mock de IMapper
            _mapperMock = new Mock<IMapper>();

            // Inyectamos el mock en el servicio
            _roleService = new RoleService(_mapperMock.Object,_rolRepositoryMock.Object);
        }

        [Fact]
        public async Task GetRoleByIdAsync_RoleExists_ReturnsRole()
        {
            // Arrange
            var roleId = 1;
            var expectedRole = new Role { IdRol = roleId, Nombre = "Admin" };
            _rolRepositoryMock.Setup(repo => repo.GetRolByIdAsync(roleId))
                              .ReturnsAsync(expectedRole);

            // Act
            var actualRole = await _roleService.GetRoleByIdAsync(roleId);

            // Assert
            Xunit.Assert.NotNull(actualRole);
            Xunit.Assert.Equal(expectedRole.IdRol, actualRole.IdRol);
            Xunit.Assert.Equal(expectedRole.Nombre, actualRole.Nombre);
        }

        [Fact]
        public async Task GetRoleByIdAsync_RoleDoesNotExist_ThrowsKeyNotFoundException()
        {
            // Arrange
            var roleId = 1;
            _rolRepositoryMock.Setup(repo => repo.GetRolByIdAsync(roleId))
                              .ReturnsAsync((Role)null);

            // Act & Assert
            await Xunit.Assert.ThrowsAsync<KeyNotFoundException>(() => _roleService.GetRoleByIdAsync(roleId));
        }

    }
}
