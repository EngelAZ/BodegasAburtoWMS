namespace BodegasAburtoWMS.View
{
    partial class Liquidacion
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
            lblBulto = new Label();
            lblRegla = new Label();
            pnlliquidacion = new Panel();
            btnEstadoCuenta = new Button();
            dateTimePicker2 = new DateTimePicker();
            lblHasta = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblDesde = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            lblPeriodo = new Label();
            comboBox1 = new ComboBox();
            lblAgencia = new Label();
            lblparametros = new Label();
            pnlliquidacion.SuspendLayout();
            SuspendLayout();
            // 
            // lblBulto
            // 
            lblBulto.AutoSize = true;
            lblBulto.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBulto.Location = new Point(129, 40);
            lblBulto.Name = "lblBulto";
            lblBulto.Size = new Size(215, 16);
            lblBulto.TabIndex = 0;
            lblBulto.Text = "Liquidacion por Bulto Contado";
            // 
            // lblRegla
            // 
            lblRegla.AutoSize = true;
            lblRegla.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegla.ForeColor = Color.Gray;
            lblRegla.Location = new Point(350, 41);
            lblRegla.Name = "lblRegla";
            lblRegla.Size = new Size(254, 15);
            lblRegla.TabIndex = 1;
            lblRegla.Text = "* Regla: bultos x C$60 = servicio de bodegaje";
            // 
            // pnlliquidacion
            // 
            pnlliquidacion.Controls.Add(btnEstadoCuenta);
            pnlliquidacion.Controls.Add(dateTimePicker2);
            pnlliquidacion.Controls.Add(lblHasta);
            pnlliquidacion.Controls.Add(dateTimePicker1);
            pnlliquidacion.Controls.Add(lblDesde);
            pnlliquidacion.Controls.Add(radioButton2);
            pnlliquidacion.Controls.Add(radioButton1);
            pnlliquidacion.Controls.Add(lblPeriodo);
            pnlliquidacion.Controls.Add(comboBox1);
            pnlliquidacion.Controls.Add(lblAgencia);
            pnlliquidacion.Controls.Add(lblparametros);
            pnlliquidacion.Location = new Point(129, 83);
            pnlliquidacion.Name = "pnlliquidacion";
            pnlliquidacion.Size = new Size(669, 213);
            pnlliquidacion.TabIndex = 2;
            // 
            // btnEstadoCuenta
            // 
            btnEstadoCuenta.BackColor = Color.FromArgb(255, 128, 0);
            btnEstadoCuenta.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnEstadoCuenta.ForeColor = Color.White;
            btnEstadoCuenta.Location = new Point(22, 142);
            btnEstadoCuenta.Name = "btnEstadoCuenta";
            btnEstadoCuenta.Size = new Size(193, 30);
            btnEstadoCuenta.TabIndex = 10;
            btnEstadoCuenta.Text = "Generar Estado de Cuenta";
            btnEstadoCuenta.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(553, 72);
            dateTimePicker2.MinDate = new DateTime(2012, 12, 24, 0, 0, 0, 0);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(95, 23);
            dateTimePicker2.TabIndex = 9;
            dateTimePicker2.Value = new DateTime(2026, 9, 3, 0, 0, 0, 0);
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHasta.ForeColor = Color.Gray;
            lblHasta.Location = new Point(553, 52);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 15);
            lblHasta.TabIndex = 8;
            lblHasta.Text = "HASTA";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(436, 72);
            dateTimePicker1.MinDate = new DateTime(2012, 12, 24, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(95, 23);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.Value = new DateTime(2026, 9, 3, 0, 0, 0, 0);
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDesde.ForeColor = Color.Gray;
            lblDesde.Location = new Point(436, 52);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(54, 15);
            lblDesde.TabIndex = 6;
            lblDesde.Text = "DESDE";
            // 
            // radioButton2
            // 
            radioButton2.Appearance = Appearance.Button;
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton2.ForeColor = Color.Gray;
            radioButton2.Location = new Point(353, 72);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(64, 23);
            radioButton2.TabIndex = 5;
            radioButton2.Text = "Mensual";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.Appearance = Appearance.Button;
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton1.ForeColor = Color.Gray;
            radioButton1.Location = new Point(282, 72);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(65, 23);
            radioButton1.TabIndex = 4;
            radioButton1.Text = "Semanal";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPeriodo.ForeColor = Color.Gray;
            lblPeriodo.Location = new Point(307, 52);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(69, 15);
            lblPeriodo.TabIndex = 3;
            lblPeriodo.Text = "PERIODO";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Seleccionar agencia..." });
            comboBox1.Location = new Point(22, 72);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(231, 21);
            comboBox1.TabIndex = 2;
            // 
            // lblAgencia
            // 
            lblAgencia.AutoSize = true;
            lblAgencia.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgencia.ForeColor = Color.Gray;
            lblAgencia.Location = new Point(22, 52);
            lblAgencia.Name = "lblAgencia";
            lblAgencia.Size = new Size(65, 15);
            lblAgencia.TabIndex = 1;
            lblAgencia.Text = "AGENCIA";
            // 
            // lblparametros
            // 
            lblparametros.AutoSize = true;
            lblparametros.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblparametros.Location = new Point(22, 13);
            lblparametros.Name = "lblparametros";
            lblparametros.Size = new Size(193, 16);
            lblparametros.TabIndex = 0;
            lblparametros.Text = "Parametros de Liquidacion";
            // 
            // Liquidacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlliquidacion);
            Controls.Add(lblRegla);
            Controls.Add(lblBulto);
            Name = "Liquidacion";
            Text = "Liquidacion por Bulto Contado - Aburto WMS";
            pnlliquidacion.ResumeLayout(false);
            pnlliquidacion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBulto;
        private Label lblRegla;
        private Panel pnlliquidacion;
        private Label lblparametros;
        private Label lblAgencia;
        private Label lblPeriodo;
        private ComboBox comboBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private DateTimePicker dateTimePicker2;
        private Label lblHasta;
        private DateTimePicker dateTimePicker1;
        private Label lblDesde;
        private Button btnEstadoCuenta;
    }
}