namespace EFMExperimentsLibrary
{
    public partial class HallprobeControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBx = new System.Windows.Forms.TextBox();
            this.txtBy = new System.Windows.Forms.TextBox();
            this.txtBz = new System.Windows.Forms.TextBox();
            this.txtBnorm = new System.Windows.Forms.TextBox();
            this.txtT = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtTPM = new System.Windows.Forms.TextBox();
            this.txtBnormPM = new System.Windows.Forms.TextBox();
            this.txtBzPM = new System.Windows.Forms.TextBox();
            this.txtByPM = new System.Windows.Forms.TextBox();
            this.txtBxPM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMHMFileFolder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudNMea = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nudCurrentMeasurement = new System.Windows.Forms.NumericUpDown();
            this.graphXYPlot1 = new EFMExperimentsLibrary.GraphXYPlot();
            this.nudMaxPlotPts = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNMea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentMeasurement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPlotPts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bx (T):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "By (T):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bz (T):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bnorm (T):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Temperature (C)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Time (ms):";
            // 
            // txtBx
            // 
            this.txtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBx.Location = new System.Drawing.Point(117, 4);
            this.txtBx.Margin = new System.Windows.Forms.Padding(4);
            this.txtBx.Name = "txtBx";
            this.txtBx.ReadOnly = true;
            this.txtBx.Size = new System.Drawing.Size(132, 22);
            this.txtBx.TabIndex = 7;
            // 
            // txtBy
            // 
            this.txtBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBy.Location = new System.Drawing.Point(117, 34);
            this.txtBy.Margin = new System.Windows.Forms.Padding(4);
            this.txtBy.Name = "txtBy";
            this.txtBy.ReadOnly = true;
            this.txtBy.Size = new System.Drawing.Size(132, 22);
            this.txtBy.TabIndex = 8;
            // 
            // txtBz
            // 
            this.txtBz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBz.Location = new System.Drawing.Point(117, 64);
            this.txtBz.Margin = new System.Windows.Forms.Padding(4);
            this.txtBz.Name = "txtBz";
            this.txtBz.ReadOnly = true;
            this.txtBz.Size = new System.Drawing.Size(132, 22);
            this.txtBz.TabIndex = 9;
            // 
            // txtBnorm
            // 
            this.txtBnorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBnorm.Location = new System.Drawing.Point(117, 94);
            this.txtBnorm.Margin = new System.Windows.Forms.Padding(4);
            this.txtBnorm.Name = "txtBnorm";
            this.txtBnorm.ReadOnly = true;
            this.txtBnorm.Size = new System.Drawing.Size(132, 22);
            this.txtBnorm.TabIndex = 10;
            // 
            // txtT
            // 
            this.txtT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtT.Location = new System.Drawing.Point(117, 124);
            this.txtT.Margin = new System.Windows.Forms.Padding(4);
            this.txtT.Name = "txtT";
            this.txtT.ReadOnly = true;
            this.txtT.Size = new System.Drawing.Size(132, 22);
            this.txtT.TabIndex = 11;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(117, 154);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(132, 22);
            this.txtTime.TabIndex = 12;
            // 
            // txtTPM
            // 
            this.txtTPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTPM.Location = new System.Drawing.Point(286, 124);
            this.txtTPM.Margin = new System.Windows.Forms.Padding(4);
            this.txtTPM.Name = "txtTPM";
            this.txtTPM.ReadOnly = true;
            this.txtTPM.Size = new System.Drawing.Size(132, 22);
            this.txtTPM.TabIndex = 17;
            // 
            // txtBnormPM
            // 
            this.txtBnormPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBnormPM.Location = new System.Drawing.Point(286, 94);
            this.txtBnormPM.Margin = new System.Windows.Forms.Padding(4);
            this.txtBnormPM.Name = "txtBnormPM";
            this.txtBnormPM.ReadOnly = true;
            this.txtBnormPM.Size = new System.Drawing.Size(132, 22);
            this.txtBnormPM.TabIndex = 16;
            // 
            // txtBzPM
            // 
            this.txtBzPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBzPM.Location = new System.Drawing.Point(286, 64);
            this.txtBzPM.Margin = new System.Windows.Forms.Padding(4);
            this.txtBzPM.Name = "txtBzPM";
            this.txtBzPM.ReadOnly = true;
            this.txtBzPM.Size = new System.Drawing.Size(132, 22);
            this.txtBzPM.TabIndex = 15;
            // 
            // txtByPM
            // 
            this.txtByPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByPM.Location = new System.Drawing.Point(286, 34);
            this.txtByPM.Margin = new System.Windows.Forms.Padding(4);
            this.txtByPM.Name = "txtByPM";
            this.txtByPM.ReadOnly = true;
            this.txtByPM.Size = new System.Drawing.Size(132, 22);
            this.txtByPM.TabIndex = 14;
            // 
            // txtBxPM
            // 
            this.txtBxPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxPM.Location = new System.Drawing.Point(286, 4);
            this.txtBxPM.Margin = new System.Windows.Forms.Padding(4);
            this.txtBxPM.Name = "txtBxPM";
            this.txtBxPM.ReadOnly = true;
            this.txtBxPM.Size = new System.Drawing.Size(132, 22);
            this.txtBxPM.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "+/-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "+/-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "+/-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(256, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "+/-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(256, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "+/-";
            // 
            // txtMHMFileFolder
            // 
            this.txtMHMFileFolder.Location = new System.Drawing.Point(117, 183);
            this.txtMHMFileFolder.Name = "txtMHMFileFolder";
            this.txtMHMFileFolder.Size = new System.Drawing.Size(301, 22);
            this.txtMHMFileFolder.TabIndex = 24;
            this.txtMHMFileFolder.Text = "c:/users/kaki/";
            this.txtMHMFileFolder.TextChanged += new System.EventHandler(this.txtMHMFileFolder_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "MHM file folder";
            // 
            // nudNMea
            // 
            this.nudNMea.Location = new System.Drawing.Point(148, 220);
            this.nudNMea.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNMea.Name = "nudNMea";
            this.nudNMea.Size = new System.Drawing.Size(83, 22);
            this.nudNMea.TabIndex = 26;
            this.nudNMea.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "No. of measurements:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(237, 222);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Current measurement:";
            // 
            // nudCurrentMeasurement
            // 
            this.nudCurrentMeasurement.Location = new System.Drawing.Point(381, 220);
            this.nudCurrentMeasurement.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCurrentMeasurement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCurrentMeasurement.Name = "nudCurrentMeasurement";
            this.nudCurrentMeasurement.ReadOnly = true;
            this.nudCurrentMeasurement.Size = new System.Drawing.Size(62, 22);
            this.nudCurrentMeasurement.TabIndex = 29;
            this.nudCurrentMeasurement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // graphXYPlot1
            // 
            this.graphXYPlot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphXYPlot1.Location = new System.Drawing.Point(7, 247);
            this.graphXYPlot1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphXYPlot1.Name = "graphXYPlot1";
            this.graphXYPlot1.Size = new System.Drawing.Size(715, 374);
            this.graphXYPlot1.TabIndex = 30;
            // 
            // nudMaxPlotPts
            // 
            this.nudMaxPlotPts.Location = new System.Drawing.Point(576, 221);
            this.nudMaxPlotPts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPlotPts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxPlotPts.Name = "nudMaxPlotPts";
            this.nudMaxPlotPts.Size = new System.Drawing.Size(120, 22);
            this.nudMaxPlotPts.TabIndex = 31;
            this.nudMaxPlotPts.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMaxPlotPts.ValueChanged += new System.EventHandler(this.nudMaxPlotPts_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(449, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 16);
            this.label15.TabIndex = 32;
            this.label15.Text = "Max. no. plot points";
            // 
            // HallprobeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nudMaxPlotPts);
            this.Controls.Add(this.graphXYPlot1);
            this.Controls.Add(this.nudCurrentMeasurement);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nudNMea);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMHMFileFolder);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTPM);
            this.Controls.Add(this.txtBnormPM);
            this.Controls.Add(this.txtBzPM);
            this.Controls.Add(this.txtByPM);
            this.Controls.Add(this.txtBxPM);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtT);
            this.Controls.Add(this.txtBnorm);
            this.Controls.Add(this.txtBz);
            this.Controls.Add(this.txtBy);
            this.Controls.Add(this.txtBx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HallprobeControl";
            this.Size = new System.Drawing.Size(750, 642);
            ((System.ComponentModel.ISupportInitialize)(this.nudNMea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentMeasurement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPlotPts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBx;
        private System.Windows.Forms.TextBox txtBy;
        private System.Windows.Forms.TextBox txtBz;
        private System.Windows.Forms.TextBox txtBnorm;
        private System.Windows.Forms.TextBox txtT;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtTPM;
        private System.Windows.Forms.TextBox txtBnormPM;
        private System.Windows.Forms.TextBox txtBzPM;
        private System.Windows.Forms.TextBox txtByPM;
        private System.Windows.Forms.TextBox txtBxPM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMHMFileFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudNMea;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudCurrentMeasurement;
        private GraphXYPlot graphXYPlot1;
        private System.Windows.Forms.NumericUpDown nudMaxPlotPts;
        private System.Windows.Forms.Label label15;
    }
}
