using AutoMapper;
using HotelBooking.Domain.HotelesPreferidos;

namespace HotelBooking.Application.HotelesPreferidos.Common;

public sealed class HotelPreferidoMapping : Profile
{
    public HotelPreferidoMapping()
    {
        CreateMap<HotelPreferido, HotelPreferidoDto>();
    }
}
