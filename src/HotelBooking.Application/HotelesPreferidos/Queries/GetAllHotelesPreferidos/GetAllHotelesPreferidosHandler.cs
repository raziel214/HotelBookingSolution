using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.HotelesPreferidos.Common;

namespace HotelBooking.Application.HotelesPreferidos.Queries.GetAllHotelesPreferidos;

public sealed class GetAllHotelesPreferidosHandler(
    IHotelPreferidoRepository repository,
    IMapper mapper) : IRequestHandler<GetAllHotelesPreferidosQuery, IReadOnlyList<HotelPreferidoDto>>
{
    public async Task<IReadOnlyList<HotelPreferidoDto>> Handle(GetAllHotelesPreferidosQuery request, CancellationToken cancellationToken)
    {
        var items = await repository.GetAllAsync(cancellationToken);
        return items.Select(mapper.Map<HotelPreferidoDto>).ToList();
    }
}
