using HotelBooking.Domain.Common;
using HotelBooking.Domain.Habitaciones;
using HotelBooking.Domain.Users;

namespace HotelBooking.Domain.Reservas;

public enum EstadoReserva
{
    Pendiente = 1,
    Confirmada = 2,
    Cancelada = 3
}

public class Reserva : Entity<int>
{
    public int IdUsuario { get; private set; }
    public int IdHabitacion { get; private set; }
    public DateTime FechaInicio { get; private set; }
    public DateTime FechaFin { get; private set; }
    public EstadoReserva Estado { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaCancelacion { get; private set; }

    public User? Usuario { get; private set; }
    public Habitacion? Habitacion { get; private set; }

    private Reserva() { }

    public static Reserva Create(int idUsuario, int idHabitacion, DateTime fechaInicio, DateTime fechaFin)
    {
        if (idUsuario <= 0)
            throw new DomainException("El usuario asignado no es válido.");
        if (idHabitacion <= 0)
            throw new DomainException("La habitación asignada no es válida.");
        if (fechaInicio.Date < DateTime.UtcNow.Date)
            throw new DomainException("La fecha de inicio no puede ser anterior a hoy.");
        if (fechaFin <= fechaInicio)
            throw new DomainException("La fecha fin debe ser posterior a la fecha inicio.");

        return new Reserva
        {
            IdUsuario = idUsuario,
            IdHabitacion = idHabitacion,
            FechaInicio = fechaInicio,
            FechaFin = fechaFin,
            Estado = EstadoReserva.Pendiente,
            FechaCreacion = DateTime.UtcNow
        };
    }

    public void Update(DateTime fechaInicio, DateTime fechaFin)
    {
        if (Estado == EstadoReserva.Cancelada)
            throw new DomainException("No se puede modificar una reserva cancelada.");
        if (fechaFin <= fechaInicio)
            throw new DomainException("La fecha fin debe ser posterior a la fecha inicio.");

        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
    }

    public void Cancelar()
    {
        if (Estado == EstadoReserva.Cancelada)
            throw new DomainException("La reserva ya está cancelada.");

        Estado = EstadoReserva.Cancelada;
        FechaCancelacion = DateTime.UtcNow;
    }
}
