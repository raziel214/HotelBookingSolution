using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBooking.Domain.HotelesPreferidos;

namespace HotelBooking.Infrastructure.Persistence.Configurations;

public sealed class HotelPreferidoConfiguration : IEntityTypeConfiguration<HotelPreferido>
{
    public void Configure(EntityTypeBuilder<HotelPreferido> builder)
    {
        builder.ToTable("HotelesPreferidos");
        builder.HasKey(hp => hp.Id);

        builder.Property(hp => hp.IdUsuario).IsRequired();
        builder.Property(hp => hp.IdHotel).IsRequired();

        builder.HasOne(hp => hp.Usuario)
            .WithMany(u => u.HotelesPreferidos)
            .HasForeignKey(hp => hp.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(hp => hp.Hotel)
            .WithMany(h => h.HotelesPreferidos)
            .HasForeignKey(hp => hp.IdHotel)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(hp => new { hp.IdUsuario, hp.IdHotel }).IsUnique();
    }
}
