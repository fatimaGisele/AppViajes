using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixDestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaqueteOpcionesPago_OpcionesDePago_IdOpcionesDePagoNavigationId",
                table: "PaqueteOpcionesPago");

            migrationBuilder.DropForeignKey(
                name: "FK_PaqueteOpcionesPago_PaqueteDeViajes_IdPaqueteDeViajeNavigationId",
                table: "PaqueteOpcionesPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaqueteOpcionesPago",
                table: "PaqueteOpcionesPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpcionesDePago",
                table: "OpcionesDePago");

            migrationBuilder.RenameTable(
                name: "PaqueteOpcionesPago",
                newName: "PaqueteOpcionesPagos");

            migrationBuilder.RenameTable(
                name: "OpcionesDePago",
                newName: "OpcionesDePagos");

            migrationBuilder.RenameColumn(
                name: "NombrDestino",
                table: "Destino",
                newName: "NombreDestino");

            migrationBuilder.RenameIndex(
                name: "IX_PaqueteOpcionesPago_IdPaqueteDeViajeNavigationId",
                table: "PaqueteOpcionesPagos",
                newName: "IX_PaqueteOpcionesPagos_IdPaqueteDeViajeNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_PaqueteOpcionesPago_IdOpcionesDePagoNavigationId",
                table: "PaqueteOpcionesPagos",
                newName: "IX_PaqueteOpcionesPagos_IdOpcionesDePagoNavigationId");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Destino",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaqueteOpcionesPagos",
                table: "PaqueteOpcionesPagos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpcionesDePagos",
                table: "OpcionesDePagos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaqueteOpcionesPagos_OpcionesDePagos_IdOpcionesDePagoNavigationId",
                table: "PaqueteOpcionesPagos",
                column: "IdOpcionesDePagoNavigationId",
                principalTable: "OpcionesDePagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaqueteOpcionesPagos_PaqueteDeViajes_IdPaqueteDeViajeNavigationId",
                table: "PaqueteOpcionesPagos",
                column: "IdPaqueteDeViajeNavigationId",
                principalTable: "PaqueteDeViajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaqueteOpcionesPagos_OpcionesDePagos_IdOpcionesDePagoNavigationId",
                table: "PaqueteOpcionesPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_PaqueteOpcionesPagos_PaqueteDeViajes_IdPaqueteDeViajeNavigationId",
                table: "PaqueteOpcionesPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaqueteOpcionesPagos",
                table: "PaqueteOpcionesPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpcionesDePagos",
                table: "OpcionesDePagos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Destino");

            migrationBuilder.RenameTable(
                name: "PaqueteOpcionesPagos",
                newName: "PaqueteOpcionesPago");

            migrationBuilder.RenameTable(
                name: "OpcionesDePagos",
                newName: "OpcionesDePago");

            migrationBuilder.RenameColumn(
                name: "NombreDestino",
                table: "Destino",
                newName: "NombrDestino");

            migrationBuilder.RenameIndex(
                name: "IX_PaqueteOpcionesPagos_IdPaqueteDeViajeNavigationId",
                table: "PaqueteOpcionesPago",
                newName: "IX_PaqueteOpcionesPago_IdPaqueteDeViajeNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_PaqueteOpcionesPagos_IdOpcionesDePagoNavigationId",
                table: "PaqueteOpcionesPago",
                newName: "IX_PaqueteOpcionesPago_IdOpcionesDePagoNavigationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaqueteOpcionesPago",
                table: "PaqueteOpcionesPago",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpcionesDePago",
                table: "OpcionesDePago",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaqueteOpcionesPago_OpcionesDePago_IdOpcionesDePagoNavigationId",
                table: "PaqueteOpcionesPago",
                column: "IdOpcionesDePagoNavigationId",
                principalTable: "OpcionesDePago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaqueteOpcionesPago_PaqueteDeViajes_IdPaqueteDeViajeNavigationId",
                table: "PaqueteOpcionesPago",
                column: "IdPaqueteDeViajeNavigationId",
                principalTable: "PaqueteDeViajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
