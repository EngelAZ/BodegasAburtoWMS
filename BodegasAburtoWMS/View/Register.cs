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
        private readonly IBodegasAburtoWMSRepository _repository;

        // Inyección de dependencias del repositorio
        public Register(IBodegasAburtoWMSRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            this.Load += Register_Load;
        }
        private async void Register_Load(object sender, EventArgs e)
        {
            await CargarRolesAsync();
        }

        private async Task CargarRolesAsync()
        {
            try
            {
                var roles = await _repository.ObtenerRolesComboAsync();

                if (roles == null || roles.Count == 0)
                {
                    MessageBox.Show("La tabla de Roles en la base de datos está vacía. Por favor, inserte roles antes de registrar usuarios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmbRol.DataSource = roles;
                cmbRol.DisplayMember = "Text";
                cmbRol.ValueMember = "Value";
                cmbRol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                 string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                 string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                MessageBox.Show("Por favor, rellene los campos obligatorios (Usuario y Contraseñas).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que se haya seleccionado un rol válido en el ComboBox
            if (cmbRol.SelectedIndex == -1 || cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un Rol válido para el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validar que las contraseñas coincidan
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifíquelas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 4. Obtener Hash y Salt con PasswordHelper
                PasswordHelper.CrearHash(txtContrasena.Text.Trim(), out byte[] hashGenerado, out byte[] saltGenerado);

                // 5. Obtener de manera segura el ID del rol seleccionado mediante SelectedValue
                int idRolSeleccionado = Convert.ToInt32(cmbRol.SelectedValue);

                // 6. Mapear datos al modelo Usuario
                Usuario nuevoUsuario = new Usuario
                {
                    UsuarioNombre = txtUsuario.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim(),
                    IdRol = idRolSeleccionado,
                    PasswordHash = hashGenerado,
                    PasswordSalt = saltGenerado,
                    Activo = true
                };

                // 7. Guardar de forma asíncrona mediante el repositorio EF Core
                bool guardado = await _repository.RegistrarUsuarioAsync(nuevoUsuario);

                if (guardado)
                {
                    MessageBox.Show("¡Usuario registrado con éxito en el sistema WMS!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario. El nombre de usuario ya se encuentra registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
