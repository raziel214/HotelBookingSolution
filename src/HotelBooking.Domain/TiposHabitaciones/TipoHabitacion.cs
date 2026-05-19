using HotelBooking.Domain.Common;
using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Domain.TiposHabitaciones;

public class TipoHabitacion : Entity<int>
{
    public string Nombre { get; private set; } = default!;
    public string Descripcion { get; private set; } = default!;

    public ICollection<Habitacion> Habitaciones { get; private set; } = new List<Habitacion>();

    private TipoHabitacion() { }

    public static TipoHabitacion Create(string nombre, string descripcion)
    {
        ValidateRequired(nombre, nameof(nombre), 100);
        ValidateRequired(descripcion, nameof(descripcion), 500);

        return new TipoHabitacion
        {
            Nombre = nombre.Trim(),
            Descripcion = descripcion.Trim()
        };
    }

    public void Update(string nombre, string descripcion)
    {
        ValidateRequired(nombre, nameof(nombre), 100);
        ValidateRequired(descripcion, nameof(descripcion), 500);

        Nombre = nombre.Trim();
        Descripcion = descripcion.Trim();
    }

    private static void ValidateRequired(string value, string field, int max)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"El campo '{field}' es obligatorio.");
        if (value.Length > max)
            throw new DomainException($"El campo '{field}' supera los {max} caracteres.");
    }
}
