namespace WindowsFormsApplication1
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cargar1Button = new System.Windows.Forms.Button();
            this.cargar2Button = new System.Windows.Forms.Button();
            this.calcularButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrador - Aeropuertos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccionar archivo de ubicaciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccionar archivo de destinos";
            // 
            // cargar1Button
            // 
            this.cargar1Button.Location = new System.Drawing.Point(305, 75);
            this.cargar1Button.Name = "cargar1Button";
            this.cargar1Button.Size = new System.Drawing.Size(75, 23);
            this.cargar1Button.TabIndex = 3;
            this.cargar1Button.Text = "Cargar";
            this.cargar1Button.UseVisualStyleBackColor = true;
            this.cargar1Button.Click += new System.EventHandler(this.cargar1Button_Click);
            // 
            // cargar2Button
            // 
            this.cargar2Button.Location = new System.Drawing.Point(305, 142);
            this.cargar2Button.Name = "cargar2Button";
            this.cargar2Button.Size = new System.Drawing.Size(75, 23);
            this.cargar2Button.TabIndex = 4;
            this.cargar2Button.Text = "Cargar";
            this.cargar2Button.UseVisualStyleBackColor = true;
            this.cargar2Button.Click += new System.EventHandler(this.cargar2Button_Click);
            // 
            // calcularButton
            // 
            this.calcularButton.Location = new System.Drawing.Point(110, 214);
            this.calcularButton.Name = "calcularButton";
            this.calcularButton.Size = new System.Drawing.Size(206, 23);
            this.calcularButton.TabIndex = 5;
            this.calcularButton.Text = "Calcular Rutas";
            this.calcularButton.UseVisualStyleBackColor = true;
            this.calcularButton.Click += new System.EventHandler(this.CalcularButton_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 249);
            this.Controls.Add(this.calcularButton);
            this.Controls.Add(this.cargar2Button);
            this.Controls.Add(this.cargar1Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Inicio";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cargar1Button;
        private System.Windows.Forms.Button cargar2Button;
        private System.Windows.Forms.Button calcularButton;
    }
}

