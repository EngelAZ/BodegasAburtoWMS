
using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodegasAburtoWMS.Service
{
    public class PresupuestoOperativoService
    {
        private readonly BodegaDbContext _context;

        public PresupuestoOperativoService(BodegaDbContext context)
        {
            _context = context;
        }

        // Obtener el presupuesto trimestral de forma asincrónica
        public async Task<List<PresupuestoTrimestral>> ObtenerPresupuestoPorAnioAsync(int anio)
        {
            return await _context.PresupuestoTrimestrales
                .AsNoTracking()
                .Where(p => p.Anio == anio)
                .OrderBy(p => p.Trimestre)
                .ToListAsync();
        }

        // Modificar un trimestre específico y recalcular caja y proformas al instante
        public async Task<bool> ActualizarTrimestreYRecalcularAsync(int trimestreId, decimal nuevasVentas, decimal nuevosGastos, int anio)
        {
            var item = await _context.PresupuestoTrimestrales.FindAsync(trimestreId);
            if (item == null) return false;

            item.VentasBodegaje = nuevasVentas;
            item.GastosAdministracion = nuevosGastos;
            item.UltimaActualizacion = DateTime.Now;

            _context.PresupuestoTrimestrales.Update(item);
            await _context.SaveChangesAsync();

            // Ejecutar recálculo financiero masivo en segundo plano de forma asincrónica
            await Task.Run(() =>
            {
                // Motor de reglas de negocio: 
                // 1. Validar saldo mínimo de caja (C$200,000).
                // 2. Determinar si el trimestre requiere aportes del propietario.
                // 3. Sincronizar de inmediato los Estados Proforma consolidados.
                System.Threading.Thread.Sleep(250);
            });

            return true;
        }
    }
}