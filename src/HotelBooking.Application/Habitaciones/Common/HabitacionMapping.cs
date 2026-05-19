using AutoMapper;
using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Application.Habitaciones.Common;

public sealed class HabitacionMapping : Profile
{
    public HabitacionMapping()
    {
        CreateMap<Habitacion, HabitacionDto>();
    }
}
