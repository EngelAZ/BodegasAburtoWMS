/*using BodegasAburtoWMS.Datos;
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

                panelTarjetas.Controls.Clear();

                foreach (var envio in pendientes.AsEnumerable().Reverse())
                {
                    var tarjeta = CrearTarjetaEnvio(envio);
                    panelTarjetas.Controls.Add(tarjeta);
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
                Height = 110,
                Dock = DockStyle.Top,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 8, 10, 9),
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
                Width = 95,
                Dock = DockStyle.Right,
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
                panelTarjetas.Controls.Clear();

                foreach (var envio in historial.AsEnumerable().Reverse())
                {
                    var tarjeta = CrearTarjetaHistorial(envio);
                    panelTarjetas.Controls.Add(tarjeta);
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
                "GU-"); // modificar luego cuando se tome en cuenta la delimitacion por agencia

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
                Height = 110,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(245, 247, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 8, 10, 9)
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
                Width = 95,
                Dock = DockStyle.Right,
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
*/


using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class Entregas_Salidas : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private bool _isProcessing = false;
        private int _idEstadoActual = 1; // Para saber qué sección estamos visualizando actualmente

        public Entregas_Salidas(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.Load += Entregas_Salidas_Load;
        }

        public Entregas_Salidas()
        {
            InitializeComponent();
            var contextLocal = new BodegaDbContext();
            _repository = new BodegasAburtoWMSRepository(contextLocal);
            this.Load += Entregas_Salidas_Load;
        }

        private async void Entregas_Salidas_Load(object sender, EventArgs e)
        {
            await CargarEnviosPorEstadoAsync(1, "Registrado");
        }

        // Carga genérica según la pestaña seleccionada
        private async Task CargarEnviosPorEstadoAsync(int idEstado, string nombreEstadoFiltro)
        {
            if (_isProcessing) return;
            _isProcessing = true;
            _idEstadoActual = idEstado; // Guardamos la sección activa

            try
            {
                var envios = await _repository.ObtenerEnviosPorEstadoAsync(idEstado);
                panelTarjetas.Controls.Clear();

                if (envios == null || envios.Count == 0)
                {
                    MostrarMensajeVacio($"No hay envíos en estado \"{nombreEstadoFiltro}\".");
                    return;
                }

                foreach (var envio in envios.AsEnumerable().Reverse())
                {
                    Panel tarjeta = (idEstado == 5) ? CrearTarjetaHistorial(envio) : CrearTarjetaEnvio(envio, idEstado);
                    panelTarjetas.Controls.Add(tarjeta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los envíos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private void MostrarMensajeVacio(string mensaje)
        {
            Panel panelVacio = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(245, 247, 250) };
            Label lblMensaje = new Label { Text = mensaje, Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.Gray, AutoSize = true };

            panelVacio.Paint += (s, e) =>
            {
                lblMensaje.Location = new Point((panelVacio.Width - lblMensaje.Width) / 2, (panelVacio.Height - lblMensaje.Height) / 2);
            };

            panelVacio.Controls.Add(lblMensaje);
            panelTarjetas.Controls.Add(panelVacio);
        }

        // =========================================================================
        // TARJETA DINÁMICA: SU BOTÓN CAMBIA DE ACCIÓN SEGÚN LA SECCIÓN ACTIVA
        // =========================================================================
        private Panel CrearTarjetaEnvio(Envio envio, int estadoActual)
        {
            int diasEnBodega = (DateTime.Now - envio.FechaEnvio).Days;
            bool esAlertaCritica = diasEnBodega > 30;
            string nombreEstado = envio.Estado?.Nombre ?? "Registrado";

            Panel panelCard = new Panel
            {
                Height = 110,
                Dock = DockStyle.Top,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 8, 10, 9),
            };

            if (esAlertaCritica) panelCard.BackColor = Color.FromArgb(255, 243, 243);

            // =========================================================================
            // 1. BOTONES DE ACCIÓN (Alineados dinámicamente a la derecha con Dock)
            // =========================================================================
            string textoBotonAvance = "Avanzar →";
            Color colorBotonAvance = Color.FromArgb(30, 78, 140);
            int estadoDestinoAvance = estadoActual + 1;

            switch (estadoActual)
            {
                case 1:
                    textoBotonAvance = "A Bodega Origen →";
                    colorBotonAvance = Color.FromArgb(30, 78, 140);
                    break;
                case 2:
                    textoBotonAvance = "A Tránsito →";
                    colorBotonAvance = Color.FromArgb(249, 115, 22);
                    break;
                case 3:
                    textoBotonAvance = "A Bodega Destino →";
                    colorBotonAvance = Color.FromArgb(13, 110, 253);
                    break;
                case 4:
                    textoBotonAvance = "Entregar ➔";
                    colorBotonAvance = Color.FromArgb(40, 167, 69);
                    estadoDestinoAvance = 5;
                    break;
            }

            Button btnAvanzar = new Button
            {
                Text = textoBotonAvance,
                Width = 135,
                Dock = DockStyle.Right,
                BackColor = colorBotonAvance,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 9f)
            };
            btnAvanzar.FlatAppearance.BorderSize = 0;

            btnAvanzar.Click += async (s, ev) =>
            {
                string mensaje = (estadoDestinoAvance == 5)
                    ? $"¿Desea registrar la entrega oficial del envío {envio.NumeroGuia}?"
                    : $"¿Desea avanzar el envío {envio.NumeroGuia} al siguiente estado?";

                if (MessageBox.Show(mensaje, "Confirmar Avance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool resultado = await _repository.CambiarEstadoEnvioAsync(envio.IdEnvio, estadoDestinoAvance, 1);
                    if (resultado)
                    {
                        MessageBox.Show("¡Envío actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarEnviosPorEstadoAsync(estadoActual, nombreEstado);
                    }
                }
            };

            if (estadoActual > 1)
            {
                int estadoDestinoRetroceso = estadoActual - 1;

                Button btnRegresar = new Button
                {
                    Text = "← Regresar",
                    Width = 95,
                    Dock = DockStyle.Right,
                    BackColor = Color.FromArgb(108, 117, 125),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI Semibold", 9f)
                };
                btnRegresar.FlatAppearance.BorderSize = 0;

                btnRegresar.Click += async (s, ev) =>
                {
                    string nombreFaseAnterior = ObtenerNombreFase(estadoDestinoRetroceso);
                    if (MessageBox.Show($"¿Desea regresar el envío {envio.NumeroGuia} a la fase \"{nombreFaseAnterior}\"?", "Confirmar Retroceso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        bool resultado = await _repository.CambiarEstadoEnvioAsync(envio.IdEnvio, estadoDestinoRetroceso, 1);
                        if (resultado)
                        {
                            MessageBox.Show("¡El envío ha sido regresado de fase con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await CargarEnviosPorEstadoAsync(estadoActual, nombreEstado);
                        }
                    }
                };

                panelCard.Controls.Add(btnRegresar);
            }

            panelCard.Controls.Add(btnAvanzar);

            // =========================================================================
            // 2. POSICIONAMIENTO DINÁMICO DE DATOS (ESTILO TICKET RESPONSIVO)
            // =========================================================================
            // Creamos las etiquetas primero para poderlas ubicar luego
            Label lblGuiaTitulo = new Label { Text = "N° Guía", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };
            Label lblGuiaValor = new Label { Text = envio.NumeroGuia, Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold), ForeColor = Color.FromArgb(30, 78, 140), AutoSize = true };

            Label lblDestTitulo = new Label { Text = "Destinatario", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };
            string nombreDestinatario = envio.ClienteDestinatario != null ? $"{envio.ClienteDestinatario.Nombre} {envio.ClienteDestinatario.Apellido}" : "N/A";
            Label lblDestValor = new Label { Text = nombreDestinatario, Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold), ForeColor = Color.Black, AutoSize = true };

            Label lblTelTitulo = new Label { Text = "Teléfono", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };
            string telefono = envio.ClienteDestinatario?.NumeroCedula ?? "+505 0000 0000";
            Label lblTelValor = new Label { Text = telefono, Font = new Font("Segoe UI", 10f), ForeColor = Color.Black, AutoSize = true };

            Label lblAgenciaTitulo = new Label { Text = "Agencia", Font = new Font("Segoe UI", 8f), ForeColor = Color.Gray, AutoSize = true };
            Label lblAgenciaValor = new Label { Text = envio.Agencia?.Nombre ?? "N/A", Font = new Font("Segoe UI", 9f), ForeColor = Color.Black, AutoSize = true };

            Label lblDiasTitulo = new Label { Text = "Días en bodega", Font = new Font("Segoe UI", 8f), ForeColor = Color.Gray, AutoSize = true };
            Label lblDiasValor = new Label { Text = $"{diasEnBodega} días ({nombreEstado})", Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold), ForeColor = esAlertaCritica ? Color.Red : Color.DimGray, AutoSize = true };

            Label lblObsValor = new Label { Text = envio.Observaciones ?? "Sin observaciones", Font = new Font("Segoe UI", 8.5f, FontStyle.Italic), ForeColor = esAlertaCritica ? Color.Red : Color.DarkOrange, AutoSize = true };

            // Función interna para recalcular las columnas proporcionalmente según el espacio disponible
            void AcomodarColumnasTicket()
            {
                // Ancho reservado para los botones de la derecha
                int anchoBotones = (estadoActual > 1) ? 240 : 145;
                int anchoDisponible = panelCard.Width - anchoBotones - 30;

                if (anchoDisponible < 300) anchoDisponible = 300; // Seguridad para resoluciones muy pequeñas

                // Repartimos el espacio en 3 columnas proporcionales (30% Columna 1, 40% Columna 2, 30% Columna 3)
                int col1_X = 15;
                int col2_X = col1_X + (int)(anchoDisponible * 0.30);
                int col3_X = col1_X + (int)(anchoDisponible * 0.68);

                // Fila 1 (Cima del ticket)
                lblGuiaTitulo.Location = new Point(col1_X, 10);
                lblGuiaValor.Location = new Point(col1_X, 28);

                lblDestTitulo.Location = new Point(col2_X, 10);
                lblDestValor.Location = new Point(col2_X, 28);

                lblTelTitulo.Location = new Point(col3_X, 10);
                lblTelValor.Location = new Point(col3_X, 28);

                // Fila 2 (Base del ticket)
                lblAgenciaTitulo.Location = new Point(col1_X, 60);
                lblAgenciaValor.Location = new Point(col1_X, 75);

                lblDiasTitulo.Location = new Point(col2_X, 60);
                lblDiasValor.Location = new Point(col2_X, 75);

                lblObsValor.Location = new Point(col3_X, 75);
            }

            // Nos aseguramos de ubicar los elementos al cargarse y cada vez que el panel cambie de tamaño
            panelCard.Resize += (s, e) => AcomodarColumnasTicket();
            AcomodarColumnasTicket(); // Ejecutar alineación inicial

            // Añadir todos los labels al panel
            panelCard.Controls.Add(lblGuiaTitulo);
            panelCard.Controls.Add(lblGuiaValor);
            panelCard.Controls.Add(lblDestTitulo);
            panelCard.Controls.Add(lblDestValor);
            panelCard.Controls.Add(lblTelTitulo);
            panelCard.Controls.Add(lblTelValor);
            panelCard.Controls.Add(lblAgenciaTitulo);
            panelCard.Controls.Add(lblAgenciaValor);
            panelCard.Controls.Add(lblDiasTitulo);
            panelCard.Controls.Add(lblDiasValor);
            panelCard.Controls.Add(lblObsValor);

            return panelCard;
        }

        // Método auxiliar rápido para mostrar el texto de la fase a la que regresará
        private string ObtenerNombreFase(int idEstado)
        {
            return idEstado switch
            {
                1 => "Registrado",
                2 => "En Bodega de Origen",
                3 => "En Tránsito",
                4 => "En Bodega de Destino",
                _ => "Estado anterior"
            };
        }

        // Tarjeta para Historial (Estado 5 - Entregados)
        private Panel CrearTarjetaHistorial(Envio envio)
        {
            Panel panelCard = new Panel
            {
                Height = 110,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(245, 247, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 8, 10, 9)
            };

            Button btnRevertir = new Button
            {
                Text = "Revertir ↩",
                Width = 95,
                Dock = DockStyle.Right,
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 9f)
            };
            btnRevertir.FlatAppearance.BorderSize = 0;

            btnRevertir.Click += async (s, ev) =>
            {
                var confirm = MessageBox.Show($"¿Está seguro de revertir la entrega del envío {envio.NumeroGuia}? Volverá al estado anterior.", "Confirmar Reversión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bool resultado = await _repository.CambiarEstadoEnvioAsync(envio.IdEnvio, 4, 1); // Regresa a Bodega de Destino (4)
                    if (resultado)
                    {
                        MessageBox.Show("¡Entrega revertida con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarEnviosPorEstadoAsync(5, "Entregado");
                    }
                }
            };

            Label lblGuia = new Label { Text = $"N° Guía: {envio.NumeroGuia}", Location = new Point(15, 15), Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(30, 78, 140), AutoSize = true };
            Label lblDest = new Label { Text = $"Destinatario: {envio.ClienteDestinatario?.Nombre} {envio.ClienteDestinatario?.Apellido}", Location = new Point(220, 15), Font = new Font("Segoe UI", 9.5f), ForeColor = Color.Black, AutoSize = true };
            Label lblFechaEntrega = new Label { Text = $"Entregado el: {envio.FechaEntregaReal?.ToString("dd/MM/yyyy HH:mm") ?? "N/A"}", Location = new Point(480, 15), Font = new Font("Segoe UI", 9f), ForeColor = Color.Green, AutoSize = true };
            Label lblAgencia = new Label { Text = $"Agencia: {envio.Agencia?.Nombre}", Location = new Point(15, 55), Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, AutoSize = true };

            panelCard.Controls.Add(btnRevertir);
            panelCard.Controls.Add(lblGuia);
            panelCard.Controls.Add(lblDest);
            panelCard.Controls.Add(lblFechaEntrega);
            panelCard.Controls.Add(lblAgencia);

            return panelCard;
        }

        private async void MostrarVentanaBusquedaRapida()
        {
            string numeroGuia = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese o escanee el número de guía:",
                "Búsqueda Rápida",
                "GU-");

            if (string.IsNullOrWhiteSpace(numeroGuia)) return;

            try
            {
                var envios = await _repository.ObtenerEnviosAsync();
                var envioEncontrado = envios.FirstOrDefault(e => e.NumeroGuia.Trim().Equals(numeroGuia.Trim(), StringComparison.OrdinalIgnoreCase));

                if (envioEncontrado != null)
                {
                    // Avanza al siguiente estado lógico o permite gestionarlo
                    int siguienteEstado = (int) (envioEncontrado.IdEstado < 5 ? envioEncontrado.IdEstado + 1 : 5);
                    bool resultado = await _repository.CambiarEstadoEnvioAsync(envioEncontrado.IdEnvio, siguienteEstado, 1);

                    if (resultado)
                    {
                        MessageBox.Show($"¡El envío {envioEncontrado.NumeroGuia} avanzó de estado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarEnviosPorEstadoAsync(_idEstadoActual, "Actualizado");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún envío con ese número de guía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Conexión de los botones superiores a sus respectivos IDs de Estado
        private async void btnPendientes_Click(object sender, EventArgs e) => await CargarEnviosPorEstadoAsync(1, "Registrado");
        private async void btnBodegaOrigen_Click(object sender, EventArgs e) => await CargarEnviosPorEstadoAsync(2, "En Bodega de Origen");
        private async void btnEnTransito_Click(object sender, EventArgs e) => await CargarEnviosPorEstadoAsync(3, "En Tránsito");
        private async void btnBodegaDestino_Click(object sender, EventArgs e) => await CargarEnviosPorEstadoAsync(4, "En Bodega de Destino");
        private async void btnHistorial_Click(object sender, EventArgs e) => await CargarEnviosPorEstadoAsync(5, "Entregado");

        private void btnRegistrarEntrega_Click(object sender, EventArgs e)
        {
            MostrarVentanaBusquedaRapida();
        }
    }
}