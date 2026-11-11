
using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodegasAburtoWMS.Service
{
    public class PresupuestoService
    {
        private readonly BodegaDbContext _context;

        public PresupuestoService(BodegaDbContext context)
        {
            _context = context;
        }

        // Obtener lista de supuestos de forma asincrónica
        public async Task<List<PresupuestoParametro>> ObtenerSupuestosPorAnioAsync(int anio)
        {
            return await _context.PresupuestoParametros
                .AsNoTracking()
                .Where(p => p.Anio == anio)
                .ToListAsync();
        }

        // Actualizar supuesto y recalcular proformas al instante de forma asincrónica
        public async Task<bool> ActualizarSupuestoYRecalcularAsync(int idSupuesto, decimal nuevoValor, int anio)
        {
            var supuesto = await _context.PresupuestoParametros.FindAsync(idSupuesto);
            if (supuesto == null) return false;

            supuesto.Valor = nuevoValor;
            supuesto.FechaModificacion = DateTime.Now;

            _context.PresupuestoParametros.Update(supuesto);
            await _context.SaveChangesAsync();

            // Recalcular proformas de forma reactiva en segundo plano
            await RecalcularEstadosProformaAsync(anio);

            return true;
        }

        public async Task RecalcularEstadosProformaAsync(int anio)
        {
            // Ejecución del motor financiero en segundo plano con Task
            await Task.Run(async () =>
            {
                // 1. Obtener parámetros y supuestos configurados
                var parametros = await _context.PresupuestoParametros
                    .Where(p => p.Anio == anio)
                    .ToListAsync();

                decimal bultosAnual = parametros.FirstOrDefault(p => p.Clave == "BultosBodegaje")?.Valor ?? 2520m;
                decimal tarifaBulto = parametros.FirstOrDefault(p => p.Clave == "TarifaBulto")?.Valor ?? 60.0m;
                decimal crecAualDomicilio = parametros.FirstOrDefault(p => p.Clave == "CrecimientoDomicilioPct")?.Valor ?? 0.10m;
                decimal costoVentaAnual = parametros.FirstOrDefault(p => p.Clave == "CostoVentaAnual")?.Valor ?? 13003.74m;
               // decimal retirosPropietario = parametros.FirstOrDefault(p => p.RetirosPropietarioAnual == anio)?.Valor ?? 420000m;
                decimal efectivoMinimo = 200000.0m; // Efectivo mínimo requerido por caja

                // 2. Distribuir y calcular trimestralmente (T1 a T4)
                var trimestres = await _context.PresupuestoTrimestrales
                    .Where(t => t.Anio == anio)
                    .OrderBy(t => t.Trimestre)
                    .ToListAsync();

                decimal cajaAcumulada = efectivoMinimo; // Saldo inicial base

                foreach (var tri in trimestres)
                {
                    // Proyección proporcional de bultos y ventas por trimestre
                    decimal bultosTri = bultosAnual / 4m;
                    tri.VentasBodegaje = bultosTri * tarifaBulto;
                    tri.VentasDomicilio = tri.VentasBodegaje * crecAualDomicilio;

                    decimal ventasTotalesTri = tri.VentasBodegaje + tri.VentasDomicilio;

                    // Costos y Gastos proporcionales
                    tri.CostoVentas = costoVentaAnual / 4m;
                    tri.GastosAdministracion = (tri.GastosAdministracion > 0) ? tri.GastosAdministracion : (ventasTotalesTri * 0.25m);

                    // Modelo de Cobranza Dinámica (Ej. 78% T2, 22% T3 por ejemplo de políticas de agencia)
                    tri.CobranzasAgencias = ventasTotalesTri * 0.85m;
                    tri.PagosCompras = tri.CostoVentas * 0.90m;
                    tri.GastosEfectivo = tri.GastosAdministracion;
                   // tri.RetirosPropietarios = retirosPropietario / 4m;

                    // Flujo de Caja del Trimestre
                    decimal efectivoGenerado = tri.CobranzasAgencias - tri.PagosCompras - tri.GastosEfectivo - tri.RetirosPropietarios;
                    cajaAcumulada += efectivoGenerado;

                    // Validación de Efectivo Mínimo y Aportes Requeridos del Propietario
                    if (cajaAcumulada < efectivoMinimo)
                    {
                        tri.AportesRequeridos = efectivoMinimo - cajaAcumulada;
                        cajaAcumulada = efectivoMinimo; // Se inyecta lo justo para mantener el límite operativo
                    }
                    else
                    {
                        tri.AportesRequeridos = 0m;
                    }

                    tri.SaldoFinalEfectivo = cajaAcumulada;
                    tri.UltimaActualizacion = DateTime.Now;
                    _context.PresupuestoTrimestrales.Update(tri);
                }

                // 3. Consolidar y actualizar los Estados Financieros Proforma
                var proformas = await _context.EstadosFinancierosProforma
                    .Where(e => e.Anio == anio)
                    .ToListAsync();

                decimal totalVentasProyectadas = trimestres.Sum(t => t.VentasBodegaje + t.VentasDomicilio);
                decimal totalCostoVentas = trimestres.Sum(t => t.CostoVentas);
                decimal totalGastos = trimestres.Sum(t => t.GastosAdministracion);
                decimal utilidadNeta = totalVentasProyectadas - totalCostoVentas - totalGastos;

                foreach (var prof in proformas)
                {
                    if (prof.Rubro.Contains("Ventas Totales") || prof.Rubro.Contains("Ingresos"))
                        prof.MontoProyectado = totalVentasProyectadas;
                    else if (prof.Rubro.Contains("Costo de Ventas"))
                        prof.MontoProyectado = totalCostoVentas;
                    else if (prof.Rubro.Contains("Utilidad Neta"))
                        prof.MontoProyectado = utilidadNeta;
                    else if (prof.Rubro.Contains("Efectivo en Caja"))
                        prof.MontoProyectado = trimestres.LastOrDefault()?.SaldoFinalEfectivo ?? efectivoMinimo;

                    prof.UltimaSincronizacion = DateTime.Now;
                    _context.EstadosFinancierosProforma.Update(prof);
                }

                // Guardar todos los cambios calculados en la base de datos de forma transaccional
                await _context.SaveChangesAsync();
            });
        }
    }
}