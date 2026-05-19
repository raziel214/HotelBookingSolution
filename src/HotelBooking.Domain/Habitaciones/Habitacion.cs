using HotelBooking.Domain.Common;
using HotelBooking.Domain.Hoteles;
using HotelBooking.Domain.Reservas;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Domain.Habitaciones;

public class Habitacion : Entity<int>
{
    public int IdHotel { get; private set; }
    public int NumeroHabitacion { get; private set; }
    public int IdTipoHabitacion { get; private set; }
    public decimal CostoBase { get; private set; }
    public int Estado { get; private set; }
    public int CantidadPersonas { get; private set; }

    public Hotel? Hotel { get; private set; }
    public TipoHabitacion? TipoHabitacion { get; private set; }
    public ICollection<Reserva> Reservas { get; private set; } = new List<Reserva>();

    private Habitacion() { }

    public static Habitacion Create(
        int idHotel,
        int numeroHabitacion,
        int idTipoHabitacion,
        decimal costoBase,
        int estado,
        int cantidadPersonas)
    {
        if (idHotel <= 0)
            throw new DomainException("El hotel asignado no es válido.");
        if (idTipoHabitacion <= 0)
            throw new DomainException("El tipo de habitación no es válido.");
        if (numeroHabitacion <= 0)
            throw new DomainException("El número de habitación debe ser positivo.");
        if (costoBase < 0)
            throw new DomainException("El costo base no puede ser negativo.");
        if (cantidadPersonas <= 0)
            throw new DomainException("La cantidad de personas debe ser positiva.");

        return new Habitacion
        {
            IdHotel = idHotel,
            NumeroHabitacion = numeroHabitacion,
            IdTipoHabitacion = idTipoHabitacion,
            CostoBase = costoBase,
            Estado = estado,
            CantidadPersonas = cantidadPersonas
        };
    }

    public void Update(
        int idHotel,
        int numeroHabitacion,
        int idTipoHabitacion,
        decimal costoBase,
        int estado,
        int cantidadPersonas)
    {
        if (idHotel <= 0)
            throw new DomainException("El hotel asignado no es válido.");
        if (idTipoHabitacion <= 0)
            throw new DomainException("El tipo de habitación no es válido.");
        if (numeroHabitacion <= 0)
            throw new DomainException("El número de habitación debe ser positivo.");
        if (costoBase < 0)
            throw new DomainException("El costo base no puede ser negativo.");
        if (cantidadPersonas <= 0)
            throw new DomainException("La cantidad de personas debe ser positiva.");

        IdHotel = idHotel;
        NumeroHabitacion = numeroHabitacion;
        IdTipoHabitacion = idTipoHabitacion;
        CostoBase = costoBase;
        Estado = estado;
        CantidadPersonas = cantidadPersonas;
    }
}
