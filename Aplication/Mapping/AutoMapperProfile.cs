using Application.Dtos.Roles;
using Application.Dtos.Usuarios;
using AutoMapper;
using Domain.Models.Roles;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
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
            CreateMap<User,UserCreate>();
            CreateMap<UserCreate,User>();
            CreateMap<User,UserRead>();
            CreateMap<UserRead,User>();
        }

    }
}
