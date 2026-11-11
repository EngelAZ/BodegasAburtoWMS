namespace BodegasAburtoWMS.View
{
    partial class ModuloEstadosFinacieros
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
            tabControl1 = new TabControl();
            tabBalance = new TabPage();
            tabResultados = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabBalance);
            tabControl1.Controls.Add(tabResultados);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabBalance
            // 
            tabBalance.Location = new Point(4, 34);
            tabBalance.Name = "tabBalance";
            tabBalance.Padding = new Padding(3);
            tabBalance.Size = new Size(792, 412);
            tabBalance.TabIndex = 0;
            tabBalance.Text = "Balance General";
            tabBalance.UseVisualStyleBackColor = true;
            // 
            // tabResultados
            // 
            tabResultados.Location = new Point(4, 34);
            tabResultados.Name = "tabResultados";
            tabResultados.Padding = new Padding(3);
            tabResultados.Size = new Size(792, 412);
            tabResultados.TabIndex = 1;
            tabResultados.Text = "Estado de Resultados";
            tabResultados.UseVisualStyleBackColor = true;
            // 
            // Gestion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Gestion";
            Text = "Gestion";
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabBalance;
        private TabPage tabResultados;
    }
}