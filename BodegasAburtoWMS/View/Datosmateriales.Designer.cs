namespace BodegasAburtoWMS.View
{
    partial class Datosmateriales
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
            lblNombre = new Label();
            textBox1 = new TextBox();
            lblUnidad = new Label();
            lblStockA = new Label();
            lblStockM = new Label();
            lblPrecioU = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(50, 48);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(118, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // lblUnidad
            // 
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new Point(50, 90);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(104, 15);
            lblUnidad.TabIndex = 2;
            lblUnidad.Text = "Unidad de medida";
            // 
            // lblStockA
            // 
            lblStockA.AutoSize = true;
            lblStockA.Location = new Point(50, 130);
            lblStockA.Name = "lblStockA";
            lblStockA.Size = new Size(71, 15);
            lblStockA.TabIndex = 3;
            lblStockA.Text = "Stock actual";
            // 
            // lblStockM
            // 
            lblStockM.AutoSize = true;
            lblStockM.Location = new Point(50, 175);
            lblStockM.Name = "lblStockM";
            lblStockM.Size = new Size(81, 15);
            lblStockM.TabIndex = 4;
            lblStockM.Text = "Stock minimo";
            // 
            // lblPrecioU
            // 
            lblPrecioU.AutoSize = true;
            lblPrecioU.Location = new Point(50, 218);
            lblPrecioU.Name = "lblPrecioU";
            lblPrecioU.Size = new Size(84, 15);
            lblPrecioU.TabIndex = 5;
            lblPrecioU.Text = "Precio unitario";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(160, 82);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(137, 122);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(137, 167);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(137, 210);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(56, 287);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(143, 287);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(242, 287);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // Datosmateriales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(lblPrecioU);
            Controls.Add(lblStockM);
            Controls.Add(lblStockA);
            Controls.Add(lblUnidad);
            Controls.Add(textBox1);
            Controls.Add(lblNombre);
            Name = "Datosmateriales";
            Text = "Datos de Materiales - Aburto WMS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox textBox1;
        private Label lblUnidad;
        private Label lblStockA;
        private Label lblStockM;
        private Label lblPrecioU;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnSalir;
    }
}