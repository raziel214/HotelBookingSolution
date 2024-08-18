using Aplication.Dtos.Hoteles;
using Aplication.Dtos.Usuarios;
using Application.Dtos.Roles;
using Application.Dtos.Usuarios;
using AutoMapper;
using Domain.Models.Hoteles;
using Domain.Models.Roles;
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

        }

    }
}
