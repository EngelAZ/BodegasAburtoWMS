using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class ModuloEstadosFinacieros : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;

        public ModuloEstadosFinacieros(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Gestion_Load;
        }

        private void Gestion_Load(object sender, EventArgs e)
        {
            CargarFormulariosFinancieros();
        }

        private void CargarFormulariosFinancieros()
        {
            try
            {
                var formBalance = new Balance_General(_repository)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                var formResultados = new Estado_de_Resultados(_repository)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                // 3. Limpiar y agregar al TabPage correspondiente
                tabBalance.Controls.Clear();
                tabBalance.Controls.Add(formBalance);
                formBalance.Show();

                tabResultados.Controls.Clear();
                tabResultados.Controls.Add(formResultados);
                formResultados.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los estados financieros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}