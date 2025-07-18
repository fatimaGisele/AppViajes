using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViajeDestino_Destino_IdDestinoNavigationId",
                table: "ViajeDestino");

            migrationBuilder.DropForeignKey(
                name: "FK_ViajeDestino_PaqueteDeViajes_IdPaqueteNavigationId",
                table: "ViajeDestino");

            migrationBuilder.DropIndex(
                name: "IX_ViajeDestino_IdDestinoNavigationId",
                table: "ViajeDestino");

            migrationBuilder.DropIndex(
                name: "IX_ViajeDestino_IdPaqueteNavigationId",
                table: "ViajeDestino");

            migrationBuilder.DropColumn(
                name: "IdDestinoNavigationId",
                table: "ViajeDestino");

            migrationBuilder.DropColumn(
                name: "IdPaqueteNavigationId",
                table: "ViajeDestino");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDestino_IdDestino",
                table: "ViajeDestino",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDestino_IdPaqueteViaje",
                table: "ViajeDestino",
                column: "IdPaqueteViaje");

            migrationBuilder.AddForeignKey(
                name: "FK_ViajeDestino_Destino_IdDestino",
                table: "ViajeDestino",
                column: "IdDestino",
                principalTable: "Destino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ViajeDestino_PaqueteDeViajes_IdPaqueteViaje",
                table: "ViajeDestino",
                column: "IdPaqueteViaje",
                principalTable: "PaqueteDeViajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViajeDestino_Destino_IdDestino",
                table: "ViajeDestino");

            migrationBuilder.DropForeignKey(
                name: "FK_ViajeDestino_PaqueteDeViajes_IdPaqueteViaje",
                table: "ViajeDestino");

            migrationBuilder.DropIndex(
                name: "IX_ViajeDestino_IdDestino",
                table: "ViajeDestino");

            migrationBuilder.DropIndex(
                name: "IX_ViajeDestino_IdPaqueteViaje",
                table: "ViajeDestino");

            migrationBuilder.AddColumn<int>(
                name: "IdDestinoNavigationId",
                table: "ViajeDestino",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPaqueteNavigationId",
                table: "ViajeDestino",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDestino_IdDestinoNavigationId",
                table: "ViajeDestino",
                column: "IdDestinoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDestino_IdPaqueteNavigationId",
                table: "ViajeDestino",
                column: "IdPaqueteNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ViajeDestino_Destino_IdDestinoNavigationId",
                table: "ViajeDestino",
                column: "IdDestinoNavigationId",
                principalTable: "Destino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViajeDestino_PaqueteDeViajes_IdPaqueteNavigationId",
                table: "ViajeDestino",
                column: "IdPaqueteNavigationId",
                principalTable: "PaqueteDeViajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
