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
        private readonly IBodegasAburtoWMSRepository repository = new BodegasAburtoWMSRepository();
        public DatosEnvios()
        {
            InitializeComponent();
        }

        private void DatosEnvios_Load(object sender, EventArgs e)
        {
            if (this.ParentForm is Principal formularioPrincipal)
            {

                // 1. Botón "Lista de Envíos" (Pestaña activa)
                Button btnListaEnvios = new Button
                {
                    Text = "📋 Lista de Envíos",
                    Size = new Size(130, 30),
                    Location = new Point(15, 5), // Esquina izquierda de la barra blanca
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(245, 245, 245), // Color gris claro de fondo
                    ForeColor = Color.DimGray,
                    Font = new Font("Segoe UI", 9f)
                };
                btnListaEnvios.FlatAppearance.BorderSize = 0;

                // Al darle clic a Lista, simplemente recargamos esta misma vista por si acaso
                btnListaEnvios.Click += (s, ev) =>
                {
                    formularioPrincipal.MostrarFormEnCentro(new RegistroDiario());
                };

                // 2. Botón "+ Nuevo Envío" (Acción para cambiar de panel)
                Button btnNuevoEnvio = new Button
                {
                    Text = "+ Nuevo Envío",
                    Size = new Size(110, 30),
                    Location = new Point(150, 5), // Al ladito del primer botón
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(30, 78, 140), // Tu azul corporativo
                    Font = new Font("Segoe UI Semibold", 9f)
                };
                btnNuevoEnvio.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);

                // 3. ¡EL TRUCO DE NAVEGACIÓN!: Cuando hagan clic en + Nuevo Envío, cargamos el formulario correspondiente en el centro
                btnNuevoEnvio.Click += (s, ev) =>
                {
                    // Suponiendo que tu formulario de creación se llama "NuevoEnvioForm"
                    // Llamamos al método público de la ventana principal para incrustarlo en la zona gris
                    formularioPrincipal.MostrarFormEnCentro(new DatosEnvios());
                };

                // 4. Agregamos ambos botones a la barra blanca superior
                formularioPrincipal.PanelOpciones.Controls.Add(btnListaEnvios);
                formularioPrincipal.PanelOpciones.Controls.Add(btnNuevoEnvio);

                try
                {
                    // Cargamos todos los ComboBoxes directo de la base de datos al abrir la pantalla
                    cmbAgencia.DataSource = repository.ObtenerAgenciasCombo();
                    cmbTipoEnvio.DataSource = repository.ObtenerTiposEnvioCombo();
                    cmbEstado.DataSource = repository.ObtenerEstadosEnvioCombo();

                    // Para remitente y destinatario usamos la misma lista de clientes registrados
                    cmbRemitente.DataSource = repository.ObtenerClientesCombo();
                    cmbDestinatario.DataSource = repository.ObtenerClientesCombo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los catálogos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroGuia.Text))
            {
                MessageBox.Show("Por favor, ingrese el Número de Guía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que se haya seleccionado un elemento en cada combo
            if (cmbAgencia.SelectedItem == null || cmbRemitente.SelectedItem == null || cmbDestinatario.SelectedItem == null)
            {
                MessageBox.Show("Asegúrese de seleccionar la Agencia y los Clientes.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Extraemos los IDs reales ocultos en la propiedad .Value del ítem seleccionado
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

                    // Asignamos las variables dinámicas de los combos
                    IdAgencia = idAgencia,
                    IdClienteRemitente = idRemitente,
                    IdClienteDestinatario = idDestinatario,
                    IdTipoEnvio = idTipo,
                    IdEstado = idEstado
                };

                if (repository.RegistrarEnvio(nuevoEnvio))
                {
                    MessageBox.Show("¡Envío registrado con éxito en la bodega!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.ParentForm is Principal formularioPrincipal)
                    {
                        formularioPrincipal.MostrarFormEnCentro(new RegistroDiario());
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
                formularioPrincipal.MostrarFormEnCentro(new RegistroDiario());
            }
        }

        private void LimpiarCampos()
        {
            // 1. Vaciar todas las cajas de texto
            txtNumeroGuia.Clear();
            txtOrigen.Clear();
            txtDestino.Clear();
            txtCostoEnvio.Text = "";
            txtObservaciones.Clear();

            // 2. Restablecer los selectores de fecha al día de hoy
            dtpFechaEnvio.Value = DateTime.Now;
            dtpFechaEntregaEstimada.Value = DateTime.Now;
            dtpFechaEntregaReal.Value = DateTime.Now;

            // 3. Regresar los ComboBoxes a la primera opción de la lista
            if (cmbAgencia.Items.Count > 0) cmbAgencia.SelectedIndex = 0;
            if (cmbRemitente.Items.Count > 0) cmbRemitente.SelectedIndex = 0;
            if (cmbDestinatario.Items.Count > 0) cmbDestinatario.SelectedIndex = 0;
            if (cmbTipoEnvio.Items.Count > 0) cmbTipoEnvio.SelectedIndex = 0;
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;

            // 4. Mandar el foco del cursor directo al número de guía para empezar a escribir de nuevo
            txtNumeroGuia.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
