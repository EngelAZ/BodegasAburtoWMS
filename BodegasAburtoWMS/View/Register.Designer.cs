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
            lblUsuario.Location = new Point(67, 88);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.Location = new Point(67, 326);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.Size = new Size(176, 23);
            txtConfirmarContrasena.TabIndex = 1;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(242, 140, 40);
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(67, 417);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 2;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(67, 132);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(67, 176);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(67, 220);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(43, 15);
            lblCorreo.TabIndex = 5;
            lblCorreo.Text = "Correo";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(67, 264);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(67, 15);
            lblContrasena.TabIndex = 6;
            lblContrasena.Text = "Contraseña";
            // 
            // lblConfirmarContrasena
            // 
            lblConfirmarContrasena.AutoSize = true;
            lblConfirmarContrasena.Location = new Point(67, 308);
            lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            lblConfirmarContrasena.Size = new Size(124, 15);
            lblConfirmarContrasena.TabIndex = 7;
            lblConfirmarContrasena.Text = "Confirmar Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(67, 106);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(176, 23);
            txtUsuario.TabIndex = 8;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(67, 150);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(176, 23);
            txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(67, 194);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(176, 23);
            txtApellido.TabIndex = 10;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(67, 238);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(176, 23);
            txtCorreo.TabIndex = 11;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(67, 282);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(176, 23);
            txtContrasena.TabIndex = 12;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(242, 140, 40);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(168, 417);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegister.Location = new Point(112, 54);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(79, 25);
            lblRegister.TabIndex = 14;
            lblRegister.Text = "Register";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(67, 370);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(176, 23);
            cmbRol.TabIndex = 15;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(67, 352);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(24, 15);
            lblRol.TabIndex = 16;
            lblRol.Text = "Rol";
            // 
            // ttlbrRegister
            // 
            ttlbrRegister.BackColor = Color.FromArgb(30, 78, 140);
            ttlbrRegister.Dock = DockStyle.Top;
            ttlbrRegister.Location = new Point(0, 0);
            ttlbrRegister.Name = "ttlbrRegister";
            ttlbrRegister.Size = new Size(314, 40);
            ttlbrRegister.TabIndex = 17;
            ttlbrRegister.TitleIcon = Properties.Resources.IconoVentana;
            ttlbrRegister.TitleText = "Register";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 254, 254);
            ClientSize = new Size(314, 485);
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