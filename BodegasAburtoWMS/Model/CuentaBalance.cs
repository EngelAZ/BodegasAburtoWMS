using System.ComponentModel.DataAnnotations;

namespace BodegasAburtoWMS.Model
{
    public class CuentaBalance
    {
        [Key]
        public int IdCuenta { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCuenta { get; set; } // Ej: "Efectivo y Equivalentes", "Cuentas por Pagar"

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; } // "Activo", "Pasivo", "Patrimonio"

        public decimal Saldo { get; set; }

        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}