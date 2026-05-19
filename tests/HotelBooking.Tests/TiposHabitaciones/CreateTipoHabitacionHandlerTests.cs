using FluentAssertions;
using Moq;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.TiposHabitaciones.Commands.CreateTipoHabitacion;
using HotelBooking.Application.TiposHabitaciones.Common;
using HotelBooking.Tests.TestHelpers;

namespace HotelBooking.Tests.TiposHabitaciones;

public class CreateTipoHabitacionHandlerTests
{
    private readonly Mock<ITipoHabitacionRepository> _repo = new();
    private readonly Mock<IUnitOfWork> _uow = new();
    private readonly AutoMapper.IMapper _mapper = MapperFactory.Create<TipoHabitacionMapping>();

    [Fact]
    public async Task Handle_Creates_Tipo_And_Saves()
    {
        var sut = new CreateTipoHabitacionHandler(_repo.Object, _uow.Object, _mapper);

        var result = await sut.Handle(new CreateTipoHabitacionCommand("Suite", "Suite con jacuzzi"), CancellationToken.None);

        result.Nombre.Should().Be("Suite");
        _repo.Verify(r => r.AddAsync(It.IsAny<Domain.TiposHabitaciones.TipoHabitacion>(), It.IsAny<CancellationToken>()), Times.Once);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
