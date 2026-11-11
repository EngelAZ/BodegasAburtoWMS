using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BodegasAburtoWMS.Model
{
    public class PresupuestoTrimestral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Anio { get; set; } // Ej. 2027

        [Required]
        public int Trimestre { get; set; } // 1, 2, 3 o 4

        // Operativo
        public decimal VentasBodegaje { get; set; }
        public decimal VentasDomicilio { get; set; }
        public decimal CostoVentas { get; set; }
        public decimal GastosVenta { get; set; }
        public decimal GastosAdministracion { get; set; }

        // Caja y Tesorería
        public decimal CobranzasAgencias { get; set; } // Aplicando modelo de cobranza
        public decimal PagosCompras { get; set; }
        public decimal GastosEfectivo { get; set; }
        public decimal RetirosPropietarios { get; set; }
        public decimal AportesRequeridos { get; set; } // Calculado si hay déficit frente al saldo mínimo
        public decimal SaldoFinalEfectivo { get; set; }

        public DateTime UltimaActualizacion { get; set; } = DateTime.Now;
    }
}
