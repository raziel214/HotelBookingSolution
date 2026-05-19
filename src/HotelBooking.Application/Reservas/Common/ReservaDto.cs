using HotelBooking.Domain.Reservas;

namespace HotelBooking.Application.Reservas.Common;

public sealed record ReservaDto(
    int Id,
    int IdUsuario,
    int IdHabitacion,
    DateTime FechaInicio,
    DateTime FechaFin,
    EstadoReserva Estado,
    DateTime FechaCreacion,
    DateTime? FechaCancelacion);
