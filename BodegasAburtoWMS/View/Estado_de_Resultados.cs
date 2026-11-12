using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class Estado_de_Resultados : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private bool _isProcessing = false;
        private bool _isInitializing = true;
        private int _anioSeleccionado = DateTime.Now.Year;

        public Estado_de_Resultados(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Estado_de_Resultados_Load;
        }

        // Solo para el diseñador de Windows Forms. En ejecución usar DI.
        public Estado_de_Resultados()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                throw new InvalidOperationException(
                    "Estado_de_Resultados debe abrirse con su constructor que recibe IBodegasAburtoWMSRepository.");
            _repository = null!;
        }

        private async void Estado_de_Resultados_Load(object sender, EventArgs e)
        {
            _isInitializing = true;

            // Cargamos los años y los datos de forma síncrona en el arranque para evitar choques de hilos
            CargarAniosDisponiblesComboBox();
            CargarDatosEstadoResultados();

            _isInitializing = false;
        }
        private void CargarAniosDisponiblesComboBox()
        {
            var aniosBD = _repository.ObtenerAniosResultados();

            var aniosList = new List<int>();
            for (int i = DateTime.Now.Year - 2; i <= DateTime.Now.Year + 3; i++)
            {
                aniosList.Add(i);
            }

            foreach (var anio in aniosBD)
            {
                if (anio > 0 && !aniosList.Contains(anio))
                {
                    aniosList.Add(anio);
                }
            }

            aniosList = aniosList.OrderByDescending(a => a).ToList();

            // 1. Asignar al ComboBox Principal con una nueva instancia independiente
            cboAniosResultados.DataSource = null;
            cboAniosResultados.DataSource = new List<int>(aniosList);

            // 2. Asignar al ComboBox Base con otra instancia independiente
            cmbAnioBaseResultados.DataSource = null;
            cmbAnioBaseResultados.DataSource = new List<int>(aniosList);

            // Seleccionar valores por defecto de forma segura
            if (aniosList.Contains(DateTime.Now.Year))
            {
                cboAniosResultados.SelectedItem = DateTime.Now.Year;
            }

            int anioAnterior = DateTime.Now.Year - 1;
            if (aniosList.Contains(anioAnterior))
            {
                cmbAnioBaseResultados.SelectedItem = anioAnterior;
            }
            else if (aniosList.Count > 1)
            {
                cmbAnioBaseResultados.SelectedIndex = 1;
            }
        }

        private void CargarDatosEstadoResultados()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                // Versión síncrona para evitar solapamientos al abrir la pestaña
                var cuentas = _repository.ObtenerCuentasResultadosPorAnio(_anioSeleccionado);

                var cuentasResultados = cuentas.Where(c =>
                    c.Tipo != null && (
                        c.Tipo.Equals("Ingresos", StringComparison.OrdinalIgnoreCase) ||
                        c.Tipo.Equals("Costos", StringComparison.OrdinalIgnoreCase) ||
                        c.Tipo.Equals("Gastos", StringComparison.OrdinalIgnoreCase)
                    )).ToList();

                dataGridViewResultados.AutoGenerateColumns = true;
                dataGridViewResultados.DataSource = cuentasResultados;

                if (dataGridViewResultados.Columns["IdCuenta"] != null)
                    dataGridViewResultados.Columns["IdCuenta"].Visible = false;

                dataGridViewResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                decimal totalIngresos = cuentasResultados.Where(c => c.Tipo.Equals("Ingresos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal totalCostos = cuentasResultados.Where(c => c.Tipo.Equals("Costos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal totalGastos = cuentasResultados.Where(c => c.Tipo.Equals("Gastos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);

                decimal utilidadNeta = totalIngresos - (totalCostos + totalGastos);

                lblTotalIngresos.Text = $"TOTAL INGRESOS: $ {totalIngresos:N2}";
                lblTotalCostos.Text = $"TOTAL COSTOS: $ {totalCostos:N2}";
                lblTotalGastos.Text = $"TOTAL GASTOS: $ {totalGastos:N2}";

                lblUtilidadNeta.Text = $"UTILIDAD NETA ({_anioSeleccionado}): $ {utilidadNeta:N2}";
                lblUtilidadNeta.ForeColor = utilidadNeta >= 0 ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el Estado de Resultados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }


        private async void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            using (var form = new FormularioCuenta())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool guardado = await _repository.GuardarCuentaBalanceAsync(form.Cuenta);
                    if (guardado)
                    {
                        MessageBox.Show("Cuenta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosEstadoResultados();
                    }
                }
            }
        }

        private async void btnEditarCuenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewResultados.CurrentRow?.DataBoundItem is CuentaBalance cuentaSeleccionada)
            {
                using (var form = new FormularioCuenta(cuentaSeleccionada))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        bool actualizado = await _repository.GuardarCuentaBalanceAsync(form.Cuenta);
                        if (actualizado)
                        {
                            MessageBox.Show("Cuenta actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatosEstadoResultados();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cuenta para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewResultados.CurrentRow?.DataBoundItem is CuentaBalance cuentaSeleccionada)
            {
                var confirm = MessageBox.Show($"¿Está seguro de eliminar la cuenta '{cuentaSeleccionada.NombreCuenta}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool eliminado = await _repository.EliminarCuentaBalanceAsync(cuentaSeleccionada.IdCuenta);
                    if (eliminado)
                    {
                        MessageBox.Show("Cuenta eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosEstadoResultados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cuenta para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void cboAniosResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            if (cboAniosResultados.SelectedItem != null)
            {
                _anioSeleccionado = Convert.ToInt32(cboAniosResultados.SelectedItem);
                CargarDatosEstadoResultados();
            }
        }

        private void btnAnalisisVerticalResultados_Click(object sender, EventArgs e)
        {
            var cuentas = dataGridViewResultados.DataSource as List<CuentaBalance>;
            if (cuentas == null || cuentas.Count == 0)
            {
                MessageBox.Show("No hay datos para calcular el análisis vertical.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Calcular el Total de Ingresos (Base del análisis vertical en Resultados = 100%)
            decimal totalIngresos = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Ingresos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);

            if (totalIngresos == 0)
            {
                MessageBox.Show("El Total de Ingresos es 0, no se pueden calcular los porcentajes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Calcular el porcentaje para cada cuenta respecto a los ingresos
            foreach (var cuenta in cuentas)
            {
                cuenta.PorcentajeVertical = (cuenta.Saldo / totalIngresos) * 100;
            }

            // 3. Refrescar el DataGridView
            dataGridViewResultados.DataSource = null;
            dataGridViewResultados.DataSource = cuentas;

            if (dataGridViewResultados.Columns["PorcentajeVertical"] != null)
            {
                dataGridViewResultados.Columns["PorcentajeVertical"].HeaderText = "% de Ingresos";
                dataGridViewResultados.Columns["PorcentajeVertical"].DefaultCellStyle.Format = "N2";
                dataGridViewResultados.Columns["PorcentajeVertical"].DisplayIndex = dataGridViewResultados.Columns["Saldo"].DisplayIndex + 1;
            }

            MessageBox.Show("Análisis vertical del Estado de Resultados calculado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnalisiHorizontalResultados_Click(object sender, EventArgs e)
        {
            if (cboAniosResultados.SelectedItem == null || cmbAnioBaseResultados.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione tanto el año actual como el año base de comparación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int anioActual = Convert.ToInt32(cboAniosResultados.SelectedItem);
            int anioBase = Convert.ToInt32(cmbAnioBaseResultados.SelectedItem);

            if (anioActual == anioBase)
            {
                MessageBox.Show("El año actual y el año base no pueden ser iguales para el análisis horizontal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Llamamos al repositorio filtrando exclusivamente por el tipo "Resultados" (Ingresos, Costos, Gastos)
                var cuentasAnalisis = _repository.ObtenerCuentasParaAnalisisHorizontal(anioActual, anioBase, "Resultados");

                dataGridViewResultados.DataSource = null;
                dataGridViewResultados.DataSource = cuentasAnalisis;

                // Formatear y personalizar las columnas de variación en el DataGridView
                if (dataGridViewResultados.Columns["VariacionAbsoluta"] != null)
                {
                    dataGridViewResultados.Columns["VariacionAbsoluta"].HeaderText = $"Var. Absoluta ({anioActual} vs {anioBase})";
                    dataGridViewResultados.Columns["VariacionAbsoluta"].DefaultCellStyle.Format = "N2";
                }

                if (dataGridViewResultados.Columns["VariacionPorcentual"] != null)
                {
                    dataGridViewResultados.Columns["VariacionPorcentual"].HeaderText = "Var. Porcentual (%)";
                    dataGridViewResultados.Columns["VariacionPorcentual"].DefaultCellStyle.Format = "N2";
                }

                if (dataGridViewResultados.Columns["IdCuenta"] != null)
                    dataGridViewResultados.Columns["IdCuenta"].Visible = false;

                dataGridViewResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MessageBox.Show($"Análisis horizontal del Estado de Resultados calculado exitosamente comparando {anioActual} con {anioBase}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular el análisis horizontal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
