using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaSepriceAPI.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "PlanesObraSocial",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "PlanesObraSocial",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "baja",
                table: "PlanesObraSocial",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Cuit",
                table: "ObrasSociales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "ObrasSociales",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "ObrasSociales",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "baja",
                table: "ObrasSociales",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "PlanesObraSocial");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "PlanesObraSocial");

            migrationBuilder.DropColumn(
                name: "baja",
                table: "PlanesObraSocial");

            migrationBuilder.DropColumn(
                name: "Cuit",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "ObrasSociales");

            migrationBuilder.DropColumn(
                name: "baja",
                table: "ObrasSociales");
        }
    }
}
