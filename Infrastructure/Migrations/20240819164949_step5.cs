using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class step5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelPreferido",
                columns: table => new
                {
                    IdPreferido = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdHotel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPreferido", x => x.IdPreferido);
                    table.ForeignKey(
                        name: "FK_HotelPreferido_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelPreferido_Hoteles_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hoteles",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelPreferido_IdUsuario",
                table: "HotelPreferido",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_HotelPreferido_IdHotel",
                table: "HotelPreferido",
                column: "IdHotel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelPreferido");
        }
    }
}
