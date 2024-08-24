using Aplication.Dtos.Habitaciones;
using Aplication.Service.Habitaciones;
using Application.Dtos.Roles;
using AutoMapper;
using Domain.Models.Habitaciones;
using Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class HabitacionServiceTest
    {
        private readonly Mock<IHabitacionRepository> _habitacionRepositoryMock;
        private readonly HabitacionService _habitacionService;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IHotelRepository>  _hotelRepositoryMock;
        private readonly new Mock<ITipoHabitacionRepository> _tipoHabitacionRepositoryMock ;

        public HabitacionServiceTest()
        {
            _habitacionRepositoryMock = new Mock<IHabitacionRepository>();
            _hotelRepositoryMock= new Mock<IHotelRepository>();
            _tipoHabitacionRepositoryMock= new Mock<ITipoHabitacionRepository>();
            _mapperMock = new Mock<IMapper>();
            _habitacionService = new HabitacionService( _mapperMock.Object, _habitacionRepositoryMock.Object,_hotelRepositoryMock.Object, _tipoHabitacionRepositoryMock.Object);
        }

        [Fact]
        public async Task GetHabitacionByIdAsync_HabitacionExists_ReturnsHabitacion()
        {
            // Arrange
            var habitacionId = 1;
            var expectedHabitacion = new Habitacion { IdHabitacion = habitacionId, NumeroHabitacion = 101 };

            _habitacionRepositoryMock.Setup(repo => repo.GetByIdHabitacionAsync(habitacionId))
                .ReturnsAsync(expectedHabitacion);

            // Act
            var result = await _habitacionService.GetByIdHabitacionAsync(habitacionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedHabitacion.IdHabitacion, result.IdHabitacion);
            Assert.Equal(expectedHabitacion.NumeroHabitacion, result.NumeroHabitacion);
        }

        [Fact]
        public async Task GetHabitacionByIdAsync_HabitacionDoesNotExist_ReturnsNull()
        {
            // Arrange
            var habitacionId = 2;
            _habitacionRepositoryMock.Setup(repo => repo.GetByIdHabitacionAsync(habitacionId))
                .ReturnsAsync((Habitacion)null);

            // Act
            var result = await _habitacionService.GetByIdHabitacionAsync(habitacionId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetHabitacionByCodeAsync_HabitacionExists_ReturnsHabitacion()
        {
            // Arrange
            var code = 101;
            var habitacion = new Habitacion { IdHabitacion = 1, NumeroHabitacion = code };

            _habitacionRepositoryMock.Setup(repo => repo.GetHabitacionByCodeAsync(code))
                .ReturnsAsync(habitacion);

            // Act
            var result = await _habitacionService.GetHabitacionByCodeAsync(code);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(habitacion.IdHabitacion, result.IdHabitacion);
        }
        [Fact]
        public async Task GetHabitacionByTypeAsync_HabitacionesExist_ReturnsListOfHabitaciones()
        {
            // Arrange
            var type = 1;
            var habitaciones = new List<Habitacion>
    {
        new Habitacion { IdHabitacion = 1, NumeroHabitacion = 101, IdTipoHabitacion = type },
        new Habitacion { IdHabitacion = 2, NumeroHabitacion = 102, IdTipoHabitacion = type }
    };

            _habitacionRepositoryMock.Setup(repo => repo.GetHabitacionByTypeAsync(type))
                .ReturnsAsync(habitaciones);

            // Act
            var result = await _habitacionService.GetHabitacionByTypeAsync(type);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(habitaciones.Count, result.Count());
        }

        [Fact]
        public async Task GetHabitacionByStatusAsync_HabitacionesExist_ReturnsListOfHabitaciones()
        {
            // Arrange
            var status = 1;
            var habitaciones = new List<Habitacion>
            {
                new Habitacion { IdHabitacion = 1, NumeroHabitacion = 101, Estado = status, CantidadPersonas=2},
                new Habitacion { IdHabitacion = 2, NumeroHabitacion = 102, Estado = status ,CantidadPersonas=2}
            };

            _habitacionRepositoryMock.Setup(repo => repo.GetHabitacionByStatusAndCapacityAsync(status, habitaciones.Capacity))
                .ReturnsAsync(habitaciones);

            // Act
            var result = await _habitacionService.GetHabitacionByStatusAndCapacityAsync(status, habitaciones.Capacity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(habitaciones.Count, result.Count());
        }
        [Fact]
        public async Task CreateHabitacionAsync_ValidHabitacion_ReturnsCreatedHabitacion()
        {
            //Arrange
            var habitacionCreate= new HabitacionCreate { IdHotel=1, NumeroHabitacion = 101,IdTipoHabitacion=1,CostoBase=150,Estado=1 };
            var createHabitacion = new Habitacion { IdHabitacion=1, IdHotel = 1, NumeroHabitacion = 101, IdTipoHabitacion = 1, CostoBase = 150, Estado = 1 };
            var habitacionRead= new HabitacionRead { IdHabitacion = 1, IdHotel = 1, NumeroHabitacion = 101, IdTipoHabitacion = 1, CostoBase = 150, Estado = 1 };


           
            _mapperMock.Setup(mapper => mapper.Map<Habitacion>(habitacionCreate)).Returns(createHabitacion);
            
            _habitacionRepositoryMock.Setup(repo => repo.CreateHabitacionAsync(createHabitacion)).ReturnsAsync(createHabitacion);
            
            _mapperMock.Setup(mapper => mapper.Map<HabitacionRead>(createHabitacion)).Returns(habitacionRead);

            //Act
            var result = await _habitacionService.CreateHabitacionAsync(habitacionCreate);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(habitacionRead.IdHabitacion, result.IdHabitacion);
            Assert.Equal(habitacionRead.IdHotel, result.IdHotel);

        }



        [Fact]
        public async Task UpdateHabitacionAsync_ValidHabitacion_UpdatesHabitacion()
        {
            // Arrange
            var habitacionId = 1;
            var habitacion = new Habitacion { IdHabitacion = habitacionId, NumeroHabitacion = 101 };

            // No return type in repository method, so we mock just the method call
            _habitacionRepositoryMock.Setup(repo => repo.UpdateHabitacionAsync(habitacionId, habitacion))
                .Returns(Task.CompletedTask);

            // Act
            await _habitacionService.UpdateHabitacionAsync(habitacionId, habitacion);

            // Assert
            _habitacionRepositoryMock.Verify(repo => repo.UpdateHabitacionAsync(habitacionId, habitacion), Times.Once);
        }

        [Fact]
        public async Task DeleteHabitacionAsync_HabitacionExists_DeletesHabitacion()
        {
            // Arrange
            var habitacionId = 1;
            var habitacion = new Habitacion { IdHabitacion = habitacionId,NumeroHabitacion=101 };
          //_rolRepositoryMock.Setup(repo => repo.GetRolByIdAsync(roleId)).ReturnsAsync(role);
            _habitacionRepositoryMock.Setup(repo => repo.GetByIdHabitacionAsync(habitacionId)).ReturnsAsync(habitacion);
            _habitacionRepositoryMock.Setup(repo=>repo.DeleteHabitacionByIdAsync(habitacionId)).ReturnsAsync(habitacion);

            // Act
            var result = await _habitacionService.DeleteHabitacionByIdAsync(habitacionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(habitacionId, result.IdHabitacion);
            _habitacionRepositoryMock.Verify(repo => repo.DeleteHabitacionByIdAsync(habitacionId), Times.Once);
        }

    }
}
