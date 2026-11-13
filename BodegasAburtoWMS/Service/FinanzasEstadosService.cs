using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using Microsoft.EntityFrameworkCore;

namespace BodegasAburtoWMS.Service
{
    /// <summary>
    /// Servicio compartido para estados financieros, ratios y presupuestos posteriores.
    /// Cada operacion usa su propio DbContext. No modifica el libro operativo WMS.
    /// </summary>
    public class FinanzasEstadosService
    {
        private readonly IDbContextFactory<BodegaDbContext> _factory;

        public FinanzasEstadosService(IDbContextFactory<BodegaDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<CatalogoCuentaFinanciera>> ListarCuentasAsync(CancellationToken ct = default)
        {
            await using var db = await _factory.CreateDbContextAsync(ct);
            return await db.CatalogoCuentasFinancieras.AsNoTracking()
                .OrderBy(x => x.OrdenPresentacion).ThenBy(x => x.Codigo).ToListAsync(ct);
        }

        public async Task<CatalogoCuentaFinanciera> GuardarCuentaAsync(
            CatalogoCuentaFinanciera cuenta, CancellationToken ct = default)
        {
            var codigo = (cuenta.Codigo ?? "").Trim().ToUpperInvariant();
            var nombre = (cuenta.Nombre ?? "").Trim();
            if (codigo.Length == 0 || codigo.Length > 30 || nombre.Length == 0 || nombre.Length > 120)
                throw new ArgumentException("Código (1-30) y nombre (1-120) son obligatorios.");
            if (!Enum.IsDefined(cuenta.Grupo))
                throw new ArgumentException("Grupo financiero inválido.");
            await using var db = await _factory.CreateDbContextAsync(ct);
            if (await db.CatalogoCuentasFinancieras.AnyAsync(x => x.Codigo == codigo && x.IdCuentaFinanciera != cuenta.IdCuentaFinanciera, ct))
                throw new InvalidOperationException("Ya existe otra cuenta con ese código.");

            if (cuenta.IdCuentaFinanciera == 0)
            {
                var nueva = new CatalogoCuentaFinanciera
                {
                    Codigo = codigo, Nombre = nombre, Grupo = cuenta.Grupo,
                    Naturaleza = NaturalezaEsperada(cuenta.Grupo),
                    Activa = cuenta.Activa, OrdenPresentacion = cuenta.OrdenPresentacion,
                    Nota = cuenta.Nota
                };
                db.CatalogoCuentasFinancieras.Add(nueva);
                await db.SaveChangesAsync(ct);
                return nueva;
            }

            var existente = await db.CatalogoCuentasFinancieras.FindAsync(new object[] { cuenta.IdCuentaFinanciera }, ct)
                ?? throw new InvalidOperationException("La cuenta ya no existe.");
            bool tieneHistorico = await db.SaldosCuentasFinancieras
                .AnyAsync(x => x.IdCuentaFinanciera == cuenta.IdCuentaFinanciera, ct);
            if (tieneHistorico && existente.Codigo != codigo)
                throw new InvalidOperationException("La cuenta tiene saldos: su código histórico no puede cambiar.");
            bool tieneCerrados = await db.SaldosCuentasFinancieras
                .AnyAsync(x => x.IdCuentaFinanciera == cuenta.IdCuentaFinanciera && x.Ejercicio.Estado == "Cerrado", ct);
            if (tieneCerrados && (existente.Grupo != cuenta.Grupo || existente.Nombre != nombre))
                throw new InvalidOperationException("La cuenta figura en un ejercicio cerrado; no cambies el nombre ni la clasificación.");
            existente.Codigo = codigo;
            existente.Nombre = nombre;
            existente.Grupo = cuenta.Grupo;
            existente.Naturaleza = NaturalezaEsperada(cuenta.Grupo);
            existente.Activa = cuenta.Activa;
            existente.OrdenPresentacion = cuenta.OrdenPresentacion;
            existente.Nota = cuenta.Nota;
            await db.SaveChangesAsync(ct);
            return existente;
        }

        /// <summary>
        /// Elimina únicamente cuentas SIN saldos históricos. Para cuentas usadas,
        /// desactivar desde el catálogo: nunca se pierde la trazabilidad.
        /// </summary>
        public async Task EliminarCuentaSinSaldosAsync(int idCuenta, CancellationToken ct = default)
        {
            await using var db = await _factory.CreateDbContextAsync(ct);
            var cuenta = await db.CatalogoCuentasFinancieras.FindAsync(new object[] { idCuenta }, ct)
                ?? throw new InvalidOperationException("La cuenta ya no existe.");
            if (await db.SaldosCuentasFinancieras.AnyAsync(x => x.IdCuentaFinanciera == idCuenta, ct))
                throw new InvalidOperationException("La cuenta tiene saldos históricos. No se puede eliminar: desmarca 'Activa' y guarda para conservar el historial.");
            db.CatalogoCuentasFinancieras.Remove(cuenta);
            try { await db.SaveChangesAsync(ct); }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("No se puede eliminar la cuenta porque está vinculada a otros registros. Desactívala en su lugar.", ex);
            }
        }

        public async Task<List<EjercicioFinanciero>> ListarEjerciciosAsync(CancellationToken ct = default)
        {
            await using var db = await _factory.CreateDbContextAsync(ct);
            return await db.EjerciciosFinancieros.AsNoTracking()
                .OrderByDescending(x => x.Anio).ThenBy(x => x.Escenario).ToListAsync(ct);
        }

        public async Task<EjercicioFinanciero> CrearEjercicioAsync(
            int anio, string escenario, string? fuente = null, CancellationToken ct = default)
        {
            if (anio < 2000 || anio > 2100) throw new ArgumentOutOfRangeException(nameof(anio));
            if (escenario != "Real" && escenario != "Academico" && escenario != "Proyectado")
                throw new ArgumentException("El escenario debe ser Real, Academico o Proyectado.");
            await using var db = await _factory.CreateDbContextAsync(ct);
            if (await db.EjerciciosFinancieros.AnyAsync(x => x.Anio == anio && x.Escenario == escenario, ct))
                throw new InvalidOperationException("Ya existe ese año y escenario.");
            var ejercicio = new EjercicioFinanciero
            {
                Anio = anio,
                FechaInicio = new DateTime(anio, 1, 1),
                FechaFin = new DateTime(anio, 12, 31),
                Escenario = escenario,
                Estado = "Borrador",
                Moneda = "NIO",
                FuenteDatos = fuente
            };
            db.EjerciciosFinancieros.Add(ejercicio);
            await db.SaveChangesAsync(ct);
            return ejercicio;
        }

        public async Task GuardarSaldoAsync(int ejercicioId, int cuentaId, decimal importe, CancellationToken ct = default)
        {
            if (importe < 0)
                throw new ArgumentOutOfRangeException(nameof(importe), "Captura importes positivos. El grupo determina el signo de presentación.");
            await using var db = await _factory.CreateDbContextAsync(ct);
            var ejercicio = await db.EjerciciosFinancieros.FindAsync(new object[] { ejercicioId }, ct)
                ?? throw new InvalidOperationException("Ejercicio inexistente.");
            if (ejercicio.Estado != "Borrador")
                throw new InvalidOperationException("El ejercicio está cerrado y no admite cambios.");
            var cuenta = await db.CatalogoCuentasFinancieras.FindAsync(new object[] { cuentaId }, ct)
                ?? throw new InvalidOperationException("Cuenta inexistente.");
            if (!cuenta.Activa) throw new InvalidOperationException("La cuenta está inactiva.");

            var saldo = await db.SaldosCuentasFinancieras
                .SingleOrDefaultAsync(x => x.IdEjercicioFinanciero == ejercicioId && x.IdCuentaFinanciera == cuentaId, ct);
            if (saldo == null)
            {
                db.SaldosCuentasFinancieras.Add(new SaldoCuentaFinanciera
                {
                    IdEjercicioFinanciero = ejercicioId,
                    IdCuentaFinanciera = cuentaId,
                    Importe = PrecisionMonetaria.Redondear(importe),
                    ActualizadoUtc = DateTime.UtcNow
                });
            }
            else
            {
                saldo.Importe = PrecisionMonetaria.Redondear(importe);
                saldo.ActualizadoUtc = DateTime.UtcNow;
            }
            await db.SaveChangesAsync(ct);
        }

        public async Task<EjercicioSnapshot> ObtenerSnapshotAsync(int ejercicioId, CancellationToken ct = default)
        {
            await using var db = await _factory.CreateDbContextAsync(ct);
            var ejercicio = await db.EjerciciosFinancieros.AsNoTracking()
                .SingleOrDefaultAsync(x => x.IdEjercicioFinanciero == ejercicioId, ct)
                ?? throw new InvalidOperationException("No existe el ejercicio seleccionado.");
            var datos = await db.SaldosCuentasFinancieras.AsNoTracking()
                .Where(x => x.IdEjercicioFinanciero == ejercicioId)
                .Select(x => new { x.Cuenta.Codigo, x.Cuenta.Nombre, x.Cuenta.Grupo,
                    x.Cuenta.OrdenPresentacion, x.Importe })
                .OrderBy(x => x.OrdenPresentacion).ThenBy(x => x.Codigo)
                .ToListAsync(ct);
            return new EjercicioSnapshot
            {
                Ejercicio = ejercicio,
                Lineas = datos.Select(x => new LineaEstadoFinanciero(x.Codigo, x.Nombre, x.Grupo, x.Importe, x.OrdenPresentacion)).ToList()
            };
        }

        public async Task<EjercicioSnapshot> ObtenerSnapshotPorAnioAsync(
            int anio, string escenario, CancellationToken ct = default)
        {
            await using var db = await _factory.CreateDbContextAsync(ct);
            var id = await db.EjerciciosFinancieros.AsNoTracking()
                .Where(x => x.Anio == anio && x.Escenario == escenario)
                .Select(x => x.IdEjercicioFinanciero)
                .SingleOrDefaultAsync(ct);
            if (id == 0)
                throw new InvalidOperationException($"No existe ejercicio {anio} ({escenario}).");
            return await ObtenerSnapshotAsync(id, ct);
        }

        public async Task<List<ComparacionFinanciera>> CompararEjerciciosAsync(
            int ejercicioBaseId, int ejercicioActualId, bool balance, CancellationToken ct = default)
        {
            var anterior = await ObtenerSnapshotAsync(ejercicioBaseId, ct);
            var actual = await ObtenerSnapshotAsync(ejercicioActualId, ct);
            if (anterior.Ejercicio.Escenario != actual.Ejercicio.Escenario)
                throw new InvalidOperationException("No compares un escenario Real con uno Académico.");
            if (anterior.Ejercicio.Moneda != actual.Ejercicio.Moneda)
                throw new InvalidOperationException("Los ejercicios deben usar la misma moneda.");
            if (anterior.Ejercicio.Anio >= actual.Ejercicio.Anio)
                throw new InvalidOperationException("Selecciona un período base anterior al actual.");
            if (anterior.Lineas.Count == 0 || actual.Lineas.Count == 0)
                throw new InvalidOperationException("Los dos ejercicios deben contener saldos.");
            bool Filtrar(LineaEstadoFinanciero x) => CalculadoraEstadosFinancieros.EsBalance(x.Grupo) == balance;
            return CalculadoraEstadosFinancieros.Comparar(anterior.Lineas.Where(Filtrar), actual.Lineas.Where(Filtrar));
        }

        public async Task CerrarEjercicioAsync(int ejercicioId, CancellationToken ct = default)
        {
            await using var db = await _factory.CreateDbContextAsync(ct);
            var ejercicio = await db.EjerciciosFinancieros.FindAsync(new object[] { ejercicioId }, ct)
                ?? throw new InvalidOperationException("No existe el ejercicio.");
            if (ejercicio.Estado == "Cerrado") return;
            var saldos = await db.SaldosCuentasFinancieras.AsNoTracking()
                .Where(x => x.IdEjercicioFinanciero == ejercicioId)
                .Select(x => new { x.Cuenta.Codigo, x.Cuenta.Nombre, x.Cuenta.Grupo, x.Importe })
                .ToListAsync(ct);
            if (saldos.Count == 0) throw new InvalidOperationException("No se puede cerrar un ejercicio sin saldos.");
            var lineas = saldos.Select(x => new LineaEstadoFinanciero(x.Codigo, x.Nombre, x.Grupo, x.Importe));
            if (!saldos.Any(x => CalculadoraEstadosFinancieros.EsBalance(x.Grupo)))
                throw new InvalidOperationException("No se puede cerrar: no hay cuentas del Balance General.");
            var balance = CalculadoraEstadosFinancieros.CalcularBalance(lineas);
            if (!balance.EstaCuadrado)
                throw new InvalidOperationException($"El balance no cuadra. Diferencia: C$ {balance.Diferencia:N2}.");
            ejercicio.Estado = "Cerrado";
            db.HistorialEstadosEjercicios.Add(new CambioEstadoEjercicioFinanciero
            {
                IdEjercicioFinanciero = ejercicioId,
                EstadoAnterior = "Borrador",
                EstadoNuevo = "Cerrado",
                Motivo = "Cierre manual tras validar el balance.",
                FechaUtc = DateTime.UtcNow
            });
            await db.SaveChangesAsync(ct);
        }

        /// <summary>
        /// La reapertura vuelve el ejercicio editable; exige un motivo trazable.
        /// </summary>
        public async Task ReabrirEjercicioAsync(int ejercicioId, string motivo, CancellationToken ct = default)
        {
            motivo = (motivo ?? "").Trim();
            if (motivo.Length < 5 || motivo.Length > 500)
                throw new ArgumentException("Indica un motivo de reapertura (5 a 500 caracteres).");
            await using var db = await _factory.CreateDbContextAsync(ct);
            var ejercicio = await db.EjerciciosFinancieros.FindAsync(new object[] { ejercicioId }, ct)
                ?? throw new InvalidOperationException("No existe el ejercicio.");
            if (ejercicio.Estado != "Cerrado")
                throw new InvalidOperationException("Solo se puede reabrir un ejercicio cerrado.");
            ejercicio.Estado = "Borrador";
            db.HistorialEstadosEjercicios.Add(new CambioEstadoEjercicioFinanciero
            {
                IdEjercicioFinanciero = ejercicioId,
                EstadoAnterior = "Cerrado",
                EstadoNuevo = "Borrador",
                Motivo = motivo,
                FechaUtc = DateTime.UtcNow
            });
            await db.SaveChangesAsync(ct);
        }

        public async Task<List<CambioEstadoEjercicioFinanciero>> ListarHistorialEstadoAsync(
            int ejercicioId, CancellationToken ct = default)
        {
            await using var db = await _factory.CreateDbContextAsync(ct);
            return await db.HistorialEstadosEjercicios.AsNoTracking()
                .Where(x => x.IdEjercicioFinanciero == ejercicioId)
                .OrderByDescending(x => x.FechaUtc)
                .ThenByDescending(x => x.IdCambioEstado)
                .ToListAsync(ct);
        }

        private static NaturalezaCuentaFinanciera NaturalezaEsperada(GrupoCuentaFinanciera grupo)
            => grupo switch
            {
                GrupoCuentaFinanciera.PasivoCorriente or
                GrupoCuentaFinanciera.PasivoNoCorriente or
                GrupoCuentaFinanciera.Patrimonio or
                GrupoCuentaFinanciera.ContraActivo or
                GrupoCuentaFinanciera.IngresoOperativo or
                GrupoCuentaFinanciera.OtroIngreso => NaturalezaCuentaFinanciera.Acreedora,
                _ => NaturalezaCuentaFinanciera.Deudora
            };

    }
}
