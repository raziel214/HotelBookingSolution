using MediatR;

namespace HotelBooking.Application.Hoteles.Commands.UpdateHotel;

public sealed record UpdateHotelCommand(int Id, string Nombre, string Codigo, string Ubicacion, short Estado) : IRequest;
