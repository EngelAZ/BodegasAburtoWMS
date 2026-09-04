using BodegasAburtoWMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class Principal : Form
    {
        private readonly Usuario usuarioActual;

        public Principal(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;

            MessageBox.Show(
            $"Usuario: {usuarioActual.UsuarioNombre}\n" +
            $"Nombre: {usuarioActual.Nombre} {usuarioActual.Apellido}\n" +
            $"Rol: {usuarioActual.Rol}",
            "Sesión actual",
            MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            MostrarFormEnCentro(new Dashboard());
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTLEFT = 10; private const int HTRIGHT = 11;
        private const int HTTOP = 12; private const int HTTOPLEFT = 13; private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15; private const int HTBOTTOMLEFT = 16; private const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (this.WindowState == FormWindowState.Maximized) return;

            if (m.Msg == WM_NCHITTEST)
            {
                // Convierte la posición física del mouse a coordenadas dentro de tu formulario
                Point pos = this.PointToClient(Cursor.Position);
                int anchoBorde = 8; // Sensibilidad del mouse

                // Esquinas superiores e inferiores
                if (pos.X <= anchoBorde && pos.Y <= anchoBorde) m.Result = (IntPtr)HTTOPLEFT;
                else if (pos.X >= this.ClientSize.Width - anchoBorde && pos.Y <= anchoBorde) m.Result = (IntPtr)HTTOPRIGHT;
                else if (pos.X <= anchoBorde && pos.Y >= this.ClientSize.Height - anchoBorde) m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (pos.X >= this.ClientSize.Width - anchoBorde && pos.Y >= this.ClientSize.Height - anchoBorde) m.Result = (IntPtr)HTBOTTOMRIGHT;
                // Bordes rectos
                else if (pos.X <= anchoBorde) m.Result = (IntPtr)HTLEFT;
                else if (pos.X >= this.ClientSize.Width - anchoBorde) m.Result = (IntPtr)HTRIGHT;
                else if (pos.Y <= anchoBorde) m.Result = (IntPtr)HTTOP;
                else if (pos.Y >= this.ClientSize.Height - anchoBorde) m.Result = (IntPtr)HTBOTTOM;
            }
        }

        // Método para incrustar cualquier Forms en la zona gris central
        public void MostrarFormEnCentro(Form formHijo)
        {
            // 1. Si ya hay una pantalla cargada en la zona gris, la cerramos para liberar memoria
            if (this.PanelContenedor.Controls.Count > 0)
            {
                // Esto busca el formulario anterior que estaba adentro y lo cierra formalmente
                if (this.PanelContenedor.Controls[0] is Form formAnterior)
                {
                    formAnterior.Close();
                }
                this.PanelContenedor.Controls.Clear();
            }
            // --- Limpiamos también la barra blanca superior cada vez que cambiamos de pantalla ---
            this.PanelOpciones.Controls.Clear();

            // 2. CONFIGURACIÓN CLAVE: Le decimos al formulario que se comporte como un control secundario
            formHijo.TopLevel = false;            // IMPORTANTE: Le quita la propiedad de ventana independiente
            formHijo.FormBorderStyle = FormBorderStyle.None; // Le borra los bordes por si las dudas
            formHijo.Dock = DockStyle.Fill;       // Hace que se estire al tamaño completo del panel gris

            // 3. Lo metemos físicamente en el contenedor y lo encendemos
            this.PanelContenedor.Controls.Add(formHijo);
            this.PanelContenedor.Tag = formHijo;  // Guardamos la referencia por si acaso
            formHijo.Show();                      // Lo hacemos visible adentro del panel
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Dashboard());
        }

        private void btnRegistroDiario_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new RegistroDiario());
        }

        private void btnSalidasEntradas_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Entregas_Salidas());
        }

        private void btnAgencias_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Agencias());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Clientes());
        }

        private void btnMateriales_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Materiales());
        }

        private void btnLiquidacion_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Liquidacion());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Reportes());
        }
    }

}
