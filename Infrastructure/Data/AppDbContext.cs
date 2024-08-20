using Domain.Models.Habitaciones;
using Domain.Models.Hoteles;
using Domain.Models.HotelesPreferidos;
using Domain.Models.Reservas;
using Domain.Models.Roles;
using Domain.Models.TiposHabitaciones;
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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<TiposHabitacion> TiposHabitaciones { get; set; }
        public DbSet<HotelPreferido> HotelesPreferidos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación uno a muchos entre Usuario y Rol
            modelBuilder.Entity<User>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol);


            // Configurar la relación uno a muchos entre Hotel y Habitación
            modelBuilder.Entity<Habitacion>()
               .HasOne(h => h.Hotel)
               .WithMany(h => h.Habitaciones)
               .HasForeignKey(h => h.IdHotel);

            // Configurar la relación uno a muchos entre TipoHabitacion y Habitacion
            modelBuilder.Entity<Habitacion>()
               .HasOne(h => h.TiposHabitacion)
               .WithMany(h => h.Habitaciones)
               .HasForeignKey(h => h.IdTipoHabitacion);

            // Configurar la preción de la tabla
            modelBuilder.Entity<Habitacion>()
                .Property(h => h.CostoBase)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<HotelPreferido>(entity =>
            {
                entity.ToTable("HotelPreferido");  // Asegúrate de usar el nombre correcto de la tabla en la base de datos
                entity.HasKey(hp => hp.IdPreferido);

                entity.HasOne(hp => hp.Usuario)
                      .WithMany(u => u.HotelesPreferidos)
                      .HasForeignKey(hp => hp.IdUsuario)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(hp => hp.Hotel)
                      .WithMany(h => h.HotelesPreferidos)
                      .HasForeignKey(hp => hp.IdHotel)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Reserva>(entity =>
            {
                // Configuración de la clave primaria
                entity.HasKey(r => r.IdReserva);

                // Configuración de la relación con Usuario
                entity.HasOne(r => r.Usuario)
                      .WithMany(u => u.Reservas)  // 'Reservas' debe ser una colección en 'User'
                      .HasForeignKey(r => r.IdUsuario)
                      .OnDelete(DeleteBehavior.Cascade);

                // Configuración de la relación con Habitacion
                entity.HasOne(r => r.Habitacion)
                      .WithMany(h => h.Reserva)  // 'Reservas' debe ser una colección en 'Habitacion'
                      .HasForeignKey(r => r.IdHabitacion)
                      .OnDelete(DeleteBehavior.Cascade);
            });

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
                    Genero="Masculino",
                    Telefono="3000000000"
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
                },
                new Hotel
                {
                    IdHotel = 3,
                    Nombre = "Hotel Montaña",
                    Codigo = "HTL003",
                    Ubicacion = "Montañas del Norte",
                    Estado = 1
                }
            );

            modelBuilder.Entity<TiposHabitacion>().HasData(
                new TiposHabitacion
                {
                    IdTipoHabitacion = 1,
                    Nombre = "Sencilla",
                    Descripcion = "Habitación sencilla con cama sencilla",
                },
                new TiposHabitacion
                {
                    IdTipoHabitacion = 2,
                    Nombre = "Doble",
                    Descripcion = "Habitación doble con cama doble",
                },
                new TiposHabitacion
                {
                    IdTipoHabitacion = 3,
                    Nombre = "Suite",
                    Descripcion = "Habitación suite con cama doble y jacuzzi",
                }
            );

            modelBuilder.Entity<Habitacion>().HasData(
                new Habitacion
                {
                    IdHabitacion = 1,
                    IdHotel = 1,
                    NumeroHabitacion = 101,
                    IdTipoHabitacion = 1,
                    CostoBase = 100000,
                    Estado = 1
                },
                new Habitacion
                {
                    IdHabitacion = 2,
                    IdHotel = 1,
                    NumeroHabitacion = 102,
                    IdTipoHabitacion = 2,
                    CostoBase = 150000,
                    Estado = 1
                },
                new Habitacion
                {
                    IdHabitacion = 3,
                    IdHotel = 2,
                    NumeroHabitacion = 201,
                    IdTipoHabitacion = 2,
                    CostoBase = 200000,
                    Estado = 1
                },
                new Habitacion
                {
                    IdHabitacion = 4,
                    IdHotel = 2,
                    NumeroHabitacion = 202,
                    IdTipoHabitacion = 3,
                    CostoBase = 300000,
                    Estado = 1
                }
            );

            modelBuilder.Entity<HotelPreferido>().HasData(
                new HotelPreferido
                {
                    IdPreferido = 1,
                    IdUsuario = 1,
                    IdHotel = 1
                },
                new HotelPreferido
                {
                    IdPreferido = 2,
                    IdUsuario = 1,
                    IdHotel = 2
                }
            );
        }
    }
}
