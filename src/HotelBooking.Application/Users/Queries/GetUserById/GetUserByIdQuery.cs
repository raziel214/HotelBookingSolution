using MediatR;
using HotelBooking.Application.Users.Common;

namespace HotelBooking.Application.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(int Id) : IRequest<UserDto>;
