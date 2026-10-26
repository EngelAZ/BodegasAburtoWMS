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

        // Constructor que recibe el repositorio por inyección de dependencias
        public Agencias(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            // Suscribir el evento de carga asíncrona
            this.Load += Agencias_Load;
        }

        private async void Agencias_Load(object sender, EventArgs e)
        {
            await CargarDatosAgenciasAsync();
        }

        private async Task CargarDatosAgenciasAsync()
        {
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBuscarAgencia_TextChanged(object sender, EventArgs e)
        {

        }

        private async void txtBuscarAgencia_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarAgencia.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                await CargarDatosAgenciasAsync();
            }
            else
            {
                dataGridView1.DataSource = await _repository.BuscarAgenciasAsync(filtro);
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
