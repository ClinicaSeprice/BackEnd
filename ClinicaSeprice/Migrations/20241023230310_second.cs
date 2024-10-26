using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaSepriceAPI.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiquidacionesMedicos",
                columns: table => new
                {
                    IdLiquidacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    FechaLiquidacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false),
                    NumeroTransaccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidacionesMedicos", x => x.IdLiquidacion);
                    table.ForeignKey(
                        name: "FK_LiquidacionesMedicos_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiquidacionesMedicos_MetodosPago_IdMetodoPago",
                        column: x => x.IdMetodoPago,
                        principalTable: "MetodosPago",
                        principalColumn: "IdMetodoPago",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PorcentajesPagoMedicos",
                columns: table => new
                {
                    IdPorcentaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorcentajesPagoMedicos", x => x.IdPorcentaje);
                    table.ForeignKey(
                        name: "FK_PorcentajesPagoMedicos_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesLiquidacionesMedicos",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdLiquidacion = table.Column<int>(type: "int", nullable: false),
                    IdTurno = table.Column<int>(type: "int", nullable: false),
                    MontoTurno = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MontoLiquidado = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesLiquidacionesMedicos", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesLiquidacionesMedicos_LiquidacionesMedicos_IdLiquidac~",
                        column: x => x.IdLiquidacion,
                        principalTable: "LiquidacionesMedicos",
                        principalColumn: "IdLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesLiquidacionesMedicos_Turnos_IdTurno",
                        column: x => x.IdTurno,
                        principalTable: "Turnos",
                        principalColumn: "IdTurno",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesLiquidacionesMedicos_IdLiquidacion",
                table: "DetallesLiquidacionesMedicos",
                column: "IdLiquidacion");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesLiquidacionesMedicos_IdTurno",
                table: "DetallesLiquidacionesMedicos",
                column: "IdTurno");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesMedicos_IdMedico",
                table: "LiquidacionesMedicos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesMedicos_IdMetodoPago",
                table: "LiquidacionesMedicos",
                column: "IdMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_PorcentajesPagoMedicos_IdMedico",
                table: "PorcentajesPagoMedicos",
                column: "IdMedico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesLiquidacionesMedicos");

            migrationBuilder.DropTable(
                name: "PorcentajesPagoMedicos");

            migrationBuilder.DropTable(
                name: "LiquidacionesMedicos");
        }
    }
}
