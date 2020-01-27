namespace EFMExperimentsLibrary
{
    partial class TemperatureProfiles
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCoeffA = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCoeffB = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCoeffC = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.lstProfiles = new System.Windows.Forms.ListBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.chrtTemperatureProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoeffA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoeffB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoeffC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTemperatureProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProfile
            // 
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(56, 16);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(184, 21);
            this.cmbProfile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Profile:";
            // 
            // nudCoeffA
            // 
            this.nudCoeffA.DecimalPlaces = 5;
            this.nudCoeffA.Location = new System.Drawing.Point(56, 43);
            this.nudCoeffA.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCoeffA.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudCoeffA.Name = "nudCoeffA";
            this.nudCoeffA.Size = new System.Drawing.Size(120, 20);
            this.nudCoeffA.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "A:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "B:";
            // 
            // nudCoeffB
            // 
            this.nudCoeffB.DecimalPlaces = 5;
            this.nudCoeffB.Location = new System.Drawing.Point(56, 69);
            this.nudCoeffB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCoeffB.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudCoeffB.Name = "nudCoeffB";
            this.nudCoeffB.Size = new System.Drawing.Size(120, 20);
            this.nudCoeffB.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "C:";
            // 
            // nudCoeffC
            // 
            this.nudCoeffC.DecimalPlaces = 5;
            this.nudCoeffC.Location = new System.Drawing.Point(56, 95);
            this.nudCoeffC.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCoeffC.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudCoeffC.Name = "nudCoeffC";
            this.nudCoeffC.Size = new System.Drawing.Size(120, 20);
            this.nudCoeffC.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Time:";
            // 
            // nudTime
            // 
            this.nudTime.DecimalPlaces = 5;
            this.nudTime.Location = new System.Drawing.Point(56, 121);
            this.nudTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTime.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(120, 20);
            this.nudTime.TabIndex = 9;
            // 
            // lstProfiles
            // 
            this.lstProfiles.FormattingEnabled = true;
            this.lstProfiles.HorizontalScrollbar = true;
            this.lstProfiles.Location = new System.Drawing.Point(56, 147);
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(263, 173);
            this.lstProfiles.TabIndex = 11;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(56, 326);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 12;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdUp
            // 
            this.cmdUp.Location = new System.Drawing.Point(6, 183);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(44, 23);
            this.cmdUp.TabIndex = 13;
            this.cmdUp.Text = "Up";
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // cmdDown
            // 
            this.cmdDown.Location = new System.Drawing.Point(6, 212);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(44, 23);
            this.cmdDown.TabIndex = 14;
            this.cmdDown.Text = "Down";
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(137, 326);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 15;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(244, 326);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 16;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(244, 355);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 17;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // chrtTemperatureProfile
            // 
            this.chrtTemperatureProfile.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.Title = "Time [s]";
            chartArea1.AxisY.Title = "Temperature [K]";
            chartArea1.Name = "ChartArea1";
            this.chrtTemperatureProfile.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtTemperatureProfile.Legends.Add(legend1);
            this.chrtTemperatureProfile.Location = new System.Drawing.Point(325, 3);
            this.chrtTemperatureProfile.Name = "chrtTemperatureProfile";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Prof.";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Curr";
            this.chrtTemperatureProfile.Series.Add(series1);
            this.chrtTemperatureProfile.Series.Add(series2);
            this.chrtTemperatureProfile.Size = new System.Drawing.Size(351, 300);
            this.chrtTemperatureProfile.TabIndex = 18;
            this.chrtTemperatureProfile.Text = "Temperature profile";
            this.chrtTemperatureProfile.Click += new System.EventHandler(this.chrtTemperatureProfile_Click);
            // 
            // TemperatureProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chrtTemperatureProfile);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lstProfiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudCoeffC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudCoeffB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudCoeffA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProfile);
            this.Name = "TemperatureProfiles";
            this.Size = new System.Drawing.Size(681, 384);
            this.Tag = "";
            ((System.ComponentModel.ISupportInitialize)(this.nudCoeffA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoeffB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoeffC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTemperatureProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCoeffA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCoeffB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCoeffC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudTime;
        private System.Windows.Forms.ListBox lstProfiles;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtTemperatureProfile;
    }
}
