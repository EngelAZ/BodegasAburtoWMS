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
    public partial class RegistroDiario : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;

        // Inyección de dependencias del repositorio
        public RegistroDiario(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            this.Load += RegistroDiario_Load;
        }

        private async void RegistroDiario_Load(object sender, EventArgs e)
        {
            if (this.ParentForm is Principal formularioPrincipal)
            {
                // 1. Botón "Lista de Envíos" (Pestaña activa)
                Button btnListaEnvios = new Button
                {
                    Text = "📋 Lista de Envíos",
                    Size = new Size(130, 30),
                    Location = new Point(15, 5),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(30, 78, 140),
                    Font = new Font("Segoe UI Semibold", 9f)
                };
                btnListaEnvios.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);

                btnListaEnvios.Click += (s, ev) =>
                {
                    formularioPrincipal.MostrarFormEnCentro(new RegistroDiario(_repository));
                };

                // 2. Botón "+ Nuevo Envío"
                Button btnNuevoEnvio = new Button
                {
                    Text = "+ Nuevo Envío",
                    Size = new Size(110, 30),
                    Location = new Point(150, 5),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(245, 245, 245),
                    ForeColor = Color.DimGray,
                    Font = new Font("Segoe UI", 9f)
                };
                btnNuevoEnvio.FlatAppearance.BorderSize = 0;

                btnNuevoEnvio.Click += (s, ev) =>
                {
                    // Pasamos el repositorio al formulario de creación de envíos
                    formularioPrincipal.MostrarFormEnCentro(new DatosEnvios(_repository));
                };

                formularioPrincipal.PanelOpciones.Controls.Add(btnListaEnvios);
                formularioPrincipal.PanelOpciones.Controls.Add(btnNuevoEnvio);
            }

            // Cargar los datos de los envíos de forma asíncrona al iniciar la vista
            await CargarEnviosAsync();
        }
        private async Task CargarEnviosAsync()
        {
            try
            {
                var listaEnvios = await _repository.ObtenerEnviosAsync();

                // Mapeo adaptado para mostrar los nombres de las entidades relacionadas en el DataGridView
                var dataSource = listaEnvios.Select(e => new
                {
                    e.IdEnvio,
                    e.NumeroGuia,
                    Agencia = e.Agencia?.Nombre ?? "N/A",
                    Remitente = e.ClienteRemitente != null ? $"{e.ClienteRemitente.Nombre} {e.ClienteRemitente.Apellido}" : "N/A",
                    Destinatario = e.ClienteDestinatario != null ? $"{e.ClienteDestinatario.Nombre} {e.ClienteDestinatario.Apellido}" : "N/A",
                    e.FechaEnvio,
                    FechaEntrega = e.FechaEntregaReal ?? e.FechaEntregaEstimada,
                    e.CostoEnvio,
                    e.Observaciones
                }).ToList();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los registros de envíos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(filtro) || filtro.Contains("Buscar"))
            {
                await CargarEnviosAsync();
            }
            else
            {
                var resultados = await _repository.BuscarEnviosAsync(filtro);

                dataGridView1.DataSource = resultados.Select(e => new
                {
                    e.IdEnvio,
                    e.NumeroGuia,
                    Agencia = e.Agencia?.Nombre ?? "N/A",
                    Remitente = e.ClienteRemitente != null ? $"{e.ClienteRemitente.Nombre} {e.ClienteRemitente.Apellido}" : "N/A",
                    Destinatario = e.ClienteDestinatario != null ? $"{e.ClienteDestinatario.Nombre} {e.ClienteDestinatario.Apellido}" : "N/A",
                    e.FechaEnvio,
                    FechaEntrega = e.FechaEntregaReal ?? e.FechaEntregaEstimada,
                    e.CostoEnvio,
                    e.Observaciones
                }).ToList();
            }
        }
    }
}
