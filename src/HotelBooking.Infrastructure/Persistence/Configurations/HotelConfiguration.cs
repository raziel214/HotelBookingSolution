using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBooking.Domain.Hoteles;

namespace HotelBooking.Infrastructure.Persistence.Configurations;

public sealed class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hoteles");
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Nombre).IsRequired().HasMaxLength(150);
        builder.Property(h => h.Codigo).IsRequired().HasMaxLength(30);
        builder.Property(h => h.Ubicacion).IsRequired().HasMaxLength(200);
        builder.Property(h => h.Estado).IsRequired();

        builder.HasIndex(h => h.Codigo).IsUnique();
    }
}
