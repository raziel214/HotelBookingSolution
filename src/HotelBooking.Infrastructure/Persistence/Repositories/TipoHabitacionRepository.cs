using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Infrastructure.Persistence.Repositories;

public sealed class TipoHabitacionRepository(AppDbContext context) : ITipoHabitacionRepository
{
    public Task<TipoHabitacion?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        context.TiposHabitaciones.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public Task<TipoHabitacion?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default) =>
        context.TiposHabitaciones.FirstOrDefaultAsync(t => t.Nombre == nombre, cancellationToken);

    public async Task<IReadOnlyList<TipoHabitacion>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.TiposHabitaciones.AsNoTracking().ToListAsync(cancellationToken);

    public async Task AddAsync(TipoHabitacion tipoHabitacion, CancellationToken cancellationToken = default) =>
        await context.TiposHabitaciones.AddAsync(tipoHabitacion, cancellationToken);

    public void Update(TipoHabitacion tipoHabitacion) => context.TiposHabitaciones.Update(tipoHabitacion);

    public void Remove(TipoHabitacion tipoHabitacion) => context.TiposHabitaciones.Remove(tipoHabitacion);
}
