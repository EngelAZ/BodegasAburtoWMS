using BodegasAburtoWMS.Datos;
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
    public partial class DatosEnvios : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private bool _isProcessing = false; // Bandera para evitar consultas simultáneas

        // Inyección de dependencias del repositorio
        public DatosEnvios(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            this.Load += DatosEnvios_Load;
        }

        public DatosEnvios()
        {
            InitializeComponent();

            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);

            this.Load += DatosEnvios_Load;
        }

        private async void DatosEnvios_Load(object sender, EventArgs e)
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
                    BackColor = Color.FromArgb(245, 245, 245),
                    ForeColor = Color.DimGray,
                    Font = new Font("Segoe UI", 9f)
                };
                btnListaEnvios.FlatAppearance.BorderSize = 0;

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
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(30, 78, 140),
                    Font = new Font("Segoe UI Semibold", 9f)
                };
                btnNuevoEnvio.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);

                btnNuevoEnvio.Click += (s, ev) =>
                {
                    formularioPrincipal.MostrarFormEnCentro(new DatosEnvios(_repository));
                };

                formularioPrincipal.PanelOpciones.Controls.Add(btnListaEnvios);
                formularioPrincipal.PanelOpciones.Controls.Add(btnNuevoEnvio);
            }

            // Carga asíncrona de todos los catálogos (Comboboxes) desde EF Core
            await CargarCatalogosAsync();
        }

        private async Task CargarCatalogosAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                cmbAgencia.DataSource = await _repository.ObtenerAgenciasComboAsync();
                cmbAgencia.DisplayMember = "Text";
                cmbAgencia.ValueMember = "Value";

                cmbTipoEnvio.DataSource = await _repository.ObtenerTiposEnvioComboAsync();
                cmbTipoEnvio.DisplayMember = "Text";
                cmbTipoEnvio.ValueMember = "Value";

                cmbEstado.DataSource = await _repository.ObtenerEstadosEnvioComboAsync();
                cmbEstado.DisplayMember = "Text";
                cmbEstado.ValueMember = "Value";

                var clientes = await _repository.ObtenerClientesComboAsync();

                cmbRemitente.DataSource = new BindingSource(clientes, null);
                cmbRemitente.DisplayMember = "Text";
                cmbRemitente.ValueMember = "Value";

                cmbDestinatario.DataSource = new BindingSource(clientes, null);
                cmbDestinatario.DisplayMember = "Text";
                cmbDestinatario.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los catálogos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroGuia.Text))
            {
                MessageBox.Show("Por favor, ingrese el Número de Guía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbAgencia.SelectedItem == null || cmbRemitente.SelectedItem == null || cmbDestinatario.SelectedItem == null)
            {
                MessageBox.Show("Asegúrese de seleccionar la Agencia y los Clientes.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idAgencia = ((ComboboxItem)cmbAgencia.SelectedItem).Value;
                int idRemitente = ((ComboboxItem)cmbRemitente.SelectedItem).Value;
                int idDestinatario = ((ComboboxItem)cmbDestinatario.SelectedItem).Value;

                int? idTipo = ((ComboboxItem)cmbTipoEnvio.SelectedItem)?.Value;
                int? idEstado = ((ComboboxItem)cmbEstado.SelectedItem)?.Value;

                Envio nuevoEnvio = new Envio
                {
                    NumeroGuia = txtNumeroGuia.Text.Trim(),
                    Origen = txtOrigen.Text.Trim(),
                    Destino = txtDestino.Text.Trim(),
                    FechaEnvio = dtpFechaEnvio.Value,
                    FechaEntregaEstimada = dtpFechaEntregaEstimada.Value,
                    FechaEntregaReal = dtpFechaEntregaReal.Value,
                    CostoEnvio = decimal.TryParse(txtCostoEnvio.Text, out decimal costo) ? costo : 0.00m,
                    Observaciones = txtObservaciones.Text.Trim(),

                    IdAgencia = idAgencia,
                    IdClienteRemitente = idRemitente,
                    IdClienteDestinatario = idDestinatario,
                    IdTipoEnvio = idTipo,
                    IdEstado = idEstado
                };

                // Registro asíncrono utilizando EF Core
                bool guardado = await _repository.RegistrarEnvioAsync(nuevoEnvio);

                if (guardado)
                {
                    MessageBox.Show("¡Envío registrado con éxito en la bodega!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.ParentForm is Principal formularioPrincipal)
                    {
                        formularioPrincipal.MostrarFormEnCentro(new RegistroDiario(_repository));
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el envío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is Principal formularioPrincipal)
            {
                formularioPrincipal.MostrarFormEnCentro(new RegistroDiario(_repository));
            }
        }

        private void LimpiarCampos()
        {
            txtNumeroGuia.Clear();
            txtOrigen.Clear();
            txtDestino.Clear();
            txtCostoEnvio.Text = "";
            txtObservaciones.Clear();

            dtpFechaEnvio.Value = DateTime.Now;
            dtpFechaEntregaEstimada.Value = DateTime.Now;
            dtpFechaEntregaReal.Value = DateTime.Now;

            if (cmbAgencia.Items.Count > 0) cmbAgencia.SelectedIndex = 0;
            if (cmbRemitente.Items.Count > 0) cmbRemitente.SelectedIndex = 0;
            if (cmbDestinatario.Items.Count > 0) cmbDestinatario.SelectedIndex = 0;
            if (cmbTipoEnvio.Items.Count > 0) cmbTipoEnvio.SelectedIndex = 0;
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;

            txtNumeroGuia.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
