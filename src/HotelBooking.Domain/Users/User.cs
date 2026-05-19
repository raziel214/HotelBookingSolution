using HotelBooking.Domain.Common;
using HotelBooking.Domain.HotelesPreferidos;
using HotelBooking.Domain.Reservas;
using HotelBooking.Domain.Roles;

namespace HotelBooking.Domain.Users;

public class User : Entity<int>
{
    public string Nombre { get; private set; } = default!;
    public string Apellido { get; private set; } = default!;
    public int Documento { get; private set; }
    public string TipoDocumento { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public int IdRol { get; private set; }
    public string Genero { get; private set; } = default!;
    public string Telefono { get; private set; } = default!;

    public Role? Rol { get; private set; }
    public ICollection<Reserva> Reservas { get; private set; } = new List<Reserva>();
    public ICollection<HotelPreferido> HotelesPreferidos { get; private set; } = new List<HotelPreferido>();

    private User() { }

    public static User Create(
        string nombre,
        string apellido,
        int documento,
        string tipoDocumento,
        string email,
        string passwordHash,
        int idRol,
        string genero,
        string telefono)
    {
        ValidateRequired(nombre, nameof(nombre), 100);
        ValidateRequired(apellido, nameof(apellido), 100);
        ValidateRequired(tipoDocumento, nameof(tipoDocumento), 20);
        ValidateRequired(email, nameof(email), 200);
        ValidateRequired(passwordHash, nameof(passwordHash), 255);
        ValidateRequired(genero, nameof(genero), 20);
        ValidateRequired(telefono, nameof(telefono), 30);

        if (documento <= 0)
            throw new DomainException("El documento debe ser positivo.");
        if (idRol <= 0)
            throw new DomainException("El rol asignado no es válido.");

        return new User
        {
            Nombre = nombre.Trim(),
            Apellido = apellido.Trim(),
            Documento = documento,
            TipoDocumento = tipoDocumento.Trim(),
            Email = email.Trim(),
            PasswordHash = passwordHash,
            IdRol = idRol,
            Genero = genero.Trim(),
            Telefono = telefono.Trim()
        };
    }

    public void Update(
        string nombre,
        string apellido,
        int documento,
        string tipoDocumento,
        string email,
        int idRol,
        string genero,
        string telefono)
    {
        ValidateRequired(nombre, nameof(nombre), 100);
        ValidateRequired(apellido, nameof(apellido), 100);
        ValidateRequired(tipoDocumento, nameof(tipoDocumento), 20);
        ValidateRequired(email, nameof(email), 200);
        ValidateRequired(genero, nameof(genero), 20);
        ValidateRequired(telefono, nameof(telefono), 30);

        if (documento <= 0)
            throw new DomainException("El documento debe ser positivo.");
        if (idRol <= 0)
            throw new DomainException("El rol asignado no es válido.");

        Nombre = nombre.Trim();
        Apellido = apellido.Trim();
        Documento = documento;
        TipoDocumento = tipoDocumento.Trim();
        Email = email.Trim();
        IdRol = idRol;
        Genero = genero.Trim();
        Telefono = telefono.Trim();
    }

    public void ChangePassword(string newPasswordHash)
    {
        ValidateRequired(newPasswordHash, nameof(newPasswordHash), 255);
        PasswordHash = newPasswordHash;
    }

    private static void ValidateRequired(string value, string field, int max)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"El campo '{field}' es obligatorio.");
        if (value.Length > max)
            throw new DomainException($"El campo '{field}' supera los {max} caracteres.");
    }
}
