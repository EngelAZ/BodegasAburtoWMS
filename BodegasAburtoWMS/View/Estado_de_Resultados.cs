using BodegasAburtoWMS.Datos;
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

        // 1. Constructor con inyección de dependencias estándar
        public Estado_de_Resultados(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Estado_de_Resultados_Load;
        }

        // 2. Constructor seguro y alternativo
        public Estado_de_Resultados()
        {
            InitializeComponent();
            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);
            this.Load += Estado_de_Resultados_Load;
        }

        private async void Estado_de_Resultados_Load(object sender, EventArgs e)
        {
            await CargarEstadoResultadosAsync();
        }
        private async Task CargarEstadoResultadosAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                // Aquí puedes consultar ingresos, costos y gastos operativos.
                // Ejemplo: var datos = await _repository.ObtenerEstadoResultadosAsync();
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
    }
}
