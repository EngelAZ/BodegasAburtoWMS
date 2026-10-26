using System;
using System.Collections.Generic;
using System.Text;

namespace BodegasAburtoWMS.Model
{
    public class TipoEnvio
    {
        public int IdTipoEnvio { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class EstadoEnvio
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class Envio
    {
        public int IdEnvio { get; set; }
        public string NumeroGuia { get; set; } = string.Empty;

        public int IdAgencia { get; set; }
        public Agencia? Agencia { get; set; }

        public int IdClienteRemitente { get; set; }
        public Cliente? ClienteRemitente { get; set; }

        public int IdClienteDestinatario { get; set; }
        public Cliente? ClienteDestinatario { get; set; }

        public int? IdTipoEnvio { get; set; }
        public TipoEnvio? TipoEnvio { get; set; }

        public int? IdEstado { get; set; }
        public EstadoEnvio? Estado { get; set; }

        public string? Origen { get; set; }
        public string? Destino { get; set; }

        public DateTime FechaEnvio { get; set; }
        public DateTime? FechaEntregaEstimada { get; set; }
        public DateTime? FechaEntregaReal { get; set; }

        public decimal CostoEnvio { get; set; }
        public string? Observaciones { get; set; }
    }
}
