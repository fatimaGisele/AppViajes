using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCantidadDiasToViajeDestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadDias",
                table: "ViajeDestino",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadDias",
                table: "ViajeDestino");
        }
    }
}
