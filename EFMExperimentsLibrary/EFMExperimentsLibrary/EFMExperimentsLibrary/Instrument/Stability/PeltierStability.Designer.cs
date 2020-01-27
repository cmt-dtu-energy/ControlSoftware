namespace EFMExperimentsLibrary
{
    partial class PeltierStability
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
            this.lblStability = new System.Windows.Forms.Label();
            this.lblStab = new System.Windows.Forms.Label();
            this.cmbSeries = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblStability
            // 
            this.lblStability.AutoSize = true;
            this.lblStability.Location = new System.Drawing.Point(55, 5);
            this.lblStability.Name = "lblStability";
            this.lblStability.Size = new System.Drawing.Size(52, 13);
            this.lblStability.TabIndex = 1;
            this.lblStability.Text = "0,000001";
            // 
            // lblStab
            // 
            this.lblStab.AutoSize = true;
            this.lblStab.Location = new System.Drawing.Point(3, 5);
            this.lblStab.Name = "lblStab";
            this.lblStab.Size = new System.Drawing.Size(46, 13);
            this.lblStab.TabIndex = 2;
            this.lblStab.Text = "Stability:";
            // 
            // cmbSeries
            // 
            this.cmbSeries.FormattingEnabled = true;
            this.cmbSeries.Location = new System.Drawing.Point(3, 21);
            this.cmbSeries.Name = "cmbSeries";
            this.cmbSeries.Size = new System.Drawing.Size(121, 21);
            this.cmbSeries.TabIndex = 4;
            this.cmbSeries.Text = "Channel";
            this.cmbSeries.SelectedIndexChanged += new System.EventHandler(this.cmbSeries_SelectedIndexChanged);
            // 
            // PeltierStability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmbSeries);
            this.Controls.Add(this.lblStab);
            this.Controls.Add(this.lblStability);
            this.Name = "PeltierStability";
            this.Size = new System.Drawing.Size(126, 51);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStability;
        private System.Windows.Forms.Label lblStab;
        private System.Windows.Forms.ComboBox cmbSeries;
    }
}
