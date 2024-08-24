using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class step8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadPersonas",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 1,
                column: "CantidadPersonas",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 2,
                column: "CantidadPersonas",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 3,
                column: "CantidadPersonas",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 4,
                column: "CantidadPersonas",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadPersonas",
                table: "Habitaciones");
        }
    }
}
