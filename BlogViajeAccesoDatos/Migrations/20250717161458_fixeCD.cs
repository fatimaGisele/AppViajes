using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixeCD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CompraDetalle_PaqueteDeViajeId",
                table: "CompraDetalle",
                column: "PaqueteDeViajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraDetalle_PaqueteDeViajes_PaqueteDeViajeId",
                table: "CompraDetalle",
                column: "PaqueteDeViajeId",
                principalTable: "PaqueteDeViajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraDetalle_PaqueteDeViajes_PaqueteDeViajeId",
                table: "CompraDetalle");

            migrationBuilder.DropIndex(
                name: "IX_CompraDetalle_PaqueteDeViajeId",
                table: "CompraDetalle");
        }
    }
}
