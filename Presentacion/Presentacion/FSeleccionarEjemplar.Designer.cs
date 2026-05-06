namespace Presentacion
{
    partial class FSeleccionarEjemplar
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
            this.lblEjemplaresDisp = new System.Windows.Forms.Label();
            this.cbEjemplares = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEjemplaresDisp
            // 
            this.lblEjemplaresDisp.AutoSize = true;
            this.lblEjemplaresDisp.Location = new System.Drawing.Point(144, 107);
            this.lblEjemplaresDisp.Name = "lblEjemplaresDisp";
            this.lblEjemplaresDisp.Size = new System.Drawing.Size(116, 13);
            this.lblEjemplaresDisp.TabIndex = 0;
            this.lblEjemplaresDisp.Text = "Ejemplares disponibles:";
            // 
            // cbEjemplares
            // 
            this.cbEjemplares.FormattingEnabled = true;
            this.cbEjemplares.Location = new System.Drawing.Point(302, 104);
            this.cbEjemplares.Name = "cbEjemplares";
            this.cbEjemplares.Size = new System.Drawing.Size(121, 21);
            this.cbEjemplares.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(240, 156);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FSeleccionarEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 204);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbEjemplares);
            this.Controls.Add(this.lblEjemplaresDisp);
            this.Name = "FSeleccionarEjemplar";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEjemplaresDisp;
        private System.Windows.Forms.ComboBox cbEjemplares;
        private System.Windows.Forms.Button btnAceptar;
    }
}