namespace DSCInterface
{
    partial class IRInterface
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
            this.peltStab = new EFMExperimentsLibrary.PeltierStability();
            this.expFlow = new EFMExperimentsLibrary.ExperimentFlow();
            this.grphPeltier = new EFMExperimentsLibrary.GraphXYPlot();
            this.grphHallprobes = new EFMExperimentsLibrary.GraphXYPlot();
            this.outfile = new EFMExperimentsLibrary.OutputFileControl();
            this.grphTemp = new EFMExperimentsLibrary.GraphXYPlot();
            this.tempRampCtrl = new EFMExperimentsLibrary.TemperatureRampControl();
            this.psuInstek = new EFMExperimentsLibrary.PSUInterface();
            this.ke2700 = new EFMExperimentsLibrary.KE2700Control();
            this.pidCurrent = new EFMExperimentsLibrary.PIDControl();
            this.relayCurrent = new EFMExperimentsLibrary.USBRelayControl();
            this.magDrive = new EFMExperimentsLibrary.MagnetDriveControl();
            this.SuspendLayout();
            // 
            // dataFilter
            // 
            this.dataFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFilter.Location = new System.Drawing.Point(1388, 395);
            this.dataFilter.Name = "dataFilter";
            this.dataFilter.Size = new System.Drawing.Size(399, 128);
            this.dataFilter.TabIndex = 11;
            // 
            // peltStab
            // 
            this.peltStab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peltStab.Location = new System.Drawing.Point(722, 555);
            this.peltStab.Name = "peltStab";
            this.peltStab.Size = new System.Drawing.Size(129, 54);
            this.peltStab.TabIndex = 10;
            // 
            // expFlow
            // 
            this.expFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expFlow.Location = new System.Drawing.Point(1387, 2);
            this.expFlow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.expFlow.Name = "expFlow";
            this.expFlow.Size = new System.Drawing.Size(475, 388);
            this.expFlow.TabIndex = 9;
            // 
            // grphPeltier
            // 
            this.grphPeltier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grphPeltier.Location = new System.Drawing.Point(856, 297);
            this.grphPeltier.Margin = new System.Windows.Forms.Padding(2);
            this.grphPeltier.Name = "grphPeltier";
            this.grphPeltier.Size = new System.Drawing.Size(527, 291);
            this.grphPeltier.TabIndex = 8;
            // 
            // grphHallprobes
            // 
            this.grphHallprobes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grphHallprobes.Location = new System.Drawing.Point(856, 591);
            this.grphHallprobes.Margin = new System.Windows.Forms.Padding(2);
            this.grphHallprobes.Name = "grphHallprobes";
            this.grphHallprobes.Size = new System.Drawing.Size(527, 291);
            this.grphHallprobes.TabIndex = 7;
            // 
            // outfile
            // 
            this.outfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outfile.Location = new System.Drawing.Point(413, 842);
            this.outfile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outfile.Name = "outfile";
            this.outfile.Size = new System.Drawing.Size(282, 77);
            this.outfile.TabIndex = 6;
            // 
            // grphTemp
            // 
            this.grphTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grphTemp.Location = new System.Drawing.Point(856, 2);
            this.grphTemp.Margin = new System.Windows.Forms.Padding(2);
            this.grphTemp.Name = "grphTemp";
            this.grphTemp.Size = new System.Drawing.Size(527, 291);
            this.grphTemp.TabIndex = 5;
            // 
            // tempRampCtrl
            // 
            this.tempRampCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tempRampCtrl.Location = new System.Drawing.Point(670, 48);
            this.tempRampCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.tempRampCtrl.Name = "tempRampCtrl";
            this.tempRampCtrl.pid_Tset = null;
            this.tempRampCtrl.Size = new System.Drawing.Size(166, 181);
            this.tempRampCtrl.TabIndex = 4;
            // 
            // psuInstek
            // 
            this.psuInstek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.psuInstek.Location = new System.Drawing.Point(12, 573);
            this.psuInstek.Margin = new System.Windows.Forms.Padding(4);
            this.psuInstek.Name = "psuInstek";
            this.psuInstek.Size = new System.Drawing.Size(395, 318);
            this.psuInstek.TabIndex = 3;
            // 
            // ke2700
            // 
            this.ke2700.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ke2700.Location = new System.Drawing.Point(11, 2);
            this.ke2700.Margin = new System.Windows.Forms.Padding(2);
            this.ke2700.Name = "ke2700";
            this.ke2700.Size = new System.Drawing.Size(653, 566);
            this.ke2700.TabIndex = 2;
            this.ke2700.userFilename = "test_file";
            // 
            // pidCurrent
            // 
            this.pidCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pidCurrent.Location = new System.Drawing.Point(670, 237);
            this.pidCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.pidCurrent.Name = "pidCurrent";
            this.pidCurrent.Size = new System.Drawing.Size(180, 311);
            this.pidCurrent.TabIndex = 1;
            // 
            // relayCurrent
            // 
            this.relayCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.relayCurrent.Location = new System.Drawing.Point(670, 4);
            this.relayCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.relayCurrent.Name = "relayCurrent";
            this.relayCurrent.Size = new System.Drawing.Size(177, 36);
            this.relayCurrent.TabIndex = 0;
            // 
            // magDrive
            // 
            this.magDrive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.magDrive.Location = new System.Drawing.Point(414, 573);
            this.magDrive.Name = "magDrive";
            this.magDrive.Size = new System.Drawing.Size(261, 264);
            this.magDrive.TabIndex = 12;
            // 
            // DSCInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 919);
            this.Controls.Add(this.magDrive);
            this.Controls.Add(this.dataFilter);
            this.Controls.Add(this.peltStab);
            this.Controls.Add(this.expFlow);
            this.Controls.Add(this.grphPeltier);
            this.Controls.Add(this.grphHallprobes);
            this.Controls.Add(this.outfile);
            this.Controls.Add(this.grphTemp);
            this.Controls.Add(this.tempRampCtrl);
            this.Controls.Add(this.psuInstek);
            this.Controls.Add(this.ke2700);
            this.Controls.Add(this.pidCurrent);
            this.Controls.Add(this.relayCurrent);
            this.Name = "DSCInterface";
            this.Text = "DSC Interface";
            this.ResumeLayout(false);

        }

        #endregion

        private EFMExperimentsLibrary.USBRelayControl relayCurrent;
        private EFMExperimentsLibrary.PIDControl pidCurrent;
        private EFMExperimentsLibrary.KE2700Control ke2700;
        private EFMExperimentsLibrary.PSUInterface psuInstek;
        private EFMExperimentsLibrary.TemperatureRampControl tempRampCtrl;
        private EFMExperimentsLibrary.GraphXYPlot grphTemp;
        private EFMExperimentsLibrary.OutputFileControl outfile;
        private EFMExperimentsLibrary.GraphXYPlot grphHallprobes;
        private EFMExperimentsLibrary.GraphXYPlot grphPeltier;
        private EFMExperimentsLibrary.TemperatureWatch tempSafety;
        private EFMExperimentsLibrary.ExperimentFlow expFlow;
        private EFMExperimentsLibrary.PeltierStability peltStab;
        private EFMExperimentsLibrary.DataFilter dataFilter;
        private EFMExperimentsLibrary.MagnetDriveControl magDrive;
    }
}

