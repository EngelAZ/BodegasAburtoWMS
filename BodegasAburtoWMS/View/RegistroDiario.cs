using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BodegasAburtoWMS.View
{
    public partial class RegistroDiario : Form
    {
        public RegistroDiario()
        {
            InitializeComponent();
        }

        private void RegistroDiario_Load(object sender, EventArgs e)
        {
            if (this.ParentForm is Principal formularioPrincipal)
            {

                // 1. Botón "Lista de Envíos" (Pestaña activa)
                Button btnListaEnvios = new Button
                {
                    Text = "📋 Lista de Envíos",
                    Size = new Size(130, 30),
                    Location = new Point(15, 5), // Esquina izquierda de la barra blanca
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(30, 78, 140), // Tu azul corporativo
                    Font = new Font("Segoe UI Semibold", 9f)
                };
                btnListaEnvios.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);

                // Al darle clic a Lista, simplemente recargamos esta misma vista por si acaso
                btnListaEnvios.Click += (s, ev) =>
                {
                    formularioPrincipal.MostrarFormEnCentro(new RegistroDiario());
                };

                // 2. Botón "+ Nuevo Envío" (Acción para cambiar de panel)
                Button btnNuevoEnvio = new Button
                {
                    Text = "+ Nuevo Envío",
                    Size = new Size(110, 30),
                    Location = new Point(150, 5), // Al ladito del primer botón
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(245, 245, 245), // Color gris claro de fondo
                    ForeColor = Color.DimGray,
                    Font = new Font("Segoe UI", 9f)
                };
                btnNuevoEnvio.FlatAppearance.BorderSize = 0;

                // 3. ¡EL TRUCO DE NAVEGACIÓN!: Cuando hagan clic en + Nuevo Envío, cargamos el formulario correspondiente en el centro
                btnNuevoEnvio.Click += (s, ev) =>
                {
                    // Suponiendo que tu formulario de creación se llama "NuevoEnvioForm"
                    // Llamamos al método público de la ventana principal para incrustarlo en la zona gris
                    formularioPrincipal.MostrarFormEnCentro(new DatosEnvios());
                };

                // 4. Agregamos ambos botones a la barra blanca superior
                formularioPrincipal.PanelOpciones.Controls.Add(btnListaEnvios);
                formularioPrincipal.PanelOpciones.Controls.Add(btnNuevoEnvio);
            }
        }
    }
}
