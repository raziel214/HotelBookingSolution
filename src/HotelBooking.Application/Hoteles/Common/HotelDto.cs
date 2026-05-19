namespace HotelBooking.Application.Hoteles.Common;

public sealed record HotelDto(int Id, string Nombre, string Codigo, string Ubicacion, short Estado);
