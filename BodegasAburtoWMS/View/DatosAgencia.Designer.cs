namespace BodegasAburtoWMS.View
{
    partial class DatosAgencia
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombre = new TextBox();
            txtContacto = new TextBox();
            txtTelefono = new TextBox();
            txtCiudad = new TextBox();
            cmbEstado = new ComboBox();
            dtpFechaRegistro = new DateTimePicker();
            btnAgregar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 29);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
            label1.TabIndex = 0;
            label1.Text = "Datos de la Agencia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 267);
            label2.Name = "label2";
            label2.Size = new Size(152, 25);
            label2.TabIndex = 1;
            label2.Text = "Fecha de Registro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 190);
            label3.Name = "label3";
            label3.Size = new Size(68, 25);
            label3.TabIndex = 2;
            label3.Text = "Ciudad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 116);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 3;
            label4.Text = "Contacto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 81);
            label5.Name = "label5";
            label5.Size = new Size(78, 25);
            label5.TabIndex = 4;
            label5.Text = "Nombre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 153);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 5;
            label6.Text = "Telefono";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 229);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 6;
            label7.Text = "Estado";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(223, 81);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 7;
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(223, 118);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(150, 31);
            txtContacto.TabIndex = 8;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(223, 153);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 31);
            txtTelefono.TabIndex = 9;
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(223, 190);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(150, 31);
            txtCiudad.TabIndex = 10;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(220, 234);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(182, 33);
            cmbEstado.TabIndex = 11;
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Location = new Point(220, 273);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(342, 31);
            dtpFechaRegistro.TabIndex = 12;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(45, 366);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(98, 34);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(171, 366);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(98, 34);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(293, 366);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(98, 34);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // DatosAgencia
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnAgregar);
            Controls.Add(dtpFechaRegistro);
            Controls.Add(cmbEstado);
            Controls.Add(txtCiudad);
            Controls.Add(txtTelefono);
            Controls.Add(txtContacto);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DatosAgencia";
            Text = "DatosAgencia";
            Load += DatosAgencia_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombre;
        private TextBox txtContacto;
        private TextBox txtTelefono;
        private TextBox txtCiudad;
        private ComboBox cmbEstado;
        private DateTimePicker dtpFechaRegistro;
        private Button btnAgregar;
        private Button btnLimpiar;
        private Button btnSalir;
    }
}