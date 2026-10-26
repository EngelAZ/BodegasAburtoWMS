using System;
using System.Collections.Generic;
using System.Text;

namespace BodegasAburtoWMS.Model
{
    public class Agencia
    {
        public int IdAgencia { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Contacto { get; set; }
        public string? Telefono { get; set; }
        public string? Ciudad { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
