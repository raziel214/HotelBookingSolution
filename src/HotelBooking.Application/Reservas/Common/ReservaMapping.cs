using AutoMapper;
using HotelBooking.Domain.Reservas;

namespace HotelBooking.Application.Reservas.Common;

public sealed class ReservaMapping : Profile
{
    public ReservaMapping()
    {
        CreateMap<Reserva, ReservaDto>();
    }
}
