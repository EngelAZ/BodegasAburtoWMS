using BodegasAburtoWMS.Helpers;
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
    public partial class Register : Form
    {
        private readonly IBodegasAburtoWMSRepository repository = new BodegasAburtoWMSRepository();
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargamos los roles disponibles (Administrador, Operador, etc.) al abrir la pantalla
                cmbRol.DataSource = repository.ObtenerRolesCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas de campos vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, rellene los campos obligatorios (Usuario, Contraseña y Rol).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que las contraseñas coincidan
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifíquelas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. OBTENER EL HASH Y SALT USANDO TU PASSWORDHELPER
                // Las variables out se llenarán automáticamente con bytes encriptados
                PasswordHelper.CrearHash(txtContrasena.Text.Trim(), out byte[] hashGenerado, out byte[] saltGenerado);

                // 4. Mapeamos los datos al modelo Usuario
                int idRolSeleccionado = ((ComboboxItem)cmbRol.SelectedItem).Value;

                Usuario nuevoUsuario = new Usuario
                {
                    UsuarioNombre = txtUsuario.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim(),
                    IdRol = idRolSeleccionado,
                    PasswordHash = hashGenerado, // Guardamos los bytes encriptados
                    PasswordSalt = saltGenerado, // Guardamos la llave de salado
                    Activo = true // El usuario entra al sistema habilitado por defecto
                };

                // 5. Mandar a guardar a la base de datos a través de tu repositorio
                bool guardado = repository.RegistrarUsuario(nuevoUsuario);

                if (guardado)
                {
                    MessageBox.Show("¡Usuario registrado con éxito en el sistema WMS!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerramos la ventana de registro
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario. El nombre de usuario podría estar duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al registrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
