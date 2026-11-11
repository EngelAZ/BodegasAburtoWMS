using BodegasAburtoWMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class FormSupuestosBudget : Form
    {
        private readonly PresupuestoService _presupuestoService;
        private readonly int _anioActual = 2027;

        public FormSupuestosBudget(PresupuestoService presupuestoService)
        {
            InitializeComponent();
            _presupuestoService = presupuestoService;

            // Configurar comportamiento responsivo inicial
            this.Load += FormSupuestosBudget_Load;
        }

        private async void FormSupuestosBudget_Load(object sender, EventArgs e)
        {
            await CargarDatosGridAsync();
        }

        private async Task CargarDatosGridAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Carga asíncrona de datos para mantener la UI fluida
                var datos = await _presupuestoService.ObtenerSupuestosPorAnioAsync(_anioActual);
                dgvSupuestos.DataSource = datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los supuestos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void btnGuardarModificacion_Click(object sender, EventArgs e)
        {
            if (dgvSupuestos.CurrentRow == null) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnGuardarModificacion.Enabled = false;

                int idSupuesto = Convert.ToInt32(dgvSupuestos.CurrentRow.Cells["Id"].Value);

                if (!decimal.TryParse(txtNuevoValor.Text, out decimal nuevoValor))
                {
                    MessageBox.Show("Por favor, introduzca un valor numérico válido.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Modificación con actualización instantánea de proformas en segundo plano
                bool exito = await _presupuestoService.ActualizarSupuestoYRecalcularAsync(idSupuesto, nuevoValor, _anioActual);

                if (exito)
                {
                    MessageBox.Show("Modificación aplicada con éxito. Estados Proforma recalculados al instante.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarDatosGridAsync(); // Refrescar vista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                btnGuardarModificacion.Enabled = true;
            }
        }
    }
}
