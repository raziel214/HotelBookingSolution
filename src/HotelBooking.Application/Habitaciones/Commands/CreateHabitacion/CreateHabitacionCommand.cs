using MediatR;
using HotelBooking.Application.Habitaciones.Common;

namespace HotelBooking.Application.Habitaciones.Commands.CreateHabitacion;

public sealed record CreateHabitacionCommand(
    int IdHotel,
    int NumeroHabitacion,
    int IdTipoHabitacion,
    decimal CostoBase,
    int Estado,
    int CantidadPersonas) : IRequest<HabitacionDto>;
