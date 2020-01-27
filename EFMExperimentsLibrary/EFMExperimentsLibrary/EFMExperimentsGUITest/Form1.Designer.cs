namespace EFMExperimentsGUITest
{
    partial class Form1
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
            this.magnetDriveControl1 = new EFMExperimentsLibrary.MagnetDriveControl();
            this.SuspendLayout();
            // 
            // magnetDriveControl1
            // 
            this.magnetDriveControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.magnetDriveControl1.Location = new System.Drawing.Point(168, 100);
            this.magnetDriveControl1.Name = "magnetDriveControl1";
            this.magnetDriveControl1.Size = new System.Drawing.Size(258, 217);
            this.magnetDriveControl1.TabIndex = 0;
            this.magnetDriveControl1.Load += new System.EventHandler(this.magnetDriveControl1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 619);
            this.Controls.Add(this.magnetDriveControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EFMExperimentsLibrary.MagnetDriveControl magnetDriveControl1;

    }
}

