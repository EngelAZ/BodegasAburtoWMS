namespace BodegasAburtoWMS.View
{
    partial class FormSupuestosBudget
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPrincipal;
        private System.Windows.Forms.DataGridView dgvSupuestos;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.TextBox txtNuevoValor;
        private System.Windows.Forms.Button btnGuardarModificacion;
        private System.Windows.Forms.Label lblTitulo;

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
            this.dgvSupuestos = new System.Windows.Forms.DataGridView();
            this.panelControles = new System.Windows.Forms.Panel();
            this.txtNuevoValor = new System.Windows.Forms.TextBox();
            this.btnGuardarModificacion = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.tableLayoutPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupuestos)).BeginInit();
            this.panelControles.SuspendLayout();
            this.SuspendLayout();

            // 
            // tableLayoutPrincipal (Responsivo con filas adaptativas)
            // 
            this.tableLayoutPrincipal.ColumnCount = 1;
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPrincipal.Controls.Add(this.dgvSupuestos, 0, 1);
            this.tableLayoutPrincipal.Controls.Add(this.panelControles, 0, 2);
            this.tableLayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPrincipal.Name = "tableLayoutPrincipal";
            this.tableLayoutPrincipal.RowCount = 3;
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPrincipal.Size = new System.Drawing.Size(800, 500);
            this.tableLayoutPrincipal.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Size = new System.Drawing.Size(500, 30);
            this.lblTitulo.Text = "Gestión Dinámica de Supuestos y Proyecciones";

            // 
            // dgvSupuestos (Llena todo el espacio disponible al redimensionar)
            // 
            this.dgvSupuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupuestos.Location = new System.Drawing.Point(3, 53);
            this.dgvSupuestos.Name = "dgvSupuestos";
            this.dgvSupuestos.RowTemplate.Height = 25;
            this.dgvSupuestos.Size = new System.Drawing.Size(794, 350);
            this.dgvSupuestos.TabIndex = 1;

            // 
            // panelControles
            // 
            this.panelControles.Controls.Add(this.txtNuevoValor);
            this.panelControles.Controls.Add(this.btnGuardarModificacion);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControles.Location = new System.Drawing.Point(3, 409);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(794, 88);
            this.panelControles.TabIndex = 2;

            // 
            // txtNuevoValor
            // 
            this.txtNuevoValor.Location = new System.Drawing.Point(20, 20);
            this.txtNuevoValor.Name = "txtNuevoValor";
            this.txtNuevoValor.Size = new System.Drawing.Size(200, 23);
            this.txtNuevoValor.TabIndex = 0;

            // 
            // btnGuardarModificacion
            // 
            this.btnGuardarModificacion.Location = new System.Drawing.Point(235, 19);
            this.btnGuardarModificacion.Name = "btnGuardarModificacion";
            this.btnGuardarModificacion.Size = new System.Drawing.Size(180, 25);
            this.btnGuardarModificacion.TabIndex = 1;
            this.btnGuardarModificacion.Text = "Modificar y Recalcular";
            this.btnGuardarModificacion.UseVisualStyleBackColor = true;
            this.btnGuardarModificacion.Click += new System.EventHandler(this.btnGuardarModificacion_Click);

            // 
            // FormSupuestosBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tableLayoutPrincipal);
            this.Name = "FormSupuestosBudget";
            this.Text = "Bodegas Aburto WMS - Módulo de Supuestos Proforma";
            this.tableLayoutPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupuestos)).EndInit();
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}