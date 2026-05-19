using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBooking.Domain.Roles;

namespace HotelBooking.Infrastructure.Persistence.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Nombre).IsRequired().HasMaxLength(100);
        builder.Property(r => r.Codigo).IsRequired().HasMaxLength(50);

        builder.HasIndex(r => r.Codigo).IsUnique();
    }
}
