using System;

namespace BodegasAburtoWMS.Service
{
    /// <summary>
    /// Regla monetaria única de ABURTO WMS (NIO): redondear cada saldo de
    /// cuenta a centavos antes de persistirlo y antes de sumar importes de
    /// presentación. No truncar; 0.005 redondea alejándose de cero.
    /// Para cálculos intermedios (tasas, porcentajes, depreciaciones), conservar
    /// toda la precisión decimal y redondear al terminar el importe de la cuenta.
    /// </summary>
    public static class PrecisionMonetaria
    {
        public static decimal Redondear(decimal importe) =>
            decimal.Round(importe, 2, MidpointRounding.AwayFromZero);
    }
}
