namespace BodegasAburtoWMS.View
{
    partial class Reportes
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
            pnl2WMS = new Panel();
            tablelp1 = new TableLayoutPanel();
            lbl5 = new Label();
            lbl3 = new Label();
            lbl2 = new Label();
            lbl6 = new Label();
            lbl4 = new Label();
            lbl1 = new Label();
            labelConsultas = new Label();
            pnl2WMS.SuspendLayout();
            tablelp1.SuspendLayout();
            SuspendLayout();
            // 
            // pnl2WMS
            // 
            pnl2WMS.BackColor = Color.LightGray;
            pnl2WMS.Controls.Add(tablelp1);
            pnl2WMS.Controls.Add(labelConsultas);
            pnl2WMS.Dock = DockStyle.Fill;
            pnl2WMS.Location = new Point(0, 0);
            pnl2WMS.Name = "pnl2WMS";
            pnl2WMS.Size = new Size(1028, 540);
            pnl2WMS.TabIndex = 2;
            // 
            // tablelp1
            // 
            tablelp1.BackColor = Color.White;
            tablelp1.ColumnCount = 3;
            tablelp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tablelp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tablelp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tablelp1.Controls.Add(lbl5, 1, 1);
            tablelp1.Controls.Add(lbl3, 2, 0);
            tablelp1.Controls.Add(lbl2, 1, 0);
            tablelp1.Controls.Add(lbl6, 2, 1);
            tablelp1.Controls.Add(lbl4, 0, 1);
            tablelp1.Controls.Add(lbl1, 0, 0);
            tablelp1.Location = new Point(0, 75);
            tablelp1.Name = "tablelp1";
            tablelp1.RowCount = 2;
            tablelp1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablelp1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablelp1.Size = new Size(808, 221);
            tablelp1.TabIndex = 1;
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl5.Location = new Point(272, 110);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(168, 15);
            lbl5.TabIndex = 4;
            lbl5.Text = "Movimientos por agencia";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(541, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(124, 15);
            lbl3.TabIndex = 2;
            lbl3.Text = "Envios pendientes";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.BackColor = Color.White;
            lbl2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(272, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(125, 15);
            lbl2.TabIndex = 1;
            lbl2.Text = "Envios entregados";
            // 
            // lbl6
            // 
            lbl6.AutoSize = true;
            lbl6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl6.Location = new Point(541, 110);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(169, 15);
            lbl6.TabIndex = 5;
            lbl6.Text = "Liquidaciones generadas";
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl4.Location = new Point(3, 110);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(119, 15);
            lbl4.TabIndex = 3;
            lbl4.Text = "Bultos de bodega";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(3, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(112, 15);
            lbl1.TabIndex = 0;
            lbl1.Text = "Envios recibidos";
            // 
            // labelConsultas
            // 
            labelConsultas.AutoSize = true;
            labelConsultas.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConsultas.Location = new Point(36, 25);
            labelConsultas.Name = "labelConsultas";
            labelConsultas.Size = new Size(181, 20);
            labelConsultas.TabIndex = 0;
            labelConsultas.Text = "Consultas y Reportes";
            // 
            // Reportes
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 540);
            Controls.Add(pnl2WMS);
            Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Reportes";
            Text = "Reportes y Consultas -- Aburto WMS";
            Load += Reportes_Load;
            pnl2WMS.ResumeLayout(false);
            pnl2WMS.PerformLayout();
            tablelp1.ResumeLayout(false);
            tablelp1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnl2WMS;
        private Label labelConsultas;
        private TableLayoutPanel tablelp1;
        private Label lbl5;
        private Label lbl4;
        private Label lbl3;
        private Label lbl2;
        private Label lbl1;
        private Label lbl6;
    }
}