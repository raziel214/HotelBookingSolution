using AutoMapper;
using HotelBooking.Domain.Users;

namespace HotelBooking.Application.Users.Common;

public sealed class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>();
    }
}
