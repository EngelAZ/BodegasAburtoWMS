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
            var datos = lineas.ToList();
            decimal S(GrupoCuentaFinanciera g) => datos.Where(x => x.Grupo == g).Sum(x => x.Importe);
            decimal corriente = S(GrupoCuentaFinanciera.ActivoCorriente);
            decimal noCorriente = S(GrupoCuentaFinanciera.ActivoNoCorriente);
            decimal contra = S(GrupoCuentaFinanciera.ContraActivo);
            decimal pasivoCorriente = S(GrupoCuentaFinanciera.PasivoCorriente);
            decimal pasivoNoCorriente = S(GrupoCuentaFinanciera.PasivoNoCorriente);
            decimal patrimonioBruto = S(GrupoCuentaFinanciera.Patrimonio);
            decimal contraPatrimonio = S(GrupoCuentaFinanciera.ContraPatrimonio);
            decimal patrimonio = patrimonioBruto - contraPatrimonio;
            decimal activos = corriente + noCorriente - contra;
            decimal pasivos = pasivoCorriente + pasivoNoCorriente;
            return new BalanceCalculado
            {
                ActivoCorriente = corriente,
                ActivoNoCorrienteBruto = noCorriente,
                ContraActivo = contra,
                TotalActivos = activos,
                PasivoCorriente = pasivoCorriente,
                PasivoNoCorriente = pasivoNoCorriente,
                TotalPasivos = pasivos,
                PatrimonioBruto = patrimonioBruto,
                ContraPatrimonio = contraPatrimonio,
                Patrimonio = patrimonio,
                Diferencia = activos - (pasivos + patrimonio)
            };
        }

        public static ResultadosCalculados CalcularResultados(IEnumerable<LineaEstadoFinanciero> lineas)
        {
            var datos = lineas.ToList();
            decimal S(GrupoCuentaFinanciera g) => datos.Where(x => x.Grupo == g).Sum(x => x.Importe);
            decimal ingresos = S(GrupoCuentaFinanciera.IngresoOperativo);
            decimal costos = S(GrupoCuentaFinanciera.CostoServicio);
            decimal bruta = ingresos - costos;
            decimal gastosOperativos = S(GrupoCuentaFinanciera.GastoAdministrativo)
                                     + S(GrupoCuentaFinanciera.GastoVenta)
                                     + S(GrupoCuentaFinanciera.GastoDepreciacion);
            decimal operativa = bruta - gastosOperativos;
            decimal otrosIngresos = S(GrupoCuentaFinanciera.OtroIngreso);
            decimal financierosYOtros = S(GrupoCuentaFinanciera.GastoFinanciero)
                                       + S(GrupoCuentaFinanciera.OtroGasto);
            decimal antesImpuestos = operativa + otrosIngresos - financierosYOtros;
            decimal impuesto = S(GrupoCuentaFinanciera.ImpuestoRenta);
            return new ResultadosCalculados
            {
                IngresosOperativos = ingresos,
                CostoServicios = costos,
                UtilidadBruta = bruta,
                GastosOperativos = gastosOperativos,
                UtilidadOperativa = operativa,
                OtrosIngresos = otrosIngresos,
                GastosFinancierosYOtros = financierosYOtros,
                UtilidadAntesImpuestos = antesImpuestos,
                ImpuestoRenta = impuesto,
                UtilidadNeta = antesImpuestos - impuesto
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
                    decimal? baseValor = baseLinea?.Importe;
                    decimal? actualValor = actualLinea?.Importe;
                    decimal diferencia = (actualValor ?? 0m) - (baseValor ?? 0m);
                    decimal? porcentaje = baseValor.HasValue && baseValor.Value != 0m
                        ? diferencia / Math.Abs(baseValor.Value) * 100m : null;
                    return new ComparacionFinanciera(codigo, nombre, grupo,
                        baseValor, actualValor, diferencia, porcentaje);
                }).ToList();
        }
    }
}
