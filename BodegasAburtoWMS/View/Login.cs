using BodegasAburtoWMS.Helpers;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;
using BodegasAburtoWMS.View;

namespace BodegasAburtoWMS
{
    public partial class Login : Form
    {
        private readonly IBodegasAburtoWMSRepository repository;
        public Login()
        {
            InitializeComponent();

            repository = new BodegasAburtoWMSRepository();

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
        private void btnInicioSesion_Click(object sender, EventArgs e)
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
                Usuario usuario = repository.ObtenerUsuarioPorNombre(nombreUsuario);

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

                repository.RegistrarUltimoAcceso(usuario.IdUsuario);

                repository.RegistrarAuditoria(
                    usuario.IdUsuario,
                    "Inicio de sesión",
                    usuario.UsuarioNombre,
                    "Inicio de sesión exitoso."
                );

                Principal principal = new Principal(usuario);

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

    }
}
