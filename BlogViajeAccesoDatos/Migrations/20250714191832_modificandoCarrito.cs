using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class modificandoCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoPaqueteDeViaje");

            migrationBuilder.DropTable(
                name: "ClienteCarrito");

            migrationBuilder.DropColumn(
                name: "IdPaqueteViaje",
                table: "Carrito");

            migrationBuilder.AddColumn<string>(
                name: "ClienteId",
                table: "Carrito",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaqueteDeViajeId",
                table: "Carrito",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarritoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    PaqueteDeViajeId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarritoDetalle_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoDetalle_PaqueteDeViajes_PaqueteDeViajeId",
                        column: x => x.PaqueteDeViajeId,
                        principalTable: "PaqueteDeViajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_PaqueteDeViajeId",
                table: "Carrito",
                column: "PaqueteDeViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoDetalle_CarritoId",
                table: "CarritoDetalle",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoDetalle_PaqueteDeViajeId",
                table: "CarritoDetalle",
                column: "PaqueteDeViajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_AspNetUsers_ClienteId",
                table: "Carrito",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_PaqueteDeViajes_PaqueteDeViajeId",
                table: "Carrito",
                column: "PaqueteDeViajeId",
                principalTable: "PaqueteDeViajes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_AspNetUsers_ClienteId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_PaqueteDeViajes_PaqueteDeViajeId",
                table: "Carrito");

            migrationBuilder.DropTable(
                name: "CarritoDetalle");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_PaqueteDeViajeId",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "PaqueteDeViajeId",
                table: "Carrito");

            migrationBuilder.AddColumn<int>(
                name: "IdPaqueteViaje",
                table: "Carrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarritoPaqueteDeViaje",
                columns: table => new
                {
                    CarritosId = table.Column<int>(type: "int", nullable: false),
                    PaqueteDeViajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoPaqueteDeViaje", x => new { x.CarritosId, x.PaqueteDeViajeId });
                    table.ForeignKey(
                        name: "FK_CarritoPaqueteDeViaje_Carrito_CarritosId",
                        column: x => x.CarritosId,
                        principalTable: "Carrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoPaqueteDeViaje_PaqueteDeViajes_PaqueteDeViajeId",
                        column: x => x.PaqueteDeViajeId,
                        principalTable: "PaqueteDeViajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteCarrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarritoNavigationId = table.Column<int>(type: "int", nullable: false),
                    IdClienteNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdCarrito = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteCarrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteCarrito_AspNetUsers_IdClienteNavigationId",
                        column: x => x.IdClienteNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClienteCarrito_Carrito_IdCarritoNavigationId",
                        column: x => x.IdCarritoNavigationId,
                        principalTable: "Carrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoPaqueteDeViaje_PaqueteDeViajeId",
                table: "CarritoPaqueteDeViaje",
                column: "PaqueteDeViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCarrito_IdCarritoNavigationId",
                table: "ClienteCarrito",
                column: "IdCarritoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCarrito_IdClienteNavigationId",
                table: "ClienteCarrito",
                column: "IdClienteNavigationId");
        }
    }
}
