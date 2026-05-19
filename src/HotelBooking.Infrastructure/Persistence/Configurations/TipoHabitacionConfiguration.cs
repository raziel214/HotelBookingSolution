using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBooking.Domain.TiposHabitaciones;

namespace HotelBooking.Infrastructure.Persistence.Configurations;

public sealed class TipoHabitacionConfiguration : IEntityTypeConfiguration<TipoHabitacion>
{
    public void Configure(EntityTypeBuilder<TipoHabitacion> builder)
    {
        builder.ToTable("TiposHabitaciones");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nombre).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Descripcion).IsRequired().HasMaxLength(500);
    }
}
