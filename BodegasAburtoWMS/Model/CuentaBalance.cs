using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodegasAburtoWMS.Model
{
    public class CuentaBalance
    {
        [Key]
        public int IdCuenta { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCuenta { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } // "Activos corrientes", "Activos fijos", etc.

        public decimal Saldo { get; set; }

        [Required]
        public int Anio { get; set; } // <-- Nuevo campo para el año fiscal (Ej: 2024, 2025, 2026)

        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        [NotMapped]
        public decimal PorcentajeVertical { get; set; }
    }
}