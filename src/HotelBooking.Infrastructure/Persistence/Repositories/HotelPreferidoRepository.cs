using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.HotelesPreferidos;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public sealed class HotelPreferidoRepository(AppDbContext context) : IHotelPreferidoRepository
{
    public Task<HotelPreferido?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.HotelesPreferidos.FirstOrDefaultAsync(hp => hp.Id == id, cancellationToken);

    public Task<HotelPreferido?> GetByUsuarioAndHotelAsync(int idUsuario, int idHotel, CancellationToken cancellationToken = default) =>
        context.HotelesPreferidos.FirstOrDefaultAsync(hp => hp.IdUsuario == idUsuario && hp.IdHotel == idHotel, cancellationToken);

    public async Task<IReadOnlyList<HotelPreferido>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.HotelesPreferidos.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<HotelPreferido>> GetByUsuarioAsync(int idUsuario, CancellationToken cancellationToken = default) =>
        await context.HotelesPreferidos.AsNoTracking().Where(hp => hp.IdUsuario == idUsuario).ToListAsync(cancellationToken);

    public async Task AddAsync(HotelPreferido hotelPreferido, CancellationToken cancellationToken = default) =>
        await context.HotelesPreferidos.AddAsync(hotelPreferido, cancellationToken);

    public void Remove(HotelPreferido hotelPreferido) => context.HotelesPreferidos.Remove(hotelPreferido);
}
