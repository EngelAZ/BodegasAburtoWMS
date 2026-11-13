using System;

namespace BodegasAburtoWMS.Service
{
    /// <summary>
    /// Guarda hasta 6 decimales originales (decimal(18,6) SQL Server);
    /// redondea a 2 SOLO cuando produce el importe final que se presenta.
    /// No reemplaza ni ajusta centavos por diferencias contables.
    /// </summary>
    public static class PrecisionMonetaria
    {
        public static decimal ConservarOrigen(decimal importe) =>
            decimal.Round(importe, 6, MidpointRounding.AwayFromZero);

        public static decimal Redondear(decimal importe) =>
            decimal.Round(importe, 2, MidpointRounding.AwayFromZero);
    }
}
