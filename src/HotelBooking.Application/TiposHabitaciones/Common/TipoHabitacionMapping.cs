using AutoMapper;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Application.TiposHabitaciones.Common;

public sealed class TipoHabitacionMapping : Profile
{
    public TipoHabitacionMapping()
    {
        CreateMap<TipoHabitacion, TipoHabitacionDto>();
    }
}
