namespace HotelBooking.Application.Habitaciones.Common;

public sealed record HabitacionDto(
    int Id,
    int IdHotel,
    int NumeroHabitacion,
    int IdTipoHabitacion,
    decimal CostoBase,
    int Estado,
    int CantidadPersonas);
