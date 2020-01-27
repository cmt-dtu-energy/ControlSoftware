namespace EFMExperimentsLibrary
{
    partial class GraphXYPlot
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
                //graphDat.WriteXml(settingsFile);
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
            this.chrtPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbSeries = new System.Windows.Forms.ComboBox();
            this.lblSeries = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.numYMax = new System.Windows.Forms.NumericUpDown();
            this.numYMin = new System.Windows.Forms.NumericUpDown();
            this.lblPlotName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYMin)).BeginInit();
            this.SuspendLayout();
            // 
            // chrtPlot
            // 
            this.chrtPlot.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chrtPlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtPlot.Legends.Add(legend1);
            this.chrtPlot.Location = new System.Drawing.Point(70, 5);
            this.chrtPlot.Margin = new System.Windows.Forms.Padding(2);
            this.chrtPlot.Name = "chrtPlot";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrtPlot.Series.Add(series1);
            this.chrtPlot.Size = new System.Drawing.Size(462, 257);
            this.chrtPlot.TabIndex = 0;
            this.chrtPlot.Text = "chart1";
            this.chrtPlot.Click += new System.EventHandler(this.chrtPlot_Click);
            // 
            // cmbSeries
            // 
            this.cmbSeries.FormattingEnabled = true;
            this.cmbSeries.Location = new System.Drawing.Point(46, 266);
            this.cmbSeries.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSeries.Name = "cmbSeries";
            this.cmbSeries.Size = new System.Drawing.Size(92, 21);
            this.cmbSeries.TabIndex = 1;
            // 
            // lblSeries
            // 
            this.lblSeries.AutoSize = true;
            this.lblSeries.Location = new System.Drawing.Point(2, 268);
            this.lblSeries.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(39, 13);
            this.lblSeries.TabIndex = 2;
            this.lblSeries.Text = "Series:";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(141, 268);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // numYMax
            // 
            this.numYMax.DecimalPlaces = 7;
            this.numYMax.Location = new System.Drawing.Point(4, 22);
            this.numYMax.Margin = new System.Windows.Forms.Padding(2);
            this.numYMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numYMax.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numYMax.Name = "numYMax";
            this.numYMax.Size = new System.Drawing.Size(91, 20);
            this.numYMax.TabIndex = 6;
            this.numYMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYMax.ValueChanged += new System.EventHandler(this.numYMax_ValueChanged);
            // 
            // numYMin
            // 
            this.numYMin.DecimalPlaces = 7;
            this.numYMin.Location = new System.Drawing.Point(4, 213);
            this.numYMin.Margin = new System.Windows.Forms.Padding(2);
            this.numYMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numYMin.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numYMin.Name = "numYMin";
            this.numYMin.Size = new System.Drawing.Size(91, 20);
            this.numYMin.TabIndex = 7;
            this.numYMin.ValueChanged += new System.EventHandler(this.nudMinY_ValueChanged);
            // 
            // lblPlotName
            // 
            this.lblPlotName.AutoSize = true;
            this.lblPlotName.Location = new System.Drawing.Point(7, 3);
            this.lblPlotName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlotName.Name = "lblPlotName";
            this.lblPlotName.Size = new System.Drawing.Size(25, 13);
            this.lblPlotName.TabIndex = 8;
            this.lblPlotName.Text = "Plot";
            // 
            // GraphXYPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPlotName);
            this.Controls.Add(this.numYMin);
            this.Controls.Add(this.numYMax);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblSeries);
            this.Controls.Add(this.cmbSeries);
            this.Controls.Add(this.chrtPlot);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphXYPlot";
            this.Size = new System.Drawing.Size(550, 292);
            ((System.ComponentModel.ISupportInitialize)(this.chrtPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPlot;
        private System.Windows.Forms.ComboBox cmbSeries;
        private System.Windows.Forms.Label lblSeries;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.NumericUpDown numYMax;
        private System.Windows.Forms.NumericUpDown numYMin;
        private System.Windows.Forms.Label lblPlotName;
    }
}
