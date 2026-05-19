using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Application.Common.Ports;

public interface IHabitacionRepository
{
    Task<Habitacion?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Habitacion>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Habitacion>> GetByHotelAsync(int idHotel, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Habitacion>> GetByTipoAsync(int idTipo, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Habitacion>> GetByEstadoAsync(int estado, CancellationToken cancellationToken = default);
    Task<Habitacion?> GetByHotelAndNumeroAsync(int idHotel, int numero, CancellationToken cancellationToken = default);
    Task AddAsync(Habitacion habitacion, CancellationToken cancellationToken = default);
    void Update(Habitacion habitacion);
    void Remove(Habitacion habitacion);
}
