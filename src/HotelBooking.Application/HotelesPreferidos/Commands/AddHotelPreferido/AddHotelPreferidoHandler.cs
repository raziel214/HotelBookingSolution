using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.HotelesPreferidos.Common;
using HotelBooking.Domain.Common;
using HotelBooking.Domain.Hoteles;
using HotelBooking.Domain.HotelesPreferidos;
using HotelBooking.Domain.Users;

namespace HotelBooking.Application.HotelesPreferidos.Commands.AddHotelPreferido;

public sealed class AddHotelPreferidoHandler(
    IHotelPreferidoRepository repository,
    IUserRepository userRepository,
    IHotelRepository hotelRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<AddHotelPreferidoCommand, HotelPreferidoDto>
{
    public async Task<HotelPreferidoDto> Handle(AddHotelPreferidoCommand request, CancellationToken cancellationToken)
    {
        _ = await userRepository.GetByIdAsync(request.IdUsuario, cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.IdUsuario);
        _ = await hotelRepository.GetByIdAsync(request.IdHotel, cancellationToken)
            ?? throw new NotFoundException(nameof(Hotel), request.IdHotel);

        var existente = await repository.GetByUsuarioAndHotelAsync(request.IdUsuario, request.IdHotel, cancellationToken);
        if (existente is not null)
            throw new DomainException("Ese hotel ya está marcado como preferido por el usuario.");

        var preferido = HotelPreferido.Create(request.IdUsuario, request.IdHotel);
        await repository.AddAsync(preferido, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<HotelPreferidoDto>(preferido);
    }
}
