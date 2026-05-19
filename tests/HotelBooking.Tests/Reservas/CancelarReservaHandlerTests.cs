using FluentAssertions;
using Moq;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Reservas.Commands.CancelarReserva;
using HotelBooking.Domain.Common;
using HotelBooking.Domain.Reservas;

namespace HotelBooking.Tests.Reservas;

public class CancelarReservaHandlerTests
{
    private readonly Mock<IReservaRepository> _reservaRepo = new();
    private readonly Mock<IUnitOfWork> _uow = new();

    private CancelarReservaHandler CreateSut() => new(_reservaRepo.Object, _uow.Object);

    [Fact]
    public async Task Handle_Cancels_Reserva_When_Exists()
    {
        var reserva = Reserva.Create(1, 1, DateTime.UtcNow.Date.AddDays(1), DateTime.UtcNow.Date.AddDays(3));
        _reservaRepo.Setup(r => r.GetByIdAsync(5, It.IsAny<CancellationToken>())).ReturnsAsync(reserva);

        await CreateSut().Handle(new CancelarReservaCommand(5), CancellationToken.None);

        reserva.Estado.Should().Be(EstadoReserva.Cancelada);
        _reservaRepo.Verify(r => r.Update(reserva), Times.Once);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Throws_NotFound_When_Reserva_Missing()
    {
        _reservaRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((Reserva?)null);

        var act = () => CreateSut().Handle(new CancelarReservaCommand(99), CancellationToken.None);

        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task Handle_Throws_DomainException_When_Already_Cancelled()
    {
        var reserva = Reserva.Create(1, 1, DateTime.UtcNow.Date.AddDays(1), DateTime.UtcNow.Date.AddDays(3));
        reserva.Cancelar();
        _reservaRepo.Setup(r => r.GetByIdAsync(5, It.IsAny<CancellationToken>())).ReturnsAsync(reserva);

        var act = () => CreateSut().Handle(new CancelarReservaCommand(5), CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>();
    }
}
