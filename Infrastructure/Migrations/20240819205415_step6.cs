using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class step6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {




            migrationBuilder.CreateTable(
         name: "Reservas",
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
             table.PrimaryKey("PK_Reservas", x => x.IdReserva);
             table.ForeignKey(
                 name: "FK_Reservas_Habitaciones_IdHabitacion",
                 column: x => x.IdHabitacion,
                 principalTable: "Habitaciones",
                 principalColumn: "IdHabitacion",
                 onDelete: ReferentialAction.Cascade);
             table.ForeignKey(
                 name: "FK_Reservas_Usuarios_IdUsuario",
                 column: x => x.IdUsuario,
                 principalTable: "Usuarios",
                 principalColumn: "Id",
                 onDelete: ReferentialAction.Cascade);
         });

           

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHabitacion",
                table: "Reservas",
                column: "IdHabitacion");
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revertir los cambios hechos en "Up"
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "Reserva");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reserva",
                newName: "IX_Reserva_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_HabitacionIdHabitacion",
                table: "Reserva",
                newName: "IX_Reserva_HabitacionIdHabitacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva",
                column: "IdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Habitaciones_IdHabitacion",
                table: "Reserva",
                column: "IdHabitacion",
                principalTable: "Habitaciones",
                principalColumn: "IdHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Usuarios_IdUsuario",
                table: "Reserva",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
