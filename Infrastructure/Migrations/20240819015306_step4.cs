using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class step4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla TiposHabitaciones
            migrationBuilder.CreateTable(
                name: "TiposHabitaciones",
                columns: table => new
                {
                    IdTipoHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHabitaciones", x => x.IdTipoHabitacion);
                });



            // Crear el índice para la relación
            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_IdTipoHabitacion",
                table: "Habitaciones",
                column: "IdTipoHabitacion");

            // Establecer la clave foránea entre Habitaciones y TiposHabitaciones
            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_TiposHabitaciones_IdTipoHabitacion",
                table: "Habitaciones",
                column: "IdTipoHabitacion",
                principalTable: "TiposHabitaciones",
                principalColumn: "IdTipoHabitacion",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar la relación y la columna si es necesario
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_TiposHabitaciones_IdTipoHabitacion",
                table: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_IdTipoHabitacion",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "IdTipoHabitacion",
                table: "Habitaciones");

            // Eliminar la tabla TiposHabitaciones
            migrationBuilder.DropTable(
                name: "TiposHabitaciones");
        }

    }
}
