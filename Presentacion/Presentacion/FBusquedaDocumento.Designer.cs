namespace Presentacion
{
    partial class FBusquedaDocumento
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
            this.lbISBN = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbAutor = new System.Windows.Forms.Label();
            this.lbEditorial = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            this.gbxTipoDoc = new System.Windows.Forms.GroupBox();
            this.panelAudio = new System.Windows.Forms.Panel();
            this.txtFormato = new System.Windows.Forms.TextBox();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.lbFormato = new System.Windows.Forms.Label();
            this.lbDuracion = new System.Windows.Forms.Label();
            this.rbAudioLibro = new System.Windows.Forms.RadioButton();
            this.rbLibro = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lbAnoPublicacion = new System.Windows.Forms.Label();
            this.txtAnoPublicacion = new System.Windows.Forms.TextBox();
            this.cbISBN = new System.Windows.Forms.ComboBox();
            this.btnListarEjemplares = new System.Windows.Forms.Button();
            this.gbxTipoDoc.SuspendLayout();
            this.panelAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbISBN
            // 
            this.lbISBN.AutoSize = true;
            this.lbISBN.Location = new System.Drawing.Point(78, 62);
            this.lbISBN.Name = "lbISBN";
            this.lbISBN.Size = new System.Drawing.Size(51, 20);
            this.lbISBN.TabIndex = 0;
            this.lbISBN.Text = "ISBN:";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Location = new System.Drawing.Point(78, 121);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(51, 20);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Titulo:";
            // 
            // lbAutor
            // 
            this.lbAutor.AutoSize = true;
            this.lbAutor.Location = new System.Drawing.Point(78, 182);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(52, 20);
            this.lbAutor.TabIndex = 2;
            this.lbAutor.Text = "Autor:";
            // 
            // lbEditorial
            // 
            this.lbEditorial.AutoSize = true;
            this.lbEditorial.Location = new System.Drawing.Point(78, 235);
            this.lbEditorial.Name = "lbEditorial";
            this.lbEditorial.Size = new System.Drawing.Size(70, 20);
            this.lbEditorial.TabIndex = 3;
            this.lbEditorial.Text = "Editorial:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(256, 114);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.ReadOnly = true;
            this.txtTitulo.Size = new System.Drawing.Size(432, 26);
            this.txtTitulo.TabIndex = 5;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(256, 174);
            this.txtAutor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.ReadOnly = true;
            this.txtAutor.Size = new System.Drawing.Size(432, 26);
            this.txtAutor.TabIndex = 6;
            // 
            // txtEditorial
            // 
            this.txtEditorial.Location = new System.Drawing.Point(256, 226);
            this.txtEditorial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.ReadOnly = true;
            this.txtEditorial.Size = new System.Drawing.Size(432, 26);
            this.txtEditorial.TabIndex = 7;
            // 
            // gbxTipoDoc
            // 
            this.gbxTipoDoc.Controls.Add(this.panelAudio);
            this.gbxTipoDoc.Controls.Add(this.rbAudioLibro);
            this.gbxTipoDoc.Controls.Add(this.rbLibro);
            this.gbxTipoDoc.Location = new System.Drawing.Point(80, 362);
            this.gbxTipoDoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxTipoDoc.Name = "gbxTipoDoc";
            this.gbxTipoDoc.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxTipoDoc.Size = new System.Drawing.Size(608, 174);
            this.gbxTipoDoc.TabIndex = 8;
            this.gbxTipoDoc.TabStop = false;
            this.gbxTipoDoc.Text = "Tipo de documento:";
            // 
            // panelAudio
            // 
            this.panelAudio.Controls.Add(this.txtFormato);
            this.panelAudio.Controls.Add(this.txtDuracion);
            this.panelAudio.Controls.Add(this.lbFormato);
            this.panelAudio.Controls.Add(this.lbDuracion);
            this.panelAudio.Location = new System.Drawing.Point(296, 28);
            this.panelAudio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAudio.Name = "panelAudio";
            this.panelAudio.Size = new System.Drawing.Size(284, 118);
            this.panelAudio.TabIndex = 2;
            // 
            // txtFormato
            // 
            this.txtFormato.Location = new System.Drawing.Point(154, 74);
            this.txtFormato.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFormato.Name = "txtFormato";
            this.txtFormato.ReadOnly = true;
            this.txtFormato.Size = new System.Drawing.Size(112, 26);
            this.txtFormato.TabIndex = 3;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(154, 28);
            this.txtDuracion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.ReadOnly = true;
            this.txtDuracion.Size = new System.Drawing.Size(112, 26);
            this.txtDuracion.TabIndex = 2;
            // 
            // lbFormato
            // 
            this.lbFormato.AutoSize = true;
            this.lbFormato.Location = new System.Drawing.Point(15, 71);
            this.lbFormato.Name = "lbFormato";
            this.lbFormato.Size = new System.Drawing.Size(73, 20);
            this.lbFormato.TabIndex = 1;
            this.lbFormato.Text = "Formato:";
            // 
            // lbDuracion
            // 
            this.lbDuracion.AutoSize = true;
            this.lbDuracion.Location = new System.Drawing.Point(15, 31);
            this.lbDuracion.Name = "lbDuracion";
            this.lbDuracion.Size = new System.Drawing.Size(116, 20);
            this.lbDuracion.TabIndex = 0;
            this.lbDuracion.Text = "Duracion (min):";
            // 
            // rbAudioLibro
            // 
            this.rbAudioLibro.AutoSize = true;
            this.rbAudioLibro.Enabled = false;
            this.rbAudioLibro.Location = new System.Drawing.Point(39, 96);
            this.rbAudioLibro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbAudioLibro.Name = "rbAudioLibro";
            this.rbAudioLibro.Size = new System.Drawing.Size(110, 24);
            this.rbAudioLibro.TabIndex = 1;
            this.rbAudioLibro.TabStop = true;
            this.rbAudioLibro.Text = "AudioLibro";
            this.rbAudioLibro.UseVisualStyleBackColor = true;
            // 
            // rbLibro
            // 
            this.rbLibro.AutoSize = true;
            this.rbLibro.Enabled = false;
            this.rbLibro.Location = new System.Drawing.Point(39, 50);
            this.rbLibro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbLibro.Name = "rbLibro";
            this.rbLibro.Size = new System.Drawing.Size(69, 24);
            this.rbLibro.TabIndex = 0;
            this.rbLibro.TabStop = true;
            this.rbLibro.Text = "Libro";
            this.rbLibro.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(198, 591);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(84, 29);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(505, 590);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(84, 29);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lbAnoPublicacion
            // 
            this.lbAnoPublicacion.AutoSize = true;
            this.lbAnoPublicacion.Location = new System.Drawing.Point(78, 291);
            this.lbAnoPublicacion.Name = "lbAnoPublicacion";
            this.lbAnoPublicacion.Size = new System.Drawing.Size(126, 20);
            this.lbAnoPublicacion.TabIndex = 11;
            this.lbAnoPublicacion.Text = "Ano Publicacion:";
            // 
            // txtAnoPublicacion
            // 
            this.txtAnoPublicacion.Location = new System.Drawing.Point(256, 284);
            this.txtAnoPublicacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnoPublicacion.Name = "txtAnoPublicacion";
            this.txtAnoPublicacion.ReadOnly = true;
            this.txtAnoPublicacion.Size = new System.Drawing.Size(112, 26);
            this.txtAnoPublicacion.TabIndex = 12;
            // 
            // cbISBN
            // 
            this.cbISBN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbISBN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbISBN.FormattingEnabled = true;
            this.cbISBN.Location = new System.Drawing.Point(256, 55);
            this.cbISBN.Name = "cbISBN";
            this.cbISBN.Size = new System.Drawing.Size(432, 28);
            this.cbISBN.TabIndex = 13;
            this.cbISBN.SelectionChangeCommitted += new System.EventHandler(this.cbISBN_SelectionChangeCommitted);
            // 
            // btnListarEjemplares
            // 
            this.btnListarEjemplares.Location = new System.Drawing.Point(326, 591);
            this.btnListarEjemplares.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnListarEjemplares.Name = "btnListarEjemplares";
            this.btnListarEjemplares.Size = new System.Drawing.Size(140, 29);
            this.btnListarEjemplares.TabIndex = 14;
            this.btnListarEjemplares.Text = "Listar Ejemplares";
            this.btnListarEjemplares.UseVisualStyleBackColor = true;
            // 
            // FBusquedaDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.btnListarEjemplares);
            this.Controls.Add(this.cbISBN);
            this.Controls.Add(this.txtAnoPublicacion);
            this.Controls.Add(this.lbAnoPublicacion);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gbxTipoDoc);
            this.Controls.Add(this.txtEditorial);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lbEditorial);
            this.Controls.Add(this.lbAutor);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbISBN);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FBusquedaDocumento";
            this.Text = "Búsqueda de Documento";
            this.gbxTipoDoc.ResumeLayout(false);
            this.gbxTipoDoc.PerformLayout();
            this.panelAudio.ResumeLayout(false);
            this.panelAudio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbISBN;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbAutor;
        private System.Windows.Forms.Label lbEditorial;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.GroupBox gbxTipoDoc;
        private System.Windows.Forms.RadioButton rbAudioLibro;
        private System.Windows.Forms.RadioButton rbLibro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lbAnoPublicacion;
        private System.Windows.Forms.TextBox txtAnoPublicacion;
        private System.Windows.Forms.Panel panelAudio;
        private System.Windows.Forms.Label lbFormato;
        private System.Windows.Forms.Label lbDuracion;
        private System.Windows.Forms.TextBox txtFormato;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.ComboBox cbISBN;
        private System.Windows.Forms.Button btnListarEjemplares;
    }
}