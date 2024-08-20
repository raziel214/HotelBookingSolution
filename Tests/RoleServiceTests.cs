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
using Application.Dtos.Roles;

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
            var expectedRole = new Role { Id = roleId, Nombre = "Admin" };
            _rolRepositoryMock.Setup(repo => repo.GetRolByIdAsync(roleId))
                              .ReturnsAsync(expectedRole);

            // Act
            var actualRole = await _roleService.GetRoleByIdAsync(roleId);

            // Assert
            Assert.NotNull(actualRole);
            Assert.Equal(expectedRole.Id, actualRole.Id);
            Assert.Equal(expectedRole.Nombre, actualRole.Nombre);
        }

        [Fact]
        public async Task GetRoleByIdAsync_RoleDoesNotExist_ThrowsKeyNotFoundException()
        {
            // Arrange
            var roleId = 1;
            _rolRepositoryMock.Setup(repo => repo.GetRolByIdAsync(roleId))
                              .ReturnsAsync((Role)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _roleService.GetRoleByIdAsync(roleId));
        }

        [Fact]
        public async Task GetRoleByNameAsync_RoleExists_ReturnsRole()
        {
            // Arrange
            var roleName = "Admin";
            var expectedRole = new Role { Id = 1, Nombre = roleName };
            _rolRepositoryMock.Setup(repo => repo.GetRolByNameAsync(roleName))
                              .ReturnsAsync(expectedRole);

            // Act
            var actualRole = await _roleService.GetRoleByNameAsync(roleName);

            // Assert
            Assert.NotNull(actualRole);
            Assert.Equal(expectedRole.Id, actualRole.Id);
            Assert.Equal(expectedRole.Nombre, actualRole.Nombre);
        }

        [Fact]
        public async Task GetRoleByNameAsync_RoleDoesNotExist_ThrowsKeyNotFoundException()
        {
            // Arrange
            var roleName = "NonexistentRole";
            _rolRepositoryMock.Setup(repo => repo.GetRolByNameAsync(roleName))
                              .ReturnsAsync((Role)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _roleService.GetRoleByNameAsync(roleName));
        }

        [Fact]
        public async Task CreateRoleAsync_ValidRole_ReturnsRoleRead()
        {
            // Arrange
            var roleCreate = new RoleCreate { Nombre = "User", Codigo = "USER" };
            var createdRole = new Role { Id = 1, Nombre = "User", Codigo = "USER" };
            var roleRead = new RoleRead { IdRol = 1, Nombre = "User" };

            _mapperMock.Setup(m => m.Map<Role>(roleCreate)).Returns(createdRole);
            _rolRepositoryMock.Setup(repo => repo.CreateRoleAsync(createdRole)).ReturnsAsync(createdRole);
            _mapperMock.Setup(m => m.Map<RoleRead>(createdRole)).Returns(roleRead);

            // Act
            var result = await _roleService.CreateRoleAsync(roleCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(roleRead.IdRol, result.IdRol);
            Assert.Equal(roleRead.Nombre, result.Nombre);
        }

        [Fact]
        public async Task UpdateRoleAsync_ValidRole_UpdatesRole()
        {
            // Arrange
            var roleId = 1;
            var role = new Role { Id = roleId, Nombre = "Admin" };

            _rolRepositoryMock.Setup(repo => repo.GetRolByIdAsync(roleId)).ReturnsAsync(role);
            _rolRepositoryMock.Setup(repo => repo.UpdateRolAsync(role)).Returns(Task.CompletedTask);

            // Act
            await _roleService.UpdateRoleAsync(roleId, role);

            // Assert
            _rolRepositoryMock.Verify(repo => repo.UpdateRolAsync(role), Times.Once);
        }

        [Fact]
        public async Task DeleteRoleByIdAsync_RoleExists_DeletesRole()
        {
            // Arrange
            var roleId = 1;
            var role = new Role { Id = roleId, Nombre = "Admin" };

            _rolRepositoryMock.Setup(repo => repo.GetRolByIdAsync(roleId)).ReturnsAsync(role);
            _rolRepositoryMock.Setup(repo => repo.DeleteRolByIdAsync(roleId)).ReturnsAsync(role);

            // Act
            var deletedRole = await _roleService.DeleteRoleByIdAsync(roleId);

            // Assert
            Assert.NotNull(deletedRole);
            Assert.Equal(roleId, deletedRole.Id);
            _rolRepositoryMock.Verify(repo => repo.DeleteRolByIdAsync(roleId), Times.Once);
        }

        [Fact]
        public async Task GetAllRolesAsync_ReturnsListOfRoles()
        {
            // Arrange
            var roles = new List<Role>
            {
                new Role { Id = 1, Nombre = "Admin" },
                new Role { Id = 2, Nombre = "User" }
            };

            _rolRepositoryMock.Setup(repo => repo.GetAllRolesAsync()).ReturnsAsync(roles);

            // Act
            var result = await _roleService.GetAllRolesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

    }
}
