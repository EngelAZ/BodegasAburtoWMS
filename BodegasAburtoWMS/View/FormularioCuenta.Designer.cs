namespace BodegasAburtoWMS.View
{
    partial class FormularioCuenta
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
            txtNombreCuenta = new TextBox();
            cmbTipo = new ComboBox();
            txtSaldo = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            numAnio = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 37);
            label1.Name = "label1";
            label1.Size = new Size(181, 25);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la Cuenta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 98);
            label2.Name = "label2";
            label2.Size = new Size(47, 25);
            label2.TabIndex = 1;
            label2.Text = "Tipo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 164);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 2;
            label3.Text = "Saldo";
            // 
            // txtNombreCuenta
            // 
            txtNombreCuenta.Location = new Point(258, 37);
            txtNombreCuenta.Name = "txtNombreCuenta";
            txtNombreCuenta.Size = new Size(150, 31);
            txtNombreCuenta.TabIndex = 3;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(258, 95);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(182, 33);
            cmbTipo.TabIndex = 4;
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(258, 164);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Size = new Size(150, 31);
            txtSaldo.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(39, 327);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(210, 327);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // numAnio
            // 
            numAnio.Location = new Point(258, 233);
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(180, 31);
            numAnio.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 239);
            label4.Name = "label4";
            label4.Size = new Size(45, 25);
            label4.TabIndex = 10;
            label4.Text = "Año";
            // 
            // FormularioCuenta
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(numAnio);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtSaldo);
            Controls.Add(cmbTipo);
            Controls.Add(txtNombreCuenta);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormularioCuenta";
            Text = "FormularioCuenta";
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNombreCuenta;
        private ComboBox cmbTipo;
        private TextBox txtSaldo;
        private Button btnGuardar;
        private Button btnCancelar;
        private NumericUpDown numAnio;
        private Label label4;
    }
}