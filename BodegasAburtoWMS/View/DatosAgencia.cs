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
    public partial class DatosAgencia : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private readonly Agencia? _agenciaActual; // Nulo si es registro nuevo, con datos si es edición

        // Constructor para Inyección de Dependencias (Soporta nuevo registro o edición)
        public DatosAgencia(IBodegasAburtoWMSRepository repository, Agencia? agencia = null)
        {
            InitializeComponent();
            _repository = repository;
            _agenciaActual = agencia;

            this.Load += DatosAgencia_Load;
        }

        private void DatosAgencia_Load(object sender, EventArgs e)
        {
            if (_agenciaActual != null)
            {
                txtNombre.Text = _agenciaActual.Nombre;
                txtContacto.Text = _agenciaActual.Contacto;
                txtTelefono.Text = _agenciaActual.Telefono;
                txtCiudad.Text = _agenciaActual.Ciudad;

                // Asumiendo que el control de estado es un ComboBox (Activo / Inactivo)
                cmbEstado.SelectedItem = _agenciaActual.Estado ? "Activo" : "Inactivo";
                dtpFechaRegistro.Value = _agenciaActual.FechaRegistro;

                this.Text = "Editar Agencia";
                btnAgregar.Text = "Actualizar";
            }
            else
            {
                dtpFechaRegistro.Value = DateTime.Now;
                dtpFechaRegistro.Enabled = false; // Por lo general la fecha de registro se genera sola
                this.Text = "Nueva Agencia";
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la agencia es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                // Mapear los datos del formulario al modelo Agencia
                var agenciaParaGuardar = _agenciaActual ?? new Agencia();

                agenciaParaGuardar.Nombre = txtNombre.Text.Trim();
                agenciaParaGuardar.Contacto = txtContacto.Text.Trim();
                agenciaParaGuardar.Telefono = txtTelefono.Text.Trim();
                agenciaParaGuardar.Ciudad = txtCiudad.Text.Trim();

                // Evaluar el estado del ComboBox (Ajusta según los items de tu diseño)
                agenciaParaGuardar.Estado = cmbEstado.SelectedItem?.ToString() == "Activo";
                agenciaParaGuardar.FechaRegistro = dtpFechaRegistro.Value;

                // Llamada asíncrona al repositorio mediante Entity Framework Core
                bool resultado = await _repository.GuardarAgenciaAsync(agenciaParaGuardar);

                if (resultado)
                {
                    MessageBox.Show("Agencia guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Devuelve OK al formulario padre para que refresque la tabla
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la agencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtCiudad.Clear();
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
