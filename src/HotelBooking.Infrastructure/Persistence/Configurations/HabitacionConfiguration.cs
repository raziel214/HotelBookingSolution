using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBooking.Domain.Habitaciones;

namespace HotelBooking.Infrastructure.Persistence.Configurations;

public sealed class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
{
    public void Configure(EntityTypeBuilder<Habitacion> builder)
    {
        builder.ToTable("Habitaciones");
        builder.HasKey(h => h.Id);

        builder.Property(h => h.IdHotel).IsRequired();
        builder.Property(h => h.NumeroHabitacion).IsRequired();
        builder.Property(h => h.IdTipoHabitacion).IsRequired();
        builder.Property(h => h.CostoBase).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(h => h.Estado).IsRequired();
        builder.Property(h => h.CantidadPersonas).IsRequired();

        builder.HasOne(h => h.Hotel)
            .WithMany(ho => ho.Habitaciones)
            .HasForeignKey(h => h.IdHotel)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(h => h.TipoHabitacion)
            .WithMany(t => t.Habitaciones)
            .HasForeignKey(h => h.IdTipoHabitacion)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(h => new { h.IdHotel, h.NumeroHabitacion }).IsUnique();
    }
}
