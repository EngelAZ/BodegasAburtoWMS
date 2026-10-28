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
    public partial class Entregas_Salidas : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private bool _isProcessing = false; // Bandera para evitar llamadas simultáneas

        // 1. Constructor con inyección de dependencias estándar
        public Entregas_Salidas(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Entregas_Salidas_Load;
        }

        // 2. Constructor seguro y alternativo (crea un contexto aislado para evitar cruce de hilos)
        public Entregas_Salidas()
        {
            InitializeComponent();

            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);

            this.Load += Entregas_Salidas_Load;
        }

        private async void Entregas_Salidas_Load(object sender, EventArgs e)
        {
            await CargarEnviosPendientesAsync();
        }

        private async Task CargarEnviosPendientesAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                var pendientes = await _repository.ObtenerEnviosPendientesAsync();

                // MENSAJE DE PRUEBA: Esto te dirá exactamente cuántos envíos pendientes detecta
                MessageBox.Show($"Envíos pendientes encontrados: {pendientes.Count}", "Depuración");

                flowPanelTarjetas.Controls.Clear();

                foreach (var envio in pendientes)
                {
                    var tarjeta = CrearTarjetaEnvio(envio);
                    flowPanelTarjetas.Controls.Add(tarjeta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar envíos pendientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        // Método que diseña dinámicamente cada tarjeta de envío imitando la interfaz moderna
        private Panel CrearTarjetaEnvio(Envio envio)
        {
            int diasEnBodega = (DateTime.Now - envio.FechaEnvio).Days;
            bool esAlertaCritica = diasEnBodega > 30;
            string nombreEstado = envio.Estado?.Nombre ?? "Registrado";

            // Panel contenedor principal de la tarjeta
            Panel panelCard = new Panel
            {
                Size = new Size(800, 110),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 5, 10, 5)
            };

            // Si supera los 30 días, se resalta con un fondo rojizo de alerta
            if (esAlertaCritica)
            {
                panelCard.BackColor = Color.FromArgb(255, 243, 243);
            }

            // Etiqueta N° Guía
            Label lblGuiaTitulo = new Label { Text = "N° Guía", Location = new Point(15, 10), Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };
            Label lblGuiaValor = new Label { Text = envio.NumeroGuia, Location = new Point(15, 28), Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold), ForeColor = Color.FromArgb(30, 78, 140), AutoSize = true };

            // Destinatario
            Label lblDestTitulo = new Label { Text = "Destinatario", Location = new Point(220, 10), Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };
            string nombreDestinatario = envio.ClienteDestinatario != null ? $"{envio.ClienteDestinatario.Nombre} {envio.ClienteDestinatario.Apellido}" : "N/A";
            Label lblDestValor = new Label { Text = nombreDestinatario, Location = new Point(220, 28), Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold), ForeColor = Color.Black, AutoSize = true };

            // Teléfono / Cédula
            Label lblTelTitulo = new Label { Text = "Teléfono", Location = new Point(450, 10), Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };
            string telefono = envio.ClienteDestinatario?.NumeroCedula ?? "+505 0000 0000";
            Label lblTelValor = new Label { Text = telefono, Location = new Point(450, 28), Font = new Font("Segoe UI", 10f), ForeColor = Color.Black, AutoSize = true };

            // Configuración del botón de acción según el estado del envío
            string textoBoton = "Entregar →";
            Color colorBoton = Color.FromArgb(249, 115, 22); // Naranja predeterminado

            if (nombreEstado == "En Tránsito")
            {
                textoBoton = "Recibir →";
                colorBoton = Color.FromArgb(30, 78, 140); // Azul informativo para recepción en bodega
            }

            Button btnAccion = new Button
            {
                Text = textoBoton,
                Size = new Size(95, 32),
                Location = new Point(680, 25),
                BackColor = colorBoton,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 9.5f)
            };
            btnAccion.FlatAppearance.BorderSize = 0;

            btnAccion.Click += async (s, ev) =>
            {
                if (nombreEstado == "En Tránsito")
                {
                    // Lógica opcional para avanzar estado a recepción de bodega
                    MessageBox.Show($"El envío {envio.NumeroGuia} ha sido procesado.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var confirm = MessageBox.Show($"¿Desea registrar la entrega oficial del envío {envio.NumeroGuia}?", "Confirmar Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        bool resultado = await _repository.RegistrarEntregaEnvioAsync(envio.IdEnvio, 1); // 1 = IdUsuario activo por defecto
                        if (resultado)
                        {
                            MessageBox.Show("¡Entrega registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await CargarEnviosPendientesAsync(); // Refrescar la lista de tarjetas
                        }
                    }
                }
            };

            // Segunda línea: Agencia, Días en bodega y Observaciones / Estado actual
            Label lblAgenciaTitulo = new Label { Text = "Agencia", Location = new Point(15, 60), Font = new Font("Segoe UI", 8f), ForeColor = Color.Gray, AutoSize = true };
            Label lblAgenciaValor = new Label { Text = envio.Agencia?.Nombre ?? "N/A", Location = new Point(15, 75), Font = new Font("Segoe UI", 9f), ForeColor = Color.Black, AutoSize = true };

            Label lblDiasTitulo = new Label { Text = "Días en bodega", Location = new Point(220, 60), Font = new Font("Segoe UI", 8f), ForeColor = Color.Gray, AutoSize = true };
            Label lblDiasValor = new Label { Text = $"{diasEnBodega} días ({nombreEstado})", Location = new Point(220, 75), Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold), ForeColor = esAlertaCritica ? Color.Red : Color.DimGray, AutoSize = true };

            Label lblObsValor = new Label { Text = envio.Observaciones ?? "Sin observaciones", Location = new Point(450, 75), Font = new Font("Segoe UI", 8.5f, FontStyle.Italic), ForeColor = esAlertaCritica ? Color.Red : Color.DarkOrange, AutoSize = true };

            // Agregar todos los controles al panel de la tarjeta
            panelCard.Controls.Add(lblGuiaTitulo);
            panelCard.Controls.Add(lblGuiaValor);
            panelCard.Controls.Add(lblDestTitulo);
            panelCard.Controls.Add(lblDestValor);
            panelCard.Controls.Add(lblTelTitulo);
            panelCard.Controls.Add(lblTelValor);
            panelCard.Controls.Add(btnAccion);
            panelCard.Controls.Add(lblAgenciaTitulo);
            panelCard.Controls.Add(lblAgenciaValor);
            panelCard.Controls.Add(lblDiasTitulo);
            panelCard.Controls.Add(lblDiasValor);
            panelCard.Controls.Add(lblObsValor);

            return panelCard;
        }

        // Cargar el historial de envíos entregados
        private async Task CargarHistorialEntregasAsync()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                var historial = await _repository.ObtenerEnviosHistorialAsync();
                flowPanelTarjetas.Controls.Clear();

                foreach (var envio in historial)
                {
                    var tarjeta = CrearTarjetaHistorial(envio);
                    flowPanelTarjetas.Controls.Add(tarjeta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        // Ventana flotante rápida para registrar entrega por número de guía
        private async void MostrarVentanaBusquedaRapida()
        {
            string numeroGuia = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese o escanee el número de guía a entregar:",
                "Registro Rápido de Entrega",
                "GU-");

            if (string.IsNullOrWhiteSpace(numeroGuia)) return;

            try
            {
                var pendientes = await _repository.ObtenerEnviosPendientesAsync();
                var envioEncontrado = pendientes.FirstOrDefault(e => e.NumeroGuia.Trim().Equals(numeroGuia.Trim(), StringComparison.OrdinalIgnoreCase));

                if (envioEncontrado != null)
                {
                    bool resultado = await _repository.RegistrarEntregaEnvioAsync(envioEncontrado.IdEnvio, 1);
                    if (resultado)
                    {
                        MessageBox.Show($"¡Envío {envioEncontrado.NumeroGuia} entregado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarEnviosPendientesAsync(); // Refrescar la vista actual
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún envío pendiente con ese número de guía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la entrega rápida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Diseño especial para las tarjetas del historial (solo lectura, con fecha de entrega real)
        private Panel CrearTarjetaHistorial(Envio envio)
        {
            Panel panelCard = new Panel
            {
                Size = new Size(800, 100),
                BackColor = Color.FromArgb(245, 247, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 5, 10, 5)
            };

            Label lblGuia = new Label { Text = $"N° Guía: {envio.NumeroGuia}", Location = new Point(15, 15), Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(30, 78, 140), AutoSize = true };
            Label lblDest = new Label { Text = $"Destinatario: {envio.ClienteDestinatario?.Nombre} {envio.ClienteDestinatario?.Apellido}", Location = new Point(220, 15), Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Black, AutoSize = true };
            Label lblFechaEntrega = new Label { Text = $"Entregado el: {envio.FechaEntregaReal?.ToString("dd/MM/yyyy HH:mm") ?? "N/A"}", Location = new Point(480, 15), Font = new Font("Segoe UI", 9f), ForeColor = Color.Green, AutoSize = true };
            Label lblAgencia = new Label { Text = $"Agencia: {envio.Agencia?.Nombre}", Location = new Point(15, 55), Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };

            // Botón para Revertir Entrega
            Button btnRevertir = new Button
            {
                Text = "Revertir ↩",
                Size = new Size(95, 30),
                Location = new Point(680, 48),
                BackColor = Color.FromArgb(220, 53, 69), // Rojo discreto de advertencia/reversión
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 9f)
            };
            btnRevertir.FlatAppearance.BorderSize = 0;

            btnRevertir.Click += async (s, ev) =>
            {
                var confirm = MessageBox.Show($"¿Está seguro de revertir la entrega del envío {envio.NumeroGuia}? Volverá a la lista de pendientes.", "Confirmar Reversión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool resultado = await _repository.RevertirEntregaEnvioAsync(envio.IdEnvio, 1); // 1 = Usuario activo por defecto
                    if (resultado)
                    {
                        MessageBox.Show("¡Entrega revertida con éxito! El envío regresó a pendientes.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarHistorialEntregasAsync(); // Refrescar la vista de historial
                    }
                }
            };

            panelCard.Controls.Add(lblGuia);
            panelCard.Controls.Add(lblDest);
            panelCard.Controls.Add(lblFechaEntrega);
            panelCard.Controls.Add(lblAgencia);
            panelCard.Controls.Add(btnRevertir);

            return panelCard;
        }

        private async void btnPendientes_Click(object sender, EventArgs e)
        {
            await CargarEnviosPendientesAsync();
        }

        private async void btnRegistrarEntrega_Click(object sender, EventArgs e)
        {
            MostrarVentanaBusquedaRapida();
        }

        private async void btnHistorial_Click(object sender, EventArgs e)
        {
            await CargarHistorialEntregasAsync();
        }
    }
}
