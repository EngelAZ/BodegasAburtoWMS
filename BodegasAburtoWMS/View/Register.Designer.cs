namespace BodegasAburtoWMS.View
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            lblUsuario = new Label();
            txtConfirmarContrasena = new TextBox();
            btnRegistrar = new Button();
            lblNombre = new Label();
            lblApellido = new Label();
            lblCorreo = new Label();
            lblContrasena = new Label();
            lblConfirmarContrasena = new Label();
            txtUsuario = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCorreo = new TextBox();
            txtContrasena = new TextBox();
            btnCancelar = new Button();
            lblRegister = new Label();
            cmbRol = new ComboBox();
            lblRol = new Label();
            ttlbrRegister = new BodegasAburtoWMS.Components.CustomTitleBar();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(96, 147);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(72, 25);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.Location = new Point(96, 543);
            txtConfirmarContrasena.Margin = new Padding(4, 5, 4, 5);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.Size = new Size(250, 31);
            txtConfirmarContrasena.TabIndex = 1;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(242, 140, 40);
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(96, 695);
            btnRegistrar.Margin = new Padding(4, 5, 4, 5);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(107, 38);
            btnRegistrar.TabIndex = 2;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(96, 220);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 25);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(96, 293);
            lblApellido.Margin = new Padding(4, 0, 4, 0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(78, 25);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(96, 367);
            lblCorreo.Margin = new Padding(4, 0, 4, 0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(66, 25);
            lblCorreo.TabIndex = 5;
            lblCorreo.Text = "Correo";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(96, 440);
            lblContrasena.Margin = new Padding(4, 0, 4, 0);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(101, 25);
            lblContrasena.TabIndex = 6;
            lblContrasena.Text = "Contraseña";
            // 
            // lblConfirmarContrasena
            // 
            lblConfirmarContrasena.AutoSize = true;
            lblConfirmarContrasena.Location = new Point(96, 513);
            lblConfirmarContrasena.Margin = new Padding(4, 0, 4, 0);
            lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            lblConfirmarContrasena.Size = new Size(185, 25);
            lblConfirmarContrasena.TabIndex = 7;
            lblConfirmarContrasena.Text = "Confirmar Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(96, 177);
            txtUsuario.Margin = new Padding(4, 5, 4, 5);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(250, 31);
            txtUsuario.TabIndex = 8;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(96, 250);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 31);
            txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(96, 323);
            txtApellido.Margin = new Padding(4, 5, 4, 5);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(250, 31);
            txtApellido.TabIndex = 10;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(96, 397);
            txtCorreo.Margin = new Padding(4, 5, 4, 5);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(250, 31);
            txtCorreo.TabIndex = 11;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(96, 470);
            txtContrasena.Margin = new Padding(4, 5, 4, 5);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(250, 31);
            txtContrasena.TabIndex = 12;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(242, 140, 40);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(240, 695);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 38);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegister.Location = new Point(160, 90);
            lblRegister.Margin = new Padding(4, 0, 4, 0);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(119, 40);
            lblRegister.TabIndex = 14;
            lblRegister.Text = "Register";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador" });
            cmbRol.Location = new Point(96, 617);
            cmbRol.Margin = new Padding(4, 5, 4, 5);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(250, 33);
            cmbRol.TabIndex = 15;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(96, 587);
            lblRol.Margin = new Padding(4, 0, 4, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(37, 25);
            lblRol.TabIndex = 16;
            lblRol.Text = "Rol";
            // 
            // ttlbrRegister
            // 
            ttlbrRegister.BackColor = Color.FromArgb(30, 78, 140);
            ttlbrRegister.Dock = DockStyle.Top;
            ttlbrRegister.Location = new Point(0, 0);
            ttlbrRegister.Margin = new Padding(4, 5, 4, 5);
            ttlbrRegister.Name = "ttlbrRegister";
            ttlbrRegister.Size = new Size(449, 67);
            ttlbrRegister.TabIndex = 17;
            ttlbrRegister.TitleIcon = Properties.Resources.IconoVentana;
            ttlbrRegister.TitleText = "Register";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 254, 254);
            ClientSize = new Size(449, 808);
            Controls.Add(ttlbrRegister);
            Controls.Add(lblRol);
            Controls.Add(cmbRol);
            Controls.Add(lblRegister);
            Controls.Add(btnCancelar);
            Controls.Add(txtContrasena);
            Controls.Add(txtCorreo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtUsuario);
            Controls.Add(lblConfirmarContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(lblCorreo);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(btnRegistrar);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private TextBox txtConfirmarContrasena;
        private Button btnRegistrar;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblCorreo;
        private Label lblContrasena;
        private Label lblConfirmarContrasena;
        private TextBox txtUsuario;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCorreo;
        private TextBox txtContrasena;
        private Button btnCancelar;
        private Label lblRegister;
        private ComboBox cmbRol;
        private Label lblRol;
        private Components.CustomTitleBar ttlbrRegister;
    }
}