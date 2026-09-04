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
