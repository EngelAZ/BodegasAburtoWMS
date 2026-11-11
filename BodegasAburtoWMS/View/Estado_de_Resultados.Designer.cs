namespace BodegasAburtoWMS.View
{
    partial class Estado_de_Resultados
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
            panel1 = new Panel();
            cboAniosResultados = new ComboBox();
            btnEliminarCuenta = new Button();
            btnEditarCuenta = new Button();
            btnAgregarCuenta = new Button();
            panel2 = new Panel();
            lblTotalCostos = new Label();
            lblTotalGastos = new Label();
            lblUtilidadNeta = new Label();
            lblTotalIngresos = new Label();
            dataGridViewResultados = new DataGridView();
            btnAnalisisVerticalResultados = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cboAniosResultados);
            panel1.Controls.Add(btnEliminarCuenta);
            panel1.Controls.Add(btnEditarCuenta);
            panel1.Controls.Add(btnAgregarCuenta);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(878, 50);
            panel1.TabIndex = 0;
            // 
            // cboAniosResultados
            // 
            cboAniosResultados.FormattingEnabled = true;
            cboAniosResultados.Location = new Point(146, 8);
            cboAniosResultados.Name = "cboAniosResultados";
            cboAniosResultados.Size = new Size(182, 33);
            cboAniosResultados.TabIndex = 4;
            cboAniosResultados.SelectedIndexChanged += cboAniosResultados_SelectedIndexChanged;
            // 
            // btnEliminarCuenta
            // 
            btnEliminarCuenta.BackColor = Color.FromArgb(255, 128, 128);
            btnEliminarCuenta.Location = new Point(710, 10);
            btnEliminarCuenta.Name = "btnEliminarCuenta";
            btnEliminarCuenta.Size = new Size(156, 34);
            btnEliminarCuenta.TabIndex = 3;
            btnEliminarCuenta.Text = "- Eliminar Cuenta";
            btnEliminarCuenta.UseVisualStyleBackColor = false;
            btnEliminarCuenta.Click += btnEliminarCuenta_Click;
            // 
            // btnEditarCuenta
            // 
            btnEditarCuenta.BackColor = SystemColors.ActiveCaption;
            btnEditarCuenta.Location = new Point(570, 8);
            btnEditarCuenta.Name = "btnEditarCuenta";
            btnEditarCuenta.Size = new Size(134, 34);
            btnEditarCuenta.TabIndex = 2;
            btnEditarCuenta.Text = "Editar Cuenta";
            btnEditarCuenta.UseVisualStyleBackColor = false;
            btnEditarCuenta.Click += btnEditarCuenta_Click;
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.BackColor = Color.FromArgb(255, 128, 0);
            btnAgregarCuenta.Location = new Point(404, 8);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(160, 34);
            btnAgregarCuenta.TabIndex = 1;
            btnAgregarCuenta.Text = "+ Nueva Cuenta";
            btnAgregarCuenta.UseVisualStyleBackColor = false;
            btnAgregarCuenta.Click += btnAgregarCuenta_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAnalisisVerticalResultados);
            panel2.Controls.Add(lblTotalCostos);
            panel2.Controls.Add(lblTotalGastos);
            panel2.Controls.Add(lblUtilidadNeta);
            panel2.Controls.Add(lblTotalIngresos);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 500);
            panel2.Name = "panel2";
            panel2.Size = new Size(878, 44);
            panel2.TabIndex = 1;
            // 
            // lblTotalCostos
            // 
            lblTotalCostos.AutoSize = true;
            lblTotalCostos.Location = new Point(91, 10);
            lblTotalCostos.Name = "lblTotalCostos";
            lblTotalCostos.Size = new Size(31, 25);
            lblTotalCostos.TabIndex = 3;
            lblTotalCostos.Text = "TC";
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.AutoSize = true;
            lblTotalGastos.Location = new Point(156, 10);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(32, 25);
            lblTotalGastos.TabIndex = 2;
            lblTotalGastos.Text = "TG";
            // 
            // lblUtilidadNeta
            // 
            lblUtilidadNeta.AutoSize = true;
            lblUtilidadNeta.Location = new Point(221, 10);
            lblUtilidadNeta.Name = "lblUtilidadNeta";
            lblUtilidadNeta.Size = new Size(37, 25);
            lblUtilidadNeta.TabIndex = 1;
            lblUtilidadNeta.Text = "UN";
            // 
            // lblTotalIngresos
            // 
            lblTotalIngresos.AutoSize = true;
            lblTotalIngresos.Location = new Point(12, 10);
            lblTotalIngresos.Name = "lblTotalIngresos";
            lblTotalIngresos.Size = new Size(26, 25);
            lblTotalIngresos.TabIndex = 0;
            lblTotalIngresos.Text = "TI";
            // 
            // dataGridViewResultados
            // 
            dataGridViewResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResultados.Dock = DockStyle.Fill;
            dataGridViewResultados.Location = new Point(0, 50);
            dataGridViewResultados.Name = "dataGridViewResultados";
            dataGridViewResultados.RowHeadersWidth = 62;
            dataGridViewResultados.Size = new Size(878, 450);
            dataGridViewResultados.TabIndex = 2;
            // 
            // btnAnalisisVerticalResultados
            // 
            btnAnalisisVerticalResultados.Location = new Point(336, 1);
            btnAnalisisVerticalResultados.Name = "btnAnalisisVerticalResultados";
            btnAnalisisVerticalResultados.Size = new Size(141, 34);
            btnAnalisisVerticalResultados.TabIndex = 4;
            btnAnalisisVerticalResultados.Text = "Analisis Vertical";
            btnAnalisisVerticalResultados.UseVisualStyleBackColor = true;
            btnAnalisisVerticalResultados.Click += btnAnalisisVerticalResultados_Click;
            // 
            // Estado_de_Resultados
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 544);
            Controls.Add(dataGridViewResultados);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Estado_de_Resultados";
            Text = "Estado_de_Resultados";
            Load += Estado_de_Resultados_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cboAniosResultados;
        private Button btnEliminarCuenta;
        private Button btnEditarCuenta;
        private Button btnAgregarCuenta;
        private Panel panel2;
        private DataGridView dataGridViewResultados;
        private Label lblTotalCostos;
        private Label lblTotalGastos;
        private Label lblUtilidadNeta;
        private Label lblTotalIngresos;
        private Button btnAnalisisVerticalResultados;
    }
}