using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Application.Hoteles.Commands.DeleteHotel;

public sealed class DeleteHotelHandler(
    IHotelRepository hotelRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteHotelCommand>
{
    public async Task Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Hotel), request.Id);

        hotelRepository.Remove(hotel);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
