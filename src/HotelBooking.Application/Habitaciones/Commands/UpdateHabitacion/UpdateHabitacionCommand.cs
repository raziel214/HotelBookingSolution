using MediatR;

namespace HotelBooking.Application.Habitaciones.Commands.UpdateHabitacion;

public sealed record UpdateHabitacionCommand(
    int Id,
    int IdHotel,
    int NumeroHabitacion,
    int IdTipoHabitacion,
    decimal CostoBase,
    int Estado,
    int CantidadPersonas) : IRequest;
