using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Hoteles.Common;
using HotelBooking.Domain.Common;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Application.Hoteles.Commands.CreateHotel;

public sealed class CreateHotelHandler(
    IHotelRepository hotelRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateHotelCommand, HotelDto>
{
    public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var existente = await hotelRepository.GetByCodigoAsync(request.Codigo, cancellationToken);
        if (existente is not null)
            throw new DomainException($"Ya existe un hotel con el código '{request.Codigo}'.");

        var hotel = Hotel.Create(request.Nombre, request.Codigo, request.Ubicacion, request.Estado);
        await hotelRepository.AddAsync(hotel, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<HotelDto>(hotel);
    }
}
