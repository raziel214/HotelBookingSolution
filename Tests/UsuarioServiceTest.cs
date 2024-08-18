using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository;
using Application.Service.Users;
using Aplication.Service.Seguridad;
using Domain.Models.Users;
using Xunit;
using Castle.Components.DictionaryAdapter.Xml;

namespace Tests
{
    public class UsuarioServiceTest
    {
        private readonly UserService _usuarioService;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUserRepository> _usuarioRepositoryMock;
        private readonly Mock<ISecurityService> _securityServiceMock;

        public UsuarioServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _usuarioRepositoryMock = new Mock<IUserRepository>();
            _securityServiceMock = new Mock<ISecurityService>();

            _usuarioService = new UserService(_usuarioRepositoryMock.Object, _mapperMock.Object, _securityServiceMock.Object);
        }

        [Fact]
        public async Task GetUserByIdAsync_UserExists_ReturnsUser()
        {
            // Arrange
            int userId = 1;
            var expectedUser = new User { Id = userId };
            _usuarioRepositoryMock.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(expectedUser);

            // Act
            var result = await _usuarioService.GetUserByIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task GetUserByIdAsync_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            int userId = 1;
            _usuarioRepositoryMock.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync((User)null);

            // Act
            var result = await _usuarioService.GetUserByIdAsync(userId);

            // Assert
            Assert.Null(result);
        }

      

        

        [Fact]
        public async Task UpdateUserAsync_ValidUser_UpdatesUser()
        {
            // Arrange
            var existingUser = new User { Id = 1, Email = "test@example.com" };

            // Act
            await _usuarioService.UpdateUserAsync(existingUser.Id, existingUser);

            // Assert
            _usuarioRepositoryMock.Verify(repo => repo.UpdateUserAsync(existingUser), Times.Once);
        }

        [Fact]
        public async Task DeleteUserByIdAsync_UserExists_DeletesUser()
        {
            // Arrange
            int userId = 1;
            var user = new User { Id = userId };

            _usuarioRepositoryMock.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(user);  // Simula que el usuario existe
            _usuarioRepositoryMock.Setup(repo => repo.DeleteUserByIdAsync(userId)).ReturnsAsync(user);  // Configura la eliminación

            // Act
            var result = await _usuarioService.DeleteUserAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            _usuarioRepositoryMock.Verify(repo => repo.DeleteUserByIdAsync(userId), Times.Once);  // Verifica que se haya llamado a la eliminación
        }


        [Fact]
        public async Task GetAllUsersAsync_ReturnsListOfUsers()
        {
            // Arrange
            var users = new List<User> { new User { Id = 1 }, new User { Id = 2 } };
            _usuarioRepositoryMock.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _usuarioService.GetAllUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<User>)result).Count);
        }


    }
}
