using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogViajes.Data.Migrations
{
    /// <inheritdoc />
    public partial class agragandoDosModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpcionesDePago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionesDePago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaqueteOpcionesPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaqueteDeViaje = table.Column<int>(type: "int", nullable: false),
                    IdOpcionesDePago = table.Column<int>(type: "int", nullable: false),
                    IdPaqueteDeViajeNavigationId = table.Column<int>(type: "int", nullable: false),
                    IdOpcionesDePagoNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteOpcionesPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaqueteOpcionesPago_OpcionesDePago_IdOpcionesDePagoNavigationId",
                        column: x => x.IdOpcionesDePagoNavigationId,
                        principalTable: "OpcionesDePago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteOpcionesPago_PaqueteDeViajes_IdPaqueteDeViajeNavigationId",
                        column: x => x.IdPaqueteDeViajeNavigationId,
                        principalTable: "PaqueteDeViajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteOpcionesPago_IdOpcionesDePagoNavigationId",
                table: "PaqueteOpcionesPago",
                column: "IdOpcionesDePagoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteOpcionesPago_IdPaqueteDeViajeNavigationId",
                table: "PaqueteOpcionesPago",
                column: "IdPaqueteDeViajeNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaqueteOpcionesPago");

            migrationBuilder.DropTable(
                name: "OpcionesDePago");
        }
    }
}
