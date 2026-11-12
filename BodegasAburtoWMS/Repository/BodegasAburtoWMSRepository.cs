using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using Microsoft.EntityFrameworkCore;

namespace BodegasAburtoWMS.Repository
{
    public class BodegasAburtoWMSRepository : IBodegasAburtoWMSRepository
    {
        private readonly IDbContextFactory<BodegaDbContext> _factory;

        // Inyección de dependencias única del DbContext
        public BodegasAburtoWMSRepository(IDbContextFactory<BodegaDbContext> factory)
        {
            _factory = factory;
        }

        // ==========================================
        // MÓDULO DE USUARIOS Y AUTENTICACIÓN
        // ==========================================

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Usuarios
                .Include(u => u.Rol)
                .OrderBy(u => u.IdUsuario)
                .ToListAsync();
        }

        public async Task<Usuario?> ObtenerUsuarioPorNombreAsync(string usuario)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Usuarios
                .Include(u => u.Rol) // Equivalente al INNER JOIN con Roles
                .FirstOrDefaultAsync(u => u.UsuarioNombre == usuario && u.Activo);
        }

        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            await using var context = await _factory.CreateDbContextAsync();
            // Validar si el nombre de usuario ya existe
            bool existe = await context.Usuarios.AnyAsync(u => u.UsuarioNombre == usuario.UsuarioNombre);
            if (existe) return false; // Usuario duplicado

            await context.Usuarios.AddAsync(usuario);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
        {
            await using var context = await _factory.CreateDbContextAsync();
            context.Usuarios.Update(usuario);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DesactivarUsuarioAsync(int idUsuario)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var usuario = await context.Usuarios.FindAsync(idUsuario);
            if (usuario == null) return false;

            usuario.Activo = false;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task RegistrarUltimoAccesoAsync(int idUsuario)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var usuario = await context.Usuarios.FindAsync(idUsuario);
            if (usuario != null)
            {
                usuario.UltimoAcceso = DateTime.Now;
                await context.SaveChangesAsync();
            }
        }

        public async Task RegistrarAuditoriaAsync(int idUsuario, string accion, string usuarioSistema, string detalle)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var auditoria = new AuditoriaUsuario
            {
                IdUsuario = idUsuario,
                Accion = accion,
                UsuarioSistema = usuarioSistema,
                Detalle = detalle,
                FechaRegistro = DateTime.Now
            };

            await context.AuditoriaUsuarios.AddAsync(auditoria);
            await context.SaveChangesAsync();
        }

        // ==========================================
        // MÓDULO DE CATÁLOGOS (COMBOBOXES)
        // ==========================================

        public async Task<List<ComboboxItem>> ObtenerAgenciasComboAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Agencias
                .Select(a => new ComboboxItem { Value = a.IdAgencia, Text = a.Nombre })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerTiposEnvioComboAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.TiposEnvio
                .Select(t => new ComboboxItem { Value = t.IdTipoEnvio, Text = t.Nombre })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerEstadosEnvioComboAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.EstadosEnvio
                .Select(e => new ComboboxItem { Value = e.IdEstado, Text = e.Nombre })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerClientesComboAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Clientes
                .Select(c => new ComboboxItem
                {
                    Value = c.IdCliente,
                    Text = (c.Nombre + " " + c.Apellido).Trim()
                })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerRolesComboAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Roles
                .Select(r => new ComboboxItem { Value = r.IdRol, Text = r.Nombre })
                .ToListAsync();
        }

        // ==========================================
        // MÓDULO DE AGENCIAS
        // ==========================================

        public async Task<List<Agencia>> ObtenerAgenciasAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Agencias
                .OrderByDescending(a => a.FechaRegistro)
                .ToListAsync();
        }

        public async Task<List<Agencia>> BuscarAgenciasAsync(string filtro)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Agencias
                .Where(a => a.Nombre.Contains(filtro) || (a.Ciudad != null && a.Ciudad.Contains(filtro)))
                .ToListAsync();
        }

        public async Task<bool> GuardarAgenciaAsync(Agencia agencia)
        {
            await using var context = await _factory.CreateDbContextAsync();
            if (agencia.IdAgencia == 0)
            {
                await context.Agencias.AddAsync(agencia);
            }
            else
            {
                context.Agencias.Update(agencia);
            }
            return await context.SaveChangesAsync() > 0;
        }

        // ==========================================
        // MÓDULO DE CLIENTES
        // ==========================================

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Clientes
                .OrderByDescending(c => c.FechaRegistro)
                .ToListAsync();
        }

        public async Task<List<Cliente>> BuscarClientesAsync(string filtro)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Clientes
                .Where(c => c.Nombre.Contains(filtro) || c.Apellido.Contains(filtro) || (c.NumeroCedula != null && c.NumeroCedula.Contains(filtro)))
                .ToListAsync();
        }

        public async Task<bool> GuardarClienteAsync(Cliente cliente)
        {
            await using var context = await _factory.CreateDbContextAsync();
            if (cliente.IdCliente == 0)
            {
                await context.Clientes.AddAsync(cliente);
            }
            else
            {
                context.Clientes.Update(cliente);
            }
            return await context.SaveChangesAsync() > 0;
        }

        // ==========================================
        // MÓDULO DE ENVÍOS Y REGISTRO DIARIO
        // ==========================================

        public async Task<bool> RegistrarEnvioAsync(Envio envio)
        {
            await using var context = await _factory.CreateDbContextAsync();
            await context.Envios.AddAsync(envio);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<Envio>> ObtenerEnviosAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Envios
                .Include(e => e.Agencia)
                .Include(e => e.ClienteRemitente)
                .Include(e => e.ClienteDestinatario)
                .Include(e => e.TipoEnvio)
                .Include(e => e.Estado) // <-- Clave para traer el estado
                .OrderByDescending(e => e.FechaEnvio)
                .ToListAsync();
        }

        public async Task<List<Envio>> BuscarEnviosAsync(string filtro)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Envios
                .Include(e => e.Agencia)
                .Include(e => e.ClienteRemitente)
                .Include(e => e.ClienteDestinatario)
                .Include(e => e.TipoEnvio)
                .Include(e => e.Estado)
                .Where(e => e.NumeroGuia.Contains(filtro) ||
                            e.ClienteRemitente.Nombre.Contains(filtro) ||
                            e.ClienteRemitente.Apellido.Contains(filtro) ||
                            e.ClienteDestinatario.Nombre.Contains(filtro) ||
                            e.ClienteDestinatario.Apellido.Contains(filtro))
                .ToListAsync();
        }

        // ==========================================
        // MÓDULO DE ENVÍOS ENTRADAS Y SALIDAS
        // ==========================================

        public async Task<List<Envio>> ObtenerEnviosPorEstadoAsync(int idEstado)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Envios
                .Include(e => e.Agencia)
                .Include(e => e.ClienteRemitente)
                .Include(e => e.ClienteDestinatario)
                .Include(e => e.TipoEnvio)
                .Include(e => e.Estado)
                .Where(e => e.IdEstado == idEstado)
                .OrderByDescending(e => e.FechaEnvio)
                .ToListAsync();
        }

        // Método universal para cambiar el estado de un envío de forma controlada
        public async Task<bool> CambiarEstadoEnvioAsync(int idEnvio, int nuevoIdEstado, int idUsuarioAuditoria)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var envio = await context.Envios.FindAsync(idEnvio);
            if (envio == null) return false;

            int estadoAnterior = (int)envio.IdEstado;
            envio.IdEstado = nuevoIdEstado;

            // Si el nuevo estado es 5 (Entregado), marcamos la fecha de entrega real
            if (nuevoIdEstado == 5)
            {
                envio.FechaEntregaReal = DateTime.Now;
            }
            else
            {
                envio.FechaEntregaReal = null; // Por si se revierte
            }

            var auditoria = new AuditoriaUsuario
            {
                IdUsuario = idUsuarioAuditoria,
                Accion = $"AVANZAR_ESTADO_{nuevoIdEstado}",
                UsuarioSistema = "Entregas / Salidas",
                Detalle = $"Se movió el envío {envio.NumeroGuia} del estado {estadoAnterior} al estado {nuevoIdEstado}",
                FechaRegistro = DateTime.Now
            };

            await context.AuditoriaUsuarios.AddAsync(auditoria);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<Envio>> ObtenerEnviosPendientesAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Envios
                .Include(e => e.Agencia)
                .Include(e => e.ClienteRemitente)
                .Include(e => e.ClienteDestinatario)
                .Include(e => e.TipoEnvio)
                .Include(e => e.Estado)
                .Where(e => e.Estado == null || e.Estado.Nombre != "Entregado") // Trae todo lo que NO esté entregado por nombre de estado
                .OrderByDescending(e => e.FechaEnvio)
                .ToListAsync();
        }
        // Registrar la salida/entrega de un envío corregido con IdEstado y las propiedades de AuditoriaUsuario
        public async Task<bool> RegistrarEntregaEnvioAsync(int idEnvio, int idUsuarioAuditoria)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var envio = await context.Envios.FindAsync(idEnvio);
            if (envio == null) return false;

            envio.FechaEntregaReal = DateTime.Now;
            envio.IdEstado = 5; // Estado Entregado (ajustar según tu catálogo)

            // Registro de auditoría adaptado a las propiedades reales de tu modelo
            var auditoria = new AuditoriaUsuario
            {
                IdUsuario = idUsuarioAuditoria,
                Accion = "ENTREGAR_ENVIO",
                UsuarioSistema = "Entregas / Salidas", // Propiedad correcta en tu modelo de auditoría
                Detalle = $"Se entregó el envío con guía {envio.NumeroGuia}",
                FechaRegistro = DateTime.Now
            };

            await context.AuditoriaUsuarios.AddAsync(auditoria);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<Envio>> ObtenerEnviosHistorialAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Envios
                .Include(e => e.Agencia)
                .Include(e => e.ClienteRemitente)
                .Include(e => e.ClienteDestinatario)
                .Include(e => e.TipoEnvio)
                .Include(e => e.Estado)
                .Where(e => e.IdEstado == 5 || e.FechaEntregaReal != null) // Asumiendo ID 5 o con fecha real de entrega
                .OrderByDescending(e => e.FechaEnvio)
                .ToListAsync();
        }

        public async Task<bool> RevertirEntregaEnvioAsync(int idEnvio, int idUsuarioAuditoria)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var envio = await context.Envios.FindAsync(idEnvio);
            if (envio == null) return false;

            // Revertir valores de entrega
            envio.FechaEntregaReal = null;
            envio.IdEstado = 1; // Regresa al estado inicial pendiente (ej. Registrado o En Bodega)

            var auditoria = new AuditoriaUsuario
            {
                IdUsuario = idUsuarioAuditoria,
                Accion = "REVERTIR_ENTREGA",
                UsuarioSistema = "Entregas / Salidas",
                Detalle = $"Se revirtió la entrega del envío con guía {envio.NumeroGuia}",
                FechaRegistro = DateTime.Now
            };

            await context.AuditoriaUsuarios.AddAsync(auditoria);
            return await context.SaveChangesAsync() > 0;
        }

        // Balance General
        public async Task<List<CuentaBalance>> ObtenerCuentasBalanceAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.CuentaBalances
                .OrderBy(c => c.Tipo)
                .ThenBy(c => c.NombreCuenta)
                .ToListAsync();
        }

        public async Task<bool> GuardarCuentaBalanceAsync(CuentaBalance cuenta)
        {
            await using var context = await _factory.CreateDbContextAsync();
            if (cuenta.IdCuenta == 0)
            {
                await context.CuentaBalances.AddAsync(cuenta);
            }
            else
            {
                context.CuentaBalances.Update(cuenta);
            }
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> EliminarCuentaBalanceAsync(int idCuenta)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var cuenta = await context.CuentaBalances.FindAsync(idCuenta);
            if (cuenta == null) return false;

            context.CuentaBalances.Remove(cuenta);
            int filasAfectadas = await context.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<List<CuentaBalance>> ObtenerCuentasBalancePorAnioAsync(int anio)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.CuentaBalances
                .Where(c => c.Anio == anio)
                .OrderBy(c => c.Tipo)
                .ThenBy(c => c.NombreCuenta)
                .ToListAsync();
        }
        /*public async Task<List<int>> ObtenerAniosDisponiblesAsync()
        {
            return await context.CuentaBalances
                .Select(c => c.Anio)
                .Distinct()
                .OrderByDescending(a => a)
                .ToListAsync();
        }*/

        // Años fiscales exclusivos para Balance General (Activos, Pasivos, Patrimonio)
        public List<int> ObtenerAniosBalance()
        {
            using var context = _factory.CreateDbContext();
            return context.CuentaBalances
                .Where(c => c.Tipo == "Activos corrientes" || c.Tipo == "Activos fijos" ||
                            c.Tipo == "Pasivos Corrientes" || c.Tipo == "Pasivos fijos" ||
                            c.Tipo == "Patrimonio")
                .Select(c => c.Anio)
                .Distinct()
                .OrderByDescending(a => a)
                .ToList();
        }
        public List<CuentaBalance> ObtenerCuentasBalancePorAnio(int anio)
        {
            using var context = _factory.CreateDbContext();
            return context.CuentaBalances
                .Where(c => c.Anio == anio && (
                    c.Tipo == "Activos corrientes" ||
                    c.Tipo == "Activos fijos" ||
                    c.Tipo == "Pasivos Corrientes" ||
                    c.Tipo == "Pasivos fijos" ||
                    c.Tipo == "Patrimonio"))
                .OrderBy(c => c.Tipo)
                .ThenBy(c => c.NombreCuenta)
                .ToList();
        }

        // Años fiscales exclusivos para Estado de Resultados (Ingresos, Costos, Gastos)
        public List<int> ObtenerAniosResultados()
        {
            using var context = _factory.CreateDbContext();
            return context.CuentaBalances
                .Where(c => c.Tipo == "Ingresos" || c.Tipo == "Costos" || c.Tipo == "Gastos")
                .Select(c => c.Anio)
                .Distinct()
                .OrderByDescending(a => a)
                .ToList();
        }
        public List<CuentaBalance> ObtenerCuentasResultadosPorAnio(int anio)
        {
            using var context = _factory.CreateDbContext();
            return context.CuentaBalances
                .Where(c => c.Anio == anio && (
                    c.Tipo == "Ingresos" ||
                    c.Tipo == "Costos" ||
                    c.Tipo == "Gastos"))
                .OrderBy(c => c.Tipo)
                .ThenBy(c => c.NombreCuenta)
                .ToList();
        }

        public List<CuentaBalance> ObtenerCuentasParaAnalisisHorizontal(int anioActual, int anioAnterior, string tipoModulo)
        {
            using var context = _factory.CreateDbContext();
            // Definimos los filtros según si es Balance General o Estado de Resultados
            var tiposFiltro = tipoModulo == "Balance"
                ? new[] { "Activos corrientes", "Activos fijos", "Pasivos Corrientes", "Pasivos fijos", "Patrimonio" }
                : new[] { "Ingresos", "Costos", "Gastos" };

            // Obtenemos las cuentas de ambos años
            var cuentasActuales = context.CuentaBalances
                .Where(c => c.Anio == anioActual && tiposFiltro.Contains(c.Tipo))
                .ToList();

            var cuentasAnteriores = context.CuentaBalances
                .Where(c => c.Anio == anioAnterior && tiposFiltro.Contains(c.Tipo))
                .ToList();

            // Cruzamos los datos por nombre y tipo de cuenta para comparar peras con peras
            foreach (var actual in cuentasActuales)
            {
                var anterior = cuentasAnteriores.FirstOrDefault(c => c.NombreCuenta.Equals(actual.NombreCuenta, StringComparison.OrdinalIgnoreCase));
                decimal saldoAnterior = anterior != null ? anterior.Saldo : 0;

                // Cálculos horizontales
                actual.VariacionAbsoluta = actual.Saldo - saldoAnterior;

                if (saldoAnterior != 0)
                {
                    actual.VariacionPorcentual = (actual.VariacionAbsoluta / saldoAnterior) * 100;
                }
                else
                {
                    actual.VariacionPorcentual = actual.Saldo > 0 ? 100 : 0; // Evitar división por cero
                }
            }

            return cuentasActuales.OrderBy(c => c.Tipo).ThenBy(c => c.NombreCuenta).ToList();
        }
    }
}