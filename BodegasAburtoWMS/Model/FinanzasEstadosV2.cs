using System;
using System.Collections.Generic;

namespace BodegasAburtoWMS.Model
{
    // Categorias tipadas: el codigo es estable entre ejercicios.
    public enum GrupoCuentaFinanciera
    {
        ActivoCorriente = 1,
        ActivoNoCorriente = 2,
        ContraActivo = 3,
        PasivoCorriente = 4,
        PasivoNoCorriente = 5,
        Patrimonio = 6,
        IngresoOperativo = 7,
        CostoServicio = 8,
        GastoAdministrativo = 9,
        GastoVenta = 10,
        GastoDepreciacion = 11,
        OtroIngreso = 12,
        GastoFinanciero = 13,
        OtroGasto = 14,
        ImpuestoRenta = 15,
        ContraPatrimonio = 16 // Agregado al final para conservar valores previos
    }

    public enum NaturalezaCuentaFinanciera { Deudora = 1, Acreedora = 2 }

    public class CatalogoCuentaFinanciera
    {
        public int IdCuentaFinanciera { get; set; }
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public GrupoCuentaFinanciera Grupo { get; set; }
        public NaturalezaCuentaFinanciera Naturaleza { get; set; }
        public bool Activa { get; set; } = true;
        public int OrdenPresentacion { get; set; }
        public string? Nota { get; set; }
        public List<SaldoCuentaFinanciera> Saldos { get; set; } = new();
    }

    public class EjercicioFinanciero
    {
        public int IdEjercicioFinanciero { get; set; }
        public int Anio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Escenario { get; set; } = "Academico"; // Real, Academico o Proyectado
        public string Estado { get; set; } = "Borrador"; // Borrador o Cerrado
        public string Moneda { get; set; } = "NIO";
        public string? FuenteDatos { get; set; }
        public DateTime CreadoUtc { get; set; } = DateTime.UtcNow;
        public List<SaldoCuentaFinanciera> Saldos { get; set; } = new();
        public List<CambioEstadoEjercicioFinanciero> HistorialEstados { get; set; } = new();
    }

    // Auditoría de cierres y reaperturas; nunca se reemplaza una entrada anterior.
    public class CambioEstadoEjercicioFinanciero
    {
        public int IdCambioEstado { get; set; }
        public int IdEjercicioFinanciero { get; set; }
        public string EstadoAnterior { get; set; } = "";
        public string EstadoNuevo { get; set; } = "";
        public string Motivo { get; set; } = "";
        public DateTime FechaUtc { get; set; } = DateTime.UtcNow;
        public EjercicioFinanciero Ejercicio { get; set; } = null!;
    }

    public class SaldoCuentaFinanciera
    {
        public int IdSaldoFinanciero { get; set; }
        public int IdEjercicioFinanciero { get; set; }
        public int IdCuentaFinanciera { get; set; }
        // Todos los importes son magnitudes con signo; contra-activos se restan en el reporte.
        public decimal Importe { get; set; }
        public DateTime ActualizadoUtc { get; set; } = DateTime.UtcNow;
        public byte[] Version { get; set; } = Array.Empty<byte>();
        public EjercicioFinanciero Ejercicio { get; set; } = null!;
        public CatalogoCuentaFinanciera Cuenta { get; set; } = null!;
    }

    // DTO independiente de EF y WinForms: reutilizable en razones financieras y Dupont.
    public record LineaEstadoFinanciero(string Codigo, string Nombre, GrupoCuentaFinanciera Grupo, decimal Importe, int OrdenPresentacion = 0);
    public record ComparacionFinanciera(
        string Codigo, string Nombre, GrupoCuentaFinanciera Grupo,
        decimal? Base, decimal? Actual, decimal Diferencia, decimal? VariacionPorcentual)
    {
        public string VariacionTexto => VariacionPorcentual.HasValue
            ? $"{VariacionPorcentual.Value:N2}%" : "N/A (base cero o ausente)";
    }

    public class BalanceCalculado
    {
        public decimal ActivoCorriente { get; set; }
        public decimal ActivoNoCorrienteBruto { get; set; }
        public decimal ContraActivo { get; set; }
        public decimal TotalActivos { get; set; }
        public decimal PasivoCorriente { get; set; }
        public decimal PasivoNoCorriente { get; set; }
        public decimal TotalPasivos { get; set; }
        // Total final calculado a partir de pasivos y patrimonio SIN redondear.
        public decimal TotalPasivosMasPatrimonio { get; set; }
        public decimal PatrimonioBruto { get; set; }
        public decimal ContraPatrimonio { get; set; }
        public decimal Patrimonio { get; set; }
        public decimal Diferencia { get; set; }
        // Los saldos ya están expresados en centavos; no considerar cuadrado
        // un estado con un centavo de diferencia.
        public bool EstaCuadrado => Diferencia == 0m;
    }

    public class ResultadosCalculados
    {
        public decimal IngresosOperativos { get; set; }
        public decimal CostoServicios { get; set; }
        public decimal UtilidadBruta { get; set; }
        public decimal GastosOperativos { get; set; }
        public decimal UtilidadOperativa { get; set; }
        public decimal OtrosIngresos { get; set; }
        public decimal GastosFinancierosYOtros { get; set; }
        public decimal UtilidadAntesImpuestos { get; set; }
        public decimal ImpuestoRenta { get; set; }
        public decimal UtilidadNeta { get; set; }
    }

    public class EjercicioSnapshot
    {
        public EjercicioFinanciero Ejercicio { get; init; } = null!;
        public List<LineaEstadoFinanciero> Lineas { get; init; } = new();
    }
}
