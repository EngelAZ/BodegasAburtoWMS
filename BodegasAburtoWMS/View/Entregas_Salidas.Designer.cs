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
            btnRegistrarEntrega = new Button();
            btnBodegaDestino = new Button();
            btnEnTransito = new Button();
            btnHistorial = new Button();
            btnBodegaOrigen = new Button();
            btnPendientes = new Button();
            panelTarjetas = new Panel();
            panelTopMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopMenu
            // 
            panelTopMenu.Controls.Add(btnRegistrarEntrega);
            panelTopMenu.Controls.Add(btnBodegaDestino);
            panelTopMenu.Controls.Add(btnEnTransito);
            panelTopMenu.Controls.Add(btnHistorial);
            panelTopMenu.Controls.Add(btnBodegaOrigen);
            panelTopMenu.Controls.Add(btnPendientes);
            panelTopMenu.Dock = DockStyle.Top;
            panelTopMenu.Location = new Point(0, 0);
            panelTopMenu.Margin = new Padding(2);
            panelTopMenu.Name = "panelTopMenu";
            panelTopMenu.Size = new Size(874, 29);
            panelTopMenu.TabIndex = 0;
            // 
            // btnRegistrarEntrega
            // 
            btnRegistrarEntrega.Location = new Point(657, 2);
            btnRegistrarEntrega.Margin = new Padding(2);
            btnRegistrarEntrega.Name = "btnRegistrarEntrega";
            btnRegistrarEntrega.Size = new Size(134, 24);
            btnRegistrarEntrega.TabIndex = 1;
            btnRegistrarEntrega.Text = "✏️ Registrar Entrega";
            btnRegistrarEntrega.UseVisualStyleBackColor = true;
            btnRegistrarEntrega.Click += btnRegistrarEntrega_Click;
            // 
            // btnBodegaDestino
            // 
            btnBodegaDestino.Location = new Point(413, 2);
            btnBodegaDestino.Margin = new Padding(2);
            btnBodegaDestino.Name = "btnBodegaDestino";
            btnBodegaDestino.Size = new Size(134, 24);
            btnBodegaDestino.TabIndex = 4;
            btnBodegaDestino.Text = "Bodega de Destino";
            btnBodegaDestino.UseVisualStyleBackColor = true;
            btnBodegaDestino.Click += btnBodegaDestino_Click;
            // 
            // btnEnTransito
            // 
            btnEnTransito.Location = new Point(275, 2);
            btnEnTransito.Margin = new Padding(2);
            btnEnTransito.Name = "btnEnTransito";
            btnEnTransito.Size = new Size(134, 24);
            btnEnTransito.TabIndex = 3;
            btnEnTransito.Text = "En Transito";
            btnEnTransito.UseVisualStyleBackColor = true;
            btnEnTransito.Click += btnEnTransito_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new Point(551, 2);
            btnHistorial.Margin = new Padding(2);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(102, 24);
            btnHistorial.TabIndex = 2;
            btnHistorial.Text = "📁 Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnBodegaOrigen
            // 
            btnBodegaOrigen.Location = new Point(137, 2);
            btnBodegaOrigen.Margin = new Padding(2);
            btnBodegaOrigen.Name = "btnBodegaOrigen";
            btnBodegaOrigen.Size = new Size(134, 24);
            btnBodegaOrigen.TabIndex = 2;
            btnBodegaOrigen.Text = "Bodega de Origen";
            btnBodegaOrigen.UseVisualStyleBackColor = true;
            btnBodegaOrigen.Click += btnBodegaOrigen_Click;
            // 
            // btnPendientes
            // 
            btnPendientes.Location = new Point(11, 2);
            btnPendientes.Margin = new Padding(2);
            btnPendientes.Name = "btnPendientes";
            btnPendientes.Size = new Size(122, 24);
            btnPendientes.TabIndex = 0;
            btnPendientes.Text = "📋 Pendientes";
            btnPendientes.UseVisualStyleBackColor = true;
            btnPendientes.Click += btnPendientes_Click;
            // 
            // panelTarjetas
            // 
            panelTarjetas.AutoScroll = true;
            panelTarjetas.Dock = DockStyle.Fill;
            panelTarjetas.Location = new Point(0, 29);
            panelTarjetas.Name = "panelTarjetas";
            panelTarjetas.Size = new Size(874, 327);
            panelTarjetas.TabIndex = 1;
            // 
            // Entregas_Salidas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 356);
            Controls.Add(panelTarjetas);
            Controls.Add(panelTopMenu);
            Margin = new Padding(2);
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
        private Panel panelTarjetas;
        private Button btnBodegaOrigen;
        private Button btnBodegaDestino;
        private Button btnEnTransito;
    }
}