using HotelBooking.Domain.Common;
using HotelBooking.Domain.Users;

namespace HotelBooking.Domain.Roles;

public class Role : Entity<int>
{
    public string Nombre { get; private set; } = default!;
    public string Codigo { get; private set; } = default!;

    public ICollection<User> Usuarios { get; private set; } = new List<User>();

    private Role() { }

    public static Role Create(string nombre, string codigo)
    {
        ValidateRequired(nombre, nameof(nombre), 100);
        ValidateRequired(codigo, nameof(codigo), 50);

        return new Role
        {
            Nombre = nombre.Trim(),
            Codigo = codigo.Trim()
        };
    }

    public void Update(string nombre, string codigo)
    {
        ValidateRequired(nombre, nameof(nombre), 100);
        ValidateRequired(codigo, nameof(codigo), 50);

        Nombre = nombre.Trim();
        Codigo = codigo.Trim();
    }

    private static void ValidateRequired(string value, string field, int max)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"El campo '{field}' es obligatorio.");
        if (value.Length > max)
            throw new DomainException($"El campo '{field}' supera los {max} caracteres.");
    }
}
