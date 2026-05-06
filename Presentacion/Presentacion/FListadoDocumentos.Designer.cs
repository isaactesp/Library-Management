namespace Presentacion
{
    partial class FListadoDocumentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false).</param>
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridDocumento = new System.Windows.Forms.DataGridView();
            this.dataGridEjemplares = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjemplares)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridDocumento);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridEjemplares);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridDocumento
            // 
            this.dataGridDocumento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDocumento.Location = new System.Drawing.Point(0, 0);
            this.dataGridDocumento.Name = "dataGridDocumento";
            this.dataGridDocumento.ReadOnly = true;
            this.dataGridDocumento.RowHeadersWidth = 62;
            this.dataGridDocumento.RowTemplate.Height = 28;
            this.dataGridDocumento.Size = new System.Drawing.Size(800, 225);
            this.dataGridDocumento.TabIndex = 0;
            // 
            // dataGridEjemplares
            // 
            this.dataGridEjemplares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEjemplares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEjemplares.Location = new System.Drawing.Point(0, 0);
            this.dataGridEjemplares.Name = "dataGridEjemplares";
            this.dataGridEjemplares.RowHeadersWidth = 62;
            this.dataGridEjemplares.RowTemplate.Height = 28;
            this.dataGridEjemplares.Size = new System.Drawing.Size(800, 221);
            this.dataGridEjemplares.TabIndex = 1;
            // 
            // FListadoDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FListadoDocumentos";
            this.Text = "Catálogo de Documentos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjemplares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDocumento;
        private System.Windows.Forms.DataGridView dataGridEjemplares;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}