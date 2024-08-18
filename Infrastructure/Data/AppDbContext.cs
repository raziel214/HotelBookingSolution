using Domain.Models.Habitaciones;
using Domain.Models.Hoteles;
using Domain.Models.Roles;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación uno a muchos entre Usuario y Rol
            modelBuilder.Entity<User>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol);
            // Configurar la relación uno a muchos entre Hotel y habitación
            modelBuilder.Entity<Habitacion>()
               .HasOne(h => h.Hotel)
               .WithMany(h => h.Habitaciones)
               .HasForeignKey(h => h.IdHotel);

            modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Nombre = "administrador", Codigo = "admin" },
            new Role { Id = 2, Nombre = "token generate", Codigo = "token_gen" }   
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nombre = "John Fredy",
                    Apellido = "Quimbaya Orozco",
                    Documento = 94042671,
                    TipoDocumento = "CC",
                    Email = "soulreavers214@gmail.com",
                    Password = "$2a$11$BLPLcNgQZvehRDi0jaz1CuRYX.CZqIEHrWU3uYaHKrli/tjbpchL.",//  
                    IdRol = 2 // Asegúrate de que este es el Id del rol "token"
                }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    IdHotel = 1,
                    Nombre = "Hotel Central",
                    Codigo = "HTL001",
                    Ubicacion = "Ciudad Central",
                    Estado = 1
                },
                new Hotel
                {
                    IdHotel = 2,
                    Nombre = "Hotel Playa",
                    Codigo = "HTL002",
                    Ubicacion = "Costa del Sol",
                    Estado = 1
                }
             );

        }
    }
}
