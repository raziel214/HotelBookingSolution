using AutoMapper;
using HotelBooking.Domain.Roles;

namespace HotelBooking.Application.Roles.Common;

public sealed class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<Role, RoleDto>();
    }
}
