namespace BodegasAburtoWMS.View
{
    partial class Balance_General
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
            panel2 = new Panel();
            btnNuevoAnio = new Button();
            cmbAnios = new ComboBox();
            btnEliminarCuenta = new Button();
            btnEditarCuenta = new Button();
            btnAgregarCuenta = new Button();
            lblDiferencia = new Label();
            lblTotalPatrimonio = new Label();
            lblTotalPasivos = new Label();
            lblTotalActivos = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblActivosCorrientes = new Label();
            lblActivosFijos = new Label();
            lblPasivosCorrientes = new Label();
            lblPasivosFijos = new Label();
            dataGridViewBalance = new DataGridView();
            btnAnalisisVertical = new Button();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnNuevoAnio);
            panel2.Controls.Add(cmbAnios);
            panel2.Controls.Add(btnEliminarCuenta);
            panel2.Controls.Add(btnEditarCuenta);
            panel2.Controls.Add(btnAgregarCuenta);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(878, 45);
            panel2.TabIndex = 3;
            // 
            // btnNuevoAnio
            // 
            btnNuevoAnio.Location = new Point(0, 1);
            btnNuevoAnio.Name = "btnNuevoAnio";
            btnNuevoAnio.Size = new Size(148, 34);
            btnNuevoAnio.TabIndex = 4;
            btnNuevoAnio.Text = "+ Nuevo Año";
            btnNuevoAnio.UseVisualStyleBackColor = true;
            btnNuevoAnio.Click += btnNuevoAnio_Click;
            // 
            // cmbAnios
            // 
            cmbAnios.FormattingEnabled = true;
            cmbAnios.Location = new Point(154, 3);
            cmbAnios.Name = "cmbAnios";
            cmbAnios.Size = new Size(182, 33);
            cmbAnios.TabIndex = 3;
            cmbAnios.SelectedIndexChanged += cmbAnios_SelectedIndexChanged;
            // 
            // btnEliminarCuenta
            // 
            btnEliminarCuenta.BackColor = Color.IndianRed;
            btnEliminarCuenta.Location = new Point(710, 2);
            btnEliminarCuenta.Name = "btnEliminarCuenta";
            btnEliminarCuenta.Size = new Size(156, 34);
            btnEliminarCuenta.TabIndex = 2;
            btnEliminarCuenta.Text = "- Eliminar Cuenta";
            btnEliminarCuenta.UseVisualStyleBackColor = false;
            btnEliminarCuenta.Click += btnEliminarCuenta_Click;
            // 
            // btnEditarCuenta
            // 
            btnEditarCuenta.BackColor = Color.PaleTurquoise;
            btnEditarCuenta.Location = new Point(557, 1);
            btnEditarCuenta.Name = "btnEditarCuenta";
            btnEditarCuenta.Size = new Size(138, 34);
            btnEditarCuenta.TabIndex = 1;
            btnEditarCuenta.Text = "Editar Cuenta";
            btnEditarCuenta.UseVisualStyleBackColor = false;
            btnEditarCuenta.Click += btnEditarCuenta_Click;
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.BackColor = Color.FromArgb(255, 128, 0);
            btnAgregarCuenta.Location = new Point(342, 5);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(184, 34);
            btnAgregarCuenta.TabIndex = 0;
            btnAgregarCuenta.Text = "+ Agregar Cuenta";
            btnAgregarCuenta.UseVisualStyleBackColor = false;
            btnAgregarCuenta.Click += btnAgregarCuenta_Click;
            // 
            // lblDiferencia
            // 
            lblDiferencia.AutoSize = true;
            lblDiferencia.Location = new Point(272, 0);
            lblDiferencia.Name = "lblDiferencia";
            lblDiferencia.Size = new Size(25, 25);
            lblDiferencia.TabIndex = 3;
            lblDiferencia.Text = "D";
            // 
            // lblTotalPatrimonio
            // 
            lblTotalPatrimonio.AutoSize = true;
            lblTotalPatrimonio.Location = new Point(234, 0);
            lblTotalPatrimonio.Name = "lblTotalPatrimonio";
            lblTotalPatrimonio.Size = new Size(32, 25);
            lblTotalPatrimonio.TabIndex = 2;
            lblTotalPatrimonio.Text = "CT";
            // 
            // lblTotalPasivos
            // 
            lblTotalPasivos.AutoSize = true;
            lblTotalPasivos.Location = new Point(197, 0);
            lblTotalPasivos.Name = "lblTotalPasivos";
            lblTotalPasivos.Size = new Size(31, 25);
            lblTotalPasivos.TabIndex = 1;
            lblTotalPasivos.Text = "PT";
            // 
            // lblTotalActivos
            // 
            lblTotalActivos.AutoSize = true;
            lblTotalActivos.Location = new Point(83, 0);
            lblTotalActivos.Name = "lblTotalActivos";
            lblTotalActivos.Size = new Size(32, 25);
            lblTotalActivos.TabIndex = 0;
            lblTotalActivos.Text = "AT";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblActivosCorrientes);
            flowLayoutPanel1.Controls.Add(lblActivosFijos);
            flowLayoutPanel1.Controls.Add(lblTotalActivos);
            flowLayoutPanel1.Controls.Add(lblPasivosCorrientes);
            flowLayoutPanel1.Controls.Add(lblPasivosFijos);
            flowLayoutPanel1.Controls.Add(lblTotalPasivos);
            flowLayoutPanel1.Controls.Add(lblTotalPatrimonio);
            flowLayoutPanel1.Controls.Add(lblDiferencia);
            flowLayoutPanel1.Controls.Add(btnAnalisisVertical);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 457);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(878, 87);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // lblActivosCorrientes
            // 
            lblActivosCorrientes.AutoSize = true;
            lblActivosCorrientes.Location = new Point(3, 0);
            lblActivosCorrientes.Name = "lblActivosCorrientes";
            lblActivosCorrientes.Size = new Size(35, 25);
            lblActivosCorrientes.TabIndex = 4;
            lblActivosCorrientes.Text = "AC";
            // 
            // lblActivosFijos
            // 
            lblActivosFijos.AutoSize = true;
            lblActivosFijos.Location = new Point(44, 0);
            lblActivosFijos.Name = "lblActivosFijos";
            lblActivosFijos.Size = new Size(33, 25);
            lblActivosFijos.TabIndex = 5;
            lblActivosFijos.Text = "AF";
            // 
            // lblPasivosCorrientes
            // 
            lblPasivosCorrientes.AutoSize = true;
            lblPasivosCorrientes.Location = new Point(121, 0);
            lblPasivosCorrientes.Name = "lblPasivosCorrientes";
            lblPasivosCorrientes.Size = new Size(33, 25);
            lblPasivosCorrientes.TabIndex = 6;
            lblPasivosCorrientes.Text = "PC";
            // 
            // lblPasivosFijos
            // 
            lblPasivosFijos.AutoSize = true;
            lblPasivosFijos.Location = new Point(160, 0);
            lblPasivosFijos.Name = "lblPasivosFijos";
            lblPasivosFijos.Size = new Size(31, 25);
            lblPasivosFijos.TabIndex = 7;
            lblPasivosFijos.Text = "PF";
            // 
            // dataGridViewBalance
            // 
            dataGridViewBalance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBalance.Dock = DockStyle.Fill;
            dataGridViewBalance.Location = new Point(0, 45);
            dataGridViewBalance.Name = "dataGridViewBalance";
            dataGridViewBalance.RowHeadersWidth = 62;
            dataGridViewBalance.Size = new Size(878, 412);
            dataGridViewBalance.TabIndex = 4;
            // 
            // btnAnalisisVertical
            // 
            btnAnalisisVertical.Location = new Point(303, 3);
            btnAnalisisVertical.Name = "btnAnalisisVertical";
            btnAnalisisVertical.Size = new Size(152, 34);
            btnAnalisisVertical.TabIndex = 8;
            btnAnalisisVertical.Text = "Analisis Vertical";
            btnAnalisisVertical.UseVisualStyleBackColor = true;
            btnAnalisisVertical.Click += btnAnalisisVertical_Click;
            // 
            // Balance_General
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 544);
            Controls.Add(dataGridViewBalance);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Name = "Balance_General";
            Text = "Balance_General";
            Load += Balance_General_Load;
            panel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBalance).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Button btnAgregarCuenta;
        private Button btnEditarCuenta;
        private Button btnEliminarCuenta;
        private Label lblDiferencia;
        private Label lblTotalPatrimonio;
        private Label lblTotalPasivos;
        private Label lblTotalActivos;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridView dataGridViewBalance;
        private Label lblActivosCorrientes;
        private Label lblActivosFijos;
        private Label lblPasivosCorrientes;
        private Label lblPasivosFijos;
        private ComboBox cmbAnios;
        private Button btnNuevoAnio;
        private Button btnAnalisisVertical;
    }
}