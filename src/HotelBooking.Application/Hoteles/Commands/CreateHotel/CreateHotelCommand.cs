using MediatR;
using HotelBooking.Application.Hoteles.Common;

namespace HotelBooking.Application.Hoteles.Commands.CreateHotel;

public sealed record CreateHotelCommand(string Nombre, string Codigo, string Ubicacion, short Estado) : IRequest<HotelDto>;
