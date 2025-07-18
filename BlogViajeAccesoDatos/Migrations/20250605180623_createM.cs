using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class createM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaqueteViaje = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrDestino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedioDePagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioDePagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteDeViajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteDeViajes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteCarrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdCarrito = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdCarritoNavigationId = table.Column<int>(type: "int", nullable: false),
                    IdClienteNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteCarrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteCarrito_Carrito_IdCarritoNavigationId",
                        column: x => x.IdCarritoNavigationId,
                        principalTable: "Carrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteCarrito_Cliente_IdClienteNavigationId",
                        column: x => x.IdClienteNavigationId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteMedioDePagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdMedioDePago = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClienteNavigationId = table.Column<int>(type: "int", nullable: false),
                    IdMedioDePagoNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMedioDePagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteMedioDePagos_Cliente_IdClienteNavigationId",
                        column: x => x.IdClienteNavigationId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteMedioDePagos_MedioDePagos_IdMedioDePagoNavigationId",
                        column: x => x.IdMedioDePagoNavigationId,
                        principalTable: "MedioDePagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Disponibilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LugaresDisponibles = table.Column<int>(type: "int", nullable: false),
                    IdPaqueteViajeId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ViajeDestino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaqueteViaje = table.Column<int>(type: "int", nullable: false),
                    IdDestino = table.Column<int>(type: "int", nullable: false),
                    IdPaqueteNavigationId = table.Column<int>(type: "int", nullable: false),
                    IdDestinoNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajeDestino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViajeDestino_Destino_IdDestinoNavigationId",
                        column: x => x.IdDestinoNavigationId,
                        principalTable: "Destino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViajeDestino_PaqueteDeViajes_IdPaqueteNavigationId",
                        column: x => x.IdPaqueteNavigationId,
                        principalTable: "PaqueteDeViajes",
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

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMedioDePagos_IdClienteNavigationId",
                table: "ClienteMedioDePagos",
                column: "IdClienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMedioDePagos_IdMedioDePagoNavigationId",
                table: "ClienteMedioDePagos",
                column: "IdMedioDePagoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidad_IdPaqueteViajeId",
                table: "Disponibilidad",
                column: "IdPaqueteViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDestino_IdDestinoNavigationId",
                table: "ViajeDestino",
                column: "IdDestinoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajeDestino_IdPaqueteNavigationId",
                table: "ViajeDestino",
                column: "IdPaqueteNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoPaqueteDeViaje");

            migrationBuilder.DropTable(
                name: "ClienteCarrito");

            migrationBuilder.DropTable(
                name: "ClienteMedioDePagos");

            migrationBuilder.DropTable(
                name: "Disponibilidad");

            migrationBuilder.DropTable(
                name: "ViajeDestino");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "MedioDePagos");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "PaqueteDeViajes");
        }
    }
}
