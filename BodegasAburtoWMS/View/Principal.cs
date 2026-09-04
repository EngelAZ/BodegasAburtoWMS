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
    }

}
