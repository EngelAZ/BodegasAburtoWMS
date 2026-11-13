using System;
using System.Collections.Generic;
using System.Linq;
using BodegasAburtoWMS.Model;

namespace BodegasAburtoWMS.Service
{
    /// <summary>
    /// Calculos de dominio sin acceso a BD ni controles WinForms. Los importes
    /// de costos/gastos/contra-activos se capturan positivos y se restan aqui.
    /// </summary>
    public static class CalculadoraEstadosFinancieros
    {
        public static bool EsBalance(GrupoCuentaFinanciera grupo) => grupo switch
        {
            GrupoCuentaFinanciera.ActivoCorriente or
            GrupoCuentaFinanciera.ActivoNoCorriente or
            GrupoCuentaFinanciera.ContraActivo or
            GrupoCuentaFinanciera.PasivoCorriente or
            GrupoCuentaFinanciera.PasivoNoCorriente or
            GrupoCuentaFinanciera.Patrimonio or
            GrupoCuentaFinanciera.ContraPatrimonio => true,
            _ => false
        };

        public static BalanceCalculado CalcularBalance(IEnumerable<LineaEstadoFinanciero> lineas)
        {
            // Mantener TODOS los decimales almacenados hasta finalizar cada total.
            // No sumar valores individuales ya redondeados para visualizarlos.
            var datos = lineas.ToList();
            decimal S(GrupoCuentaFinanciera grupo) =>
                datos.Where(x => x.Grupo == grupo).Sum(x => x.Importe);

            decimal corriente = S(GrupoCuentaFinanciera.ActivoCorriente);
            decimal noCorriente = S(GrupoCuentaFinanciera.ActivoNoCorriente);
            decimal contraActivo = S(GrupoCuentaFinanciera.ContraActivo);
            decimal pasivoCorriente = S(GrupoCuentaFinanciera.PasivoCorriente);
            decimal pasivoNoCorriente = S(GrupoCuentaFinanciera.PasivoNoCorriente);
            decimal patrimonioBruto = S(GrupoCuentaFinanciera.Patrimonio);
            decimal contraPatrimonio = S(GrupoCuentaFinanciera.ContraPatrimonio);

            decimal activosRaw = corriente + noCorriente - contraActivo;
            decimal pasivosRaw = pasivoCorriente + pasivoNoCorriente;
            decimal patrimonioRaw = patrimonioBruto - contraPatrimonio;

            // Comprobación contable coherente con los TRES totales presentados.
            // Una diferencia de 0.01 NO se oculta ni se tolera automáticamente.
            decimal activos = PrecisionMonetaria.Redondear(activosRaw);
            decimal pasivos = PrecisionMonetaria.Redondear(pasivosRaw);
            decimal patrimonio = PrecisionMonetaria.Redondear(patrimonioRaw);
            return new BalanceCalculado
            {
                ActivoCorriente = PrecisionMonetaria.Redondear(corriente),
                ActivoNoCorrienteBruto = PrecisionMonetaria.Redondear(noCorriente),
                ContraActivo = PrecisionMonetaria.Redondear(contraActivo),
                TotalActivos = activos,
                PasivoCorriente = PrecisionMonetaria.Redondear(pasivoCorriente),
                PasivoNoCorriente = PrecisionMonetaria.Redondear(pasivoNoCorriente),
                TotalPasivos = pasivos,
                PatrimonioBruto = PrecisionMonetaria.Redondear(patrimonioBruto),
                ContraPatrimonio = PrecisionMonetaria.Redondear(contraPatrimonio),
                Patrimonio = patrimonio,
                Diferencia = activos - (pasivos + patrimonio)
            };
        }

        public static ResultadosCalculados CalcularResultados(IEnumerable<LineaEstadoFinanciero> lineas)
        {
            var datos = lineas.ToList();
            decimal S(GrupoCuentaFinanciera grupo) =>
                datos.Where(x => x.Grupo == grupo).Sum(x => x.Importe);
            decimal ingresos = S(GrupoCuentaFinanciera.IngresoOperativo);
            decimal costos = S(GrupoCuentaFinanciera.CostoServicio);
            decimal utilidadBruta = ingresos - costos;
            decimal gastosOperativos = S(GrupoCuentaFinanciera.GastoAdministrativo)
                                    + S(GrupoCuentaFinanciera.GastoVenta)
                                    + S(GrupoCuentaFinanciera.GastoDepreciacion);
            decimal utilidadOperativa = utilidadBruta - gastosOperativos;
            decimal otrosIngresos = S(GrupoCuentaFinanciera.OtroIngreso);
            decimal financierosYOtros = S(GrupoCuentaFinanciera.GastoFinanciero)
                                       + S(GrupoCuentaFinanciera.OtroGasto);
            decimal antesImpuestos = utilidadOperativa + otrosIngresos - financierosYOtros;
            decimal impuesto = S(GrupoCuentaFinanciera.ImpuestoRenta);
            return new ResultadosCalculados
            {
                IngresosOperativos = PrecisionMonetaria.Redondear(ingresos),
                CostoServicios = PrecisionMonetaria.Redondear(costos),
                UtilidadBruta = PrecisionMonetaria.Redondear(utilidadBruta),
                GastosOperativos = PrecisionMonetaria.Redondear(gastosOperativos),
                UtilidadOperativa = PrecisionMonetaria.Redondear(utilidadOperativa),
                OtrosIngresos = PrecisionMonetaria.Redondear(otrosIngresos),
                GastosFinancierosYOtros = PrecisionMonetaria.Redondear(financierosYOtros),
                UtilidadAntesImpuestos = PrecisionMonetaria.Redondear(antesImpuestos),
                ImpuestoRenta = PrecisionMonetaria.Redondear(impuesto),
                UtilidadNeta = PrecisionMonetaria.Redondear(antesImpuestos - impuesto)
            };
        }

        public static decimal? AnalisisVertical(decimal importe, decimal baseMonetaria) =>
            baseMonetaria == 0 ? null : importe / baseMonetaria * 100m;

        /// <summary>
        /// Full outer join por codigo estable. Ausencias distintas de importe 0.
        /// Diferencia: actual-base; %: diferencia / ABS(base) * 100.
        /// Con base 0 o no presente: porcentaje indefinido (null), NUNCA 100%.
        /// </summary>
        public static List<ComparacionFinanciera> Comparar(
            IEnumerable<LineaEstadoFinanciero> anterior,
            IEnumerable<LineaEstadoFinanciero> actual)
        {
            var a = anterior.ToDictionary(x => x.Codigo, StringComparer.OrdinalIgnoreCase);
            var b = actual.ToDictionary(x => x.Codigo, StringComparer.OrdinalIgnoreCase);
            return a.Keys.Union(b.Keys, StringComparer.OrdinalIgnoreCase)
                .OrderBy(c => b.TryGetValue(c, out var actualLinea) ? actualLinea.OrdenPresentacion : a[c].OrdenPresentacion)
                .ThenBy(c => c, StringComparer.OrdinalIgnoreCase)
                .Select(codigo =>
                {
                    a.TryGetValue(codigo, out var baseLinea);
                    b.TryGetValue(codigo, out var actualLinea);
                    var nombre = actualLinea?.Nombre ?? baseLinea!.Nombre;
                    var grupo = actualLinea?.Grupo ?? baseLinea!.Grupo;
                    decimal? baseRaw = baseLinea?.Importe;
                    decimal? actualRaw = actualLinea?.Importe;
                    decimal diferenciaRaw = (actualRaw ?? 0m) - (baseRaw ?? 0m);
                    decimal? porcentaje = baseRaw.HasValue && baseRaw.Value != 0m
                        ? diferenciaRaw / Math.Abs(baseRaw.Value) * 100m : null;
                    decimal? baseValor = baseRaw.HasValue ? PrecisionMonetaria.Redondear(baseRaw.Value) : null;
                    decimal? actualValor = actualRaw.HasValue ? PrecisionMonetaria.Redondear(actualRaw.Value) : null;
                    decimal diferencia = PrecisionMonetaria.Redondear(diferenciaRaw);
                    return new ComparacionFinanciera(codigo, nombre, grupo,
                        baseValor, actualValor, diferencia, porcentaje);
                }).ToList();
        }
    }
}
