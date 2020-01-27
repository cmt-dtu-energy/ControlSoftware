namespace GUITest
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
            this.xyzControl1 = new EFMExperimentsLibrary.XYZControl();
            this.SuspendLayout();
            // 
            // xyzControl1
            // 
            this.xyzControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xyzControl1.experimentCallback = null;
            this.xyzControl1.k2230Readings = null;
            this.xyzControl1.Location = new System.Drawing.Point(33, 21);
            this.xyzControl1.Name = "xyzControl1";
            this.xyzControl1.Size = new System.Drawing.Size(480, 536);
            this.xyzControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 580);
            this.Controls.Add(this.xyzControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private EFMExperimentsLibrary.XYZControl xyzControl1;
    }
}

