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
    public partial class DatosCliente : Form
    {
        private readonly IBodegasAburtoWMSRepository _repository;
        private readonly Cliente? _clienteActual;

        public DatosCliente(IBodegasAburtoWMSRepository repository, Cliente? cliente = null)
        {
            InitializeComponent();
            _repository = repository;
            _clienteActual = cliente;

            this.Load += DatosCliente_Load;
        }

        private void DatosCliente_Load(object sender, EventArgs e)
        {
            if (_clienteActual != null)
            {
                txtNombre.Text = _clienteActual.Nombre;
                txtApellido.Text = _clienteActual.Apellido;
                txtTelefono.Text = _clienteActual.Telefono;
                txtCorreo.Text = _clienteActual.Correo;
                txtDireccion.Text = _clienteActual.Direccion;
                txtCedula.Text = _clienteActual.NumeroCedula;
                dtpFechaRegistro.Value = _clienteActual.FechaRegistro;

                this.Text = "Editar Cliente";
            }
            else
            {
                dtpFechaRegistro.Value = DateTime.Now;
                dtpFechaRegistro.Enabled = false;
                this.Text = "Nuevo Cliente";
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El nombre y el apellido son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var clienteParaGuardar = _clienteActual ?? new Cliente();

                clienteParaGuardar.Nombre = txtNombre.Text.Trim();
                clienteParaGuardar.Apellido = txtApellido.Text.Trim();
                clienteParaGuardar.Telefono = txtTelefono.Text.Trim();
                clienteParaGuardar.Correo = txtCorreo.Text.Trim();
                clienteParaGuardar.Direccion = txtDireccion.Text.Trim();
                clienteParaGuardar.NumeroCedula = txtCedula.Text.Trim();
                clienteParaGuardar.FechaRegistro = dtpFechaRegistro.Value;

                bool resultado = await _repository.GuardarClienteAsync(clienteParaGuardar);

                if (resultado)
                {
                    MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtCedula.Clear();
            txtNombre.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
