using BodegasAburtoWMS.Model;
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
        private bool _isProcessing = false; // Bandera para evitar consultas simultáneas

<<<<<<< HEAD
=======
        // Inyección de dependencias del repositorio
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
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
<<<<<<< HEAD
                // Botón "Lista de Envíos"
=======
                // 1. Botón "Lista de Envíos" (Pestaña activa)
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
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
<<<<<<< HEAD
=======

>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
                btnListaEnvios.Click += (s, ev) =>
                {
                    formularioPrincipal.MostrarFormEnCentro(new RegistroDiario(_repository));
                };

<<<<<<< HEAD
                // Botón "+ Nuevo Envío"
=======
                // 2. Botón "+ Nuevo Envío"
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
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
<<<<<<< HEAD
                btnNuevoEnvio.Click += (s, ev) =>
                {
=======

                btnNuevoEnvio.Click += (s, ev) =>
                {
                    // Pasamos el repositorio al formulario de creación de envíos
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
                    formularioPrincipal.MostrarFormEnCentro(new DatosEnvios(_repository));
                };

                formularioPrincipal.PanelOpciones.Controls.Add(btnListaEnvios);
                formularioPrincipal.PanelOpciones.Controls.Add(btnNuevoEnvio);
            }

<<<<<<< HEAD
=======
            // Cargar los datos de los envíos de forma asíncrona al iniciar la vista
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
            await CargarEnviosAsync();
        }
        private async Task CargarEnviosAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                var listaEnvios = await _repository.ObtenerEnviosAsync();

<<<<<<< HEAD
=======
                // Mapeo adaptado para mostrar los nombres de las entidades relacionadas en el DataGridView
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
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
<<<<<<< HEAD
                    Estado = e.Estado?.Nombre ?? "Registrado" // <-- Mostramos el estado aquí
=======
                    e.Observaciones
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
                }).ToList();

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dataSource;
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                MessageBox.Show($"Error al cargar los registros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
=======
                MessageBox.Show($"Error al cargar los registros de envíos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            _isProcessing = true;

<<<<<<< HEAD
=======

>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
            try
            {
                string filtro = txtBuscar.Text.Trim();
                if (string.IsNullOrEmpty(filtro) || filtro.Contains("Buscar"))
                {
                    var listaEnvios = await _repository.ObtenerEnviosAsync();
                    ActualizarGrid(listaEnvios);
                }
                else
                {
                    var resultados = await _repository.BuscarEnviosAsync(filtro);
                    ActualizarGrid(resultados);
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

        private void ActualizarGrid(List<Envio> lista)
        {
            dataGridView1.DataSource = lista.Select(e => new
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
