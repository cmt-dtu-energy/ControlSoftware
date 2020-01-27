namespace EFMExperimentsLibrary
{
    partial class PIDControl
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
            this.nudSetTemperature = new System.Windows.Forms.NumericUpDown();
            this.nudAmpOut = new System.Windows.Forms.NumericUpDown();
            this.nudP = new System.Windows.Forms.NumericUpDown();
            this.nudI = new System.Windows.Forms.NumericUpDown();
            this.nudD = new System.Windows.Forms.NumericUpDown();
            this.lblSetT = new System.Windows.Forms.Label();
            this.lblAmpOut = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.nudCurrentTemperature = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentT = new System.Windows.Forms.Label();
            this.nudError = new System.Windows.Forms.NumericUpDown();
            this.lblError = new System.Windows.Forms.Label();
            this.cmbKeithleyPort = new System.Windows.Forms.ComboBox();
            this.cmbPSUPort = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.nudMaxVoltage = new System.Windows.Forms.NumericUpDown();
            this.lblMaxVoltage = new System.Windows.Forms.Label();
            this.lblMaxCurrent = new System.Windows.Forms.Label();
            this.nudMaxCurrent = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmpOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoltage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // nudSetTemperature
            // 
            this.nudSetTemperature.DecimalPlaces = 2;
            this.nudSetTemperature.Location = new System.Drawing.Point(70, 21);
            this.nudSetTemperature.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSetTemperature.Name = "nudSetTemperature";
            this.nudSetTemperature.Size = new System.Drawing.Size(93, 20);
            this.nudSetTemperature.TabIndex = 0;
            // 
            // nudAmpOut
            // 
            this.nudAmpOut.DecimalPlaces = 2;
            this.nudAmpOut.Enabled = false;
            this.nudAmpOut.Location = new System.Drawing.Point(70, 73);
            this.nudAmpOut.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAmpOut.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nudAmpOut.Name = "nudAmpOut";
            this.nudAmpOut.Size = new System.Drawing.Size(93, 20);
            this.nudAmpOut.TabIndex = 1;
            // 
            // nudP
            // 
            this.nudP.DecimalPlaces = 5;
            this.nudP.Location = new System.Drawing.Point(70, 99);
            this.nudP.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudP.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudP.Name = "nudP";
            this.nudP.Size = new System.Drawing.Size(93, 20);
            this.nudP.TabIndex = 2;
            this.nudP.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudI
            // 
            this.nudI.DecimalPlaces = 5;
            this.nudI.Location = new System.Drawing.Point(70, 125);
            this.nudI.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudI.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudI.Name = "nudI";
            this.nudI.Size = new System.Drawing.Size(93, 20);
            this.nudI.TabIndex = 3;
            // 
            // nudD
            // 
            this.nudD.DecimalPlaces = 5;
            this.nudD.Location = new System.Drawing.Point(70, 151);
            this.nudD.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudD.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudD.Name = "nudD";
            this.nudD.Size = new System.Drawing.Size(93, 20);
            this.nudD.TabIndex = 4;
            this.nudD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSetT
            // 
            this.lblSetT.AutoSize = true;
            this.lblSetT.Location = new System.Drawing.Point(2, 23);
            this.lblSetT.Name = "lblSetT";
            this.lblSetT.Size = new System.Drawing.Size(49, 13);
            this.lblSetT.TabIndex = 5;
            this.lblSetT.Text = "Set T (K)";
            // 
            // lblAmpOut
            // 
            this.lblAmpOut.AutoSize = true;
            this.lblAmpOut.Location = new System.Drawing.Point(5, 77);
            this.lblAmpOut.Name = "lblAmpOut";
            this.lblAmpOut.Size = new System.Drawing.Size(46, 13);
            this.lblAmpOut.TabIndex = 6;
            this.lblAmpOut.Text = "Amp out";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(6, 95);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(17, 13);
            this.lblP.TabIndex = 7;
            this.lblP.Text = "P:";
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(5, 123);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(13, 13);
            this.lblI.TabIndex = 8;
            this.lblI.Text = "I:";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(5, 149);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(18, 13);
            this.lblD.TabIndex = 9;
            this.lblD.Text = "D:";
            // 
            // nudCurrentTemperature
            // 
            this.nudCurrentTemperature.DecimalPlaces = 2;
            this.nudCurrentTemperature.Location = new System.Drawing.Point(70, 47);
            this.nudCurrentTemperature.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCurrentTemperature.Name = "nudCurrentTemperature";
            this.nudCurrentTemperature.Size = new System.Drawing.Size(93, 20);
            this.nudCurrentTemperature.TabIndex = 10;
            // 
            // lblCurrentT
            // 
            this.lblCurrentT.AutoSize = true;
            this.lblCurrentT.Location = new System.Drawing.Point(5, 49);
            this.lblCurrentT.Name = "lblCurrentT";
            this.lblCurrentT.Size = new System.Drawing.Size(33, 13);
            this.lblCurrentT.TabIndex = 11;
            this.lblCurrentT.Text = "T (K):";
            // 
            // nudError
            // 
            this.nudError.DecimalPlaces = 5;
            this.nudError.Enabled = false;
            this.nudError.Location = new System.Drawing.Point(70, 177);
            this.nudError.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudError.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nudError.Name = "nudError";
            this.nudError.Size = new System.Drawing.Size(93, 20);
            this.nudError.TabIndex = 12;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(5, 179);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(32, 13);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "Error:";
            // 
            // cmbKeithleyPort
            // 
            this.cmbKeithleyPort.FormattingEnabled = true;
            this.cmbKeithleyPort.Location = new System.Drawing.Point(70, 203);
            this.cmbKeithleyPort.Name = "cmbKeithleyPort";
            this.cmbKeithleyPort.Size = new System.Drawing.Size(93, 21);
            this.cmbKeithleyPort.TabIndex = 14;
            // 
            // cmbPSUPort
            // 
            this.cmbPSUPort.FormattingEnabled = true;
            this.cmbPSUPort.Location = new System.Drawing.Point(70, 230);
            this.cmbPSUPort.Name = "cmbPSUPort";
            this.cmbPSUPort.Size = new System.Drawing.Size(93, 21);
            this.cmbPSUPort.TabIndex = 15;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 13);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "PID Control";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(5, 207);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 17;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // nudMaxVoltage
            // 
            this.nudMaxVoltage.DecimalPlaces = 2;
            this.nudMaxVoltage.Location = new System.Drawing.Point(72, 258);
            this.nudMaxVoltage.Name = "nudMaxVoltage";
            this.nudMaxVoltage.Size = new System.Drawing.Size(90, 20);
            this.nudMaxVoltage.TabIndex = 18;
            this.nudMaxVoltage.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lblMaxVoltage
            // 
            this.lblMaxVoltage.AutoSize = true;
            this.lblMaxVoltage.Location = new System.Drawing.Point(-2, 260);
            this.lblMaxVoltage.Name = "lblMaxVoltage";
            this.lblMaxVoltage.Size = new System.Drawing.Size(68, 13);
            this.lblMaxVoltage.TabIndex = 19;
            this.lblMaxVoltage.Text = "Max. voltage";
            // 
            // lblMaxCurrent
            // 
            this.lblMaxCurrent.AutoSize = true;
            this.lblMaxCurrent.Location = new System.Drawing.Point(-2, 289);
            this.lblMaxCurrent.Name = "lblMaxCurrent";
            this.lblMaxCurrent.Size = new System.Drawing.Size(66, 13);
            this.lblMaxCurrent.TabIndex = 21;
            this.lblMaxCurrent.Text = "Max. current";
            // 
            // nudMaxCurrent
            // 
            this.nudMaxCurrent.DecimalPlaces = 2;
            this.nudMaxCurrent.Location = new System.Drawing.Point(72, 287);
            this.nudMaxCurrent.Name = "nudMaxCurrent";
            this.nudMaxCurrent.Size = new System.Drawing.Size(90, 20);
            this.nudMaxCurrent.TabIndex = 20;
            this.nudMaxCurrent.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // PIDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblMaxCurrent);
            this.Controls.Add(this.nudMaxCurrent);
            this.Controls.Add(this.lblMaxVoltage);
            this.Controls.Add(this.nudMaxVoltage);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbPSUPort);
            this.Controls.Add(this.cmbKeithleyPort);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.nudError);
            this.Controls.Add(this.lblCurrentT);
            this.Controls.Add(this.nudCurrentTemperature);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.lblI);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.lblAmpOut);
            this.Controls.Add(this.lblSetT);
            this.Controls.Add(this.nudD);
            this.Controls.Add(this.nudI);
            this.Controls.Add(this.nudP);
            this.Controls.Add(this.nudAmpOut);
            this.Controls.Add(this.nudSetTemperature);
            this.Name = "PIDControl";
            this.Size = new System.Drawing.Size(180, 311);
            this.Load += new System.EventHandler(this.PIDControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSetTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmpOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoltage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCurrent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudSetTemperature;
        private System.Windows.Forms.NumericUpDown nudAmpOut;
        private System.Windows.Forms.NumericUpDown nudP;
        private System.Windows.Forms.NumericUpDown nudI;
        private System.Windows.Forms.NumericUpDown nudD;
        private System.Windows.Forms.Label lblSetT;
        private System.Windows.Forms.Label lblAmpOut;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.NumericUpDown nudCurrentTemperature;
        private System.Windows.Forms.Label lblCurrentT;
        private System.Windows.Forms.NumericUpDown nudError;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ComboBox cmbKeithleyPort;
        private System.Windows.Forms.ComboBox cmbPSUPort;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.NumericUpDown nudMaxVoltage;
        private System.Windows.Forms.Label lblMaxVoltage;
        private System.Windows.Forms.Label lblMaxCurrent;
        private System.Windows.Forms.NumericUpDown nudMaxCurrent;
    }
}
