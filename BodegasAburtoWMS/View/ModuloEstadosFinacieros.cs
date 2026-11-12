using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class ModuloEstadosFinacieros : Form
    {
        private readonly IBodegasAburtoWMSRepository? _repository;
        private bool _balanceCargado = false;
        private bool _resultadosCargados = false;
        private bool _isInitializing = true; // Bandera para controlar el arranque

        // Constructor que acepta opcionalmente un repositorio
        public ModuloEstadosFinacieros(IBodegasAburtoWMSRepository? repository = null)
        {
            InitializeComponent();
            _repository = repository;

            // Suscribirse al evento de cambio de pestañas y al Load
            this.Load += Gestion_Load;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void Gestion_Load(object sender, EventArgs e)
        {
            _isInitializing = true;

            // Cargamos la primera pestaña por defecto al abrir el módulo
            CargarBalanceGeneral();

            _isInitializing = false; // Finaliza la inicialización
        }

        private void CargarBalanceGeneral()
        {
            if (_balanceCargado) return; // Si ya está cargado, no lo recarga innecesariamente

            try
            {
                var formBalance = new Balance_General(_repository ?? throw new InvalidOperationException("Repositorio no configurado"))
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                tabBalance.Controls.Clear();
                tabBalance.Controls.Add(formBalance);
                formBalance.Show();

                _balanceCargado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Balance General: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEstadoResultados()
        {
            if (_resultadosCargados) return; // Si ya está cargado, no lo recarga

            try
            {
                var formResultados = new Estado_de_Resultados(_repository ?? throw new InvalidOperationException("Repositorio no configurado"))
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                tabResultados.Controls.Clear();
                tabResultados.Controls.Add(formResultados);
                formResultados.Show();

                _resultadosCargados = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Estado de Resultados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el formulario se está inicializando, ignoramos este evento
            if (_isInitializing) return;

            if (tabControl1.SelectedTab == tabBalance)
            {
                CargarBalanceGeneral();
            }
            else if (tabControl1.SelectedTab == tabResultados)
            {
                CargarEstadoResultados();
            }
        }
    }
}