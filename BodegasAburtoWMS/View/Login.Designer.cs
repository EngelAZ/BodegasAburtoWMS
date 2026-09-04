namespace BodegasAburtoWMS
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            lbTituloLogin = new Label();
            lblSubtitulo2 = new Label();
            lblContrasena = new Label();
            lblUsuario = new Label();
            lblSubtitulo1 = new Label();
            tbxUsuario = new TextBox();
            tbxContrasena = new TextBox();
            btnInicioSesion = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = Properties.Resources.IconoVentana;
            pictureBox1.Location = new Point(176, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 117);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbTituloLogin
            // 
            lbTituloLogin.AutoSize = true;
            lbTituloLogin.Font = new Font("Cinzel", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTituloLogin.ForeColor = Color.FromArgb(30, 77, 140);
            lbTituloLogin.Location = new Point(150, 132);
            lbTituloLogin.Name = "lbTituloLogin";
            lbTituloLogin.Size = new Size(198, 36);
            lbTituloLogin.TabIndex = 1;
            lbTituloLogin.Text = "Aburto WMS";
            // 
            // lblSubtitulo2
            // 
            lblSubtitulo2.AutoSize = true;
            lblSubtitulo2.Font = new Font("Alegreya Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitulo2.ForeColor = SystemColors.ControlDark;
            lblSubtitulo2.Location = new Point(131, 192);
            lblSubtitulo2.Name = "lblSubtitulo2";
            lblSubtitulo2.Size = new Size(228, 24);
            lblSubtitulo2.TabIndex = 2;
            lblSubtitulo2.Text = "Bodegas Aburto · Envíos CR ↔ NI";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Lora SemiBold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblContrasena.ForeColor = Color.FromArgb(38, 50, 56);
            lblContrasena.Location = new Point(61, 332);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(126, 31);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Lora SemiBold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(38, 50, 56);
            lblUsuario.Location = new Point(61, 247);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(92, 31);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // lblSubtitulo1
            // 
            lblSubtitulo1.AutoSize = true;
            lblSubtitulo1.Font = new Font("Lora Medium", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSubtitulo1.ForeColor = SystemColors.ControlDarkDark;
            lblSubtitulo1.Location = new Point(122, 168);
            lblSubtitulo1.Name = "lblSubtitulo1";
            lblSubtitulo1.Size = new Size(248, 24);
            lblSubtitulo1.TabIndex = 5;
            lblSubtitulo1.Text = "Warehouse Management System";
            // 
            // tbxUsuario
            // 
            tbxUsuario.Font = new Font("Alegreya Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxUsuario.ForeColor = SystemColors.ButtonShadow;
            tbxUsuario.Location = new Point(61, 281);
            tbxUsuario.Name = "tbxUsuario";
            tbxUsuario.Size = new Size(378, 29);
            tbxUsuario.TabIndex = 6;
            tbxUsuario.Text = "Ingrese su usuario";
            tbxUsuario.TextChanged += tbxUsuario_TextChanged;
            tbxUsuario.Enter += tbxUsuario_Enter;
            tbxUsuario.Leave += tbxUsuario_Leave;
            // 
            // tbxContrasena
            // 
            tbxContrasena.Font = new Font("Alegreya Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxContrasena.ForeColor = SystemColors.ButtonShadow;
            tbxContrasena.Location = new Point(61, 366);
            tbxContrasena.Name = "tbxContrasena";
            tbxContrasena.Size = new Size(378, 29);
            tbxContrasena.TabIndex = 7;
            tbxContrasena.Text = "Ingrese su contraseña";
            tbxContrasena.Enter += tbxContrasena_Enter;
            tbxContrasena.Leave += tbxContrasena_Leave;
            // 
            // btnInicioSesion
            // 
            btnInicioSesion.BackColor = Color.FromArgb(242, 140, 40);
            btnInicioSesion.DialogResult = DialogResult.Cancel;
            btnInicioSesion.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btnInicioSesion.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnInicioSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            btnInicioSesion.FlatStyle = FlatStyle.Flat;
            btnInicioSesion.Font = new Font("Lora SemiBold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnInicioSesion.ForeColor = Color.White;
            btnInicioSesion.Location = new Point(61, 424);
            btnInicioSesion.Name = "btnInicioSesion";
            btnInicioSesion.Size = new Size(378, 43);
            btnInicioSesion.TabIndex = 8;
            btnInicioSesion.Text = "Iniciar Sesión";
            btnInicioSesion.UseVisualStyleBackColor = false;
            btnInicioSesion.Click += btnInicioSesion_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 254, 254);
            ClientSize = new Size(487, 544);
            Controls.Add(btnInicioSesion);
            Controls.Add(tbxContrasena);
            Controls.Add(tbxUsuario);
            Controls.Add(lblSubtitulo1);
            Controls.Add(lblUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(lblSubtitulo2);
            Controls.Add(lbTituloLogin);
            Controls.Add(pictureBox1);
            Font = new Font("Cinzel", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "Login";
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = true;
            Text = "Aburto WMS - Inicio de Sesión";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbTituloLogin;
        private Label lblSubtitulo2;
        private Label lblContrasena;
        private Label lblUsuario;
        private Label lblSubtitulo1;
        private TextBox tbxUsuario;
        private TextBox tbxContrasena;
        private Button btnInicioSesion;
    }
}
