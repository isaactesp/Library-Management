namespace Presentacion
{
    partial class FConsultaUsuarioPrestamos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDNI = new System.Windows.Forms.Label();
            this.comboDNI = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.btnListarEjemplares = new System.Windows.Forms.Button();
            this.btnListarVencidos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(12, 25);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(29, 13);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI:";
            // 
            // comboDNI
            // 
            this.comboDNI.FormattingEnabled = true;
            this.comboDNI.Location = new System.Drawing.Point(47, 22);
            this.comboDNI.Name = "comboDNI";
            this.comboDNI.Size = new System.Drawing.Size(225, 21);
            this.comboDNI.TabIndex = 1;
            this.comboDNI.SelectedIndexChanged += new System.EventHandler(this.comboDNI_SelectedIndexChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(65, 60);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblNombreUsuario.TabIndex = 3;
            // 
            // btnListarEjemplares
            // 
            this.btnListarEjemplares.Enabled = false;
            this.btnListarEjemplares.Location = new System.Drawing.Point(15, 100);
            this.btnListarEjemplares.Name = "btnListarEjemplares";
            this.btnListarEjemplares.Size = new System.Drawing.Size(120, 23);
            this.btnListarEjemplares.TabIndex = 4;
            this.btnListarEjemplares.Text = "Listar Ejemplares";
            this.btnListarEjemplares.UseVisualStyleBackColor = true;
            this.btnListarEjemplares.Click += new System.EventHandler(this.btnListarEjemplares_Click);
            // 
            // btnListarVencidos
            // 
            this.btnListarVencidos.Enabled = false;
            this.btnListarVencidos.Location = new System.Drawing.Point(152, 100);
            this.btnListarVencidos.Name = "btnListarVencidos";
            this.btnListarVencidos.Size = new System.Drawing.Size(120, 23);
            this.btnListarVencidos.TabIndex = 5;
            this.btnListarVencidos.Text = "Listar Vencidos";
            this.btnListarVencidos.UseVisualStyleBackColor = true;
            this.btnListarVencidos.Click += new System.EventHandler(this.btnListarVencidos_Click);
            // 
            // FConsultaUsuarioPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.btnListarVencidos);
            this.Controls.Add(this.btnListarEjemplares);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.comboDNI);
            this.Controls.Add(this.lblDNI);
            this.Name = "FConsultaUsuarioPrestamos";
            this.Text = "Consultar Préstamos de Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.ComboBox comboDNI;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnListarEjemplares;
        private System.Windows.Forms.Button btnListarVencidos;
    }
}
