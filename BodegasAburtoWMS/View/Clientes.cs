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
    public partial class Clientes : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private bool _isProcessing = false; // Bandera para evitar llamadas simultáneas

        // 1. Constructor normal con inyección de dependencias
        public Clientes(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Clientes_Load;
        }

        // 2. Constructor alternativo y seguro (crea su propio contexto aislado para evitar cruce de hilos)
        public Clientes()
        {
            InitializeComponent();

            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);

            this.Load += Clientes_Load;
        }

        private async void Clientes_Load(object sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private async Task CargarClientesAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

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
            finally
            {
                _isProcessing = false;
            }
        }

        private async void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using var formDatos = new DatosCliente(_repository);
            if (formDatos.ShowDialog() == DialogResult.OK)
            {
                await CargarClientesAsync();
            }
        }

        private async void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                string filtro = txtBuscarCliente.Text.Trim();
                if (string.IsNullOrEmpty(filtro))
                {
                    var listaClientes = await _repository.ObtenerClientesAsync();
                    dataGridView1.DataSource = listaClientes;
                }
                else
                {
                    var resultados = await _repository.BuscarClientesAsync(filtro);
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
    }
}
