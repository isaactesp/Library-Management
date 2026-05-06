namespace Presentacion
{
    partial class FDevolverEjemplar
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
            this.lblPrestamo = new System.Windows.Forms.Label();
            this.cbPrestamos = new System.Windows.Forms.ComboBox();
            this.lblEjemplar = new System.Windows.Forms.Label();
            this.cbEjemplares = new System.Windows.Forms.ComboBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPrestamo
            // 
            this.lblPrestamo.AutoSize = true;
            this.lblPrestamo.Location = new System.Drawing.Point(30, 30);
            this.lblPrestamo.Name = "lblPrestamo";
            this.lblPrestamo.Size = new System.Drawing.Size(113, 13);
            this.lblPrestamo.TabIndex = 0;
            this.lblPrestamo.Text = "Seleccionar Préstamo:";
            // 
            // cbPrestamos
            // 
            this.cbPrestamos.FormattingEnabled = true;
            this.cbPrestamos.Location = new System.Drawing.Point(33, 46);
            this.cbPrestamos.Name = "cbPrestamos";
            this.cbPrestamos.Size = new System.Drawing.Size(171, 21);
            this.cbPrestamos.TabIndex = 1;
            // 
            // lblEjemplar
            // 
            this.lblEjemplar.AutoSize = true;
            this.lblEjemplar.Location = new System.Drawing.Point(30, 90);
            this.lblEjemplar.Name = "lblEjemplar";
            this.lblEjemplar.Size = new System.Drawing.Size(109, 13);
            this.lblEjemplar.TabIndex = 2;
            this.lblEjemplar.Text = "Seleccionar Ejemplar:";
            // 
            // cbEjemplares
            // 
            this.cbEjemplares.FormattingEnabled = true;
            this.cbEjemplares.Location = new System.Drawing.Point(33, 106);
            this.cbEjemplares.Name = "cbEjemplares";
            this.cbEjemplares.Size = new System.Drawing.Size(171, 21);
            this.cbEjemplares.TabIndex = 3;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(33, 148);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 23);
            this.btnDevolver.TabIndex = 4;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(129, 148);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FDevolverEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 211);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.cbEjemplares);
            this.Controls.Add(this.lblEjemplar);
            this.Controls.Add(this.cbPrestamos);
            this.Controls.Add(this.lblPrestamo);
            this.Name = "FDevolverEjemplar";
            this.Text = "Devolver Ejemplar";
            this.Load += new System.EventHandler(this.FDevolverEjemplar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrestamo;
        private System.Windows.Forms.ComboBox cbPrestamos;
        private System.Windows.Forms.Label lblEjemplar;
        private System.Windows.Forms.ComboBox cbEjemplares;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnCancelar;
    }
}