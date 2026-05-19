using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Application.Common.Ports;

public interface ITipoHabitacionRepository
{
    Task<TipoHabitacion?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TipoHabitacion?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TipoHabitacion>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(TipoHabitacion tipoHabitacion, CancellationToken cancellationToken = default);
    void Update(TipoHabitacion tipoHabitacion);
    void Remove(TipoHabitacion tipoHabitacion);
}
