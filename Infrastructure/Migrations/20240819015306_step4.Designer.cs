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
    [Migration("20240819015306_step4")]
    partial class step4
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
                        });
                });

            modelBuilder.Entity("Domain.Models.HotelesPreferidos.HotelPreferido", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<int>("HotelIdHotel")
                        .HasColumnType("int");

                    b.Property<int>("IdHotel")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("HotelIdHotel");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HotelPreferido");
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

                    b.Property<int>("HabitacionIdHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("HabitacionIdHabitacion");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reserva");
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
                            Codigo = "token_gen",
                            Nombre = "token generate"
                        });
                });

            modelBuilder.Entity("Domain.Models.TiposHabitaciones.TiposHabitacion", b =>
                {
                    b.Property<int>("IdTipoHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoHabitacion"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoHabitacion");

                    b.ToTable("TiposHabitaciones");
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

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
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
                            IdRol = 2,
                            Nombre = "John Fredy",
                            Password = "$2a$11$BLPLcNgQZvehRDi0jaz1CuRYX.CZqIEHrWU3uYaHKrli/tjbpchL.",
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
                        .WithMany()
                        .HasForeignKey("HotelIdHotel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Users.User", "Usuario")
                        .WithMany("HotelesPreferidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Reservas.Reserva", b =>
                {
                    b.HasOne("Domain.Models.Habitaciones.Habitacion", "Habitacion")
                        .WithMany()
                        .HasForeignKey("HabitacionIdHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Users.User", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
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

            modelBuilder.Entity("Domain.Models.Hoteles.Hotel", b =>
                {
                    b.Navigation("Habitaciones");
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
