using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Service;

namespace BodegasAburtoWMS.View
{
    /// <summary>
    /// Interfaz nueva, sin modificar archivos .Designer.cs existentes.
    /// Catálogo, ejercicios, saldos y reportes comparten FinanzasEstadosService.
    /// </summary>
    public sealed class FinanzasEstadosV2Form : Form
    {
        private readonly FinanzasEstadosService _service;
        private readonly List<CatalogoCuentaFinanciera> _cuentas = new();
        private readonly List<EjercicioFinanciero> _ejercicios = new();
        private readonly Color _azul = ColorTranslator.FromHtml("#1E4D8F");
        private readonly Color _naranja = ColorTranslator.FromHtml("#F28C28");
        private bool _ocupado;

        private readonly DataGridView _tablaCuentas = NuevaTabla();
        private readonly TextBox _codigo = new() { Width = 95 };
        private readonly TextBox _nombre = new() { Width = 185 };
        private readonly ComboBox _grupo = NuevoCombo(200);
        private readonly NumericUpDown _orden = new() { Width = 70, Minimum = 0, Maximum = 100000 };
        private readonly CheckBox _activa = new() { Text = "Activa", Checked = true, AutoSize = true };
        private int _cuentaEnEdicion;

        private readonly DataGridView _tablaEjercicios = NuevaTabla();
        private readonly NumericUpDown _anio = new() { Width = 90, Minimum = 2000, Maximum = 2100 };
        private readonly ComboBox _escenario = NuevoCombo(110);
        private readonly TextBox _fuente = new() { Width = 190 };
        private readonly ComboBox _ejercicioParaCerrar = NuevoCombo(185);

        private readonly ComboBox _ejercicioCaptura = NuevoCombo(190);
        private readonly ComboBox _cuentaCaptura = NuevoCombo(280);
        private readonly NumericUpDown _importe = new()
        {
            Width = 140, Minimum = 0, Maximum = 999999999999.99m,
            DecimalPlaces = 2, ThousandsSeparator = true
        };
        private readonly DataGridView _tablaSaldos = NuevaTabla();

        private readonly ComboBox _ejercicioReporte = NuevoCombo(190);
        private readonly ComboBox _ejercicioBase = NuevoCombo(190);
        private readonly ComboBox _modoReporte = NuevoCombo(205);
        private readonly DataGridView _tablaReporte = NuevaTabla();
        private readonly TextBox _resumen = new()
        {
            Multiline = true, ReadOnly = true, Dock = DockStyle.Bottom,
            Height = 116, ScrollBars = ScrollBars.Vertical,
            BackColor = Color.White, Font = new Font("Segoe UI", 10)
        };

        public FinanzasEstadosV2Form(FinanzasEstadosService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            Text = "Estados financieros · ABURTO WMS";
            BackColor = Color.White;
            MinimumSize = new Size(840, 550);
            Size = new Size(1020, 650);

            var pestañas = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };
            pestañas.TabPages.Add(CrearCatalogo());
            pestañas.TabPages.Add(CrearEjercicios());
            pestañas.TabPages.Add(CrearCaptura());
            pestañas.TabPages.Add(CrearReportes());
            Controls.Add(pestañas);
            Shown += async (_, _) => await EjecutarAsync(RefrescarTodoAsync);
        }

        private TabPage CrearCatalogo()
        {
            var tab = new TabPage("Catálogo de cuentas") { BackColor = Color.White };
            var barra = Barra();
            barra.Controls.Add(Etiqueta("Código")); barra.Controls.Add(_codigo);
            barra.Controls.Add(Etiqueta("Nombre")); barra.Controls.Add(_nombre);
            barra.Controls.Add(Etiqueta("Grupo")); barra.Controls.Add(_grupo);
            barra.Controls.Add(Etiqueta("Orden")); barra.Controls.Add(_orden);
            barra.Controls.Add(_activa);
            var guardar = Boton("Guardar cuenta", _naranja);
            guardar.Click += async (_, _) => await EjecutarAsync(GuardarCuentaAsync);
            barra.Controls.Add(guardar);
            var nuevo = Boton("Nueva / limpiar", _azul);
            nuevo.Click += (_, _) => LimpiarCuenta();
            barra.Controls.Add(nuevo);
            _grupo.DataSource = Enum.GetValues<GrupoCuentaFinanciera>();
            _tablaCuentas.SelectionChanged += (_, _) => SeleccionarCuentaEnTabla();
            tab.Controls.Add(_tablaCuentas);
            tab.Controls.Add(barra);
            return tab;
        }

        private TabPage CrearEjercicios()
        {
            var tab = new TabPage("Ejercicios fiscales") { BackColor = Color.White };
            var barra = Barra(116);
            _anio.Value = Math.Min((int)_anio.Maximum, DateTime.Now.Year);
            _escenario.Items.AddRange(new object[] { "Academico", "Real", "Proyectado" });
            _escenario.SelectedIndex = 0;
            barra.Controls.Add(Etiqueta("Año")); barra.Controls.Add(_anio);
            barra.Controls.Add(Etiqueta("Escenario")); barra.Controls.Add(_escenario);
            barra.Controls.Add(Etiqueta("Fuente")); barra.Controls.Add(_fuente);
            var nuevo = Boton("Crear ejercicio", _naranja);
            nuevo.Click += async (_, _) => await EjecutarAsync(CrearEjercicioAsync);
            barra.Controls.Add(nuevo);
            barra.Controls.Add(Etiqueta("Cerrar ejercicio")); barra.Controls.Add(_ejercicioParaCerrar);
            var cerrar = Boton("Cerrar", _azul);
            cerrar.Click += async (_, _) => await EjecutarAsync(CerrarEjercicioAsync);
            barra.Controls.Add(cerrar);
            var importar = Boton("Importar legacy (una vez)", _azul);
            importar.Click += async (_, _) => await EjecutarAsync(ImportarLegacyAsync);
            barra.Controls.Add(importar);
            tab.Controls.Add(_tablaEjercicios);
            tab.Controls.Add(barra);
            return tab;
        }

        private TabPage CrearCaptura()
        {
            var tab = new TabPage("Saldos por ejercicio") { BackColor = Color.White };
            var barra = Barra();
            barra.Controls.Add(Etiqueta("Ejercicio")); barra.Controls.Add(_ejercicioCaptura);
            barra.Controls.Add(Etiqueta("Cuenta")); barra.Controls.Add(_cuentaCaptura);
            barra.Controls.Add(Etiqueta("C$")); barra.Controls.Add(_importe);
            var guardar = Boton("Guardar saldo", _naranja);
            guardar.Click += async (_, _) => await EjecutarAsync(GuardarSaldoAsync);
            barra.Controls.Add(guardar);
            _ejercicioCaptura.SelectedIndexChanged += async (_, _) =>
            {
                if (!_ocupado) await EjecutarAsync(RefrescarSaldosAsync);
            };
            _tablaSaldos.CellClick += (_, e) =>
            {
                if (e.RowIndex < 0) return;
                var fila = _tablaSaldos.Rows[e.RowIndex];
                if (fila.Cells["IdCuentaFinanciera"].Value is int idCuenta)
                    _cuentaCaptura.SelectedValue = idCuenta;
                if (fila.Cells["Importe"].Value is decimal val && val >= 0 && val <= _importe.Maximum)
                    _importe.Value = val;
            };
            tab.Controls.Add(_tablaSaldos);
            tab.Controls.Add(barra);
            return tab;
        }

        private TabPage CrearReportes()
        {
            var tab = new TabPage("Estados y análisis") { BackColor = Color.White };
            var barra = Barra();
            _modoReporte.Items.AddRange(new object[]
            {
                "Balance general", "Estado de resultados", "Horizontal · Balance", "Horizontal · Resultados"
            });
            _modoReporte.SelectedIndex = 0;
            barra.Controls.Add(Etiqueta("Ejercicio actual")); barra.Controls.Add(_ejercicioReporte);
            barra.Controls.Add(Etiqueta("Base")); barra.Controls.Add(_ejercicioBase);
            barra.Controls.Add(Etiqueta("Informe")); barra.Controls.Add(_modoReporte);
            var mostrar = Boton("Calcular", _naranja);
            mostrar.Click += async (_, _) => await EjecutarAsync(MostrarReporteAsync);
            barra.Controls.Add(mostrar);
            tab.Controls.Add(_tablaReporte);
            tab.Controls.Add(_resumen);
            tab.Controls.Add(barra);
            return tab;
        }

        private async Task RefrescarTodoAsync()
        {
            _cuentas.Clear();
            _cuentas.AddRange(await _service.ListarCuentasAsync());
            _ejercicios.Clear();
            _ejercicios.AddRange(await _service.ListarEjerciciosAsync());
            if (IsDisposed || Disposing) return;

            _tablaCuentas.DataSource = _cuentas.Select(c => new
            {
                c.IdCuentaFinanciera, c.Codigo, c.Nombre,
                Grupo = c.Grupo.ToString(), Naturaleza = c.Naturaleza.ToString(), c.Activa, c.OrdenPresentacion
            }).ToList();
            OcultarId(_tablaCuentas, "IdCuentaFinanciera");
            _tablaEjercicios.DataSource = _ejercicios.Select(e => new
            {
                e.IdEjercicioFinanciero, e.Anio, e.Escenario, e.Estado, e.Moneda, e.FuenteDatos
            }).ToList();
            OcultarId(_tablaEjercicios, "IdEjercicioFinanciero");
            var opcionesCuenta = _cuentas.Where(c => c.Activa)
                .OrderBy(c => c.Codigo)
                .Select(c => new Opcion(c.IdCuentaFinanciera, $"{c.Codigo} · {c.Nombre}")).ToList();
            AsignarOpciones(_cuentaCaptura, opcionesCuenta);
            var opcionesEjercicios = _ejercicios.Select(e =>
                new Opcion(e.IdEjercicioFinanciero, $"{e.Anio} · {e.Escenario} [{e.Estado}]")).ToList();
            AsignarOpciones(_ejercicioCaptura, opcionesEjercicios);
            AsignarOpciones(_ejercicioParaCerrar, opcionesEjercicios);
            AsignarOpciones(_ejercicioReporte, opcionesEjercicios);
            AsignarOpciones(_ejercicioBase, opcionesEjercicios);
            await RefrescarSaldosAsync();
        }

        private async Task GuardarCuentaAsync()
        {
            var cuenta = new CatalogoCuentaFinanciera
            {
                IdCuentaFinanciera = _cuentaEnEdicion,
                Codigo = _codigo.Text,
                Nombre = _nombre.Text,
                Grupo = (GrupoCuentaFinanciera)(_grupo.SelectedItem ?? GrupoCuentaFinanciera.ActivoCorriente),
                Activa = _activa.Checked,
                OrdenPresentacion = (int)_orden.Value
            };
            await _service.GuardarCuentaAsync(cuenta);
            await RefrescarTodoAsync();
            LimpiarCuenta();
        }

        private async Task CrearEjercicioAsync()
        {
            await _service.CrearEjercicioAsync((int)_anio.Value, _escenario.SelectedItem?.ToString() ?? "Academico", _fuente.Text.Trim());
            await RefrescarTodoAsync();
        }

        private async Task CerrarEjercicioAsync()
        {
            int id = ValorSeleccionado(_ejercicioParaCerrar);
            if (id == 0) throw new InvalidOperationException("Selecciona un ejercicio.");
            if (MessageBox.Show("¿Cerrar el ejercicio? No podrá editar sus saldos.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            await _service.CerrarEjercicioAsync(id);
            await RefrescarTodoAsync();
        }

        private async Task ImportarLegacyAsync()
        {
            if (MessageBox.Show(
                "Se importarán las cuentas de la tabla LEGACY CuentaBalances como escenario Académico. " +
                "Se cancelará si el módulo nuevo contiene datos. Los rubros importados requieren revisión manual. ¿Continuar?",
                "Importación conservadora", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            int cantidad = await _service.ImportarCuentaBalancesLegacyAsync();
            await RefrescarTodoAsync();
            MessageBox.Show($"Se importaron {cantidad} saldos. REVISA su clasificación antes de usar los reportes.");
        }

        private async Task GuardarSaldoAsync()
        {
            int ejercicioId = ValorSeleccionado(_ejercicioCaptura);
            int cuentaId = ValorSeleccionado(_cuentaCaptura);
            if (ejercicioId == 0 || cuentaId == 0)
                throw new InvalidOperationException("Selecciona ejercicio y cuenta.");
            await _service.GuardarSaldoAsync(ejercicioId, cuentaId, _importe.Value);
            await RefrescarSaldosAsync();
        }

        private async Task RefrescarSaldosAsync()
        {
            int id = ValorSeleccionado(_ejercicioCaptura);
            if (id == 0) { _tablaSaldos.DataSource = null; return; }
            var snapshot = await _service.ObtenerSnapshotAsync(id);
            if (IsDisposed || Disposing) return;
            _tablaSaldos.DataSource = snapshot.Lineas.Select(x => new
            {
                IdCuentaFinanciera = _cuentas.FirstOrDefault(c => c.Codigo == x.Codigo)?.IdCuentaFinanciera ?? 0,
                x.Codigo, x.Nombre, Grupo = x.Grupo.ToString(), Importe = x.Importe
            }).ToList();
            OcultarId(_tablaSaldos, "IdCuentaFinanciera");
            FormatearMoneda(_tablaSaldos, "Importe");
        }

        private async Task MostrarReporteAsync()
        {
            int actualId = ValorSeleccionado(_ejercicioReporte);
            if (actualId == 0) throw new InvalidOperationException("Selecciona un ejercicio con datos.");
            string modo = _modoReporte.SelectedItem?.ToString() ?? "Balance general";
            bool horizontal = modo.StartsWith("Horizontal", StringComparison.Ordinal);
            bool esBalance = modo.Contains("Balance", StringComparison.OrdinalIgnoreCase) || modo == "Balance general";
            if (horizontal)
            {
                int baseId = ValorSeleccionado(_ejercicioBase);
                if (baseId == 0) throw new InvalidOperationException("Selecciona ejercicio base.");
                var comparacion = await _service.CompararEjerciciosAsync(baseId, actualId, esBalance);
                _tablaReporte.DataSource = comparacion.Select(x => new
                {
                    x.Codigo, x.Nombre, Grupo = x.Grupo.ToString(),
                    Base = x.Base, Actual = x.Actual,
                    Diferencia = x.Diferencia, Variacion = x.VariacionTexto
                }).ToList();
                foreach (string col in new[] { "Base", "Actual", "Diferencia" }) FormatearMoneda(_tablaReporte, col);
                var anterior = await _service.ObtenerSnapshotAsync(baseId);
                var actual = await _service.ObtenerSnapshotAsync(actualId);
                if (esBalance)
                {
                    var b = CalculadoraEstadosFinancieros.CalcularBalance(anterior.Lineas);
                    var a = CalculadoraEstadosFinancieros.CalcularBalance(actual.Lineas);
                    _resumen.Text = $"Comparación {anterior.Ejercicio.Anio} → {actual.Ejercicio.Anio}: " +
                        $"Activos: C$ {b.TotalActivos:N2} → C$ {a.TotalActivos:N2}; " +
                        $"Pasivos: C$ {b.TotalPasivos:N2} → C$ {a.TotalPasivos:N2}; " +
                        $"Patrimonio: C$ {b.Patrimonio:N2} → C$ {a.Patrimonio:N2}." + Environment.NewLine +
                        "Variación absoluta = actual - base. % = variación / |base| × 100. N/A si base=0 o no existe.";
                }
                else
                {
                    var b = CalculadoraEstadosFinancieros.CalcularResultados(anterior.Lineas);
                    var a = CalculadoraEstadosFinancieros.CalcularResultados(actual.Lineas);
                    _resumen.Text = $"Comparación {anterior.Ejercicio.Anio} → {actual.Ejercicio.Anio}: " +
                        $"Utilidad bruta C$ {b.UtilidadBruta:N2} → C$ {a.UtilidadBruta:N2}; " +
                        $"Utilidad operativa C$ {b.UtilidadOperativa:N2} → C$ {a.UtilidadOperativa:N2}; " +
                        $"Utilidad neta C$ {b.UtilidadNeta:N2} → C$ {a.UtilidadNeta:N2}." + Environment.NewLine +
                        "Las cuentas que solo aparecen en uno de los ejercicios también se incluyen.";
                }
                return;
            }

            var snapshotActual = await _service.ObtenerSnapshotAsync(actualId);
            if (snapshotActual.Lineas.Count == 0)
                throw new InvalidOperationException("Este ejercicio no tiene saldos cargados.");
            decimal baseVertical = esBalance
                ? CalculadoraEstadosFinancieros.CalcularBalance(snapshotActual.Lineas).TotalActivos
                : CalculadoraEstadosFinancieros.CalcularResultados(snapshotActual.Lineas).IngresosOperativos;
            var filas = esBalance ? CrearFilasBalance(snapshotActual.Lineas) : CrearFilasResultados(snapshotActual.Lineas);
            _tablaReporte.DataSource = filas.Select(x => new
            {
                x.Seccion, x.Codigo, x.Cuenta, x.Importe,
                Vertical = CalculadoraEstadosFinancieros.AnalisisVertical(x.Importe, baseVertical) is decimal p ? $"{p:N2}%" : "N/A"
            }).ToList();
            FormatearMoneda(_tablaReporte, "Importe");
            if (esBalance)
            {
                var b = CalculadoraEstadosFinancieros.CalcularBalance(snapshotActual.Lineas);
                _resumen.Text = $"Balance General {snapshotActual.Ejercicio.Anio} ({snapshotActual.Ejercicio.Escenario})" + Environment.NewLine +
                    $"Activos C$ {b.TotalActivos:N2} = Pasivos C$ {b.TotalPasivos:N2} + Patrimonio C$ {b.Patrimonio:N2}" + Environment.NewLine +
                    $"Diferencia: C$ {b.Diferencia:N2}. Estado: {(b.EstaCuadrado ? "CUADRADO" : "NO CUADRADO — revisar saldos")}." + Environment.NewLine +
                    "La utilidad neta NO se agrega automáticamente al patrimonio: registrar explícitamente el resultado del ejercicio sin duplicarlo.";
            }
            else
            {
                var r = CalculadoraEstadosFinancieros.CalcularResultados(snapshotActual.Lineas);
                _resumen.Text = $"Resultados {snapshotActual.Ejercicio.Anio} ({snapshotActual.Ejercicio.Escenario}): " +
                    $"Bruta C$ {r.UtilidadBruta:N2} → Operativa C$ {r.UtilidadOperativa:N2} → " +
                    $"Antes de impuestos C$ {r.UtilidadAntesImpuestos:N2} → Neta C$ {r.UtilidadNeta:N2}." + Environment.NewLine +
                    "Análisis vertical: base = ingresos operativos (100%). Los importes de gastos se restan al calcular utilidades.";
            }
        }

        private static List<FilaInforme> CrearFilasBalance(List<LineaEstadoFinanciero> lineas)
        {
            var resultado = new List<FilaInforme>();
            decimal Agregar(string nombre, GrupoCuentaFinanciera grupo, decimal signo = 1)
            {
                foreach (var x in lineas.Where(x => x.Grupo == grupo).OrderBy(x => x.Codigo))
                    resultado.Add(new FilaInforme(nombre, x.Codigo, x.Nombre, x.Importe * signo));
                return lineas.Where(x => x.Grupo == grupo).Sum(x => x.Importe) * signo;
            }
            decimal corriente = Agregar("Activos corrientes", GrupoCuentaFinanciera.ActivoCorriente);
            decimal fijo = Agregar("Activos no corrientes", GrupoCuentaFinanciera.ActivoNoCorriente);
            decimal contra = Agregar("(-) Depreciación / contraactivo", GrupoCuentaFinanciera.ContraActivo, -1);
            resultado.Add(new FilaInforme("SUBTOTAL", "", "TOTAL ACTIVOS", corriente + fijo + contra));
            decimal pc = Agregar("Pasivos corrientes", GrupoCuentaFinanciera.PasivoCorriente);
            decimal pf = Agregar("Pasivos no corrientes", GrupoCuentaFinanciera.PasivoNoCorriente);
            resultado.Add(new FilaInforme("SUBTOTAL", "", "TOTAL PASIVOS", pc + pf));
            decimal patrimonio = Agregar("Patrimonio", GrupoCuentaFinanciera.Patrimonio);
            resultado.Add(new FilaInforme("SUBTOTAL", "", "TOTAL PATRIMONIO", patrimonio));
            resultado.Add(new FilaInforme("TOTAL", "", "PASIVO + PATRIMONIO", pc + pf + patrimonio));
            resultado.Add(new FilaInforme("CONTROL", "", "DIFERENCIA DEL BALANCE", corriente + fijo + contra - (pc + pf + patrimonio)));
            return resultado;
        }

        private static List<FilaInforme> CrearFilasResultados(List<LineaEstadoFinanciero> lineas)
        {
            var resultado = new List<FilaInforme>();
            decimal Agregar(string seccion, GrupoCuentaFinanciera grupo, decimal signo = 1)
            {
                foreach (var x in lineas.Where(x => x.Grupo == grupo).OrderBy(x => x.Codigo))
                    resultado.Add(new FilaInforme(seccion, x.Codigo, x.Nombre, x.Importe * signo));
                return lineas.Where(x => x.Grupo == grupo).Sum(x => x.Importe) * signo;
            }
            void Subtotal(string nombre, decimal val) => resultado.Add(new FilaInforme("SUBTOTAL", "", nombre, val));
            decimal ingresos = Agregar("Ingresos operativos", GrupoCuentaFinanciera.IngresoOperativo);
            Subtotal("INGRESOS OPERATIVOS", ingresos);
            decimal costos = Agregar("(-) Costo del servicio", GrupoCuentaFinanciera.CostoServicio, -1);
            decimal bruta = ingresos + costos;
            Subtotal("UTILIDAD BRUTA", bruta);
            decimal gastos = Agregar("(-) Gastos administrativos", GrupoCuentaFinanciera.GastoAdministrativo, -1)
                           + Agregar("(-) Gastos de ventas", GrupoCuentaFinanciera.GastoVenta, -1)
                           + Agregar("(-) Depreciación del período", GrupoCuentaFinanciera.GastoDepreciacion, -1);
            decimal operativa = bruta + gastos;
            Subtotal("UTILIDAD OPERATIVA", operativa);
            decimal otros = Agregar("Otros ingresos", GrupoCuentaFinanciera.OtroIngreso);
            decimal fin = Agregar("(-) Gastos financieros", GrupoCuentaFinanciera.GastoFinanciero, -1)
                        + Agregar("(-) Otros gastos", GrupoCuentaFinanciera.OtroGasto, -1);
            decimal antes = operativa + otros + fin;
            Subtotal("UTILIDAD ANTES DE IMPUESTOS", antes);
            decimal impuestos = Agregar("(-) Impuesto sobre la renta", GrupoCuentaFinanciera.ImpuestoRenta, -1);
            Subtotal("UTILIDAD NETA", antes + impuestos);
            return resultado;
        }

        private void SeleccionarCuentaEnTabla()
        {
            if (_ocupado || _tablaCuentas.CurrentRow == null) return;
            if (_tablaCuentas.CurrentRow.Cells["IdCuentaFinanciera"].Value is not int id) return;
            var c = _cuentas.FirstOrDefault(x => x.IdCuentaFinanciera == id);
            if (c == null) return;
            _cuentaEnEdicion = id;
            _codigo.Text = c.Codigo;
            _nombre.Text = c.Nombre;
            _grupo.SelectedItem = c.Grupo;
            _orden.Value = Math.Clamp(c.OrdenPresentacion, (int)_orden.Minimum, (int)_orden.Maximum);
            _activa.Checked = c.Activa;
        }

        private void LimpiarCuenta()
        {
            _cuentaEnEdicion = 0;
            _codigo.Clear(); _nombre.Clear();
            _grupo.SelectedIndex = 0;
            _orden.Value = 0;
            _activa.Checked = true;
            _tablaCuentas.ClearSelection();
        }

        private async Task EjecutarAsync(Func<Task> accion)
        {
            if (_ocupado || IsDisposed || Disposing) return;
            _ocupado = true;
            UseWaitCursor = true;
            try { await accion(); }
            catch (Exception ex) { if (!IsDisposed) MessageBox.Show(ex.Message, "Estados financieros", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            finally { if (!IsDisposed) UseWaitCursor = false; _ocupado = false; }
        }

        private static FlowLayoutPanel Barra(int alto = 90) => new()
        {
            Dock = DockStyle.Top, Height = alto, AutoScroll = true,
            WrapContents = true, Padding = new Padding(7), BackColor = Color.WhiteSmoke
        };
        private static Label Etiqueta(string texto) => new()
        {
            Text = texto, AutoSize = true, Padding = new Padding(3, 7, 3, 0)
        };
        private static ComboBox NuevoCombo(int ancho) => new()
        {
            Width = ancho, DropDownStyle = ComboBoxStyle.DropDownList
        };
        private static Button Boton(string titulo, Color color) => new()
        {
            Text = titulo, Width = Math.Max(112, titulo.Length * 8 + 20), Height = 30,
            BackColor = color, ForeColor = Color.White, FlatStyle = FlatStyle.Flat
        };
        private static DataGridView NuevaTabla() => new()
        {
            Dock = DockStyle.Fill, ReadOnly = true, MultiSelect = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AllowUserToAddRows = false, AllowUserToDeleteRows = false,
            AutoGenerateColumns = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White
        };
        private static void AsignarOpciones(ComboBox combo, List<Opcion> items)
        {
            combo.DataSource = null;
            combo.DisplayMember = nameof(Opcion.Titulo);
            combo.ValueMember = nameof(Opcion.Id);
            combo.DataSource = items;
        }
        private static int ValorSeleccionado(ComboBox combo) => combo.SelectedValue is int i ? i : 0;
        private static void OcultarId(DataGridView tabla, string campo)
        {
            if (tabla.Columns[campo] != null) tabla.Columns[campo]!.Visible = false;
        }
        private static void FormatearMoneda(DataGridView tabla, string campo)
        {
            if (tabla.Columns[campo] != null) tabla.Columns[campo]!.DefaultCellStyle.Format = "N2";
        }
        private sealed record Opcion(int Id, string Titulo);
        private sealed record FilaInforme(string Seccion, string Codigo, string Cuenta, decimal Importe);
    }
}
