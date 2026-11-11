using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodegasAburtoWMS.Migrations
{
    /// <inheritdoc />
    public partial class AgregarModuloPresupuestoProforma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosFinancierosProforma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    TipoEstado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rubro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MontoProyectado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoRealAnterior = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UltimaSincronizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosFinancierosProforma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresupuestoParametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestoParametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresupuestoTrimestrales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    VentasBodegaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VentasDomicilio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoVentas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GastosVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GastosAdministracion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CobranzasAgencias = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagosCompras = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GastosEfectivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RetirosPropietarios = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AportesRequeridos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoFinalEfectivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UltimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestoTrimestrales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosFinancierosProforma");

            migrationBuilder.DropTable(
                name: "PresupuestoParametros");

            migrationBuilder.DropTable(
                name: "PresupuestoTrimestrales");
        }
    }
}
