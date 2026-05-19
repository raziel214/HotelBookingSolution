using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Roles;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public sealed class RoleRepository(AppDbContext context) : IRoleRepository
{
    public Task<Role?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public Task<Role?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default) =>
        context.Roles.FirstOrDefaultAsync(r => r.Nombre == nombre, cancellationToken);

    public async Task<IReadOnlyList<Role>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.Roles.AsNoTracking().ToListAsync(cancellationToken);

    public async Task AddAsync(Role role, CancellationToken cancellationToken = default) =>
        await context.Roles.AddAsync(role, cancellationToken);

    public void Update(Role role) => context.Roles.Update(role);

    public void Remove(Role role) => context.Roles.Remove(role);
}
