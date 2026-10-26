namespace BodegasAburtoWMS.View
{
    partial class RegistroDiario
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
            panel3 = new Panel();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            txtBuscar = new TextBox();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NumeroGuia = new DataGridViewTextBoxColumn();
            Agencia = new DataGridViewTextBoxColumn();
            Remitente = new DataGridViewTextBoxColumn();
            Destinatario = new DataGridViewTextBoxColumn();
            FechaEnvio = new DataGridViewTextBoxColumn();
            FechaEntrega = new DataGridViewTextBoxColumn();
            CostoEnvio = new DataGridViewTextBoxColumn();
            Observaciones = new DataGridViewTextBoxColumn();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(txtBuscar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 48);
            panel3.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Todos los Estados" });
            comboBox2.Location = new Point(564, 7);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(183, 33);
            comboBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Todas las Agencias" });
            comboBox1.Location = new Point(361, 7);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 33);
            comboBox1.TabIndex = 1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(21, 7);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(334, 31);
            txtBuscar.TabIndex = 0;
            txtBuscar.Text = "Buscar por Guia, Remitente o destinatario";
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, NumeroGuia, Agencia, Remitente, Destinatario, FechaEnvio, FechaEntrega, CostoEnvio, Observaciones });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(800, 402);
            dataGridView1.TabIndex = 3;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 8;
            ID.Name = "ID";
            ID.Width = 150;
            // 
            // NumeroGuia
            // 
            NumeroGuia.HeaderText = "Numero de Guia";
            NumeroGuia.MinimumWidth = 8;
            NumeroGuia.Name = "NumeroGuia";
            NumeroGuia.Width = 150;
            // 
            // Agencia
            // 
            Agencia.HeaderText = "Agencia";
            Agencia.MinimumWidth = 8;
            Agencia.Name = "Agencia";
            Agencia.Width = 150;
            // 
            // Remitente
            // 
            Remitente.HeaderText = "Remitente";
            Remitente.MinimumWidth = 8;
            Remitente.Name = "Remitente";
            Remitente.Width = 150;
            // 
            // Destinatario
            // 
            Destinatario.HeaderText = "Destinatario";
            Destinatario.MinimumWidth = 8;
            Destinatario.Name = "Destinatario";
            Destinatario.Width = 150;
            // 
            // FechaEnvio
            // 
            FechaEnvio.HeaderText = "FechaEnvio";
            FechaEnvio.MinimumWidth = 8;
            FechaEnvio.Name = "FechaEnvio";
            FechaEnvio.Width = 150;
            // 
            // FechaEntrega
            // 
            FechaEntrega.HeaderText = "Fecha de Entrega";
            FechaEntrega.MinimumWidth = 8;
            FechaEntrega.Name = "FechaEntrega";
            FechaEntrega.Width = 150;
            // 
            // CostoEnvio
            // 
            CostoEnvio.HeaderText = "Costo de Envio";
            CostoEnvio.MinimumWidth = 8;
            CostoEnvio.Name = "CostoEnvio";
            CostoEnvio.Width = 150;
            // 
            // Observaciones
            // 
            Observaciones.HeaderText = "Observaciones";
            Observaciones.MinimumWidth = 8;
            Observaciones.Name = "Observaciones";
            Observaciones.Width = 150;
            // 
            // RegistroDiario
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistroDiario";
            Text = "RegistroDiario";
            Load += RegistroDiario_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private ComboBox comboBox1;
        private TextBox txt;
        private ComboBox comboBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NumeroGuia;
        private DataGridViewTextBoxColumn Agencia;
        private DataGridViewTextBoxColumn Remitente;
        private DataGridViewTextBoxColumn Destinatario;
        private DataGridViewTextBoxColumn FechaEnvio;
        private DataGridViewTextBoxColumn FechaEntrega;
        private DataGridViewTextBoxColumn CostoEnvio;
        private DataGridViewTextBoxColumn Observaciones;
        private TextBox txtBuscar;
    }
}