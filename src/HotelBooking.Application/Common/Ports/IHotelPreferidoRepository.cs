using HotelBooking.Domain.HotelesPreferidos;

namespace HotelBooking.Application.Common.Ports;

public interface IHotelPreferidoRepository
{
    Task<HotelPreferido?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<HotelPreferido?> GetByUsuarioAndHotelAsync(int idUsuario, int idHotel, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<HotelPreferido>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<HotelPreferido>> GetByUsuarioAsync(int idUsuario, CancellationToken cancellationToken = default);
    Task AddAsync(HotelPreferido hotelPreferido, CancellationToken cancellationToken = default);
    void Remove(HotelPreferido hotelPreferido);
}
