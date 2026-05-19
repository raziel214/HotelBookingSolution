using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Application.Common.Ports;

public interface IHotelRepository
{
    Task<Hotel?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Hotel?> GetByCodigoAsync(string codigo, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Hotel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Hotel>> GetByEstadoAsync(short estado, CancellationToken cancellationToken = default);
    Task AddAsync(Hotel hotel, CancellationToken cancellationToken = default);
    void Update(Hotel hotel);
    void Remove(Hotel hotel);
}
