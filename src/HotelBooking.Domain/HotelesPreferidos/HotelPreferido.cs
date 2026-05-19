using HotelBooking.Domain.Common;
using HotelBooking.Domain.Hoteles;
using HotelBooking.Domain.Users;

namespace HotelBooking.Domain.HotelesPreferidos;

public class HotelPreferido : Entity<int>
{
    public int IdUsuario { get; private set; }
    public int IdHotel { get; private set; }

    public User? Usuario { get; private set; }
    public Hotel? Hotel { get; private set; }

    private HotelPreferido() { }

    public static HotelPreferido Create(int idUsuario, int idHotel)
    {
        if (idUsuario <= 0)
            throw new DomainException("El usuario asignado no es válido.");
        if (idHotel <= 0)
            throw new DomainException("El hotel asignado no es válido.");

        return new HotelPreferido
        {
            IdUsuario = idUsuario,
            IdHotel = idHotel
        };
    }
}
