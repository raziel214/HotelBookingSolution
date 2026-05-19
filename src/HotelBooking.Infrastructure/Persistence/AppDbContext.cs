using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain.Habitaciones;
using HotelBooking.Domain.Hoteles;
using HotelBooking.Domain.HotelesPreferidos;
using HotelBooking.Domain.Reservas;
using HotelBooking.Domain.Roles;
using HotelBooking.Domain.TiposHabitaciones;
using HotelBooking.Domain.Users;

namespace HotelBooking.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Usuarios => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Hotel> Hoteles => Set<Hotel>();
    public DbSet<Habitacion> Habitaciones => Set<Habitacion>();
    public DbSet<TipoHabitacion> TiposHabitaciones => Set<TipoHabitacion>();
    public DbSet<HotelPreferido> HotelesPreferidos => Set<HotelPreferido>();
    public DbSet<Reserva> Reservas => Set<Reserva>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
