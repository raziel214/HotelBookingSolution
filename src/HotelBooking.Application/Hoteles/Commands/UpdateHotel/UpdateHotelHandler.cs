using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Application.Hoteles.Commands.UpdateHotel;

public sealed class UpdateHotelHandler(
    IHotelRepository hotelRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateHotelCommand>
{
    public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Hotel), request.Id);

        hotel.Update(request.Nombre, request.Codigo, request.Ubicacion, request.Estado);
        hotelRepository.Update(hotel);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
