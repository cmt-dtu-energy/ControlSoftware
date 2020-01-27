namespace HallProbeGUI
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
            this.dataFilter = new EFMExperimentsLibrary.DataFilter();
            this.grphHallProbe = new EFMExperimentsLibrary.GraphXYPlot();
            this.outFile = new EFMExperimentsLibrary.OutputFileControl();
            this.ke2700 = new EFMExperimentsLibrary.KE2700Control();
            this.hallXYZ1 = new EFMExperimentsLibrary.HallXYZ();
            this.SuspendLayout();
            // 
            // dataFilter
            // 
            this.dataFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFilter.Location = new System.Drawing.Point(889, 713);
            this.dataFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataFilter.Name = "dataFilter";
            this.dataFilter.Size = new System.Drawing.Size(533, 160);
            this.dataFilter.TabIndex = 4;
            // 
            // grphHallProbe
            // 
            this.grphHallProbe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grphHallProbe.Location = new System.Drawing.Point(12, 514);
            this.grphHallProbe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grphHallProbe.Name = "grphHallProbe";
            this.grphHallProbe.Size = new System.Drawing.Size(733, 359);
            this.grphHallProbe.TabIndex = 3;
            // 
            // outFile
            // 
            this.outFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outFile.Location = new System.Drawing.Point(12, 415);
            this.outFile.Name = "outFile";
            this.outFile.Size = new System.Drawing.Size(376, 94);
            this.outFile.TabIndex = 2;
            // 
            // ke2700
            // 
            this.ke2700.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ke2700.Location = new System.Drawing.Point(889, 11);
            this.ke2700.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ke2700.Name = "ke2700";
            this.ke2700.Size = new System.Drawing.Size(873, 696);
            this.ke2700.TabIndex = 1;
            this.ke2700.userFilename = "test_file";
            // 
            // hallXYZ1
            // 
            this.hallXYZ1.Location = new System.Drawing.Point(12, 11);
            this.hallXYZ1.Margin = new System.Windows.Forms.Padding(4);
            this.hallXYZ1.Name = "hallXYZ1";
            this.hallXYZ1.Size = new System.Drawing.Size(699, 362);
            this.hallXYZ1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 876);
            this.Controls.Add(this.hallXYZ1);
            this.Controls.Add(this.dataFilter);
            this.Controls.Add(this.grphHallProbe);
            this.Controls.Add(this.outFile);
            this.Controls.Add(this.ke2700);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private EFMExperimentsLibrary.KE2700Control ke2700;
        private EFMExperimentsLibrary.OutputFileControl outFile;
        private EFMExperimentsLibrary.GraphXYPlot grphHallProbe;
        private EFMExperimentsLibrary.DataFilter dataFilter;
        private EFMExperimentsLibrary.HallXYZ hallXYZ1;
    }
}

