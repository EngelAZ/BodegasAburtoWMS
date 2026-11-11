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
    public partial class Balance_General : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private bool _isProcessing = false;
        private bool _isInitializing = true;
        private int _anioSeleccionado = DateTime.Now.Year;

        public Balance_General(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Balance_General_Load;
        }

        public Balance_General()
        {
            InitializeComponent();
            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);
            this.Load += Balance_General_Load;
        }

        private async void Balance_General_Load(object sender, EventArgs e)
        {
            _isInitializing = true;

            // Carga síncrona inicial para evitar conflictos de hilos al abrir la pestaña
            CargarAniosDisponiblesComboBox();
            CargarDatosBalance();

            _isInitializing = false;
        }
        private void CargarAniosDisponiblesComboBox()
        {
            // Método síncrono exclusivo para los años del balance
            var aniosBD = _repository.ObtenerAniosBalance(); // Asegúrate de tener este método síncrono en tu repositorio

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

            cmbAnios.DataSource = null;
            cmbAnios.DataSource = aniosList;

            if (aniosList.Contains(DateTime.Now.Year))
            {
                cmbAnios.SelectedItem = DateTime.Now.Year;
            }
        }

        private void CargarDatosBalance()
        {
            if (_isProcessing) return;
            _isProcessing = true;


            try
            {
                // Carga síncrona de las cuentas del balance
                var cuentas = _repository.ObtenerCuentasBalancePorAnio(_anioSeleccionado);

                dataGridViewBalance.AutoGenerateColumns = true;
                dataGridViewBalance.DataSource = cuentas;

                if (dataGridViewBalance.Columns["IdCuenta"] != null)
                    dataGridViewBalance.Columns["IdCuenta"].Visible = false;

                dataGridViewBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Cálculos de subtotales
                decimal activosCorrientes = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Activos corrientes", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal activosFijos = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Activos fijos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal totalActivos = activosCorrientes + activosFijos;

                decimal pasivosCorrientes = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Pasivos Corrientes", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal pasivosFijos = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Pasivos fijos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal totalPasivos = pasivosCorrientes + pasivosFijos;

                decimal patrimonio = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Patrimonio", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);

                lblTotalActivos.Text = $"TOTAL ACTIVOS ({_anioSeleccionado}): $ {totalActivos:N2}";
                lblTotalPasivos.Text = $"TOTAL PASIVOS: $ {totalPasivos:N2}";
                lblTotalPatrimonio.Text = $"Patrimonio: $ {patrimonio:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el Balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        CargarDatosBalance();
                    }
                }
            }
        }

        private async void btnEditarCuenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewBalance.CurrentRow?.DataBoundItem is CuentaBalance cuentaSeleccionada)
            {
                using (var form = new FormularioCuenta(cuentaSeleccionada))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        bool actualizado = await _repository.GuardarCuentaBalanceAsync(form.Cuenta);
                        if (actualizado)
                        {
                            MessageBox.Show("Cuenta actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatosBalance();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cuenta de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewBalance.CurrentRow?.DataBoundItem is CuentaBalance cuentaSeleccionada)
            {
                var confirm = MessageBox.Show($"¿Está seguro de eliminar la cuenta '{cuentaSeleccionada.NombreCuenta}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool eliminado = await _repository.EliminarCuentaBalanceAsync(cuentaSeleccionada.IdCuenta);
                    if (eliminado)
                    {
                        MessageBox.Show("Cuenta eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosBalance();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cuenta de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void cmbAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            if (cmbAnios.SelectedItem != null)
            {
                _anioSeleccionado = Convert.ToInt32(cmbAnios.SelectedItem);
                CargarDatosBalance();
            }
        }

        private void btnNuevoAnio_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo año fiscal:", "Nuevo Periodo", (DateTime.Now.Year + 1).ToString());

            if (int.TryParse(input, out int nuevoAnio))
            {
                if (!((List<int>)cmbAnios.DataSource).Contains(nuevoAnio))
                {
                    var lista = (List<int>)cmbAnios.DataSource;
                    lista.Insert(0, nuevoAnio);
                    cmbAnios.DataSource = null;
                    cmbAnios.DataSource = lista;
                }
                cmbAnios.SelectedItem = nuevoAnio;
            }
        }

        private void btnAnalisisVertical_Click(object sender, EventArgs e)
        {
            var cuentas = dataGridViewBalance.DataSource as List<CuentaBalance>;
            if (cuentas == null || cuentas.Count == 0)
            {
                MessageBox.Show("No hay datos para calcular el análisis vertical.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Calcular el Total de Activos (Base del análisis vertical en el Balance General = 100%)
            decimal activosCorrientes = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Activos corrientes", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
            decimal activosFijos = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Activos fijos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
            decimal totalActivos = activosCorrientes + activosFijos;

            if (totalActivos == 0)
            {
                MessageBox.Show("El Total de Activos es 0, no se puede calcular porcentajes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Calcular el porcentaje para cada cuenta
            foreach (var cuenta in cuentas)
            {
                cuenta.PorcentajeVertical = (cuenta.Saldo / totalActivos) * 100;
            }

            // 3. Refrescar el DataGridView y configurar la nueva columna
            dataGridViewBalance.DataSource = null;
            dataGridViewBalance.DataSource = cuentas;

            // Asegurarnos de que la columna se muestre estéticamente con el símbolo %
            if (dataGridViewBalance.Columns["PorcentajeVertical"] != null)
            {
                dataGridViewBalance.Columns["PorcentajeVertical"].HeaderText = "% Análisis Vertical";
                dataGridViewBalance.Columns["PorcentajeVertical"].DefaultCellStyle.Format = "N2"; // Formato con 2 decimales
                dataGridViewBalance.Columns["PorcentajeVertical"].DisplayIndex = dataGridViewBalance.Columns["Saldo"].DisplayIndex + 1;
            }

            MessageBox.Show("Análisis vertical del Balance General calculado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
