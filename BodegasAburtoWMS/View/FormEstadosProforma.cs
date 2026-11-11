using BodegasAburtoWMS.Service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class FormEstadosProforma : Form
    {
        private readonly EstadoProformaService _proformaService;
        private readonly int _anioActual = 2027;

        public FormEstadosProforma(EstadoProformaService proformaService)
        {
            InitializeComponent();
            _proformaService = proformaService;
            this.Load += FormEstadosProforma_Load;
        }

        private async void FormEstadosProforma_Load(object sender, EventArgs e)
        {
            await CargarEstadosProformaAsync();
        }

        private async Task CargarEstadosProformaAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var estados = await _proformaService.ObtenerEstadosProformaPorAnioAsync(_anioActual);
                dgvProforma.DataSource = estados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los estados financieros: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnSincronizar.Enabled = false;

                // Sincronización asincrónica con los módulos operativos y de caja
                bool exito = await _proformaService.SincronizarEstadosProformaAsync(_anioActual);

                if (exito)
                {
                    MessageBox.Show("Estados Financieros Proforma sincronizados y recalculados al instante con éxito.", "Sincronización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarEstadosProformaAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la sincronización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                btnSincronizar.Enabled = true;
            }
        }
    }
}