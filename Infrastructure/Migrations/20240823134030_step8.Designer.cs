﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240823134030_step8")]
    partial class step8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Habitaciones.Habitacion", b =>
                {
                    b.Property<int>("IdHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHabitacion"));

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<decimal>("CostoBase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdHotel")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("NumeroHabitacion")
                        .HasColumnType("int");

                    b.HasKey("IdHabitacion");

                    b.HasIndex("IdHotel");

                    b.HasIndex("IdTipoHabitacion");

                    b.ToTable("Habitaciones");

                    b.HasData(
                        new
                        {
                            IdHabitacion = 1,
                            CantidadPersonas = 0,
                            CostoBase = 100000m,
                            Estado = 1,
                            IdHotel = 1,
                            IdTipoHabitacion = 1,
                            NumeroHabitacion = 101
                        },
                        new
                        {
                            IdHabitacion = 2,
                            CantidadPersonas = 0,
                            CostoBase = 150000m,
                            Estado = 1,
                            IdHotel = 1,
                            IdTipoHabitacion = 2,
                            NumeroHabitacion = 102
                        },
                        new
                        {
                            IdHabitacion = 3,
                            CantidadPersonas = 0,
                            CostoBase = 200000m,
                            Estado = 1,
                            IdHotel = 2,
                            IdTipoHabitacion = 2,
                            NumeroHabitacion = 201
                        },
                        new
                        {
                            IdHabitacion = 4,
                            CantidadPersonas = 0,
                            CostoBase = 300000m,
                            Estado = 1,
                            IdHotel = 2,
                            IdTipoHabitacion = 3,
                            NumeroHabitacion = 202
                        });
                });

            modelBuilder.Entity("Domain.Models.Hoteles.Hotel", b =>
                {
                    b.Property<int>("IdHotel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHotel"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Estado")
                        .HasColumnType("smallint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHotel");

                    b.ToTable("Hoteles");

                    b.HasData(
                        new
                        {
                            IdHotel = 1,
                            Codigo = "HTL001",
                            Estado = (short)1,
                            Nombre = "Hotel Central",
                            Ubicacion = "Ciudad Central"
                        },
                        new
                        {
                            IdHotel = 2,
                            Codigo = "HTL002",
                            Estado = (short)1,
                            Nombre = "Hotel Playa",
                            Ubicacion = "Costa del Sol"
                        },
                        new
                        {
                            IdHotel = 3,
                            Codigo = "HTL003",
                            Estado = (short)1,
                            Nombre = "Hotel Montaña",
                            Ubicacion = "Montañas del Norte"
                        });
                });

            modelBuilder.Entity("Domain.Models.HotelesPreferidos.HotelPreferido", b =>
                {
                    b.Property<int>("IdPreferido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPreferido"));

                    b.Property<int>("IdHotel")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPreferido");

                    b.HasIndex("IdHotel");

                    b.HasIndex("IdUsuario");

                    b.ToTable("HotelPreferido", (string)null);

                    b.HasData(
                        new
                        {
                            IdPreferido = 1,
                            IdHotel = 1,
                            IdUsuario = 1
                        },
                        new
                        {
                            IdPreferido = 2,
                            IdHotel = 2,
                            IdUsuario = 1
                        });
                });

            modelBuilder.Entity("Domain.Models.Reservas.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdHabitacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Domain.Models.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = "admin",
                            Nombre = "administrador"
                        },
                        new
                        {
                            Id = 2,
                            Codigo = "token",
                            Nombre = "token generate"
                        },
                        new
                        {
                            Id = 3,
                            Codigo = "vjh",
                            Nombre = "Viajero"
                        });
                });

            modelBuilder.Entity("Domain.Models.TiposHabitaciones.TiposHabitacion", b =>
                {
                    b.Property<int>("IdTipoHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoHabitacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoHabitacion");

                    b.ToTable("TiposHabitaciones");

                    b.HasData(
                        new
                        {
                            IdTipoHabitacion = 1,
                            Descripcion = "Habitación sencilla con cama sencilla",
                            Nombre = "Sencilla"
                        },
                        new
                        {
                            IdTipoHabitacion = 2,
                            Descripcion = "Habitación doble con cama doble",
                            Nombre = "Doble"
                        },
                        new
                        {
                            IdTipoHabitacion = 3,
                            Descripcion = "Habitación suite con cama doble y jacuzzi",
                            Nombre = "Suite"
                        });
                });

            modelBuilder.Entity("Domain.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Documento")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Quimbaya Orozco",
                            Documento = 94042671,
                            Email = "soulreavers214@gmail.com",
                            Genero = "Masculino",
                            IdRol = 2,
                            Nombre = "John Fredy",
                            Password = "$2a$11$BLPLcNgQZvehRDi0jaz1CuRYX.CZqIEHrWU3uYaHKrli/tjbpchL.",
                            Telefono = "3000000000",
                            TipoDocumento = "CC"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Quintero",
                            Documento = 94042673,
                            Email = "soulreavers214@gmail.com",
                            Genero = "Masculino",
                            IdRol = 2,
                            Nombre = "John alex",
                            Password = "$2a$11$BLPLcNgQZvehRDi0jaz1CuRYX.CZqIEHrWU3uYaHKrli/tjbpchL.",
                            Telefono = "3000000000",
                            TipoDocumento = "CC"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "correa Orozco",
                            Documento = 94042673,
                            Email = "soulreavers214@gmail.com",
                            Genero = "Femenino",
                            IdRol = 2,
                            Nombre = "Angie tatiana",
                            Password = "$2a$11$BLPLcNgQZvehRDi0jaz1CuRYX.CZqIEHrWU3uYaHKrli/tjbpchL.",
                            Telefono = "3000000000",
                            TipoDocumento = "CC"
                        });
                });

            modelBuilder.Entity("Domain.Models.Habitaciones.Habitacion", b =>
                {
                    b.HasOne("Domain.Models.Hoteles.Hotel", "Hotel")
                        .WithMany("Habitaciones")
                        .HasForeignKey("IdHotel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TiposHabitaciones.TiposHabitacion", "TiposHabitacion")
                        .WithMany("Habitaciones")
                        .HasForeignKey("IdTipoHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("TiposHabitacion");
                });

            modelBuilder.Entity("Domain.Models.HotelesPreferidos.HotelPreferido", b =>
                {
                    b.HasOne("Domain.Models.Hoteles.Hotel", "Hotel")
                        .WithMany("HotelesPreferidos")
                        .HasForeignKey("IdHotel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Users.User", "Usuario")
                        .WithMany("HotelesPreferidos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Reservas.Reserva", b =>
                {
                    b.HasOne("Domain.Models.Habitaciones.Habitacion", "Habitacion")
                        .WithMany("Reserva")
                        .HasForeignKey("IdHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Users.User", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habitacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Users.User", b =>
                {
                    b.HasOne("Domain.Models.Roles.Role", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Domain.Models.Habitaciones.Habitacion", b =>
                {
                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Domain.Models.Hoteles.Hotel", b =>
                {
                    b.Navigation("Habitaciones");

                    b.Navigation("HotelesPreferidos");
                });

            modelBuilder.Entity("Domain.Models.Roles.Role", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Domain.Models.TiposHabitaciones.TiposHabitacion", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("Domain.Models.Users.User", b =>
                {
                    b.Navigation("HotelesPreferidos");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
