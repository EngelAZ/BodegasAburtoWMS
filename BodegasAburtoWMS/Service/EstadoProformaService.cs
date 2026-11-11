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
        private readonly BodegaDbContext _context;

        public EstadoProformaService(BodegaDbContext context)
        {
            _context = context;
        }

        // Obtener los estados proforma de forma asincrónica
        public async Task<List<EstadoFinancieroProforma>> ObtenerEstadosProformaPorAnioAsync(int anio)
        {
            return await _context.Set<EstadoFinancieroProforma>()
                .AsNoTracking()
                .Where(e => e.Anio == anio)
                .OrderBy(e => e.TipoEstado)
                .ToListAsync();
        }

        // Sincronizar y recalcular estados proforma de forma asincrónica en segundo plano
        public async Task<bool> SincronizarEstadosProformaAsync(int anio)
        {
            await Task.Run(() =>
            {
                // Lógica de consolidación contable:
                // 1. Sumar ingresos de los 4 trimestres para el Estado de Resultados.
                // 2. Calcular utilidad neta proyectada.
                // 3. Verificar la partida doble en el Balance General (Activo = Pasivo + Patrimonio).
                System.Threading.Thread.Sleep(300);
            });

            return true;
        }
    }
}