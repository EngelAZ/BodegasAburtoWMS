using BodegasAburtoWMS.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class FormPresupuestoOperacion : Form
    {
        private readonly PresupuestoOperativoService _operativoService;
        private readonly int _anioActual = 2027;

        public FormPresupuestoOperacion(PresupuestoOperativoService operativoService)
        {
            InitializeComponent();
            _operativoService = operativoService;
            this.Load += FormPresupuestoOperacion_Load;
        }

        private async void FormPresupuestoOperacion_Load(object sender, EventArgs e)
        {
            await CargarGrillaTrimestralAsync();
        }

        private async Task CargarGrillaTrimestralAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var listaTrimestres = await _operativoService.ObtenerPresupuestoPorAnioAsync(_anioActual);
                dgvPresupuesto.DataSource = listaTrimestres;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el presupuesto operativo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void btnActualizarTrimestre_Click(object sender, EventArgs e)
        {
            if (dgvPresupuesto.CurrentRow == null) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnActualizarTrimestre.Enabled = false;

                int idTrimestre = Convert.ToInt32(dgvPresupuesto.CurrentRow.Cells["Id"].Value);

                if (!decimal.TryParse(txtVentasParam.Text, out decimal nuevasVentas) ||
                    !decimal.TryParse(txtGastosParam.Text, out decimal nuevosGastos))
                {
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos de edición.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Actualización y recálculo instantáneo asíncrono
                bool exito = await _operativoService.ActualizarTrimestreYRecalcularAsync(idTrimestre, nuevasVentas, nuevosGastos, _anioActual);

                if (exito)
                {
                    MessageBox.Show("Trimestre actualizado. Los estados proforma y flujos de caja se han recalculado al instante.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarGrillaTrimestralAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al procesar el cambio: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                btnActualizarTrimestre.Enabled = true;
            }
        }
    }
}