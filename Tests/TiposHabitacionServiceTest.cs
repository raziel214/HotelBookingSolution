
using AutoMapper;
using Domain.Repository;
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
using Aplication.Service.TiposHabitaciones;
using Domain.Models.TiposHabitaciones;
using Aplication.Dtos.HabitacionesTipos;

namespace Tests
{
    public class TiposHabitacionServiceTest
    {
        private readonly TipoHabitacionService _tiposHabitacionService;
        private readonly Mock<ITipoHabitacionRepository> _tiposHabitacionRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public TiposHabitacionServiceTest()
        {
            // Configuramos el mock del repositorio
            _tiposHabitacionRepositoryMock = new Mock<ITipoHabitacionRepository>();

            // Configuramos el mock de IMapper
            _mapperMock = new Mock<IMapper>();

            // Inyectamos el mock en el servicio
            _tiposHabitacionService = new TipoHabitacionService(_mapperMock.Object, _tiposHabitacionRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllHabitacionAsync_ReturnsListOfHabitaciones()
        {
            // Arrange
            var habitaciones = new List<TiposHabitacion>
            {
                new TiposHabitacion { IdTipoHabitacion = 1, Nombre = "Habitación Sencilla" },
                new TiposHabitacion { IdTipoHabitacion = 2, Nombre = "Habitación Doble" }
            };

            _tiposHabitacionRepositoryMock.Setup(repo => repo.GetAllHabitacionTipoAsync())
                .ReturnsAsync(habitaciones);

            // Act
            var result = await _tiposHabitacionService.GetAllHabitacionTipoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(habitaciones, result);
        }

        [Fact]
        public async Task GetTipoHabitacionByIdAsync_ValidId_ReturnsHabitacion()
        {
            // Arrange
            var habitacion = new TiposHabitacion { IdTipoHabitacion = 1, Nombre = "Habitación Sencilla" };

            _tiposHabitacionRepositoryMock.Setup(repo => repo.GetHabitacionTipoByIdAsync(1))
                .ReturnsAsync(habitacion);

            // Act
            var result = await _tiposHabitacionService.GetHabitacionTipoByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(habitacion, result);
        }

        [Fact]
        public async Task GetHabitacionTipoByNombreAsync_ValidNombre_ReturnsHabitacion()
        {
            // Arrange
            var habitacion = new TiposHabitacion { IdTipoHabitacion = 1, Nombre = "Habitación Sencilla" };

            _tiposHabitacionRepositoryMock.Setup(repo => repo.GetHabitacionTipoByNombreAsync("Habitación Sencilla"))
                .ReturnsAsync(habitacion);

            // Act
            var result = await _tiposHabitacionService.GetHabitacionTipoByNombreAsync("Habitación Sencilla");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(habitacion, result);
        }
        [Fact]
        public async Task CreateHabitacionTipoAsync_ValidHabitacion_ReturnsCreatedHabitacion()
        {
            // Arrange
            var habitacionCreate = new TipoHabitacionCreate { Nombre = "Habitación Sencilla", Descripcion = "Descripción" };
            var habitacion = new TiposHabitacion { IdTipoHabitacion = 1, Nombre = "Habitación Sencilla" };

            _mapperMock.Setup(m => m.Map<TiposHabitacion>(habitacionCreate)).Returns(habitacion);
            _tiposHabitacionRepositoryMock.Setup(repo => repo.CreateTipoHabitacionAsync(habitacion)).ReturnsAsync(habitacion);
            _mapperMock.Setup(m => m.Map<TipoHabitacionRead>(habitacion)).Returns(new TipoHabitacionRead { IdTipoHabitacion = 1, Nombre = "Habitación Sencilla" });

            // Act
            var result = await _tiposHabitacionService.CreateTipoHabitacionAsync(habitacionCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(habitacion.IdTipoHabitacion, result.IdTipoHabitacion);
        }
        [Fact]
        public async Task UpdateHabitacionTipoAsync_ValidHabitacion_UpdatesHabitacion()
        {
            // Arrange
            var habitacion = new TiposHabitacion { IdTipoHabitacion = 1, Nombre = "Habitación Sencilla" };

            _tiposHabitacionRepositoryMock.Setup(repo => repo.UpdateHabitacionTipoAsync(habitacion)).Returns(Task.CompletedTask);

            // Act
            await _tiposHabitacionService.UpdateHabitacionTipoAsync(habitacion);

            // Assert
            _tiposHabitacionRepositoryMock.Verify(repo => repo.UpdateHabitacionTipoAsync(habitacion), Times.Once);
        }

        [Fact]
        public async Task DeleteHabitacionTipoAsync_ValidId_DeletesHabitacion()
        {
            // Arrange
            var idHabitacion = 1;
            var habitacion = new TiposHabitacion { IdTipoHabitacion = idHabitacion, Nombre = "Habitación Sencilla" };

            _tiposHabitacionRepositoryMock.Setup(repo => repo.GetHabitacionTipoByIdAsync(idHabitacion)).ReturnsAsync(habitacion);
            _tiposHabitacionRepositoryMock.Setup(repo => repo.DeleteHabitacionTipoAsync(idHabitacion)).ReturnsAsync(habitacion);

            // Act
            var result = await _tiposHabitacionService.DeleteHabitacionTipoAsync(idHabitacion);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(idHabitacion, result.IdTipoHabitacion);
            _tiposHabitacionRepositoryMock.Verify(repo => repo.DeleteHabitacionTipoAsync(idHabitacion), Times.Once);
        }




    }
}
