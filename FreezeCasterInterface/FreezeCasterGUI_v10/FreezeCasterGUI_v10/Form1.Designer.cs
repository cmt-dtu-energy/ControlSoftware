namespace FreezeCasterGUI_v10
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
            this.temperatureProf = new EFMExperimentsLibrary.TemperatureProfiles();
            this.outputFile = new EFMExperimentsLibrary.OutputFileControl();
            this.psuCP400 = new EFMExperimentsLibrary.PSUInterface();
            this.grphTemp = new EFMExperimentsLibrary.GraphXYPlot();
            this.tempRampCtrl = new EFMExperimentsLibrary.TemperatureRampControl();
            this.relayCurrent = new EFMExperimentsLibrary.USBRelayControl();
            this.pidCurrent = new EFMExperimentsLibrary.PIDControl();
            this.ke2700 = new EFMExperimentsLibrary.KE2700Control();
            this.SuspendLayout();
            // 
            // temperatureProf
            // 
            this.temperatureProf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.temperatureProf.Location = new System.Drawing.Point(323, 624);
            this.temperatureProf.Name = "temperatureProf";
            this.temperatureProf.pid_Tset = null;
            this.temperatureProf.Size = new System.Drawing.Size(691, 384);
            this.temperatureProf.TabIndex = 10;
            this.temperatureProf.Tag = "";
            // 
            // outputFile
            // 
            this.outputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputFile.Location = new System.Drawing.Point(9, 578);
            this.outputFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outputFile.Name = "outputFile";
            this.outputFile.Size = new System.Drawing.Size(282, 77);
            this.outputFile.TabIndex = 9;
            // 
            // psuCP400
            // 
            this.psuCP400.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.psuCP400.Location = new System.Drawing.Point(848, 9);
            this.psuCP400.Margin = new System.Windows.Forms.Padding(4);
            this.psuCP400.Name = "psuCP400";
            this.psuCP400.Size = new System.Drawing.Size(395, 315);
            this.psuCP400.TabIndex = 6;
            // 
            // grphTemp
            // 
            this.grphTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grphTemp.Location = new System.Drawing.Point(843, 327);
            this.grphTemp.Margin = new System.Windows.Forms.Padding(2);
            this.grphTemp.Name = "grphTemp";
            this.grphTemp.Size = new System.Drawing.Size(550, 292);
            this.grphTemp.TabIndex = 5;
            // 
            // tempRampCtrl
            // 
            this.tempRampCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tempRampCtrl.Location = new System.Drawing.Point(662, 371);
            this.tempRampCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.tempRampCtrl.Name = "tempRampCtrl";
            this.tempRampCtrl.pid_Tset = null;
            this.tempRampCtrl.Size = new System.Drawing.Size(169, 179);
            this.tempRampCtrl.TabIndex = 4;
            // 
            // relayCurrent
            // 
            this.relayCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.relayCurrent.Location = new System.Drawing.Point(662, 327);
            this.relayCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.relayCurrent.Name = "relayCurrent";
            this.relayCurrent.Size = new System.Drawing.Size(176, 36);
            this.relayCurrent.TabIndex = 3;
            // 
            // pidCurrent
            // 
            this.pidCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pidCurrent.Location = new System.Drawing.Point(662, 9);
            this.pidCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.pidCurrent.Name = "pidCurrent";
            this.pidCurrent.Size = new System.Drawing.Size(180, 311);
            this.pidCurrent.TabIndex = 2;
            // 
            // ke2700
            // 
            this.ke2700.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ke2700.Location = new System.Drawing.Point(9, 9);
            this.ke2700.Margin = new System.Windows.Forms.Padding(2);
            this.ke2700.Name = "ke2700";
            this.ke2700.Size = new System.Drawing.Size(647, 566);
            this.ke2700.TabIndex = 1;
            this.ke2700.userFilename = "test_file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1641, 1009);
            this.Controls.Add(this.temperatureProf);
            this.Controls.Add(this.outputFile);
            this.Controls.Add(this.psuCP400);
            this.Controls.Add(this.grphTemp);
            this.Controls.Add(this.tempRampCtrl);
            this.Controls.Add(this.relayCurrent);
            this.Controls.Add(this.pidCurrent);
            this.Controls.Add(this.ke2700);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private EFMExperimentsLibrary.KE2700Control ke2700;
        private EFMExperimentsLibrary.PIDControl pidCurrent;
        private EFMExperimentsLibrary.USBRelayControl relayCurrent;
        private EFMExperimentsLibrary.TemperatureRampControl tempRampCtrl;
        private EFMExperimentsLibrary.GraphXYPlot grphTemp;
        private EFMExperimentsLibrary.PSUInterface psuCP400;
        private EFMExperimentsLibrary.OutputFileControl outputFile;
        private EFMExperimentsLibrary.TemperatureProfiles temperatureProf;
    }
}

