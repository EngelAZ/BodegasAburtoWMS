using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BodegasAburtoWMS.Components
{
    public partial class CustomTitleBar : UserControl
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Agregamos el operador '!' para indicarle a .NET 10 que se inicializarán inmediatamente
        private PictureBox picIcono = null!;
        private Label lblTitulo = null!;
        private Button btnCerrar = null!;
        private Button btnMaximizar = null!;
        private Button btnMinimizar = null!;

        // --- PROPIEDADES VISIBLES EN EL MENÚ DE PROPIEDADES ---

        [Category("Design")]
        [Description("Establece el texto que se muestra en la barra de título.")]
        [Browsable(true)] // <- ESTA LÍNEA OBLIGA A VISUAL STUDIO A MOSTRARLA A LA DERECHA
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TitleText
        {
            get => lblTitulo != null ? lblTitulo.Text : "Título";
            set { if (lblTitulo != null) lblTitulo.Text = value; }
        }

        [Category("Design")]
        [Description("Establece la imagen del icono de la barra.")]
        [Browsable(true)] // Slots de visualización para el diseñador
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image? TitleIcon
        {
            get => picIcono?.Image;
            set { if (picIcono != null) picIcono.Image = value; }
        }

        [Category("Design")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor
        {
            get => lblTitulo != null ? lblTitulo.ForeColor : base.ForeColor;
            set
            {
                base.ForeColor = value;
                if (lblTitulo != null) lblTitulo.ForeColor = value;
            }
        }

        [Category("Design")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Font Font
        {
            get => lblTitulo != null ? lblTitulo.Font : base.Font;
            set
            {
                base.Font = value;
                if (lblTitulo != null) lblTitulo.Font = value;
            }
        }

        [Category("Design")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                // Si quieres que los botones de minimizar/maximizar hereden el fondo de la barra, los actualizamos aquí:
                if (btnMinimizar != null) btnMinimizar.BackColor = value;
                if (btnMaximizar != null) btnMaximizar.BackColor = value;
            }
        }

        public CustomTitleBar()
        {
            InicializarComponentesPersonalizados();

            this.Dock = DockStyle.Top;
            this.Height = 40;
            this.BackColor = Color.FromArgb(30, 78, 140);
        }

        private void InicializarComponentesPersonalizados()
        {
            btnCerrar = new Button
            {
                Text = "✕",
                Size = new Size(45, 40),
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.Red;
            btnCerrar.Click += (s, e) => ParentForm?.Close();

            btnMaximizar = new Button
            {
                Text = "🗖",
                Size = new Size(45, 40),
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            };
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 100, 170);
            btnMaximizar.Click += (s, e) => {
                if (ParentForm == null) return;
                if (ParentForm.WindowState == FormWindowState.Maximized)
                {
                    ParentForm.WindowState = FormWindowState.Normal;
                    btnMaximizar.Text = "🗖";
                }
                else
                {
                    ParentForm.WindowState = FormWindowState.Maximized;
                    btnMaximizar.Text = "🗗";
                }
            };

            btnMinimizar = new Button
            {
                Text = "—",
                Size = new Size(45, 40),
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 100, 170);
            btnMinimizar.Click += (s, e) => { if (ParentForm != null) ParentForm.WindowState = FormWindowState.Minimized; };

            picIcono = new PictureBox
            {
                Size = new Size(24, 24),
                Location = new Point(10, 8),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblTitulo = new Label
            {
                Text = "Título",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10f),
                AutoSize = true,
                Location = new Point(40, 10)
            };

            this.MouseDown += Bar_MouseDown;
            lblTitulo.MouseDown += Bar_MouseDown;
            this.DoubleClick += Bar_DoubleClick;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(picIcono);
            this.Controls.Add(btnMinimizar);
            this.Controls.Add(btnMaximizar);
            this.Controls.Add(btnCerrar);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (ParentForm != null)
            {
                // Quitamos los bordes nativos de Windows
                ParentForm.FormBorderStyle = FormBorderStyle.None;

                // Intentamos detectar si el formulario tiene una propiedad personalizada llamada "IsLocked" (o "Lock")
                bool estaBloqueado = false;

                // Buscamos mediante Reflection si el formulario padre tiene una propiedad bool llamada "IsLocked" o "Lock"
                var propLock = ParentForm.GetType().GetProperty("IsLocked") ?? ParentForm.GetType().GetProperty("Lock");
                if (propLock != null && propLock.PropertyType == typeof(bool))
                {
                    estaBloqueado = (bool)(propLock.GetValue(ParentForm) ?? false);
                }

                // SI ESTÁ BLOQUEADO (Lock == true), OCULTAMOS MINIMIZAR Y MAXIMIZAR
                if (estaBloqueado)
                {
                    btnMaximizar.Visible = false;
                    btnMinimizar.Visible = false;
                }
                else
                {
                    // Si no está bloqueado, respetamos lo que diga el formulario normalmente
                    btnMaximizar.Visible = ParentForm.MaximizeBox;
                    btnMinimizar.Visible = ParentForm.MinimizeBox;
                }
            }

        }

        private void Bar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ParentForm != null)
            {
                ReleaseCapture();
                SendMessage(ParentForm.Handle, 0x112, 0xf012, 0);
            }
        }

        private void Bar_DoubleClick(object sender, EventArgs e)
        {
            btnMaximizar.PerformClick();
        }

        // Método Dispose propio y controlado para evitar conflictos con el diseñador
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                picIcono?.Dispose();
                btnCerrar?.Dispose();
                btnMaximizar?.Dispose();
                btnMinimizar?.Dispose();
                lblTitulo?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}