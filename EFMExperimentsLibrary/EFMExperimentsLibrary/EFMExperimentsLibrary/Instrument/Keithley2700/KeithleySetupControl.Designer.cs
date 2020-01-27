namespace EFMExperimentsLibrary
{
    partial class KeithleySetupControl
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
            this.lblPortNumber = new System.Windows.Forms.Label();
            this.lblMeasurementType = new System.Windows.Forms.Label();
            this.cmbMeasurementType = new System.Windows.Forms.ComboBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtDataoutName = new System.Windows.Forms.TextBox();
            this.lblDataName = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.cmbPortNumber = new System.Windows.Forms.ComboBox();
            this.cmdLoadSettings = new System.Windows.Forms.Button();
            this.cmdSaveSettings = new System.Windows.Forms.Button();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMaxRange = new System.Windows.Forms.NumericUpDown();
            this.lblMaxRange = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxRange)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPortNumber
            // 
            this.lblPortNumber.AutoSize = true;
            this.lblPortNumber.Location = new System.Drawing.Point(132, 23);
            this.lblPortNumber.Name = "lblPortNumber";
            this.lblPortNumber.Size = new System.Drawing.Size(56, 13);
            this.lblPortNumber.TabIndex = 1;
            this.lblPortNumber.Text = "Channel #";
            // 
            // lblMeasurementType
            // 
            this.lblMeasurementType.AutoSize = true;
            this.lblMeasurementType.Location = new System.Drawing.Point(194, 23);
            this.lblMeasurementType.Name = "lblMeasurementType";
            this.lblMeasurementType.Size = new System.Drawing.Size(94, 13);
            this.lblMeasurementType.TabIndex = 3;
            this.lblMeasurementType.Text = "Measurement type";
            // 
            // cmbMeasurementType
            // 
            this.cmbMeasurementType.FormattingEnabled = true;
            this.cmbMeasurementType.Location = new System.Drawing.Point(197, 38);
            this.cmbMeasurementType.Name = "cmbMeasurementType";
            this.cmbMeasurementType.Size = new System.Drawing.Size(100, 21);
            this.cmbMeasurementType.TabIndex = 4;
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(315, 37);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(84, 21);
            this.cmbUnit.TabIndex = 5;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(312, 23);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "Unit";
            // 
            // txtDataoutName
            // 
            this.txtDataoutName.Location = new System.Drawing.Point(414, 37);
            this.txtDataoutName.Name = "txtDataoutName";
            this.txtDataoutName.Size = new System.Drawing.Size(106, 20);
            this.txtDataoutName.TabIndex = 7;
            // 
            // lblDataName
            // 
            this.lblDataName.AutoSize = true;
            this.lblDataName.Location = new System.Drawing.Point(411, 22);
            this.lblDataName.Name = "lblDataName";
            this.lblDataName.Size = new System.Drawing.Size(55, 13);
            this.lblDataName.TabIndex = 8;
            this.lblDataName.Text = "Data label";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(461, 4);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 9;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // cmbPortNumber
            // 
            this.cmbPortNumber.FormattingEnabled = true;
            this.cmbPortNumber.Location = new System.Drawing.Point(135, 37);
            this.cmbPortNumber.Name = "cmbPortNumber";
            this.cmbPortNumber.Size = new System.Drawing.Size(45, 21);
            this.cmbPortNumber.TabIndex = 10;
            this.cmbPortNumber.SelectedIndexChanged += new System.EventHandler(this.cmbPortNumber_SelectedIndexChanged_1);
            // 
            // cmdLoadSettings
            // 
            this.cmdLoadSettings.Location = new System.Drawing.Point(284, 0);
            this.cmdLoadSettings.Name = "cmdLoadSettings";
            this.cmdLoadSettings.Size = new System.Drawing.Size(81, 23);
            this.cmdLoadSettings.TabIndex = 12;
            this.cmdLoadSettings.Text = "Load settings";
            this.cmdLoadSettings.UseVisualStyleBackColor = true;
            this.cmdLoadSettings.Click += new System.EventHandler(this.cmdLoadSettings_Click);
            // 
            // cmdSaveSettings
            // 
            this.cmdSaveSettings.Location = new System.Drawing.Point(371, 0);
            this.cmdSaveSettings.Name = "cmdSaveSettings";
            this.cmdSaveSettings.Size = new System.Drawing.Size(84, 23);
            this.cmdSaveSettings.TabIndex = 13;
            this.cmdSaveSettings.Text = "Save settings";
            this.cmdSaveSettings.UseVisualStyleBackColor = true;
            this.cmdSaveSettings.Click += new System.EventHandler(this.cmdSaveSettings_Click);
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Location = new System.Drawing.Point(-2, 37);
            this.cmbMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(123, 21);
            this.cmbMode.TabIndex = 14;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(-3, 22);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(88, 13);
            this.lblMode.TabIndex = 15;
            this.lblMode.Text = "Experiment mode";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-4, -5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "KE2700 Control and data output";
            // 
            // nudMaxRange
            // 
            this.nudMaxRange.DecimalPlaces = 3;
            this.nudMaxRange.Location = new System.Drawing.Point(526, 37);
            this.nudMaxRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxRange.Name = "nudMaxRange";
            this.nudMaxRange.Size = new System.Drawing.Size(105, 20);
            this.nudMaxRange.TabIndex = 18;
            this.nudMaxRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxRange.ValueChanged += new System.EventHandler(this.nudMaxRange_ValueChanged);
            // 
            // lblMaxRange
            // 
            this.lblMaxRange.AutoSize = true;
            this.lblMaxRange.Location = new System.Drawing.Point(523, 21);
            this.lblMaxRange.Name = "lblMaxRange";
            this.lblMaxRange.Size = new System.Drawing.Size(76, 13);
            this.lblMaxRange.TabIndex = 19;
            this.lblMaxRange.Text = "Max. range [V]";
            // 
            // KeithleySetupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMaxRange);
            this.Controls.Add(this.nudMaxRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSaveSettings);
            this.Controls.Add(this.cmdLoadSettings);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.cmbPortNumber);
            this.Controls.Add(this.cmbMeasurementType);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.txtDataoutName);
            this.Controls.Add(this.lblDataName);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblMeasurementType);
            this.Controls.Add(this.lblPortNumber);
            this.Name = "KeithleySetupControl";
            this.Size = new System.Drawing.Size(638, 61);
            this.Load += new System.EventHandler(this.KeithleySetupControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPortNumber;
        private System.Windows.Forms.Label lblMeasurementType;
        private System.Windows.Forms.ComboBox cmbMeasurementType;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtDataoutName;
        private System.Windows.Forms.Label lblDataName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.ComboBox cmbPortNumber;
        private System.Windows.Forms.Button cmdLoadSettings;
        private System.Windows.Forms.Button cmdSaveSettings;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMaxRange;
        private System.Windows.Forms.Label lblMaxRange;
    }
}
