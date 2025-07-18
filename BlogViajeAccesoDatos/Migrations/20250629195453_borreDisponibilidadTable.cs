using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class borreDisponibilidadTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilidad");

            migrationBuilder.AddColumn<int>(
                name: "Disponibilidad",
                table: "PaqueteDeViajes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilidad",
                table: "PaqueteDeViajes");

            migrationBuilder.CreateTable(
                name: "Disponibilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaqueteViajeId = table.Column<int>(type: "int", nullable: false),
                    LugaresDisponibles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disponibilidad_PaqueteDeViajes_IdPaqueteViajeId",
                        column: x => x.IdPaqueteViajeId,
                        principalTable: "PaqueteDeViajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidad_IdPaqueteViajeId",
                table: "Disponibilidad",
                column: "IdPaqueteViajeId");
        }
    }
}
