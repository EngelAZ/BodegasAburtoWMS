namespace BodegasAburtoWMS.View
{
    partial class FormEstadosProforma
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPrincipal;
        private System.Windows.Forms.DataGridView dgvProforma;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.Label lblTituloProforma;

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
            this.dgvProforma = new System.Windows.Forms.DataGridView();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.lblTituloProforma = new System.Windows.Forms.Label();

            this.tableLayoutPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProforma)).BeginInit();
            this.panelInferior.SuspendLayout();
            this.SuspendLayout();

            // 
            // tableLayoutPrincipal
            // 
            this.tableLayoutPrincipal.ColumnCount = 1;
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.Controls.Add(this.lblTituloProforma, 0, 0);
            this.tableLayoutPrincipal.Controls.Add(this.dgvProforma, 0, 1);
            this.tableLayoutPrincipal.Controls.Add(this.panelInferior, 0, 2);
            this.tableLayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPrincipal.Name = "tableLayoutPrincipal";
            this.tableLayoutPrincipal.RowCount = 3;
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPrincipal.Size = new System.Drawing.Size(950, 550);
            this.tableLayoutPrincipal.TabIndex = 0;

            // 
            // lblTituloProforma
            // 
            this.lblTituloProforma.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTituloProforma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloProforma.Location = new System.Drawing.Point(15, 10);
            this.lblTituloProforma.Size = new System.Drawing.Size(600, 30);
            this.lblTituloProforma.Text = "Estados Financieros Proforma Consolidados (2027)";

            // 
            // dgvProforma (Se ajusta dinámicamente al tamaño de la ventana)
            // 
            this.dgvProforma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProforma.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProforma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProforma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProforma.Location = new System.Drawing.Point(3, 53);
            this.dgvProforma.Name = "dgvProforma";
            this.dgvProforma.RowTemplate.Height = 25;
            this.dgvProforma.Size = new System.Drawing.Size(944, 396);
            this.dgvProforma.TabIndex = 1;

            // 
            // panelInferior
            // 
            this.panelInferior.Controls.Add(this.btnSincronizar);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInferior.Location = new System.Drawing.Point(3, 455);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(944, 92);
            this.panelInferior.TabIndex = 2;

            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(20, 20);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(240, 30);
            this.btnSincronizar.TabIndex = 0;
            this.btnSincronizar.Text = "Forzar Sincronización Proforma";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);

            // 
            // FormEstadosProforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.tableLayoutPrincipal);
            this.Name = "FormEstadosProforma";
            this.Text = "Bodegas Aburto WMS - Estados Financieros Proforma";
            this.tableLayoutPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProforma)).EndInit();
            this.panelInferior.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}