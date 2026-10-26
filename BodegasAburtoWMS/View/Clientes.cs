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
    public partial class Clientes : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;

        public Clientes(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            this.Load += Clientes_Load;
        }

        private async void Clientes_Load(object sender, EventArgs e)
        {
            await CargarDatosClientesAsync();
        }

        private async Task CargarDatosClientesAsync()
        {
            try
            {
                var listaClientes = await _repository.ObtenerClientesAsync();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using var formDatos = new DatosCliente(_repository);
            if (formDatos.ShowDialog() == DialogResult.OK)
            {
                await CargarDatosClientesAsync();
            }
        }

        private async void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarCliente.Text.Trim();
            if (string.IsNullOrEmpty(filtro) || filtro == "Buscar por Nombre") // Ajusta si usas placeholder
            {
                await CargarDatosClientesAsync();
            }
            else
            {
                dataGridView1.DataSource = await _repository.BuscarClientesAsync(filtro);
            }
        }
    }
}
