using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class step3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.IdHotel);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    IdTipoHabitacion = table.Column<int>(type: "int", nullable: false),
                    CostoBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.IdHabitacion);
                    table.ForeignKey(
                        name: "FK_Habitaciones_Hoteles_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hoteles",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelPreferido",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    HotelIdHotel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPreferido", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_HotelPreferido_Hoteles_HotelIdHotel",
                        column: x => x.HotelIdHotel,
                        principalTable: "Hoteles",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelPreferido_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdUsuario",
                table: "Reserva",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdHabitacion",
                table: "Reserva",
                column: "IdHabitacion");


            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "IdHotel", "Codigo", "Estado", "Nombre", "Ubicacion" },
                values: new object[,]
                {
                    { 1, "HTL001", (short)1, "Hotel Central", "Ciudad Central" },
                    { 2, "HTL002", (short)1, "Hotel Playa", "Costa del Sol" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_IdHotel",
                table: "Habitaciones",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelPreferido_HotelIdHotel",
                table: "HotelPreferido",
                column: "HotelIdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelPreferido_UsuarioId",
                table: "HotelPreferido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HabitacionIdHabitacion",
                table: "Reserva",
                column: "HabitacionIdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UsuarioId",
                table: "Reserva",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelPreferido");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Hoteles");
        }
    }
}
