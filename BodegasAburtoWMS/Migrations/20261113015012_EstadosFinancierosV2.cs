using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodegasAburtoWMS.Migrations
{
    /// <inheritdoc />
    public partial class EstadosFinancierosV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogoCuentasFinancieras",
                columns: table => new
                {
                    IdCuentaFinanciera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Grupo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Naturaleza = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    OrdenPresentacion = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoCuentasFinancieras", x => x.IdCuentaFinanciera);
                });

            migrationBuilder.CreateTable(
                name: "EjerciciosFinancieros",
                columns: table => new
                {
                    IdEjercicioFinanciero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Escenario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FuenteDatos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreadoUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjerciciosFinancieros", x => x.IdEjercicioFinanciero);
                });

            migrationBuilder.CreateTable(
                name: "SaldosCuentasFinancieras",
                columns: table => new
                {
                    IdSaldoFinanciero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEjercicioFinanciero = table.Column<int>(type: "int", nullable: false),
                    IdCuentaFinanciera = table.Column<int>(type: "int", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ActualizadoUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldosCuentasFinancieras", x => x.IdSaldoFinanciero);
                    table.ForeignKey(
                        name: "FK_SaldosCuentasFinancieras_CatalogoCuentasFinancieras_IdCuentaFinanciera",
                        column: x => x.IdCuentaFinanciera,
                        principalTable: "CatalogoCuentasFinancieras",
                        principalColumn: "IdCuentaFinanciera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaldosCuentasFinancieras_EjerciciosFinancieros_IdEjercicioFinanciero",
                        column: x => x.IdEjercicioFinanciero,
                        principalTable: "EjerciciosFinancieros",
                        principalColumn: "IdEjercicioFinanciero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoCuentasFinancieras_Codigo",
                table: "CatalogoCuentasFinancieras",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EjerciciosFinancieros_Anio_Escenario",
                table: "EjerciciosFinancieros",
                columns: new[] { "Anio", "Escenario" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaldosCuentasFinancieras_IdCuentaFinanciera",
                table: "SaldosCuentasFinancieras",
                column: "IdCuentaFinanciera");

            migrationBuilder.CreateIndex(
                name: "IX_SaldosCuentasFinancieras_IdEjercicioFinanciero_IdCuentaFinanciera",
                table: "SaldosCuentasFinancieras",
                columns: new[] { "IdEjercicioFinanciero", "IdCuentaFinanciera" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaldosCuentasFinancieras");

            migrationBuilder.DropTable(
                name: "CatalogoCuentasFinancieras");

            migrationBuilder.DropTable(
                name: "EjerciciosFinancieros");
        }
    }
}
