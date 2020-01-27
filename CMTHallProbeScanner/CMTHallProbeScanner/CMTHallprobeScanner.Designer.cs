namespace CMTHallProbeScanner
{
    partial class CMTHallprobeScanner
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
            this.outputFileControl1 = new EFMExperimentsLibrary.OutputFileControl();
            this.hallprobeControl1 = new EFMExperimentsLibrary.HallprobeControl();
            this.xyzStagev21 = new EFMExperimentsLibrary.XYZStagev2();
            this.SuspendLayout();
            // 
            // outputFileControl1
            // 
            this.outputFileControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputFileControl1.Location = new System.Drawing.Point(6, 567);
            this.outputFileControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outputFileControl1.Name = "outputFileControl1";
            this.outputFileControl1.Size = new System.Drawing.Size(282, 77);
            this.outputFileControl1.TabIndex = 2;
            // 
            // hallprobeControl1
            // 
            this.hallprobeControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hallprobeControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hallprobeControl1.Location = new System.Drawing.Point(311, 6);
            this.hallprobeControl1.Margin = new System.Windows.Forms.Padding(1);
            this.hallprobeControl1.Name = "hallprobeControl1";
            this.hallprobeControl1.Size = new System.Drawing.Size(739, 648);
            this.hallprobeControl1.TabIndex = 1;
            // 
            // xyzStagev21
            // 
            this.xyzStagev21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xyzStagev21.Location = new System.Drawing.Point(6, 6);
            this.xyzStagev21.Margin = new System.Windows.Forms.Padding(1);
            this.xyzStagev21.Name = "xyzStagev21";
            this.xyzStagev21.Size = new System.Drawing.Size(303, 558);
            this.xyzStagev21.TabIndex = 0;
            this.xyzStagev21.Load += new System.EventHandler(this.xyzStagev21_Load);
            // 
            // CMTHallprobeScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 684);
            this.Controls.Add(this.outputFileControl1);
            this.Controls.Add(this.hallprobeControl1);
            this.Controls.Add(this.xyzStagev21);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CMTHallprobeScanner";
            this.Text = "CMTHallprobeScanner";
            this.ResumeLayout(false);

        }

        #endregion

        private EFMExperimentsLibrary.XYZStagev2 xyzStagev21;
        private EFMExperimentsLibrary.HallprobeControl hallprobeControl1;
        private EFMExperimentsLibrary.OutputFileControl outputFileControl1;
    }
}