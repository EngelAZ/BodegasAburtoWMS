namespace BodegasAburtoWMS.View
{
    partial class Agencias
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            txtBuscarAgencia = new TextBox();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Contacto = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            Ciudad = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            Fecha_Registro = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(txtBuscarAgencia);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 32);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 0);
            button1.Location = new Point(416, 6);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(118, 20);
            button1.TabIndex = 2;
            button1.Text = "+ Nueva Agencia";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Todas", "Activa", "Inactiva" });
            comboBox1.Location = new Point(130, 6);
            comboBox1.Margin = new Padding(2, 2, 2, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(129, 23);
            comboBox1.TabIndex = 1;
            // 
            // txtBuscarAgencia
            // 
            txtBuscarAgencia.Location = new Point(8, 7);
            txtBuscarAgencia.Margin = new Padding(2, 2, 2, 2);
            txtBuscarAgencia.Name = "txtBuscarAgencia";
            txtBuscarAgencia.Size = new Size(106, 23);
            txtBuscarAgencia.TabIndex = 0;
            txtBuscarAgencia.Text = "Buscar Agencia";
            txtBuscarAgencia.TextChanged += txtBuscarAgencia_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Nombre, Contacto, Telefono, Ciudad, Estado, Fecha_Registro });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 32);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(560, 238);
            dataGridView1.TabIndex = 1;
            // 
            // ID
            // 
            ID.DataPropertyName = "IdAgencia";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 8;
            ID.Name = "ID";
            ID.Width = 150;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 8;
            Nombre.Name = "Nombre";
            Nombre.Width = 150;
            // 
            // Contacto
            // 
            Contacto.DataPropertyName = "Contacto";
            Contacto.HeaderText = "Contacto";
            Contacto.MinimumWidth = 8;
            Contacto.Name = "Contacto";
            Contacto.Width = 150;
            // 
            // Telefono
            // 
            Telefono.DataPropertyName = "Telefono";
            Telefono.HeaderText = "Telefono";
            Telefono.MinimumWidth = 8;
            Telefono.Name = "Telefono";
            Telefono.Width = 150;
            // 
            // Ciudad
            // 
            Ciudad.DataPropertyName = "Ciudad";
            Ciudad.HeaderText = "Ciudad";
            Ciudad.MinimumWidth = 8;
            Ciudad.Name = "Ciudad";
            Ciudad.Width = 150;
            // 
            // Estado
            // 
            Estado.DataPropertyName = "Estado";
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 8;
            Estado.Name = "Estado";
            Estado.Width = 150;
            // 
            // Fecha_Registro
            // 
            Fecha_Registro.DataPropertyName = "FechaRegistro";
            Fecha_Registro.HeaderText = "Fecha de Registro";
            Fecha_Registro.MinimumWidth = 8;
            Fecha_Registro.Name = "Fecha_Registro";
            Fecha_Registro.Width = 150;
            // 
            // Agencias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Agencias";
            Text = "Agencias";
            Load += Agencias_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox txtBuscarAgencia;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Contacto;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn Ciudad;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn Fecha_Registro;
    }
}