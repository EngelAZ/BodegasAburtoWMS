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

        // 1. Constructor con inyección de dependencias estándar
        public Balance_General(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Balance_General_Load;
        }

        // 2. Constructor seguro y alternativo de respaldo
        public Balance_General()
        {
            InitializeComponent();
            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);
            this.Load += Balance_General_Load;
        }

        private async void Balance_General_Load(object sender, EventArgs e)
        {
            await CargarDatosBalanceAsync();
        }

        private async Task CargarDatosBalanceAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                var cuentas = await _repository.ObtenerCuentasBalanceAsync();

                // Enlazar al DataGridView
                dataGridViewBalance.AutoGenerateColumns = true;
                dataGridViewBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewBalance.DataSource = cuentas;

                // Ocultar la columna ID visualmente para que no se muestre en la tabla
                if (dataGridViewBalance.Columns["IdCuenta"] != null)
                {
                    dataGridViewBalance.Columns["IdCuenta"].Visible = false;
                }

                // Cambiar nombres de cabeceras para mayor claridad si se generan automáticamente
                if (dataGridViewBalance.Columns["NombreCuenta"] != null)
                    dataGridViewBalance.Columns["NombreCuenta"].HeaderText = "Nombre de Cuenta";
                if (dataGridViewBalance.Columns["Tipo"] != null)
                    dataGridViewBalance.Columns["Tipo"].HeaderText = "Clasificación";
                if (dataGridViewBalance.Columns["Saldo"] != null)
                {
                    dataGridViewBalance.Columns["Saldo"].HeaderText = "Saldo ($)";
                    dataGridViewBalance.Columns["Saldo"].DefaultCellStyle.Format = "N2";
                }

                // --- CÁLCULOS ESPECÍFICOS POR CLASIFICACIÓN ---
                decimal activosCorrientes = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Activos corrientes", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal activosFijos = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Activos fijos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal totalActivos = activosCorrientes + activosFijos;

                decimal pasivosCorrientes = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Pasivos Corrientes", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal pasivosFijos = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Pasivos fijos", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);
                decimal totalPasivos = pasivosCorrientes + pasivosFijos;

                decimal patrimonio = cuentas.Where(c => c.Tipo != null && c.Tipo.Equals("Patrimonio", StringComparison.OrdinalIgnoreCase)).Sum(c => c.Saldo);

                // --- MOSTRAR EN ETIQUETAS DE RESUMEN ---
                // Asegúrate de tener estas etiquetas en tu panel inferior o ajústalas a tus nombres reales:
                lblActivosCorrientes.Text = $"Activos Corrientes: $ {activosCorrientes:N2}";
                lblActivosFijos.Text = $"Activos Fijos: $ {activosFijos:N2}";
                lblTotalActivos.Text = $"TOTAL ACTIVOS: $ {totalActivos:N2}";

                lblPasivosCorrientes.Text = $"Pasivos Corrientes: $ {pasivosCorrientes:N2}";
                lblPasivosFijos.Text = $"Pasivos Fijos: $ {pasivosFijos:N2}";
                lblTotalPasivos.Text = $"TOTAL PASIVOS: $ {totalPasivos:N2}";

                lblTotalPatrimonio.Text = $"Patrimonio: $ {patrimonio:N2}";

                // Validación contable: Total Activos = Total Pasivos + Patrimonio
                decimal pasivosMasPatrimonio = totalPasivos + patrimonio;
                decimal diferencia = totalActivos - pasivosMasPatrimonio;

                if (Math.Abs(diferencia) > 0.01m)
                {
                    lblDiferencia.ForeColor = Color.Red;
                    lblDiferencia.Text = $"⚠️ Descuadre Contable: $ {diferencia:N2} (Activos ≠ Pasivos + Patrimonio)";
                }
                else
                {
                    lblDiferencia.ForeColor = Color.Green;
                    lblDiferencia.Text = "✔ Balance Cuadrado Perfectamente";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el Balance General: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        await CargarDatosBalanceAsync();
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
                            await CargarDatosBalanceAsync();
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
                        await CargarDatosBalanceAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cuenta de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
