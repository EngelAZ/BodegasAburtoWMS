namespace BodegasAburtoWMS.View
{
    partial class Materiales
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
            dgvMateriales = new DataGridView();
            lblControl = new Label();
            btnNuevo = new Button();
            pnlMateriales = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).BeginInit();
            pnlMateriales.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMateriales
            // 
            dgvMateriales.BackgroundColor = Color.LightGray;
            dgvMateriales.BorderStyle = BorderStyle.None;
            dgvMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMateriales.Dock = DockStyle.Fill;
            dgvMateriales.Location = new Point(0, 0);
            dgvMateriales.Name = "dgvMateriales";
            dgvMateriales.Size = new Size(804, 450);
            dgvMateriales.TabIndex = 0;
            // 
            // lblControl
            // 
            lblControl.AutoSize = true;
            lblControl.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblControl.Location = new Point(3, 12);
            lblControl.Name = "lblControl";
            lblControl.Size = new Size(155, 16);
            lblControl.TabIndex = 1;
            lblControl.Text = "Control de Materiales";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(255, 128, 0);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(661, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(132, 27);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "+ Nuevo Material";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // pnlMateriales
            // 
            pnlMateriales.BorderStyle = BorderStyle.FixedSingle;
            pnlMateriales.Controls.Add(btnNuevo);
            pnlMateriales.Controls.Add(lblControl);
            pnlMateriales.Dock = DockStyle.Top;
            pnlMateriales.Location = new Point(0, 0);
            pnlMateriales.Name = "pnlMateriales";
            pnlMateriales.Size = new Size(804, 36);
            pnlMateriales.TabIndex = 3;
            // 
            // Materiales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 450);
            Controls.Add(pnlMateriales);
            Controls.Add(dgvMateriales);
            Name = "Materiales";
            Text = "Materiales";
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).EndInit();
            pnlMateriales.ResumeLayout(false);
            pnlMateriales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMateriales;
        private Label lblControl;
        private Button btnNuevo;
        private Panel pnlMateriales;
    }
}