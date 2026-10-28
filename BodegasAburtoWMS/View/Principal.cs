using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;
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
        private readonly IBodegasAburtoWMSRepository _repository; // Opcional si usas repositorio con DI

        // Constructor que recibe el usuario y opcionalmente el repositorio para tareas en segundo plano
        public Principal(Usuario usuario, IBodegasAburtoWMSRepository? repository = null)
        {
            InitializeComponent();
            usuarioActual = usuario;
            _repository = repository;

            // Suscribirse al evento Load para tareas asíncronas de inicio
            this.Load += Principal_Load;
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
                Point pos = this.PointToClient(Cursor.Position);
                int anchoBorde = 8;

                if (pos.X <= anchoBorde && pos.Y <= anchoBorde) m.Result = (IntPtr)HTTOPLEFT;
                else if (pos.X >= this.ClientSize.Width - anchoBorde && pos.Y <= anchoBorde) m.Result = (IntPtr)HTTOPRIGHT;
                else if (pos.X <= anchoBorde && pos.Y >= this.ClientSize.Height - anchoBorde) m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (pos.X >= this.ClientSize.Width - anchoBorde && pos.Y >= this.ClientSize.Height - anchoBorde) m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (pos.X <= anchoBorde) m.Result = (IntPtr)HTLEFT;
                else if (pos.X >= this.ClientSize.Width - anchoBorde) m.Result = (IntPtr)HTRIGHT;
                else if (pos.Y <= anchoBorde) m.Result = (IntPtr)HTTOP;
                else if (pos.Y >= this.ClientSize.Height - anchoBorde) m.Result = (IntPtr)HTBOTTOM;
            }
        }

        public void MostrarFormEnCentro(Form formHijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
            {
                if (this.PanelContenedor.Controls[0] is Form formAnterior)
                {
                    formAnterior.Close();
                }
                this.PanelContenedor.Controls.Clear();
            }
            this.PanelOpciones.Controls.Clear();

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            this.PanelContenedor.Controls.Add(formHijo);
            this.PanelContenedor.Tag = formHijo;
            formHijo.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Dashboard());
        }

        private void btnRegistroDiario_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new RegistroDiario(_repository));
        }

        private void btnSalidasEntradas_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Entregas_Salidas(_repository));
        }

        private void btnAgencias_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Agencias(_repository));
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new Clientes(_repository));
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

        private void Principal_Load(object sender, EventArgs e)
        {
            string nombreRol = usuarioActual.Rol?.Nombre ?? "Sin Rol Asignado";

            MessageBox.Show(
                $"Usuario: {usuarioActual.UsuarioNombre}\n" +
                $"Nombre: {usuarioActual.Nombre} {usuarioActual.Apellido}\n" +
                $"Rol: {nombreRol}",
                "Sesión actual",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // 2. Cargar el dashboard inicial
            MostrarFormEnCentro(new Dashboard());

            // 3. Ejecutar tarea en segundo plano (Asíncrona) para registrar el último acceso sin congelar la UI
            if (_repository != null)
            {
                // Usamos Task.Run o directamente el método async del repositorio
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await _repository.RegistrarUltimoAccesoAsync(usuarioActual.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores en segundo plano (ej. log)
                        System.Diagnostics.Debug.WriteLine($"Error al registrar último acceso: {ex.Message}");
                    }
                });
            }
        }
    }

}
