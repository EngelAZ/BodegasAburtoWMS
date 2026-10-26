

namespace BodegasAburtoWMS.View
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            panel1 = new Panel();
            btnInicio = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            btnAgencias = new Button();
            btnClientes = new Button();
            btnReportes = new Button();
            btnLiquidacion = new Button();
            btnMateriales = new Button();
            btnSalidasEntradas = new Button();
            btnRegistroDiario = new Button();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            PanelOpciones = new Panel();
            button8 = new Button();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            PanelContenedor = new Panel();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            BarraSuperior = new BodegasAburtoWMS.Components.CustomTitleBar();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelOpciones.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 78, 140);
            panel1.Controls.Add(btnInicio);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnAgencias);
            panel1.Controls.Add(btnClientes);
            panel1.Controls.Add(btnReportes);
            panel1.Controls.Add(btnLiquidacion);
            panel1.Controls.Add(btnMateriales);
            panel1.Controls.Add(btnSalidasEntradas);
            panel1.Controls.Add(btnRegistroDiario);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(1, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 869);
            panel1.TabIndex = 1;
            // 
            // btnInicio
            // 
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(11, 90);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(203, 42);
            btnInicio.TabIndex = 12;
            btnInicio.Text = "Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(11, 553);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 11;
            label6.Text = "Finanzas";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(11, 323);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 10;
            label5.Text = "Gestion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(11, 152);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 1;
            label4.Text = "Operaciones";
            // 
            // btnAgencias
            // 
            btnAgencias.FlatAppearance.BorderSize = 0;
            btnAgencias.FlatStyle = FlatStyle.Flat;
            btnAgencias.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgencias.Location = new Point(11, 382);
            btnAgencias.Name = "btnAgencias";
            btnAgencias.Size = new Size(203, 42);
            btnAgencias.TabIndex = 7;
            btnAgencias.Text = "Agencias";
            btnAgencias.TextAlign = ContentAlignment.MiddleLeft;
            btnAgencias.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgencias.UseVisualStyleBackColor = true;
            btnAgencias.Click += btnAgencias_Click;
            // 
            // btnClientes
            // 
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(11, 430);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(203, 42);
            btnClientes.TabIndex = 6;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnReportes
            // 
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(11, 660);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(203, 42);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnLiquidacion
            // 
            btnLiquidacion.FlatAppearance.BorderSize = 0;
            btnLiquidacion.FlatStyle = FlatStyle.Flat;
            btnLiquidacion.ImageAlign = ContentAlignment.MiddleLeft;
            btnLiquidacion.Location = new Point(11, 612);
            btnLiquidacion.Name = "btnLiquidacion";
            btnLiquidacion.Size = new Size(203, 42);
            btnLiquidacion.TabIndex = 4;
            btnLiquidacion.Text = "Liquidacion";
            btnLiquidacion.TextAlign = ContentAlignment.MiddleLeft;
            btnLiquidacion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLiquidacion.UseVisualStyleBackColor = true;
            btnLiquidacion.Click += btnLiquidacion_Click;
            // 
            // btnMateriales
            // 
            btnMateriales.FlatAppearance.BorderSize = 0;
            btnMateriales.FlatStyle = FlatStyle.Flat;
            btnMateriales.ImageAlign = ContentAlignment.MiddleLeft;
            btnMateriales.Location = new Point(11, 478);
            btnMateriales.Name = "btnMateriales";
            btnMateriales.Size = new Size(203, 42);
            btnMateriales.TabIndex = 3;
            btnMateriales.Text = "Materiales";
            btnMateriales.TextAlign = ContentAlignment.MiddleLeft;
            btnMateriales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMateriales.UseVisualStyleBackColor = true;
            btnMateriales.Click += btnMateriales_Click;
            // 
            // btnSalidasEntradas
            // 
            btnSalidasEntradas.FlatAppearance.BorderSize = 0;
            btnSalidasEntradas.FlatStyle = FlatStyle.Flat;
            btnSalidasEntradas.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalidasEntradas.Location = new Point(11, 247);
            btnSalidasEntradas.Name = "btnSalidasEntradas";
            btnSalidasEntradas.Size = new Size(203, 42);
            btnSalidasEntradas.TabIndex = 2;
            btnSalidasEntradas.Text = "Salidas / Entradas";
            btnSalidasEntradas.TextAlign = ContentAlignment.MiddleLeft;
            btnSalidasEntradas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalidasEntradas.UseVisualStyleBackColor = true;
            btnSalidasEntradas.Click += btnSalidasEntradas_Click;
            // 
            // btnRegistroDiario
            // 
            btnRegistroDiario.FlatAppearance.BorderSize = 0;
            btnRegistroDiario.FlatStyle = FlatStyle.Flat;
            btnRegistroDiario.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistroDiario.Location = new Point(11, 198);
            btnRegistroDiario.Name = "btnRegistroDiario";
            btnRegistroDiario.Size = new Size(203, 42);
            btnRegistroDiario.TabIndex = 1;
            btnRegistroDiario.Text = "Registro Diario";
            btnRegistroDiario.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistroDiario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistroDiario.UseVisualStyleBackColor = true;
            btnRegistroDiario.Click += btnRegistroDiario_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 68);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(61, 43);
            label2.Name = "label2";
            label2.Size = new Size(113, 17);
            label2.TabIndex = 3;
            label2.Text = "WMS | Bodega";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.749998F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(71, 13);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 2;
            label1.Text = "Aburto";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.IconoVentana;
            pictureBox1.Location = new Point(11, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // PanelOpciones
            // 
            PanelOpciones.BackColor = Color.White;
            PanelOpciones.Controls.Add(button8);
            PanelOpciones.Controls.Add(dateTimePicker1);
            PanelOpciones.Controls.Add(label3);
            PanelOpciones.Dock = DockStyle.Top;
            PanelOpciones.Location = new Point(230, 107);
            PanelOpciones.Name = "PanelOpciones";
            PanelOpciones.Size = new Size(1223, 62);
            PanelOpciones.TabIndex = 2;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(245, 130, 32);
            button8.Location = new Point(1026, 15);
            button8.Name = "button8";
            button8.Size = new Size(151, 37);
            button8.TabIndex = 3;
            button8.Text = "+ Nuevo Envio";
            button8.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(696, 15);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 22);
            label3.Name = "label3";
            label3.Size = new Size(270, 25);
            label3.TabIndex = 0;
            label3.Text = "Dashboard | Resumen Operativo";
            // 
            // PanelContenedor
            // 
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(230, 169);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Padding = new Padding(14, 15, 14, 15);
            PanelContenedor.Size = new Size(1223, 807);
            PanelContenedor.TabIndex = 3;
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(88, 29);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(73, 29);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(53, 29);
            verToolStripMenuItem.Text = "Ver";
            // 
            // herramientasToolStripMenuItem
            // 
            herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            herramientasToolStripMenuItem.Size = new Size(133, 29);
            herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(79, 29);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, editarToolStripMenuItem, verToolStripMenuItem, herramientasToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(1, 74);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1452, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // BarraSuperior
            // 
            BarraSuperior.BackColor = Color.FromArgb(30, 78, 140);
            BarraSuperior.BackgroundImageLayout = ImageLayout.Center;
            BarraSuperior.Dock = DockStyle.Top;
            BarraSuperior.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BarraSuperior.ForeColor = Color.White;
            BarraSuperior.Location = new Point(1, 2);
            BarraSuperior.Margin = new Padding(4, 5, 4, 5);
            BarraSuperior.Name = "BarraSuperior";
            BarraSuperior.Size = new Size(1452, 72);
            BarraSuperior.TabIndex = 4;
            BarraSuperior.TitleIcon = Properties.Resources.IconoVentana;
            BarraSuperior.TitleText = "Inicio";
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1454, 978);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelOpciones);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Controls.Add(BarraSuperior);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Principal";
            Padding = new Padding(1, 2, 1, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            Load += Principal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelOpciones.ResumeLayout(false);
            PanelOpciones.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnRegistroDiario;
        private Button btnAgencias;
        private Button btnClientes;
        private Button btnReportes;
        private Button btnLiquidacion;
        private Button btnMateriales;
        private Button btnSalidasEntradas;
        private Button button8;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Panel PanelContenedor;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private MenuStrip menuStrip1;
        private BodegasAburtoWMS.Components.CustomTitleBar BarraSuperior;
        private Button btnInicio;
        private Label label6;
        private Label label5;
        private Label label4;
        public Panel PanelOpciones;
    }
}