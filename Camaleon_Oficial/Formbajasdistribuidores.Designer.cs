namespace Presentacion
{
    partial class Formbajasdistribuidores
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
            this.dvgbajadis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgbajadis)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgbajadis
            // 
            this.dvgbajadis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgbajadis.Location = new System.Drawing.Point(46, 72);
            this.dvgbajadis.Name = "dvgbajadis";
            this.dvgbajadis.RowTemplate.Height = 25;
            this.dvgbajadis.Size = new System.Drawing.Size(347, 150);
            this.dvgbajadis.TabIndex = 0;
            this.dvgbajadis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgbajadis_CellContentClick);
            // 
            // Formbajasdistribuidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dvgbajadis);
            this.Name = "Formbajasdistribuidores";
            this.Text = "Formbajasdistribuidores";
            ((System.ComponentModel.ISupportInitialize)(this.dvgbajadis)).EndInit();
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.Formbajasdistribuidores_Load);

        }

        #endregion

        private DataGridView dvgbajadis;
    }
}