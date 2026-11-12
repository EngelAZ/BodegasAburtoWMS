using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using Microsoft.EntityFrameworkCore;

namespace BodegasAburtoWMS.Service
{
    public class PresupuestoOperativoService
    {
        private readonly IDbContextFactory<BodegaDbContext> _factory;

        public PresupuestoOperativoService(IDbContextFactory<BodegaDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<PresupuestoTrimestral>> ObtenerPresupuestoPorAnioAsync(int anio)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.PresupuestoTrimestrales.AsNoTracking()
                .Where(p => p.Anio == anio)
                .OrderBy(p => p.Trimestre).ToListAsync();
        }

        public async Task<bool> ActualizarTrimestreYRecalcularAsync(
            int trimestreId, decimal nuevasVentas, decimal nuevosGastos, int anio)
        {
            await using var context = await _factory.CreateDbContextAsync();
            await using var transaction = await context.Database.BeginTransactionAsync();
            var item = await context.PresupuestoTrimestrales.FindAsync(trimestreId);
            if (item is null || item.Anio != anio) return false;

            item.VentasBodegaje = nuevasVentas;
            item.GastosAdministracion = nuevosGastos;
            item.UltimaActualizacion = DateTime.Now;
            await context.SaveChangesAsync();

            // Antes este método solo hacía Thread.Sleep: ahora actualiza los
            // rubros proforma calculables. La planificación de caja requiere
            // políticas adicionales; no se inventan flujos ni saldos.
            await ProformaConsolidacion.SincronizarAsync(context, anio);
            await transaction.CommitAsync();
            return true;
        }
    }
}
