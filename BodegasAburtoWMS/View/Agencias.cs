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
    public partial class Agencias : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private bool _isProcessing = false; // Bandera para evitar llamadas simultáneas al DbContext

        // 1. Constructor que recibe el repositorio por inyección de dependencias
        public Agencias(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            // Suscribir el evento de carga asíncrona
            this.Load += Agencias_Load;
        }

        // 2. Constructor seguro y alternativo (crea un contexto aislado para evitar cruce de hilos)
        public Agencias()
        {
            InitializeComponent();

            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);

            this.Load += Agencias_Load;
        }

        private async void Agencias_Load(object sender, EventArgs e)
        {
            await CargarDatosAgenciasAsync();
        }

        private async Task CargarDatosAgenciasAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                // Llamada asíncrona al repositorio para obtener las agencias
                var listaAgencias = await _repository.ObtenerAgenciasAsync();

                // Enlazar los datos al DataGridView respetando el mapeo de columnas de la imagen
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = listaAgencias;

                // Mapear DataPropertyName asegurando que coincidan con las propiedades de la clase Agencia
                // ID -> IdAgencia, Nombre -> Nombre, Contacto -> Contacto, Telefono -> Telefono, Ciudad -> Ciudad, Estado -> Estado, Fecha de Registro -> FechaRegistro
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las agencias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBuscarAgencia_TextChanged(object sender, EventArgs e)
        {

        }

        private async void txtBuscarAgencia_TextChanged(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                string filtro = txtBuscarAgencia.Text.Trim();
                if (string.IsNullOrEmpty(filtro))
                {
                    var listaAgencias = await _repository.ObtenerAgenciasAsync();
                    dataGridView1.DataSource = listaAgencias;
                }
                else
                {
                    var resultados = await _repository.BuscarAgenciasAsync(filtro);
                    dataGridView1.DataSource = resultados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using var formDatos = new DatosAgencia(_repository);
            if (formDatos.ShowDialog() == DialogResult.OK)
            {
                // Refrescar la tabla de agencias de forma asíncrona al volver
                await CargarDatosAgenciasAsync();
            }
        }
    }
}
