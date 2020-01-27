namespace EFMExperimentsLibrary
{
    partial class OutputFileControl
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
            this.foldFilePath = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSampleName = new System.Windows.Forms.TextBox();
            this.lblSampleName = new System.Windows.Forms.Label();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // foldFilePath
            // 
            this.foldFilePath.HelpRequest += new System.EventHandler(this.foldFilePath_HelpRequest);
            // 
            // txtSampleName
            // 
            this.txtSampleName.Location = new System.Drawing.Point(107, 57);
            this.txtSampleName.Name = "txtSampleName";
            this.txtSampleName.Size = new System.Drawing.Size(254, 22);
            this.txtSampleName.TabIndex = 0;
            this.txtSampleName.TextChanged += new System.EventHandler(this.txtSampleName_TextChanged);
            this.txtSampleName.KeyPress += this.txtSampleName_KeyPress;
            // 
            // lblSampleName
            // 
            this.lblSampleName.AutoSize = true;
            this.lblSampleName.Location = new System.Drawing.Point(3, 57);
            this.lblSampleName.Name = "lblSampleName";
            this.lblSampleName.Size = new System.Drawing.Size(98, 17);
            this.lblSampleName.TabIndex = 1;
            this.lblSampleName.Text = "Sample name:";
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(6, 9);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(95, 17);
            this.lblFolder.TabIndex = 2;
            this.lblFolder.Text = "Output folder:";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(107, 9);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(254, 22);
            this.txtOutputFolder.TabIndex = 3;
            this.txtOutputFolder.TextChanged += new System.EventHandler(this.txtOutputFolder_TextChanged);
            // 
            // OutputFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.lblSampleName);
            this.Controls.Add(this.txtSampleName);
            this.Name = "OutputFileControl";
            this.Size = new System.Drawing.Size(376, 94);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.FolderBrowserDialog foldFilePath;
        private System.Windows.Forms.TextBox txtSampleName;
        private System.Windows.Forms.Label lblSampleName;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
    }
}
