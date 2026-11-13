using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodegasAburtoWMS.Migrations
{
    /// <inheritdoc />
    public partial class HistorialReaperturaEjercicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialEstadosEjercicios",
                columns: table => new
                {
                    IdCambioEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEjercicioFinanciero = table.Column<int>(type: "int", nullable: false),
                    EstadoAnterior = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoNuevo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialEstadosEjercicios", x => x.IdCambioEstado);
                    table.ForeignKey(
                        name: "FK_HistorialEstadosEjercicios_EjerciciosFinancieros_IdEjercicioFinanciero",
                        column: x => x.IdEjercicioFinanciero,
                        principalTable: "EjerciciosFinancieros",
                        principalColumn: "IdEjercicioFinanciero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEstadosEjercicios_IdEjercicioFinanciero_FechaUtc",
                table: "HistorialEstadosEjercicios",
                columns: new[] { "IdEjercicioFinanciero", "FechaUtc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialEstadosEjercicios");
        }
    }
}
