using HotelBooking.Domain.Reservas;

namespace HotelBooking.Application.Common.Ports;

public interface IReservaRepository
{
    Task<Reserva?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Reserva>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Reserva>> GetByUsuarioAsync(int idUsuario, CancellationToken cancellationToken = default);
    Task AddAsync(Reserva reserva, CancellationToken cancellationToken = default);
    void Update(Reserva reserva);
}
