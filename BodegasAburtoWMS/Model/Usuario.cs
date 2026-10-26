using System;
using System.Collections.Generic;
using System.Text;

namespace BodegasAburtoWMS.Model
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
    public class Usuario
    {
        public int IdUsuario { get; set; }

        // Mapea a la columna "Usuario" en SQL
        public string UsuarioNombre { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? Correo { get; set; }

        public int IdRol { get; set; }
        public Rol? Rol { get; set; } // Propiedad de navegación

        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public bool Activo { get; set; }
        public DateTime? UltimoAcceso { get; set; }
    }

    public class AuditoriaUsuario
    {
        public int IdAuditoria { get; set; }
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; } // Propiedad de navegación

        public string Accion { get; set; } = string.Empty;
        public string UsuarioSistema { get; set; } = string.Empty;
        public string? Detalle { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
