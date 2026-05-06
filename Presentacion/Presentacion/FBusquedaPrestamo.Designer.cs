namespace Presentacion
{
    partial class FBusquedaPrestamo
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
            this.gbEjemplares = new System.Windows.Forms.GroupBox();
            this.lstEjemplares = new System.Windows.Forms.ListBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.cbIdPrestamo = new System.Windows.Forms.ComboBox();
            this.gbEjemplares.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEjemplares
            // 
            this.gbEjemplares.Controls.Add(this.lstEjemplares);
            this.gbEjemplares.Location = new System.Drawing.Point(282, 68);
            this.gbEjemplares.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEjemplares.Name = "gbEjemplares";
            this.gbEjemplares.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEjemplares.Size = new System.Drawing.Size(512, 314);
            this.gbEjemplares.TabIndex = 16;
            this.gbEjemplares.TabStop = false;
            this.gbEjemplares.Text = "Ejemplares prestados";
            // 
            // lstEjemplares
            // 
            this.lstEjemplares.FormattingEnabled = true;
            this.lstEjemplares.ItemHeight = 20;
            this.lstEjemplares.Location = new System.Drawing.Point(9, 29);
            this.lstEjemplares.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstEjemplares.Name = "lstEjemplares";
            this.lstEjemplares.Size = new System.Drawing.Size(492, 264);
            this.lstEjemplares.TabIndex = 0;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(7, 231);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(72, 20);
            this.lblUsuario.TabIndex = 14;
            this.lblUsuario.Text = "Usuario: ";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(99, 156);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(148, 26);
            this.txtFecha.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(49, 109);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(30, 20);
            this.lblId.TabIndex = 11;
            this.lblId.Text = "ID:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(99, 225);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(148, 26);
            this.txtUsuario.TabIndex = 17;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(99, 275);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(148, 26);
            this.txtEstado.TabIndex = 19;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(7, 281);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(68, 20);
            this.lblEstado.TabIndex = 18;
            this.lblEstado.Text = "Estado: ";
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(114, 358);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(93, 34);
            this.btBuscar.TabIndex = 20;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // cbIdPrestamo
            // 
            this.cbIdPrestamo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbIdPrestamo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbIdPrestamo.FormattingEnabled = true;
            this.cbIdPrestamo.Location = new System.Drawing.Point(99, 109);
            this.cbIdPrestamo.Name = "cbIdPrestamo";
            this.cbIdPrestamo.Size = new System.Drawing.Size(148, 28);
            this.cbIdPrestamo.TabIndex = 21;
            this.cbIdPrestamo.SelectionChangeCommitted += new System.EventHandler(this.cbIdPrestamo_SelectionChangeCommitted);
            this.cbIdPrestamo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbIdPrestamo_KeyDown);
            // 
            // FBusquedaPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 450);
            this.Controls.Add(this.cbIdPrestamo);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.gbEjemplares);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblId);
            this.Name = "FBusquedaPrestamo";
            this.Text = "Form1";
            this.gbEjemplares.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEjemplares;
        private System.Windows.Forms.ListBox lstEjemplares;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.ComboBox cbIdPrestamo;
    }
}