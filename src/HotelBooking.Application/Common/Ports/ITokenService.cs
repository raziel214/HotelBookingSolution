using HotelBooking.Domain.Users;

namespace HotelBooking.Application.Common.Ports;

public interface ITokenService
{
    string GenerateToken(User user);
}
