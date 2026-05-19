using HotelBooking.Domain.Common;
using HotelBooking.Domain.Habitaciones;
using HotelBooking.Domain.HotelesPreferidos;

namespace HotelBooking.Domain.Hoteles;

public class Hotel : Entity<int>
{
    public string Nombre { get; private set; } = default!;
    public string Codigo { get; private set; } = default!;
    public string Ubicacion { get; private set; } = default!;
    public short Estado { get; private set; }

    public ICollection<Habitacion> Habitaciones { get; private set; } = new List<Habitacion>();
    public ICollection<HotelPreferido> HotelesPreferidos { get; private set; } = new List<HotelPreferido>();

    private Hotel() { }

    public static Hotel Create(string nombre, string codigo, string ubicacion, short estado)
    {
        ValidateRequired(nombre, nameof(nombre), 150);
        ValidateRequired(codigo, nameof(codigo), 30);
        ValidateRequired(ubicacion, nameof(ubicacion), 200);

        return new Hotel
        {
            Nombre = nombre.Trim(),
            Codigo = codigo.Trim(),
            Ubicacion = ubicacion.Trim(),
            Estado = estado
        };
    }

    public void Update(string nombre, string codigo, string ubicacion, short estado)
    {
        ValidateRequired(nombre, nameof(nombre), 150);
        ValidateRequired(codigo, nameof(codigo), 30);
        ValidateRequired(ubicacion, nameof(ubicacion), 200);

        Nombre = nombre.Trim();
        Codigo = codigo.Trim();
        Ubicacion = ubicacion.Trim();
        Estado = estado;
    }

    private static void ValidateRequired(string value, string field, int max)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"El campo '{field}' es obligatorio.");
        if (value.Length > max)
            throw new DomainException($"El campo '{field}' supera los {max} caracteres.");
    }
}
