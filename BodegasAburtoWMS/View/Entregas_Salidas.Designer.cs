namespace BodegasAburtoWMS.View
{
    partial class Entregas_Salidas
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
            panelTopMenu = new Panel();
            btnHistorial = new Button();
            btnRegistrarEntrega = new Button();
            btnPendientes = new Button();
            flowPanelTarjetas = new FlowLayoutPanel();
            panelTopMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopMenu
            // 
            panelTopMenu.Controls.Add(btnHistorial);
            panelTopMenu.Controls.Add(btnRegistrarEntrega);
            panelTopMenu.Controls.Add(btnPendientes);
            panelTopMenu.Dock = DockStyle.Top;
            panelTopMenu.Location = new Point(0, 0);
            panelTopMenu.Name = "panelTopMenu";
            panelTopMenu.Size = new Size(838, 49);
            panelTopMenu.TabIndex = 0;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new Point(415, 0);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(146, 34);
            btnHistorial.TabIndex = 2;
            btnHistorial.Text = "📁 Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnRegistrarEntrega
            // 
            btnRegistrarEntrega.Location = new Point(199, 0);
            btnRegistrarEntrega.Name = "btnRegistrarEntrega";
            btnRegistrarEntrega.Size = new Size(192, 34);
            btnRegistrarEntrega.TabIndex = 1;
            btnRegistrarEntrega.Text = "✏️ Registrar Entrega";
            btnRegistrarEntrega.UseVisualStyleBackColor = true;
            btnRegistrarEntrega.Click += btnRegistrarEntrega_Click;
            // 
            // btnPendientes
            // 
            btnPendientes.Location = new Point(0, 0);
            btnPendientes.Name = "btnPendientes";
            btnPendientes.Size = new Size(175, 34);
            btnPendientes.TabIndex = 0;
            btnPendientes.Text = "📋 Pendientes";
            btnPendientes.UseVisualStyleBackColor = true;
            btnPendientes.Click += btnPendientes_Click;
            // 
            // flowPanelTarjetas
            // 
            flowPanelTarjetas.AutoScroll = true;
            flowPanelTarjetas.BackColor = Color.FromArgb(245, 247, 250);
            flowPanelTarjetas.Dock = DockStyle.Fill;
            flowPanelTarjetas.FlowDirection = FlowDirection.TopDown;
            flowPanelTarjetas.Location = new Point(0, 49);
            flowPanelTarjetas.Name = "flowPanelTarjetas";
            flowPanelTarjetas.Size = new Size(838, 545);
            flowPanelTarjetas.TabIndex = 1;
            flowPanelTarjetas.WrapContents = false;
            // 
            // Entregas_Salidas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 594);
            Controls.Add(flowPanelTarjetas);
            Controls.Add(panelTopMenu);
            Name = "Entregas_Salidas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entregas_Salidas";
            Load += Entregas_Salidas_Load;
            panelTopMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopMenu;
        private Button btnHistorial;
        private Button btnRegistrarEntrega;
        private Button btnPendientes;
        private FlowLayoutPanel flowPanelTarjetas;
    }
}