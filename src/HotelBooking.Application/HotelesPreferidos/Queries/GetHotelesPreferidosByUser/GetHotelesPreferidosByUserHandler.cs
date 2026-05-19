using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.HotelesPreferidos.Common;

namespace HotelBooking.Application.HotelesPreferidos.Queries.GetHotelesPreferidosByUser;

public sealed class GetHotelesPreferidosByUserHandler(
    IHotelPreferidoRepository repository,
    IMapper mapper) : IRequestHandler<GetHotelesPreferidosByUserQuery, IReadOnlyList<HotelPreferidoDto>>
{
    public async Task<IReadOnlyList<HotelPreferidoDto>> Handle(GetHotelesPreferidosByUserQuery request, CancellationToken cancellationToken)
    {
        var items = await repository.GetByUsuarioAsync(request.IdUsuario, cancellationToken);
        return items.Select(mapper.Map<HotelPreferidoDto>).ToList();
    }
}
