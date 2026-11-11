namespace BodegasAburtoWMS.View
{
    partial class FormPresupuestoOperacion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPrincipal;
        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.TextBox txtVentasParam;
        private System.Windows.Forms.TextBox txtGastosParam;
        private System.Windows.Forms.Button btnActualizarTrimestre;
        private System.Windows.Forms.Label lblEncabezado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.txtVentasParam = new System.Windows.Forms.TextBox();
            this.txtGastosParam = new System.Windows.Forms.TextBox();
            this.btnActualizarTrimestre = new System.Windows.Forms.Button();
            this.lblEncabezado = new System.Windows.Forms.Label();

            this.tableLayoutPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();

            // 
            // tableLayoutPrincipal
            // 
            this.tableLayoutPrincipal.ColumnCount = 1;
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.Controls.Add(this.lblEncabezado, 0, 0);
            this.tableLayoutPrincipal.Controls.Add(this.dgvPresupuesto, 0, 1);
            this.tableLayoutPrincipal.Controls.Add(this.panelAcciones, 0, 2);
            this.tableLayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPrincipal.Name = "tableLayoutPrincipal";
            this.tableLayoutPrincipal.RowCount = 3;
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPrincipal.Size = new System.Drawing.Size(900, 550);
            this.tableLayoutPrincipal.TabIndex = 0;

            // 
            // lblEncabezado
            // 
            this.lblEncabezado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEncabezado.Location = new System.Drawing.Point(15, 10);
            this.lblEncabezado.Size = new System.Drawing.Size(600, 30);
            this.lblEncabezado.Text = "Presupuesto Operativo y Flujo de Caja por Trimestre";

            // 
            // dgvPresupuesto (Se adapta dinámicamente con DockStyle.Fill)
            // 
            this.dgvPresupuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPresupuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresupuesto.Location = new System.Drawing.Point(3, 53);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.RowTemplate.Height = 25;
            this.dgvPresupuesto.Size = new System.Drawing.Size(894, 367);
            this.dgvPresupuesto.TabIndex = 1;

            // 
            // panelAcciones
            // 
            this.panelAcciones.Controls.Add(this.txtVentasParam);
            this.panelAcciones.Controls.Add(this.txtGastosParam);
            this.panelAcciones.Controls.Add(this.btnActualizarTrimestre);
            this.panelAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAcciones.Location = new System.Drawing.Point(3, 426);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(894, 121);
            this.panelAcciones.TabIndex = 2;

            // 
            // txtVentasParam
            // 
            this.txtVentasParam.Location = new System.Drawing.Point(20, 25);
            this.txtVentasParam.Name = "txtVentasParam";
            this.txtVentasParam.Size = new System.Drawing.Size(180, 23);
            this.txtVentasParam.TabIndex = 0;
            // (Placeholder o texto guía implícito por contexto operativo)

            // 
            // txtGastosParam
            // 
            this.txtGastosParam.Location = new System.Drawing.Point(220, 25);
            this.txtGastosParam.Name = "txtGastosParam";
            this.txtGastosParam.Size = new System.Drawing.Size(180, 23);
            this.txtGastosParam.TabIndex = 1;

            // 
            // btnActualizarTrimestre
            // 
            this.btnActualizarTrimestre.Location = new System.Drawing.Point(420, 24);
            this.btnActualizarTrimestre.Name = "btnActualizarTrimestre";
            this.btnActualizarTrimestre.Size = new System.Drawing.Size(200, 25);
            this.btnActualizarTrimestre.TabIndex = 2;
            this.btnActualizarTrimestre.Text = "Actualizar y Recalcular Caja";
            this.btnActualizarTrimestre.UseVisualStyleBackColor = true;
            this.btnActualizarTrimestre.Click += new System.EventHandler(this.btnActualizarTrimestre_Click);

            // 
            // FormPresupuestoOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.tableLayoutPrincipal);
            this.Name = "FormPresupuestoOperacion";
            this.Text = "Bodegas Aburto WMS - Presupuesto Operativo y Tesorería";
            this.tableLayoutPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            this.panelAcciones.ResumeLayout(false);
            this.panelAcciones.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}