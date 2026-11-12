using System;
using System.Linq;
using System.Threading.Tasks;
using BodegasAburtoWMS.Datos;
using Microsoft.EntityFrameworkCore;

namespace BodegasAburtoWMS.Service
{
    /// <summary>
    /// Sincronización limitada a rubros calculables desde los cuatro presupuestos
    /// trimestrales. No simula asientos contables ni cuadre del Balance General.
    /// </summary>
    internal static class ProformaConsolidacion
    {
        public static async Task<bool> SincronizarAsync(BodegaDbContext context, int anio)
        {
            var trimestres = await context.PresupuestoTrimestrales
                .AsNoTracking().Where(t => t.Anio == anio)
                .OrderBy(t => t.Trimestre).ToListAsync();

            if (trimestres.Count == 0) return false;

            var proformas = await context.EstadosFinancierosProforma
                .Where(p => p.Anio == anio).ToListAsync();

            if (proformas.Count == 0) return false;

            decimal ingresos = trimestres.Sum(t => t.VentasBodegaje + t.VentasDomicilio);
            decimal costos = trimestres.Sum(t => t.CostoVentas);
            decimal gastos = trimestres.Sum(t => t.GastosVenta + t.GastosAdministracion);
            decimal utilidad = ingresos - costos - gastos;
            decimal efectivo = trimestres.Last().SaldoFinalEfectivo;

            bool actualizado = false;
            foreach (var p in proformas)
            {
                // Solo actualizamos rubros reconocidos. No tocar otros balances manuales.
                string rubro = p.Rubro.ToUpperInvariant();
                decimal? monto = rubro switch
                {
                    var x when x.Contains("VENTAS TOTALES") || x == "INGRESOS" => ingresos,
                    var x when x.Contains("COSTO DE VENTAS") => costos,
                    var x when x.Contains("GASTOS OPERATIVOS") => gastos,
                    var x when x.Contains("UTILIDAD NETA") => utilidad,
                    var x when x.Contains("EFECTIVO EN CAJA") => efectivo,
                    _ => null
                };
                if (monto is null) continue;
                p.MontoProyectado = monto.Value;
                p.UltimaSincronizacion = DateTime.Now;
                actualizado = true;
            }

            if (actualizado) await context.SaveChangesAsync();
            return actualizado;
        }
    }
}
