using FluentAssertions;
using Moq;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Hoteles.Commands.CreateHotel;
using HotelBooking.Application.Hoteles.Common;
using HotelBooking.Domain.Common;
using HotelBooking.Domain.Hoteles;
using HotelBooking.Tests.TestHelpers;

namespace HotelBooking.Tests.Hoteles;

public class CreateHotelHandlerTests
{
    private readonly Mock<IHotelRepository> _hotelRepo = new();
    private readonly Mock<IUnitOfWork> _uow = new();
    private readonly AutoMapper.IMapper _mapper = MapperFactory.Create<HotelMapping>();

    private CreateHotelHandler CreateSut() => new(_hotelRepo.Object, _uow.Object, _mapper);

    [Fact]
    public async Task Handle_Creates_Hotel_When_Code_Is_Unique()
    {
        _hotelRepo.Setup(r => r.GetByCodigoAsync("HTL010", It.IsAny<CancellationToken>())).ReturnsAsync((Hotel?)null);

        var result = await CreateSut().Handle(new CreateHotelCommand("Hotel X", "HTL010", "Lugar", 1), CancellationToken.None);

        result.Codigo.Should().Be("HTL010");
        _hotelRepo.Verify(r => r.AddAsync(It.IsAny<Hotel>(), It.IsAny<CancellationToken>()), Times.Once);
        _uow.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Throws_DomainException_When_Code_Already_Exists()
    {
        _hotelRepo.Setup(r => r.GetByCodigoAsync("HTL010", It.IsAny<CancellationToken>()))
            .ReturnsAsync(Hotel.Create("Existente", "HTL010", "Lugar", 1));

        var act = () => CreateSut().Handle(new CreateHotelCommand("Otro", "HTL010", "Lugar2", 1), CancellationToken.None);

        await act.Should().ThrowAsync<DomainException>();
    }
}
