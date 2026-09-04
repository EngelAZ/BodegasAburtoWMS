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
    public partial class Principal : Form
    {
        private readonly Usuario usuarioActual;

        public Principal(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;

            MessageBox.Show(
        $"Usuario: {usuarioActual.UsuarioNombre}\n" +
        $"Nombre: {usuarioActual.Nombre} {usuarioActual.Apellido}\n" +
        $"Rol: {usuarioActual.Rol}",
        "Sesión actual",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    );
        }
    }
}
