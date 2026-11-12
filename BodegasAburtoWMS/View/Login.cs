using BodegasAburtoWMS.Helpers;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;
using BodegasAburtoWMS.View;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace BodegasAburtoWMS
{
    public partial class Login : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLocked { get; set; } = true;
        private readonly IBodegasAburtoWMSRepository _repository;
        private readonly IServiceProvider _serviceProvider;

        // Inyección de dependencias del repositorio
        public Login(IServiceProvider serviceProvider, IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            _serviceProvider = serviceProvider;

            // Suscripción de eventos para los placeholders de los TextBox
            tbxContrasena.Enter += tbxContrasena_Enter;
            tbxContrasena.Leave += tbxContrasena_Leave;
            tbxUsuario.Enter += tbxUsuario_Enter;
            tbxUsuario.Leave += tbxUsuario_Leave;
        }

        private void tbxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        /*
        Usuario:
        admin

        Contraseña:
        Admin123*
        */
        private async void btnInicioSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = tbxUsuario.Text.Trim();
            string contraseña = tbxContrasena.Text;

            if (nombreUsuario == "" || nombreUsuario == "Ingrese su usuario")
            {
                MessageBox.Show(
                    "Ingrese su usuario.",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbxUsuario.Focus();
                return;
            }

            if (contraseña == "" || contraseña == "Ingrese su contraseña")
            {
                MessageBox.Show(
                    "Ingrese su contraseña.",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tbxContrasena.Focus();
                return;
            }

            try
            {
                // 1. Obtener usuario de forma asíncrona mediante EF Core
                Usuario usuario = await _repository.ObtenerUsuarioPorNombreAsync(nombreUsuario);

                if (usuario == null)
                {
                    MessageBox.Show(
                        "El usuario no existe o se encuentra inactivo.",
                        "Inicio de sesión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    tbxUsuario.Focus();
                    return;
                }

                // 2. Verificar el Password Hash y Salt
                bool contraseñaCorrecta = PasswordHelper.VerificarPassword(
                    contraseña,
                    usuario.PasswordHash,
                    usuario.PasswordSalt
                );

                if (!contraseñaCorrecta)
                {
                    MessageBox.Show(
                        "La contraseña es incorrecta.",
                        "Inicio de sesión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    tbxContrasena.Focus();
                    return;
                }

                // 3. Registrar último acceso y auditoría de manera asíncrona en segundo plano
                await _repository.RegistrarUltimoAccesoAsync(usuario.IdUsuario);

                await _repository.RegistrarAuditoriaAsync(
                    usuario.IdUsuario,
                    "Inicio de sesión",
                    usuario.UsuarioNombre,
                    "Inicio de sesión exitoso."
                );

                // 4. Abrir ventana Principal inyectándole el usuario y el repositorio actual
                Principal principal = new Principal(usuario, _serviceProvider, _repository);

                this.Hide();

                principal.ShowDialog();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al intentar iniciar sesión.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void tbxContrasena_Enter(object sender, EventArgs e)
        {
            if (tbxContrasena.Text == "Ingrese su contraseña")
            {
                tbxContrasena.Text = "";
                tbxContrasena.UseSystemPasswordChar = true;
            }
        }

        private void tbxContrasena_Leave(object sender, EventArgs e)
        {
            if (tbxContrasena.Text == "")
            {
                tbxContrasena.UseSystemPasswordChar = false;
                tbxContrasena.Text = "Ingrese su contraseña";
            }

        }

        private void tbxUsuario_Enter(object sender, EventArgs e)
        {
            if (tbxUsuario.Text == "Ingrese su usuario")
            {
                tbxUsuario.Text = "";
            }
        }

        private void tbxUsuario_Leave(object sender, EventArgs e)
        {
            if (tbxUsuario.Text == "")
            {
                tbxUsuario.Text = "Ingrese su usuario";
            }
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

        private void lnklblRegistrarUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Pasamos el mismo repositorio ya inyectado al formulario Register
            Register ventanaRegistro = new Register(_repository);

            this.Hide();
            ventanaRegistro.ShowDialog();
            this.Show();
        }
    }
}
