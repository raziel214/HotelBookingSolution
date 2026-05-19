using MediatR;

namespace HotelBooking.Application.Hoteles.Commands.DeleteHotel;

public sealed record DeleteHotelCommand(int Id) : IRequest;
