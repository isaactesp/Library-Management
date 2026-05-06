namespace Presentacion
{
    partial class FLogin
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
            this.Nombre = new System.Windows.Forms.Label();
            this.Contraseña = new System.Windows.Forms.Label();
            this.txtBxNombre = new System.Windows.Forms.TextBox();
            this.txtBxContraseña = new System.Windows.Forms.TextBox();
            this.gBTipoEmpleado = new System.Windows.Forms.GroupBox();
            this.rbPAdq = new System.Windows.Forms.RadioButton();
            this.rbPSala = new System.Windows.Forms.RadioButton();
            this.btEntrar = new System.Windows.Forms.Button();
            this.gBTipoEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(47, 76);
            this.Nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(47, 13);
            this.Nombre.TabIndex = 0;
            this.Nombre.Text = "Nombre:";
            // 
            // Contraseña
            // 
            this.Contraseña.AutoSize = true;
            this.Contraseña.Location = new System.Drawing.Point(50, 105);
            this.Contraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(64, 13);
            this.Contraseña.TabIndex = 1;
            this.Contraseña.Text = "Contraseña:";
            // 
            // txtBxNombre
            // 
            this.txtBxNombre.Location = new System.Drawing.Point(184, 70);
            this.txtBxNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBxNombre.Name = "txtBxNombre";
            this.txtBxNombre.Size = new System.Drawing.Size(76, 20);
            this.txtBxNombre.TabIndex = 2;
            // 
            // txtBxContraseña
            // 
            this.txtBxContraseña.Location = new System.Drawing.Point(184, 105);
            this.txtBxContraseña.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBxContraseña.Name = "txtBxContraseña";
            this.txtBxContraseña.Size = new System.Drawing.Size(76, 20);
            this.txtBxContraseña.TabIndex = 3;
            // 
            // gBTipoEmpleado
            // 
            this.gBTipoEmpleado.Controls.Add(this.rbPAdq);
            this.gBTipoEmpleado.Controls.Add(this.rbPSala);
            this.gBTipoEmpleado.Location = new System.Drawing.Point(58, 174);
            this.gBTipoEmpleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBTipoEmpleado.Name = "gBTipoEmpleado";
            this.gBTipoEmpleado.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBTipoEmpleado.Size = new System.Drawing.Size(184, 88);
            this.gBTipoEmpleado.TabIndex = 4;
            this.gBTipoEmpleado.TabStop = false;
            this.gBTipoEmpleado.Text = "Tipo Empleado";
            // 
            // rbPAdq
            // 
            this.rbPAdq.AutoSize = true;
            this.rbPAdq.Location = new System.Drawing.Point(26, 60);
            this.rbPAdq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbPAdq.Name = "rbPAdq";
            this.rbPAdq.Size = new System.Drawing.Size(134, 17);
            this.rbPAdq.TabIndex = 1;
            this.rbPAdq.TabStop = true;
            this.rbPAdq.Text = "Personal Adquisiciones";
            this.rbPAdq.UseVisualStyleBackColor = true;
            // 
            // rbPSala
            // 
            this.rbPSala.AutoSize = true;
            this.rbPSala.Location = new System.Drawing.Point(26, 26);
            this.rbPSala.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbPSala.Name = "rbPSala";
            this.rbPSala.Size = new System.Drawing.Size(90, 17);
            this.rbPSala.TabIndex = 0;
            this.rbPSala.TabStop = true;
            this.rbPSala.Text = "Personal Sala";
            this.rbPSala.UseVisualStyleBackColor = true;
            // 
            // btEntrar
            // 
            this.btEntrar.Location = new System.Drawing.Point(202, 324);
            this.btEntrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(56, 19);
            this.btEntrar.TabIndex = 5;
            this.btEntrar.Text = "Entrar";
            this.btEntrar.UseVisualStyleBackColor = true;
            this.btEntrar.Click += new System.EventHandler(this.btEntrar_Click);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 529);
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.gBTipoEmpleado);
            this.Controls.Add(this.txtBxContraseña);
            this.Controls.Add(this.txtBxNombre);
            this.Controls.Add(this.Contraseña);
            this.Controls.Add(this.Nombre);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FLogin";
            this.Text = "Loguearse";
            this.gBTipoEmpleado.ResumeLayout(false);
            this.gBTipoEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label Contraseña;
        private System.Windows.Forms.TextBox txtBxNombre;
        private System.Windows.Forms.TextBox txtBxContraseña;
        private System.Windows.Forms.GroupBox gBTipoEmpleado;
        private System.Windows.Forms.RadioButton rbPAdq;
        private System.Windows.Forms.RadioButton rbPSala;
        private System.Windows.Forms.Button btEntrar;
    }
}