using Microsoft.Data.SqlClient;
using BodegasAburtoWMS.Helpers;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;

namespace BodegasAburtoWMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();


            tbxContrasena.Enter += tbxContrasena_Enter;
            tbxContrasena.Leave += tbxContrasena_Leave;
            tbxUsuario.Enter += tbxUsuario_Enter;
            tbxUsuario.Leave += tbxUsuario_Leave;

        }

        private void tbxUsuario_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string contraseña = "Admin123*";

                PasswordHelper.CrearHash(
                    contraseña,
                    out byte[] passwordHash,
                    out byte[] passwordSalt
                );

                Usuario nuevoUsuario = new Usuario
                {
                    UsuarioNombre = "admin",
                    Nombre = "Administrador",
                    Apellido = "Sistema",
                    Correo = "admin@bodegasaburto.com",
                    IdRol = 1,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Activo = true
                };

                IBodegasAburtoWMSRepository repository =
                    new BodegasAburtoWMSRepository();

                bool registrado = repository.RegistrarUsuario(nuevoUsuario);

                if (registrado)
                {
                    MessageBox.Show(
                        "Usuario administrador creado correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo registrar el usuario.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al registrar el usuario.\n\n" +
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
