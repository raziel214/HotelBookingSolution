using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public sealed class HotelRepository(AppDbContext context) : IHotelRepository
{
    public Task<Hotel?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.Hoteles.FirstOrDefaultAsync(h => h.Id == id, cancellationToken);

    public Task<Hotel?> GetByCodigoAsync(string codigo, CancellationToken cancellationToken = default) =>
        context.Hoteles.FirstOrDefaultAsync(h => h.Codigo == codigo, cancellationToken);

    public async Task<IReadOnlyList<Hotel>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.Hoteles.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Hotel>> GetByEstadoAsync(short estado, CancellationToken cancellationToken = default) =>
        await context.Hoteles.AsNoTracking().Where(h => h.Estado == estado).ToListAsync(cancellationToken);

    public async Task AddAsync(Hotel hotel, CancellationToken cancellationToken = default) =>
        await context.Hoteles.AddAsync(hotel, cancellationToken);

    public void Update(Hotel hotel) => context.Hoteles.Update(hotel);

    public void Remove(Hotel hotel) => context.Hoteles.Remove(hotel);
}
