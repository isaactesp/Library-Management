namespace Presentacion
{
    partial class FListarEjemplares
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
            this.dataGridEjemplares = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjemplares)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridEjemplares
            // 
            this.dataGridEjemplares.AllowUserToDeleteRows = false;
            this.dataGridEjemplares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEjemplares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEjemplares.Location = new System.Drawing.Point(0, 0);
            this.dataGridEjemplares.Name = "dataGridEjemplares";
            this.dataGridEjemplares.ReadOnly = true;
            this.dataGridEjemplares.RowHeadersWidth = 62;
            this.dataGridEjemplares.Size = new System.Drawing.Size(800, 450);
            this.dataGridEjemplares.TabIndex = 0;
            // 
            // FListarEjemplares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridEjemplares);
            this.Name = "FListarEjemplares";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEjemplares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridEjemplares;
    }
}