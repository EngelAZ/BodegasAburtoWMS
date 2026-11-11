using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BodegasAburtoWMS.Model
{
    public class PresupuestoParametro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Anio { get; set; } // Ej. 2027

        [Required]
        [StringLength(100)]
        public string Clave { get; set; } // Ej. "BultosBodegaje", "TarifaBulto"

        [Required]
        public decimal Valor { get; set; } // Ej. 2520, 60.0

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
