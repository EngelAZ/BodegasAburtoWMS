

namespace BodegasAburtoWMS.View
{
    partial class PanelFinanciero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelFinanciero));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnRegresarPrincipal = new Button();
            btnPresupuestoPersonal = new Button();
            btnPuntoEquilibrioCVU = new Button();
            label4 = new Label();
            btnApalancamiento = new Button();
            btnFlujoEfectivo = new Button();
            btnControlBasicoInventario = new Button();
            btnProforma = new Button();
            btnPlaneacionPresupuestos = new Button();
            btnAnalisisFinanciero = new Button();
            btnEstadosFinancieros = new Button();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            PanelOpciones = new Panel();
            PanelContenedor = new Panel();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            BarraSuperior = new BodegasAburtoWMS.Components.CustomTitleBar();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 78, 140);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(btnPresupuestoPersonal);
            panel1.Controls.Add(btnPuntoEquilibrioCVU);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnApalancamiento);
            panel1.Controls.Add(btnFlujoEfectivo);
            panel1.Controls.Add(btnControlBasicoInventario);
            panel1.Controls.Add(btnProforma);
            panel1.Controls.Add(btnPlaneacionPresupuestos);
            panel1.Controls.Add(btnAnalisisFinanciero);
            panel1.Controls.Add(btnEstadosFinancieros);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(1, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 976);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnRegresarPrincipal, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 874);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(229, 102);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // btnRegresarPrincipal
            // 
            btnRegresarPrincipal.Dock = DockStyle.Fill;
            btnRegresarPrincipal.FlatAppearance.BorderSize = 0;
            btnRegresarPrincipal.FlatStyle = FlatStyle.Flat;
            btnRegresarPrincipal.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegresarPrincipal.Location = new Point(4, 5);
            btnRegresarPrincipal.Margin = new Padding(4, 5, 4, 5);
            btnRegresarPrincipal.Name = "btnRegresarPrincipal";
            btnRegresarPrincipal.Size = new Size(221, 92);
            btnRegresarPrincipal.TabIndex = 0;
            btnRegresarPrincipal.Text = "⬅";
            btnRegresarPrincipal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegresarPrincipal.UseVisualStyleBackColor = true;
            btnRegresarPrincipal.Click += btnRegresarPrincipal_Click;
            // 
            // btnPresupuestoPersonal
            // 
            btnPresupuestoPersonal.FlatAppearance.BorderSize = 0;
            btnPresupuestoPersonal.FlatStyle = FlatStyle.Flat;
            btnPresupuestoPersonal.ImageAlign = ContentAlignment.MiddleLeft;
            btnPresupuestoPersonal.Location = new Point(11, 707);
            btnPresupuestoPersonal.Name = "btnPresupuestoPersonal";
            btnPresupuestoPersonal.Size = new Size(203, 42);
            btnPresupuestoPersonal.TabIndex = 13;
            btnPresupuestoPersonal.Text = "Presupuesto Personal";
            btnPresupuestoPersonal.TextAlign = ContentAlignment.MiddleLeft;
            btnPresupuestoPersonal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPresupuestoPersonal.UseVisualStyleBackColor = true;
            btnPresupuestoPersonal.Click += btnPresupuestoPersonal_Click;
            // 
            // btnPuntoEquilibrioCVU
            // 
            btnPuntoEquilibrioCVU.FlatAppearance.BorderSize = 0;
            btnPuntoEquilibrioCVU.FlatStyle = FlatStyle.Flat;
            btnPuntoEquilibrioCVU.ImageAlign = ContentAlignment.MiddleLeft;
            btnPuntoEquilibrioCVU.Location = new Point(11, 293);
            btnPuntoEquilibrioCVU.Name = "btnPuntoEquilibrioCVU";
            btnPuntoEquilibrioCVU.Size = new Size(203, 73);
            btnPuntoEquilibrioCVU.TabIndex = 12;
            btnPuntoEquilibrioCVU.Text = "Punto de Equilibrio y C-V-U";
            btnPuntoEquilibrioCVU.TextAlign = ContentAlignment.MiddleLeft;
            btnPuntoEquilibrioCVU.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPuntoEquilibrioCVU.UseVisualStyleBackColor = true;
            btnPuntoEquilibrioCVU.Click += btnPuntoEquilibrioCVU_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(11, 92);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 1;
            label4.Text = "Modulos";
            // 
            // btnApalancamiento
            // 
            btnApalancamiento.FlatAppearance.BorderSize = 0;
            btnApalancamiento.FlatStyle = FlatStyle.Flat;
            btnApalancamiento.ImageAlign = ContentAlignment.MiddleLeft;
            btnApalancamiento.Location = new Point(11, 397);
            btnApalancamiento.Name = "btnApalancamiento";
            btnApalancamiento.Size = new Size(203, 42);
            btnApalancamiento.TabIndex = 7;
            btnApalancamiento.Text = "Apalancamiento";
            btnApalancamiento.TextAlign = ContentAlignment.MiddleLeft;
            btnApalancamiento.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnApalancamiento.UseVisualStyleBackColor = true;
            btnApalancamiento.Click += btnApalancamiento_Click;
            // 
            // btnFlujoEfectivo
            // 
            btnFlujoEfectivo.FlatAppearance.BorderSize = 0;
            btnFlujoEfectivo.FlatStyle = FlatStyle.Flat;
            btnFlujoEfectivo.ImageAlign = ContentAlignment.MiddleLeft;
            btnFlujoEfectivo.Location = new Point(11, 468);
            btnFlujoEfectivo.Name = "btnFlujoEfectivo";
            btnFlujoEfectivo.Size = new Size(203, 42);
            btnFlujoEfectivo.TabIndex = 6;
            btnFlujoEfectivo.Text = "Flujo de Efectivo";
            btnFlujoEfectivo.TextAlign = ContentAlignment.MiddleLeft;
            btnFlujoEfectivo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFlujoEfectivo.UseVisualStyleBackColor = true;
            btnFlujoEfectivo.Click += btnFlujoEfectivo_Click;
            // 
            // btnControlBasicoInventario
            // 
            btnControlBasicoInventario.FlatAppearance.BorderSize = 0;
            btnControlBasicoInventario.FlatStyle = FlatStyle.Flat;
            btnControlBasicoInventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnControlBasicoInventario.Location = new Point(11, 782);
            btnControlBasicoInventario.Name = "btnControlBasicoInventario";
            btnControlBasicoInventario.Size = new Size(203, 78);
            btnControlBasicoInventario.TabIndex = 5;
            btnControlBasicoInventario.Text = "Control Básico de Inventario";
            btnControlBasicoInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnControlBasicoInventario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnControlBasicoInventario.UseVisualStyleBackColor = true;
            btnControlBasicoInventario.Click += btnControlBasicoInventario_Click;
            // 
            // btnProforma
            // 
            btnProforma.FlatAppearance.BorderSize = 0;
            btnProforma.FlatStyle = FlatStyle.Flat;
            btnProforma.ImageAlign = ContentAlignment.MiddleLeft;
            btnProforma.Location = new Point(11, 635);
            btnProforma.Name = "btnProforma";
            btnProforma.Size = new Size(203, 42);
            btnProforma.TabIndex = 4;
            btnProforma.Text = "Proforma / Reporte Integrado";
            btnProforma.TextAlign = ContentAlignment.MiddleLeft;
            btnProforma.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProforma.UseVisualStyleBackColor = true;
            btnProforma.Click += btnProforma_Click;
            // 
            // btnPlaneacionPresupuestos
            // 
            btnPlaneacionPresupuestos.FlatAppearance.BorderSize = 0;
            btnPlaneacionPresupuestos.FlatStyle = FlatStyle.Flat;
            btnPlaneacionPresupuestos.ImageAlign = ContentAlignment.MiddleLeft;
            btnPlaneacionPresupuestos.Location = new Point(11, 537);
            btnPlaneacionPresupuestos.Name = "btnPlaneacionPresupuestos";
            btnPlaneacionPresupuestos.Size = new Size(203, 68);
            btnPlaneacionPresupuestos.TabIndex = 3;
            btnPlaneacionPresupuestos.Text = "Planeación y Presupuestos";
            btnPlaneacionPresupuestos.TextAlign = ContentAlignment.MiddleLeft;
            btnPlaneacionPresupuestos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPlaneacionPresupuestos.UseVisualStyleBackColor = true;
            btnPlaneacionPresupuestos.Click += btnPlaneacionPresupuestos_Click;
            // 
            // btnAnalisisFinanciero
            // 
            btnAnalisisFinanciero.FlatAppearance.BorderSize = 0;
            btnAnalisisFinanciero.FlatStyle = FlatStyle.Flat;
            btnAnalisisFinanciero.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnalisisFinanciero.Location = new Point(11, 222);
            btnAnalisisFinanciero.Name = "btnAnalisisFinanciero";
            btnAnalisisFinanciero.Size = new Size(203, 42);
            btnAnalisisFinanciero.TabIndex = 2;
            btnAnalisisFinanciero.Text = "Análisis Financiero";
            btnAnalisisFinanciero.TextAlign = ContentAlignment.MiddleLeft;
            btnAnalisisFinanciero.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAnalisisFinanciero.UseVisualStyleBackColor = true;
            btnAnalisisFinanciero.Click += btnAnalisisFinanciero_Click;
            // 
            // btnEstadosFinancieros
            // 
            btnEstadosFinancieros.FlatAppearance.BorderSize = 0;
            btnEstadosFinancieros.FlatStyle = FlatStyle.Flat;
            btnEstadosFinancieros.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstadosFinancieros.Location = new Point(11, 150);
            btnEstadosFinancieros.Name = "btnEstadosFinancieros";
            btnEstadosFinancieros.Size = new Size(203, 42);
            btnEstadosFinancieros.TabIndex = 1;
            btnEstadosFinancieros.Text = "Estados Financieros";
            btnEstadosFinancieros.TextAlign = ContentAlignment.MiddleLeft;
            btnEstadosFinancieros.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEstadosFinancieros.UseVisualStyleBackColor = true;
            btnEstadosFinancieros.Click += btnEstadosFinancieros_Click;
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
            PanelOpciones.Dock = DockStyle.Top;
            PanelOpciones.Location = new Point(230, 107);
            PanelOpciones.Name = "PanelOpciones";
            PanelOpciones.Size = new Size(1223, 62);
            PanelOpciones.TabIndex = 2;
            // 
            // PanelContenedor
            // 
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(230, 169);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Padding = new Padding(14, 15, 14, 15);
            PanelContenedor.Size = new Size(1223, 914);
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
            BarraSuperior.TitleText = "Panel Financiero";
            // 
            // PanelFinanciero
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1454, 1085);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelOpciones);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Controls.Add(BarraSuperior);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "PanelFinanciero";
            Padding = new Padding(1, 2, 1, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            Load += PanelFinanciero_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button btnEstadosFinancieros;
        private Button btnApalancamiento;
        private Button btnFlujoEfectivo;
        private Button btnControlBasicoInventario;
        private Button btnProforma;
        private Button btnPlaneacionPresupuestos;
        private Button btnAnalisisFinanciero;
        private Panel PanelContenedor;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private MenuStrip menuStrip1;
        private BodegasAburtoWMS.Components.CustomTitleBar BarraSuperior;
        private Button btnPuntoEquilibrioCVU;
        private Label label4;
        public Panel PanelOpciones;
        private Button btnPresupuestoPersonal;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnRegresarPrincipal;
    }
}