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
        private readonly BodegaDbContext _context;

        // Inyección de dependencias única del DbContext
        public BodegasAburtoWMSRepository(BodegaDbContext context)
        {
            _context = context;
        }

        // ==========================================
        // MÓDULO DE USUARIOS Y AUTENTICACIÓN
        // ==========================================

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .OrderBy(u => u.IdUsuario)
                .ToListAsync();
        }

        public async Task<Usuario?> ObtenerUsuarioPorNombreAsync(string usuario)
        {
            return await _context.Usuarios
                .Include(u => u.Rol) // Equivalente al INNER JOIN con Roles
                .FirstOrDefaultAsync(u => u.UsuarioNombre == usuario && u.Activo);
        }

        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            // Validar si el nombre de usuario ya existe
            bool existe = await _context.Usuarios.AnyAsync(u => u.UsuarioNombre == usuario.UsuarioNombre);
            if (existe) return false; // Usuario duplicado

            await _context.Usuarios.AddAsync(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DesactivarUsuarioAsync(int idUsuario)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null) return false;

            usuario.Activo = false;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task RegistrarUltimoAccesoAsync(int idUsuario)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario != null)
            {
                usuario.UltimoAcceso = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RegistrarAuditoriaAsync(int idUsuario, string accion, string usuarioSistema, string detalle)
        {
            var auditoria = new AuditoriaUsuario
            {
                IdUsuario = idUsuario,
                Accion = accion,
                UsuarioSistema = usuarioSistema,
                Detalle = detalle,
                FechaRegistro = DateTime.Now
            };

            await _context.AuditoriaUsuarios.AddAsync(auditoria);
            await _context.SaveChangesAsync();
        }

        // ==========================================
        // MÓDULO DE CATÁLOGOS (COMBOBOXES)
        // ==========================================

        public async Task<List<ComboboxItem>> ObtenerAgenciasComboAsync()
        {
            return await _context.Agencias
                .Select(a => new ComboboxItem { Value = a.IdAgencia, Text = a.Nombre })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerTiposEnvioComboAsync()
        {
            return await _context.TiposEnvio
                .Select(t => new ComboboxItem { Value = t.IdTipoEnvio, Text = t.Nombre })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerEstadosEnvioComboAsync()
        {
            return await _context.EstadosEnvio
                .Select(e => new ComboboxItem { Value = e.IdEstado, Text = e.Nombre })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerClientesComboAsync()
        {
            return await _context.Clientes
                .Select(c => new ComboboxItem
                {
                    Value = c.IdCliente,
                    Text = (c.Nombre + " " + c.Apellido).Trim()
                })
                .ToListAsync();
        }

        public async Task<List<ComboboxItem>> ObtenerRolesComboAsync()
        {
            return await _context.Roles
                .Select(r => new ComboboxItem { Value = r.IdRol, Text = r.Nombre })
                .ToListAsync();
        }

        // ==========================================
        // MÓDULO DE AGENCIAS
        // ==========================================

        public async Task<List<Agencia>> ObtenerAgenciasAsync()
        {
            return await _context.Agencias
                .OrderByDescending(a => a.FechaRegistro)
                .ToListAsync();
        }

        public async Task<List<Agencia>> BuscarAgenciasAsync(string filtro)
        {
            return await _context.Agencias
                .Where(a => a.Nombre.Contains(filtro) || (a.Ciudad != null && a.Ciudad.Contains(filtro)))
                .ToListAsync();
        }

        public async Task<bool> GuardarAgenciaAsync(Agencia agencia)
        {
            if (agencia.IdAgencia == 0)
            {
                await _context.Agencias.AddAsync(agencia);
            }
            else
            {
                _context.Agencias.Update(agencia);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        // ==========================================
        // MÓDULO DE CLIENTES
        // ==========================================

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _context.Clientes
                .OrderByDescending(c => c.FechaRegistro)
                .ToListAsync();
        }

        public async Task<List<Cliente>> BuscarClientesAsync(string filtro)
        {
            return await _context.Clientes
                .Where(c => c.Nombre.Contains(filtro) || c.Apellido.Contains(filtro) || (c.NumeroCedula != null && c.NumeroCedula.Contains(filtro)))
                .ToListAsync();
        }

        public async Task<bool> GuardarClienteAsync(Cliente cliente)
        {
            if (cliente.IdCliente == 0)
            {
                await _context.Clientes.AddAsync(cliente);
            }
            else
            {
                _context.Clientes.Update(cliente);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        // ==========================================
        // MÓDULO DE ENVÍOS Y REGISTRO DIARIO
        // ==========================================

        public async Task<bool> RegistrarEnvioAsync(Envio envio)
        {
            await _context.Envios.AddAsync(envio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Envio>> ObtenerEnviosAsync()
        {
            return await _context.Envios
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
            return await _context.Envios
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
            return await _context.Envios
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
            var envio = await _context.Envios.FindAsync(idEnvio);
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

            await _context.AuditoriaUsuarios.AddAsync(auditoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Envio>> ObtenerEnviosPendientesAsync()
        {
            return await _context.Envios
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
            var envio = await _context.Envios.FindAsync(idEnvio);
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

            await _context.AuditoriaUsuarios.AddAsync(auditoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Envio>> ObtenerEnviosHistorialAsync()
        {
            return await _context.Envios
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
            var envio = await _context.Envios.FindAsync(idEnvio);
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

            await _context.AuditoriaUsuarios.AddAsync(auditoria);
            return await _context.SaveChangesAsync() > 0;
        }

        // Balance General
        public async Task<List<CuentaBalance>> ObtenerCuentasBalanceAsync()
        {
            return await _context.CuentaBalances
                .OrderBy(c => c.Tipo)
                .ThenBy(c => c.NombreCuenta)
                .ToListAsync();
        }

        public async Task<bool> GuardarCuentaBalanceAsync(CuentaBalance cuenta)
        {
            if (cuenta.IdCuenta == 0)
            {
                await _context.CuentaBalances.AddAsync(cuenta);
            }
            else
            {
                _context.CuentaBalances.Update(cuenta);
            }
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> EliminarCuentaBalanceAsync(int idCuenta)
        {
            var cuenta = await _context.CuentaBalances.FindAsync(idCuenta);
            if (cuenta == null) return false;

            _context.CuentaBalances.Remove(cuenta);
            int filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas > 0;
        }
    }
}