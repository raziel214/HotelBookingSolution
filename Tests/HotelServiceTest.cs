using Aplication.Service.Hoteles;
using AutoMapper;
using Domain.Models.Hoteles;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class HotelServiceTest
    {
        private readonly Mock<IHotelRepository> _hotelRepositoryMock;
        private readonly HotelService _hotelService;
        private readonly Mock<IMapper> _mapperMock;

       public HotelServiceTest()
        {
            _hotelRepositoryMock = new Mock<IHotelRepository>();
            _mapperMock = new Mock<IMapper>();
            _hotelService = new HotelService(_hotelRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetHotelByIdAsync_HotelExists_ReturnsHotel()
        {
            // Arrange
            var hotelId = 1;
            var expectedHotel = new Hotel { IdHotel = hotelId, Nombre = "Hotel Test" };

            _hotelRepositoryMock.Setup(repo => repo.GetHotelByIdAsync(hotelId))
                .ReturnsAsync(expectedHotel);

            // Act
            var result = await _hotelService.GetHotelByIdAsync(hotelId);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedHotel.IdHotel, result.IdHotel);
            Xunit.Assert.Equal(expectedHotel.Nombre, result.Nombre);
        }

        [Fact]
        public async Task GetHotelByIdAsync_HotelDoesNotExist_ReturnsNull()
        {
            // Arrange
            var hotelId = 2;
            _hotelRepositoryMock.Setup(repo => repo.GetHotelByIdAsync(hotelId))
                .ReturnsAsync((Hotel)null);

            // Act
            var result = await _hotelService.GetHotelByIdAsync(hotelId);

            // Assert
            Xunit.Assert.Null(result);
        }

        

        [Fact]
        public async Task GetHotelByCode_HotelExists_ReturnsHotel()
        {
            // Arrange
            var hotelCode = "HT123";
            var expectedHotel = new Hotel { IdHotel = 1, Codigo = hotelCode };
            _hotelRepositoryMock.Setup(s => s.GetHotelByCodeAsync(hotelCode)).ReturnsAsync(expectedHotel);

            // Act
            var result = await _hotelService.GetHotelByCodeAsync(hotelCode);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedHotel.Codigo, result.Codigo);  // Verificar que el código coincide
        }


        [Fact]
        public async Task GetHotelByCode_HotelDoesNotExist_ReturnsNull()
        {
            // Arrange
            var hotelCode = "Nonexistent Code";
            _hotelRepositoryMock.Setup(s => s.GetHotelByCodeAsync(hotelCode)).ReturnsAsync((Hotel)null);

            // Act
            var result = await _hotelService.GetHotelByCodeAsync(hotelCode);

            // Assert
            Xunit.Assert.Null(result);  // Verificar que el resultado es nulo
        }

        [Fact]
        public async Task GetHotelByName_HotelExists_ReturnsHotel()
        {
            // Arrange
            var hotelName = "Hotel Test";
            var expectedHotel = new Hotel { IdHotel = 1, Nombre = hotelName };
            _hotelRepositoryMock.Setup(s => s.GetHotelByNameAsync(hotelName)).ReturnsAsync(expectedHotel);

            // Act
            var result = await _hotelService.GetHotelByNameAsync(hotelName);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expectedHotel.Nombre, result.Nombre);
        }

        [Fact]
        public async Task GetHotelByName_HotelDoesNotExist_ReturnsNull()
        {
            // Arrange
            var hotelName = "Nonexistent Hotel";
            _hotelRepositoryMock.Setup(s => s.GetHotelByNameAsync(hotelName)).ReturnsAsync((Hotel)null);

            // Act
            var result = await _hotelService.GetHotelByNameAsync(hotelName);

            // Assert
            Xunit.Assert.Null(result);
        }



    }
}
