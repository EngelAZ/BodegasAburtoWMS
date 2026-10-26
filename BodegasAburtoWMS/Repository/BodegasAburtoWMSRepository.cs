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
                .Include(e => e.Estado)
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
    }
}