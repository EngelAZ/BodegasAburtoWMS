using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class PanelFinanciero : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Usuario usuarioActual;
        private readonly IBodegasAburtoWMSRepository _repository;

<<<<<<< HEAD
        // Constructor que recibe el usuario y opcionalmente el repositorio para tareas en segundo plano
        public PanelFinanciero(Usuario usuario, IServiceProvider serviceProvider, IBodegasAburtoWMSRepository? repository = null)
=======
        // Constructor que recibe el usuario y el repositorio
        public PanelFinanciero(Usuario usuario, IBodegasAburtoWMSRepository? repository = null)
>>>>>>> 20ff628be66b085614fec40c670d42f638b80bf6
        {
            InitializeComponent();
            usuarioActual = usuario;
            _repository = repository;
            _serviceProvider = serviceProvider;

            // Suscribirse al evento Load para tareas asíncronas de inicio
            this.Load += PanelFinanciero_Load;
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

            // Opcional: limpiar PanelOpciones si lo usabas para otra botonera secundaria
            if (this.PanelOpciones != null)
            {
                this.PanelOpciones.Controls.Clear();
            }

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            this.PanelContenedor.Controls.Add(formHijo);
            this.PanelContenedor.Tag = formHijo;
            formHijo.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // Ejecutar tarea en segundo plano (Asíncrona) para registrar el último acceso sin congelar la UI
            if (_repository != null)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await _repository.RegistrarUltimoAccesoAsync(usuarioActual.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error al registrar último acceso: {ex.Message}");
                    }
                });
            }
        }

        private void btnEstadosFinancieros_Click(object sender, EventArgs e)
        {
            MostrarFormEnCentro(new ModuloEstadosFinacieros(_repository));
        }

        private void btnAnalisisFinanciero_Click(object sender, EventArgs e)
        {

        }

        private void btnPuntoEquilibrioCVU_Click(object sender, EventArgs e)
        {

        }

        private void btnApalancamiento_Click(object sender, EventArgs e)
        {

        }

        private void btnFlujoEfectivo_Click(object sender, EventArgs e)
        {

        }

        private void btnPlaneacionPresupuestos_Click(object sender, EventArgs e)
        {
            var moduloPresupuesto = _serviceProvider.GetRequiredService<FormModuloPresupuesto>();
            MostrarFormEnCentro(moduloPresupuesto);
        }

        private void btnProforma_Click(object sender, EventArgs e)
        {

        }

        private void btnPresupuestoPersonal_Click(object sender, EventArgs e)
        {

        }

        private void btnControlBasicoInventario_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresarPrincipal_Click(object sender, EventArgs e)
        {
            this.Hide();

            Principal P = new Principal(usuarioActual, _serviceProvider, _repository, 1);
            P.ShowDialog();

            this.Close();

        }

        private void PanelFinanciero_Load(object sender, EventArgs e)
        {
            if (_repository != null)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await _repository.RegistrarUltimoAccesoAsync(usuarioActual.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error al registrar último acceso: {ex.Message}");
                    }
                });
            }
        }
    }

}
