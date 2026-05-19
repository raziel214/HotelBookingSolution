using AutoMapper;

namespace HotelBooking.Tests.TestHelpers;

public static class MapperFactory
{
    public static IMapper Create<TProfile>() where TProfile : Profile, new()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<TProfile>());
        return config.CreateMapper();
    }
}
