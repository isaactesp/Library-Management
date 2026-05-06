namespace Presentacion
{
    partial class FListadoUsuarios
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
            this.btnOrdenarDNI = new System.Windows.Forms.Button();
            this.btnOrdenarNombre = new System.Windows.Forms.Button();
            this.lstDNI = new System.Windows.Forms.ListBox();
            this.lstNombre = new System.Windows.Forms.ListBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrdenarDNI
            // 
            this.btnOrdenarDNI.Location = new System.Drawing.Point(33, 25);
            this.btnOrdenarDNI.Name = "btnOrdenarDNI";
            this.btnOrdenarDNI.Size = new System.Drawing.Size(135, 31);
            this.btnOrdenarDNI.TabIndex = 0;
            this.btnOrdenarDNI.Text = "DNI";
            this.btnOrdenarDNI.UseVisualStyleBackColor = true;
            this.btnOrdenarDNI.Click += new System.EventHandler(this.btnOrdenarDNI_Click);
            // 
            // btnOrdenarNombre
            // 
            this.btnOrdenarNombre.Location = new System.Drawing.Point(202, 25);
            this.btnOrdenarNombre.Name = "btnOrdenarNombre";
            this.btnOrdenarNombre.Size = new System.Drawing.Size(135, 31);
            this.btnOrdenarNombre.TabIndex = 1;
            this.btnOrdenarNombre.Text = "Nombre";
            this.btnOrdenarNombre.UseVisualStyleBackColor = true;
            this.btnOrdenarNombre.Click += new System.EventHandler(this.btnOrdenarNombre_Click);
            // 
            // lstDNI
            // 
            this.lstDNI.FormattingEnabled = true;
            this.lstDNI.ItemHeight = 20;
            this.lstDNI.Location = new System.Drawing.Point(33, 63);
            this.lstDNI.Name = "lstDNI";
            this.lstDNI.Size = new System.Drawing.Size(134, 284);
            this.lstDNI.TabIndex = 2;
            // 
            // lstNombre
            // 
            this.lstNombre.FormattingEnabled = true;
            this.lstNombre.ItemHeight = 20;
            this.lstNombre.Location = new System.Drawing.Point(202, 63);
            this.lstNombre.Name = "lstNombre";
            this.lstNombre.Size = new System.Drawing.Size(134, 284);
            this.lstNombre.TabIndex = 3;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(129, 369);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(112, 31);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 425);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lstNombre);
            this.Controls.Add(this.lstDNI);
            this.Controls.Add(this.btnOrdenarNombre);
            this.Controls.Add(this.btnOrdenarDNI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FListadoUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de usuarios";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrdenarDNI;
        private System.Windows.Forms.Button btnOrdenarNombre;
        private System.Windows.Forms.ListBox lstDNI;
        private System.Windows.Forms.ListBox lstNombre;
        private System.Windows.Forms.Button btnCerrar;
    }
}
