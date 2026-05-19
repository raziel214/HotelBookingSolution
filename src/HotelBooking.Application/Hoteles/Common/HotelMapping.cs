using AutoMapper;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Application.Hoteles.Common;

public sealed class HotelMapping : Profile
{
    public HotelMapping()
    {
        CreateMap<Hotel, HotelDto>();
    }
}
