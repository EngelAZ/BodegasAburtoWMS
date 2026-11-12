using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasAburtoWMS.Service
{
    public class EstadoProformaService
    {
        private readonly IDbContextFactory<BodegaDbContext> _factory;
        public EstadoProformaService(IDbContextFactory<BodegaDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<List<EstadoFinancieroProforma>> ObtenerEstadosProformaPorAnioAsync(int anio)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.EstadosFinancierosProforma.AsNoTracking()
                .Where(e => e.Anio == anio)
                .OrderBy(e => e.TipoEstado).ToListAsync();
        }

        public async Task<bool> SincronizarEstadosProformaAsync(int anio)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await ProformaConsolidacion.SincronizarAsync(context, anio);
        }
    }
}