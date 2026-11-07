using BodegasAburtoWMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class FormularioCuenta : Form
    {
        public CuentaBalance Cuenta { get; private set; }

        // Constructor para CREAR una nueva cuenta
        public FormularioCuenta()
        {
            InitializeComponent();
            Cuenta = new CuentaBalance();
            CargarTiposCuenta();
            cmbTipo.SelectedIndex = 0;
        }

        // Constructor para EDITAR una cuenta existente
        public FormularioCuenta(CuentaBalance cuentaExistente)
        {
            InitializeComponent();
            Cuenta = cuentaExistente;
            CargarTiposCuenta();

            // Rellenar los controles con los datos actuales
            txtNombreCuenta.Text = Cuenta.NombreCuenta;

            if (!string.IsNullOrEmpty(Cuenta.Tipo))
            {
                cmbTipo.SelectedItem = Cuenta.Tipo;
                if (cmbTipo.SelectedIndex == -1 && cmbTipo.Items.Count > 0)
                {
                    cmbTipo.SelectedIndex = 0; // Fallback por seguridad
                }
            }

            txtSaldo.Text = Cuenta.Saldo.ToString("N2");
            this.Text = "Editar Cuenta Contable";
        }

        private void CargarTiposCuenta()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Activos corrientes");
            cmbTipo.Items.Add("Activos fijos");
            cmbTipo.Items.Add("Pasivos Corrientes");
            cmbTipo.Items.Add("Pasivos fijos");
            cmbTipo.Items.Add("Patrimonio");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombreCuenta.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la cuenta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSaldo.Text, out decimal saldo))
            {
                MessageBox.Show("El saldo ingresado no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Asignar valores a la entidad
            Cuenta.NombreCuenta = txtNombreCuenta.Text.Trim();
            Cuenta.Tipo = cmbTipo.SelectedItem?.ToString() ?? "Activo";
            Cuenta.Saldo = saldo;
            Cuenta.FechaActualizacion = DateTime.Now;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
