namespace EFMExperimentsLibrary
{
    partial class PicoTc08Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.datGrdPico = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datGrdPico)).BeginInit();
            this.SuspendLayout();
            // 
            // datGrdPico
            // 
            this.datGrdPico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGrdPico.Location = new System.Drawing.Point(3, 78);
            this.datGrdPico.Name = "datGrdPico";
            this.datGrdPico.Size = new System.Drawing.Size(1068, 103);
            this.datGrdPico.TabIndex = 0;
            // 
            // PicoTc08Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.datGrdPico);
            this.Name = "PicoTc08Control";
            this.Size = new System.Drawing.Size(1074, 282);
            this.Load += new System.EventHandler(this.PicoTc08Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datGrdPico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datGrdPico;

    }
}
