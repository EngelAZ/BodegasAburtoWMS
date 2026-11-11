using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BodegasAburtoWMS.Model
{
    public class EstadoFinancieroProforma
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Anio { get; set; } // Ej. 2027

        [Required]
        [StringLength(50)]
        public string TipoEstado { get; set; } // "Estado de Resultados" o "Balance General"

        [Required]
        [StringLength(150)]
        public string Rubro { get; set; } // Ej. "Ventas Totales", "Costo de Ventas", "Activo Circulante", etc.

        public decimal MontoProyectado { get; set; }

        public decimal MontoRealAnterior { get; set; } // Ej. Cierre 2026 para comparación

        public DateTime UltimaSincronizacion { get; set; } = DateTime.Now;
    }
}
