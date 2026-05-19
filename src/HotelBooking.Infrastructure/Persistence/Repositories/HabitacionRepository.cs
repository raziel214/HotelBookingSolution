using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public sealed class HabitacionRepository(AppDbContext context) : IHabitacionRepository
{
    public Task<Habitacion?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.Habitaciones.FirstOrDefaultAsync(h => h.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Habitacion>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.Habitaciones.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Habitacion>> GetByHotelAsync(int idHotel, CancellationToken cancellationToken = default) =>
        await context.Habitaciones.AsNoTracking().Where(h => h.IdHotel == idHotel).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Habitacion>> GetByTipoAsync(int idTipo, CancellationToken cancellationToken = default) =>
        await context.Habitaciones.AsNoTracking().Where(h => h.IdTipoHabitacion == idTipo).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Habitacion>> GetByEstadoAsync(int estado, CancellationToken cancellationToken = default) =>
        await context.Habitaciones.AsNoTracking().Where(h => h.Estado == estado).ToListAsync(cancellationToken);

    public Task<Habitacion?> GetByHotelAndNumeroAsync(int idHotel, int numero, CancellationToken cancellationToken = default) =>
        context.Habitaciones.FirstOrDefaultAsync(h => h.IdHotel == idHotel && h.NumeroHabitacion == numero, cancellationToken);

    public async Task AddAsync(Habitacion habitacion, CancellationToken cancellationToken = default) =>
        await context.Habitaciones.AddAsync(habitacion, cancellationToken);

    public void Update(Habitacion habitacion) => context.Habitaciones.Update(habitacion);

    public void Remove(Habitacion habitacion) => context.Habitaciones.Remove(habitacion);
}
