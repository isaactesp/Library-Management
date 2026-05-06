namespace Presentacion
{
    partial class FDocumento
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
            this.txtISBN = new System.Windows.Forms.TextBox();
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
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbAnoPublicacion = new System.Windows.Forms.Label();
            this.txtAnoPublicacion = new System.Windows.Forms.TextBox();
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
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(256, 55);
            this.txtISBN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(112, 26);
            this.txtISBN.TabIndex = 4;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(256, 114);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(432, 26);
            this.txtTitulo.TabIndex = 5;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(256, 174);
            this.txtAutor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(432, 26);
            this.txtAutor.TabIndex = 6;
            // 
            // txtEditorial
            // 
            this.txtEditorial.Location = new System.Drawing.Point(256, 226);
            this.txtEditorial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEditorial.Name = "txtEditorial";
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
            this.gbxTipoDoc.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.txtFormato.Size = new System.Drawing.Size(112, 26);
            this.txtFormato.TabIndex = 3;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(154, 28);
            this.txtDuracion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDuracion.Name = "txtDuracion";
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
            this.lbDuracion.Click += new System.EventHandler(this.label1_Click);
            // 
            // rbAudioLibro
            // 
            this.rbAudioLibro.AutoSize = true;
            this.rbAudioLibro.Location = new System.Drawing.Point(39, 96);
            this.rbAudioLibro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbAudioLibro.Name = "rbAudioLibro";
            this.rbAudioLibro.Size = new System.Drawing.Size(110, 24);
            this.rbAudioLibro.TabIndex = 1;
            this.rbAudioLibro.TabStop = true;
            this.rbAudioLibro.Text = "AduioLibro";
            this.rbAudioLibro.UseVisualStyleBackColor = true;
            // 
            // rbLibro
            // 
            this.rbLibro.AutoSize = true;
            this.rbLibro.Location = new System.Drawing.Point(39, 50);
            this.rbLibro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbLibro.Name = "rbLibro";
            this.rbLibro.Size = new System.Drawing.Size(69, 24);
            this.rbLibro.TabIndex = 0;
            this.rbLibro.TabStop = true;
            this.rbLibro.Text = "Libro";
            this.rbLibro.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(302, 591);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(84, 29);
            this.btAceptar.TabIndex = 9;
            this.btAceptar.Text = "Dar Alta";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(443, 590);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(84, 29);
            this.btCancelar.TabIndex = 10;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
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
            this.txtAnoPublicacion.Size = new System.Drawing.Size(112, 26);
            this.txtAnoPublicacion.TabIndex = 12;
            // 
            // FDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.txtAnoPublicacion);
            this.Controls.Add(this.lbAnoPublicacion);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.gbxTipoDoc);
            this.Controls.Add(this.txtEditorial);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lbEditorial);
            this.Controls.Add(this.lbAutor);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbISBN);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FDocumento";
            this.Text = "FDocumento";
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
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.GroupBox gbxTipoDoc;
        private System.Windows.Forms.RadioButton rbAudioLibro;
        private System.Windows.Forms.RadioButton rbLibro;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lbAnoPublicacion;
        private System.Windows.Forms.TextBox txtAnoPublicacion;
        private System.Windows.Forms.Panel panelAudio;
        private System.Windows.Forms.Label lbFormato;
        private System.Windows.Forms.Label lbDuracion;
        private System.Windows.Forms.TextBox txtFormato;
        private System.Windows.Forms.TextBox txtDuracion;
    }
}