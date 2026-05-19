using AutoMapper;
using MediatR;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Application.Users.Common;
using HotelBooking.Domain.Users;

namespace HotelBooking.Application.Users.Queries.GetUserById;

public sealed class GetUserByIdHandler(
    IUserRepository userRepository,
    IMapper mapper) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        return mapper.Map<UserDto>(user);
    }
}
