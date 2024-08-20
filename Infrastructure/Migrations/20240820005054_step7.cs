using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    public partial class step7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminación de las claves foráneas de las tablas
            migrationBuilder.DropForeignKey(
                name: "FK_HotelPreferido_Hoteles_IdHotel",
                table: "HotelPreferido");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelPreferido_Usuarios_IdUsuario",
                table: "HotelPreferido");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas");

            // Eliminación de los índices
            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas");

            // Eliminación de la clave primaria de la tabla HotelPreferido
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelPreferido",
                table: "HotelPreferido");

            // Cambio de nombre de la tabla si es necesario
            migrationBuilder.RenameTable(
                name: "HotelPreferido",
                newName: "HotelPreferido");

            migrationBuilder.RenameIndex(
                name: "IX_HotelPreferido_IdUsuario",
                table: "HotelPreferido",
                newName: "IX_HotelPreferido_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_HotelPreferido_IdHotel",
                table: "HotelPreferido",
                newName: "IX_HotelPreferido_IdHotel");

            // Agregar nuevas columnas en la tabla Usuarios
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // Reagregar la clave primaria de la tabla HotelPreferido
            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelPreferido",
                table: "HotelPreferido",
                column: "IdPreferido");

            // Actualizar datos existentes en la tabla Roles
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Codigo",
                value: "token");

            // Insertar nuevos datos en las tablas
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Codigo", "Nombre" },
                values: new object[] { 3, "vjh", "Viajero" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Genero", "Telefono" },
                values: new object[] { "Masculino", "3000000000" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Documento", "Email", "Genero", "IdRol", "Nombre", "Password", "Telefono", "TipoDocumento" },
                values: new object[,]
                {
                    { 2, "Quintero", 94042673, "soulreavers214@gmail.com", "Masculino", 2, "John alex", "$2a$11$BLPLcNgQZvehRDi0jaz1CuRYX.CZqIEHrWU3uYaHKrli/tjbpchL.", "3000000000", "CC" },
                    { 3, "correa Orozco", 94042673, "soulreavers214@gmail.com", "Femenino", 2, "Angie tatiana", "$2a$11$BLPLcNgQZvehRDi0jaz1CuRYX.CZqIEHrWU3uYaHKrli/tjbpchL.", "3000000000", "CC" }
                });

            // Crear nuevamente los índices en la tabla Reservas
            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHabitacion",
                table: "Reservas",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas",
                column: "IdUsuario");

            // Reagregar las llaves foráneas en las tablas
            migrationBuilder.AddForeignKey(
                name: "FK_HotelPreferido_Hoteles_IdHotel",
                table: "HotelPreferido",
                column: "IdHotel",
                principalTable: "Hoteles",
                principalColumn: "IdHotel",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPreferido_Usuarios_IdUsuario",
                table: "HotelPreferido",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion",
                table: "Reservas",
                column: "IdHabitacion",
                principalTable: "Habitaciones",
                principalColumn: "IdHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelPreferido_Hoteles_IdHotel",
                table: "HotelPreferido");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelPreferido_Usuarios_IdUsuario",
                table: "HotelPreferido");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelPreferido",
                table: "HotelPreferido");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "HotelPreferido",
                newName: "HotelPreferido");

            migrationBuilder.RenameIndex(
                name: "IX_HotelPreferido_IdUsuario",
                table: "HotelPreferido",
                newName: "IX_HotelPreferido_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_HotelPreferido_IdHotel",
                table: "HotelPreferido",
                newName: "IX_HotelPreferido_IdHotel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelPreferido",
                table: "HotelPreferido",
                column: "IdPreferido");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Codigo",
                value: "token_gen");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPreferido_Hoteles_IdHotel",
                table: "HotelPreferido",
                column: "IdHotel",
                principalTable: "Hoteles",
                principalColumn: "IdHotel",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPreferido_Usuarios_IdUsuario",
                table: "HotelPreferido",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
