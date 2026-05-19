using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.HotelesPreferidos;

namespace HotelBooking.Application.HotelesPreferidos.Commands.RemoveHotelPreferido;

public sealed class RemoveHotelPreferidoHandler(
    IHotelPreferidoRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveHotelPreferidoCommand>
{
    public async Task Handle(RemoveHotelPreferidoCommand request, CancellationToken cancellationToken)
    {
        var preferido = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(HotelPreferido), request.Id);

        repository.Remove(preferido);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
