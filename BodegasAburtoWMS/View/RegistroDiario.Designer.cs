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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 39);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 48);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(textBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 39);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 48);
            panel3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(22, 3);
            button1.Name = "button1";
            button1.Size = new Size(171, 34);
            button1.TabIndex = 0;
            button1.Text = "Lista de Envios";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(228, 3);
            button2.Name = "button2";
            button2.Size = new Size(171, 34);
            button2.TabIndex = 1;
            button2.Text = "+ Nuevo Envio";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(334, 31);
            textBox1.TabIndex = 0;
            textBox1.Text = "Buscar por Guia, Remitente o destinatario";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Todas las Agencias" });
            comboBox1.Location = new Point(362, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Todos los Estados" });
            comboBox2.Location = new Point(564, 6);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, NumeroGuia, Agencia, Remitente, Destinatario, FechaEnvio, FechaEntrega, CostoEnvio, Observaciones });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 87);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(800, 363);
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
            Controls.Add(panel1);
            Name = "RegistroDiario";
            Text = "RegistroDiario";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private Panel panel3;
        private ComboBox comboBox1;
        private TextBox textBox1;
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
    }
}