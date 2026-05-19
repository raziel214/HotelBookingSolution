using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Reservas;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public sealed class ReservaRepository(AppDbContext context) : IReservaRepository
{
    public Task<Reserva?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.Reservas.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Reserva>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.Reservas.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Reserva>> GetByUsuarioAsync(int idUsuario, CancellationToken cancellationToken = default) =>
        await context.Reservas.AsNoTracking().Where(r => r.IdUsuario == idUsuario).ToListAsync(cancellationToken);

    public async Task AddAsync(Reserva reserva, CancellationToken cancellationToken = default) =>
        await context.Reservas.AddAsync(reserva, cancellationToken);

    public void Update(Reserva reserva) => context.Reservas.Update(reserva);
}
