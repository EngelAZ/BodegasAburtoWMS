namespace BodegasAburtoWMS.View
{
    partial class DatosEnvios
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dtpFechaEnvio = new DateTimePicker();
            dtpFechaEntregaEstimada = new DateTimePicker();
            dtpFechaEntregaReal = new DateTimePicker();
            txtNumeroGuia = new TextBox();
            txtOrigen = new TextBox();
            txtDestino = new TextBox();
            txtCostoEnvio = new TextBox();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            cmbAgencia = new ComboBox();
            cmbRemitente = new ComboBox();
            cmbDestinatario = new ComboBox();
            cmbTipoEnvio = new ComboBox();
            cmbEstado = new ComboBox();
            lblAgencia = new Label();
            lblRemitente = new Label();
            lblDestinatatio = new Label();
            lblTipoEnvio = new Label();
            lblEstado = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 50);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "Numero de guia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 89);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Origen";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 134);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 2;
            label3.Text = "Destino";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 174);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha de envio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 218);
            label5.Name = "label5";
            label5.Size = new Size(141, 15);
            label5.TabIndex = 4;
            label5.Text = "Fecha de etrega estimada";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 258);
            label6.Name = "label6";
            label6.Size = new Size(119, 15);
            label6.TabIndex = 5;
            label6.Text = "Fecha de entrega real";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 300);
            label7.Name = "label7";
            label7.Size = new Size(86, 15);
            label7.TabIndex = 6;
            label7.Text = "Costo de envio";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(45, 338);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 7;
            label8.Text = "Observaciones";
            // 
            // dtpFechaEnvio
            // 
            dtpFechaEnvio.Format = DateTimePickerFormat.Short;
            dtpFechaEnvio.Location = new Point(137, 168);
            dtpFechaEnvio.Name = "dtpFechaEnvio";
            dtpFechaEnvio.Size = new Size(255, 23);
            dtpFechaEnvio.TabIndex = 8;
            // 
            // dtpFechaEntregaEstimada
            // 
            dtpFechaEntregaEstimada.Format = DateTimePickerFormat.Short;
            dtpFechaEntregaEstimada.Location = new Point(192, 212);
            dtpFechaEntregaEstimada.Name = "dtpFechaEntregaEstimada";
            dtpFechaEntregaEstimada.Size = new Size(200, 23);
            dtpFechaEntregaEstimada.TabIndex = 9;
            // 
            // dtpFechaEntregaReal
            // 
            dtpFechaEntregaReal.Format = DateTimePickerFormat.Short;
            dtpFechaEntregaReal.Location = new Point(170, 252);
            dtpFechaEntregaReal.Name = "dtpFechaEntregaReal";
            dtpFechaEntregaReal.Size = new Size(222, 23);
            dtpFechaEntregaReal.TabIndex = 10;
            // 
            // txtNumeroGuia
            // 
            txtNumeroGuia.Location = new Point(144, 47);
            txtNumeroGuia.Name = "txtNumeroGuia";
            txtNumeroGuia.Size = new Size(248, 23);
            txtNumeroGuia.TabIndex = 11;
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(98, 86);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(294, 23);
            txtOrigen.TabIndex = 12;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(98, 131);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(294, 23);
            txtDestino.TabIndex = 13;
            // 
            // txtCostoEnvio
            // 
            txtCostoEnvio.Location = new Point(144, 297);
            txtCostoEnvio.Name = "txtCostoEnvio";
            txtCostoEnvio.Size = new Size(248, 23);
            txtCostoEnvio.TabIndex = 14;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(144, 335);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(248, 23);
            txtObservaciones.TabIndex = 15;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(45, 397);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(126, 397);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(207, 397);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // cmbAgencia
            // 
            cmbAgencia.FormattingEnabled = true;
            cmbAgencia.Location = new Point(632, 50);
            cmbAgencia.Name = "cmbAgencia";
            cmbAgencia.Size = new Size(121, 23);
            cmbAgencia.TabIndex = 19;
            // 
            // cmbRemitente
            // 
            cmbRemitente.FormattingEnabled = true;
            cmbRemitente.Location = new Point(632, 100);
            cmbRemitente.Name = "cmbRemitente";
            cmbRemitente.Size = new Size(121, 23);
            cmbRemitente.TabIndex = 20;
            // 
            // cmbDestinatario
            // 
            cmbDestinatario.FormattingEnabled = true;
            cmbDestinatario.Location = new Point(632, 152);
            cmbDestinatario.Name = "cmbDestinatario";
            cmbDestinatario.Size = new Size(121, 23);
            cmbDestinatario.TabIndex = 21;
            // 
            // cmbTipoEnvio
            // 
            cmbTipoEnvio.FormattingEnabled = true;
            cmbTipoEnvio.Location = new Point(632, 210);
            cmbTipoEnvio.Name = "cmbTipoEnvio";
            cmbTipoEnvio.Size = new Size(121, 23);
            cmbTipoEnvio.TabIndex = 22;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(632, 258);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 23;
            // 
            // lblAgencia
            // 
            lblAgencia.AutoSize = true;
            lblAgencia.Location = new Point(544, 53);
            lblAgencia.Name = "lblAgencia";
            lblAgencia.Size = new Size(50, 15);
            lblAgencia.TabIndex = 24;
            lblAgencia.Text = "Agencia";
            // 
            // lblRemitente
            // 
            lblRemitente.AutoSize = true;
            lblRemitente.Location = new Point(544, 103);
            lblRemitente.Name = "lblRemitente";
            lblRemitente.Size = new Size(61, 15);
            lblRemitente.TabIndex = 25;
            lblRemitente.Text = "Remitente";
            // 
            // lblDestinatatio
            // 
            lblDestinatatio.AutoSize = true;
            lblDestinatatio.Location = new Point(544, 155);
            lblDestinatatio.Name = "lblDestinatatio";
            lblDestinatatio.Size = new Size(70, 15);
            lblDestinatatio.TabIndex = 26;
            lblDestinatatio.Text = "Destinatario";
            // 
            // lblTipoEnvio
            // 
            lblTipoEnvio.AutoSize = true;
            lblTipoEnvio.Location = new Point(544, 213);
            lblTipoEnvio.Name = "lblTipoEnvio";
            lblTipoEnvio.Size = new Size(78, 15);
            lblTipoEnvio.TabIndex = 27;
            lblTipoEnvio.Text = "Tipo de Envio";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(544, 261);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 28;
            lblEstado.Text = "Estado";
            // 
            // DatosEnvios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblEstado);
            Controls.Add(lblTipoEnvio);
            Controls.Add(lblDestinatatio);
            Controls.Add(lblRemitente);
            Controls.Add(lblAgencia);
            Controls.Add(cmbEstado);
            Controls.Add(cmbTipoEnvio);
            Controls.Add(cmbDestinatario);
            Controls.Add(cmbRemitente);
            Controls.Add(cmbAgencia);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservaciones);
            Controls.Add(txtCostoEnvio);
            Controls.Add(txtDestino);
            Controls.Add(txtOrigen);
            Controls.Add(txtNumeroGuia);
            Controls.Add(dtpFechaEntregaReal);
            Controls.Add(dtpFechaEntregaEstimada);
            Controls.Add(dtpFechaEnvio);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DatosEnvios";
            Text = "Datos de Envios";
            Load += DatosEnvios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DateTimePicker dtpFechaEnvio;
        private DateTimePicker dtpFechaEntregaEstimada;
        private DateTimePicker dtpFechaEntregaReal;
        private TextBox txtNumeroGuia;
        private TextBox txtOrigen;
        private TextBox txtDestino;
        private TextBox txtCostoEnvio;
        private TextBox txtObservaciones;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnSalir;
        private ComboBox cmbAgencia;
        private ComboBox cmbRemitente;
        private ComboBox cmbDestinatario;
        private ComboBox cmbTipoEnvio;
        private ComboBox cmbEstado;
        private Label lblAgencia;
        private Label lblRemitente;
        private Label lblDestinatatio;
        private Label lblTipoEnvio;
        private Label lblEstado;
    }
}