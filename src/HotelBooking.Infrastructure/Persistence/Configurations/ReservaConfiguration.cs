using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBooking.Domain.Reservas;

namespace HotelBooking.Infrastructure.Persistence.Configurations;

public sealed class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ToTable("Reservas");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.IdUsuario).IsRequired();
        builder.Property(r => r.IdHabitacion).IsRequired();
        builder.Property(r => r.FechaInicio).IsRequired();
        builder.Property(r => r.FechaFin).IsRequired();
        builder.Property(r => r.Estado).HasConversion<int>().IsRequired();
        builder.Property(r => r.FechaCreacion).IsRequired();
        builder.Property(r => r.FechaCancelacion);

        builder.HasOne(r => r.Usuario)
            .WithMany(u => u.Reservas)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Habitacion)
            .WithMany(h => h.Reservas)
            .HasForeignKey(r => r.IdHabitacion)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
