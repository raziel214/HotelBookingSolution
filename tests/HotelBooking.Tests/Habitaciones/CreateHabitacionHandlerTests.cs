using FluentAssertions;
using Moq;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Habitaciones.Commands.CreateHabitacion;
using HotelBooking.Application.Habitaciones.Common;
using HotelBooking.Domain.Habitaciones;
using HotelBooking.Domain.Hoteles;
using HotelBooking.Domain.TiposHabitaciones;
using HotelBooking.Tests.TestHelpers;

namespace HotelBooking.Tests.Habitaciones;

public class CreateHabitacionHandlerTests
{
    private readonly Mock<IHabitacionRepository> _habitacionRepo = new();
    private readonly Mock<IHotelRepository> _hotelRepo = new();
    private readonly Mock<ITipoHabitacionRepository> _tipoRepo = new();
    private readonly Mock<IUnitOfWork> _uow = new();
    private readonly AutoMapper.IMapper _mapper = MapperFactory.Create<HabitacionMapping>();

    private CreateHabitacionHandler CreateSut() =>
        new(_habitacionRepo.Object, _hotelRepo.Object, _tipoRepo.Object, _uow.Object, _mapper);

    [Fact]
    public async Task Handle_Creates_Habitacion_When_Hotel_And_Tipo_Exist()
    {
        _hotelRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Hotel.Create("H", "C1", "U", 1));
        _tipoRepo.Setup(r => r.GetByIdAsync(2, It.IsAny<CancellationToken>()))
            .ReturnsAsync(TipoHabitacion.Create("Suite", "Descripcion suite"));

        var command = new CreateHabitacionCommand(1, 101, 2, 200000m, 1, 2);
        var result = await CreateSut().Handle(command, CancellationToken.None);

        result.NumeroHabitacion.Should().Be(101);
        _habitacionRepo.Verify(r => r.AddAsync(It.IsAny<Habitacion>(), It.IsAny<CancellationToken>()), Times.Once);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Throws_NotFound_When_Hotel_Missing()
    {
        _hotelRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((Hotel?)null);

        var act = () => CreateSut().Handle(new CreateHabitacionCommand(1, 101, 2, 200000m, 1, 2), CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}
