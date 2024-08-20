using Aplication.Dtos.Habitaciones;
using Aplication.Dtos.HabitacionesTipos;
using Aplication.Dtos.Hoteles;
using Aplication.Dtos.HotelesPreferidos;
using Aplication.Dtos.Reservas;
using Aplication.Dtos.Usuarios;
using Application.Dtos.Roles;
using Application.Dtos.Usuarios;
using AutoMapper;
using Domain.Models.Habitaciones;
using Domain.Models.Hoteles;
using Domain.Models.HotelesPreferidos;
using Domain.Models.Reservas;
using Domain.Models.Roles;
using Domain.Models.TiposHabitaciones;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Aquí defines los mapeos entre tus entidades y DTOs
            CreateMap<Role, RoleRead>();
            CreateMap<RoleRead, Role>();
            CreateMap<RoleCreate, Role>();
            CreateMap<Role, RoleCreate>();
            CreateMap<User, UserCreate>();
            CreateMap<UserCreate, User>();
            CreateMap<User, UserRead>();
            CreateMap<UserRead, User>();
            CreateMap<UserLogin, User>();
            CreateMap<User, UserLogin>();
            CreateMap<Hotel,HotelCreate>();
            CreateMap<HotelCreate,Hotel>();
            CreateMap<Hotel,HotelRead>();
            CreateMap<HotelRead,Hotel>();
            CreateMap<HotelRead, Hotel>();
            CreateMap<Habitacion, HabitacionCreate>();
            CreateMap<HabitacionCreate, Habitacion>();
            CreateMap<Habitacion, HabitacionRead>();
            CreateMap<HabitacionRead, Habitacion>();
            CreateMap<TiposHabitacion, TipoHabitacionCreate>();
            CreateMap<TipoHabitacionCreate, TiposHabitacion>();
            CreateMap<TiposHabitacion, TipoHabitacionRead>();
            CreateMap<TipoHabitacionRead, TiposHabitacion>();
            CreateMap<HotelPreferidoCreate, HotelPreferido>();
            CreateMap<HotelPreferido, HotelPreferidoCreate>();
            CreateMap<HotelPreferidoRead, HotelPreferido>();
            CreateMap<HotelPreferido, HotelPreferidoRead>();            
            CreateMap<ReservasCreate, Reserva>();
            CreateMap<Reserva, ReservasCreate>();
            CreateMap<Reserva, ReservasRead>();
            CreateMap<ReservasRead, Reserva>();
        }

    }
}
