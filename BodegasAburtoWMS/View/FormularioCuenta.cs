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

            // Configurar límites seguros para el NumericUpDown del año
            numAnio.Minimum = 2000;
            numAnio.Maximum = 2100;
            numAnio.Value = DateTime.Now.Year; // Por defecto el año actual
        }

        public FormularioCuenta(CuentaBalance cuentaExistente)
        {
            InitializeComponent();
            Cuenta = cuentaExistente;
            CargarTiposCuenta();

            // Configurar límites seguros para el NumericUpDown del año
            numAnio.Minimum = 2000;
            numAnio.Maximum = 2100;

            txtNombreCuenta.Text = Cuenta.NombreCuenta;
            cmbTipo.SelectedItem = Cuenta.Tipo;
            txtSaldo.Text = Cuenta.Saldo.ToString("N2");

            int anioObjetivo = Cuenta.Anio > 0 ? Cuenta.Anio : DateTime.Now.Year;
            if (anioObjetivo >= numAnio.Minimum && anioObjetivo <= numAnio.Maximum)
            {
                numAnio.Value = anioObjetivo;
            }
            else
            {
                numAnio.Value = DateTime.Now.Year;
            }

            this.Text = "Editar Cuenta Contable";
        }

        // En el botón Guardar:

        private void CargarTiposCuenta()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Activos corrientes");
            cmbTipo.Items.Add("Activos fijos");
            cmbTipo.Items.Add("Pasivos Corrientes");
            cmbTipo.Items.Add("Pasivos fijos");
            cmbTipo.Items.Add("Patrimonio");

            cmbTipo.Items.Add("Ingresos");
            cmbTipo.Items.Add("Costos");
            cmbTipo.Items.Add("Gastos");
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
            Cuenta.Anio = (int)numAnio.Value;
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
