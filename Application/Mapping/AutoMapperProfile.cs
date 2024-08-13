using Application.Dtos.Roles;
using AutoMapper;
using Domain.Models.Roles;
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
        }

    }
}
