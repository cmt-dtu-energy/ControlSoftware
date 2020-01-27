namespace EFMExperimentsLibrary
{
    partial class MagnetDriveControl
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
            this.cmdInitDrive = new System.Windows.Forms.Button();
            this.lblDriveStatus = new System.Windows.Forms.Label();
            this.txtComPort = new System.Windows.Forms.TextBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.nudBaudRate = new System.Windows.Forms.NumericUpDown();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.nudAxisID = new System.Windows.Forms.NumericUpDown();
            this.lblAxisID = new System.Windows.Forms.Label();
            this.nudCurrentPos = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentPos = new System.Windows.Forms.Label();
            this.lblSetPos = new System.Windows.Forms.Label();
            this.nudSetPos = new System.Windows.Forms.NumericUpDown();
            this.cmdCalibration = new System.Windows.Forms.Button();
            this.lblSetField = new System.Windows.Forms.Label();
            this.nudFieldValue = new System.Windows.Forms.NumericUpDown();
            this.cmdMoveToField = new System.Windows.Forms.Button();
            this.cmdMovePos = new System.Windows.Forms.Button();
            this.lblRampRate = new System.Windows.Forms.Label();
            this.nudRampRate = new System.Windows.Forms.NumericUpDown();
            this.txtSetupFile = new System.Windows.Forms.TextBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmbHallProbe1 = new System.Windows.Forms.ComboBox();
            this.cmbHallProbe2 = new System.Windows.Forms.ComboBox();
            this.nudHallProbe1 = new System.Windows.Forms.NumericUpDown();
            this.lblHP1 = new System.Windows.Forms.Label();
            this.lblHP2 = new System.Windows.Forms.Label();
            this.nudHallProbe2 = new System.Windows.Forms.NumericUpDown();
            this.nudCalibrationRes = new System.Windows.Forms.NumericUpDown();
            this.lblCalibrationRes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaudRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAxisID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRampRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHallProbe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHallProbe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibrationRes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdInitDrive
            // 
            this.cmdInitDrive.Location = new System.Drawing.Point(3, 16);
            this.cmdInitDrive.Name = "cmdInitDrive";
            this.cmdInitDrive.Size = new System.Drawing.Size(75, 23);
            this.cmdInitDrive.TabIndex = 0;
            this.cmdInitDrive.Text = "Init drive";
            this.cmdInitDrive.UseVisualStyleBackColor = true;
            this.cmdInitDrive.Click += new System.EventHandler(this.cmdInitDrive_Click);
            // 
            // lblDriveStatus
            // 
            this.lblDriveStatus.AutoSize = true;
            this.lblDriveStatus.Location = new System.Drawing.Point(3, 0);
            this.lblDriveStatus.Name = "lblDriveStatus";
            this.lblDriveStatus.Size = new System.Drawing.Size(81, 13);
            this.lblDriveStatus.TabIndex = 1;
            this.lblDriveStatus.Text = "Drive status: off";
            // 
            // txtComPort
            // 
            this.txtComPort.Location = new System.Drawing.Point(192, 3);
            this.txtComPort.Name = "txtComPort";
            this.txtComPort.Size = new System.Drawing.Size(56, 20);
            this.txtComPort.TabIndex = 2;
            this.txtComPort.Text = "COM5";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(103, 3);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(55, 13);
            this.lblComPort.TabIndex = 3;
            this.lblComPort.Text = "COM port:";
            // 
            // nudBaudRate
            // 
            this.nudBaudRate.Location = new System.Drawing.Point(192, 29);
            this.nudBaudRate.Maximum = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            this.nudBaudRate.Minimum = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            this.nudBaudRate.Name = "nudBaudRate";
            this.nudBaudRate.Size = new System.Drawing.Size(60, 20);
            this.nudBaudRate.TabIndex = 4;
            this.nudBaudRate.Value = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(103, 31);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(53, 13);
            this.lblBaudRate.TabIndex = 5;
            this.lblBaudRate.Text = "Baudrate:";
            // 
            // nudAxisID
            // 
            this.nudAxisID.Location = new System.Drawing.Point(192, 55);
            this.nudAxisID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudAxisID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAxisID.Name = "nudAxisID";
            this.nudAxisID.Size = new System.Drawing.Size(60, 20);
            this.nudAxisID.TabIndex = 6;
            this.nudAxisID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAxisID
            // 
            this.lblAxisID.AutoSize = true;
            this.lblAxisID.Location = new System.Drawing.Point(103, 57);
            this.lblAxisID.Name = "lblAxisID";
            this.lblAxisID.Size = new System.Drawing.Size(43, 13);
            this.lblAxisID.TabIndex = 7;
            this.lblAxisID.Text = "Axis ID:";
            // 
            // nudCurrentPos
            // 
            this.nudCurrentPos.DecimalPlaces = 3;
            this.nudCurrentPos.Location = new System.Drawing.Point(192, 81);
            this.nudCurrentPos.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCurrentPos.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudCurrentPos.Name = "nudCurrentPos";
            this.nudCurrentPos.ReadOnly = true;
            this.nudCurrentPos.Size = new System.Drawing.Size(60, 20);
            this.nudCurrentPos.TabIndex = 8;
            // 
            // lblCurrentPos
            // 
            this.lblCurrentPos.AutoSize = true;
            this.lblCurrentPos.Location = new System.Drawing.Point(103, 83);
            this.lblCurrentPos.Name = "lblCurrentPos";
            this.lblCurrentPos.Size = new System.Drawing.Size(88, 13);
            this.lblCurrentPos.TabIndex = 9;
            this.lblCurrentPos.Text = "Current pos(deg):";
            // 
            // lblSetPos
            // 
            this.lblSetPos.AutoSize = true;
            this.lblSetPos.Location = new System.Drawing.Point(103, 109);
            this.lblSetPos.Name = "lblSetPos";
            this.lblSetPos.Size = new System.Drawing.Size(73, 13);
            this.lblSetPos.TabIndex = 11;
            this.lblSetPos.Text = "Set pos (deg):";
            // 
            // nudSetPos
            // 
            this.nudSetPos.DecimalPlaces = 3;
            this.nudSetPos.Location = new System.Drawing.Point(192, 107);
            this.nudSetPos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSetPos.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudSetPos.Name = "nudSetPos";
            this.nudSetPos.Size = new System.Drawing.Size(60, 20);
            this.nudSetPos.TabIndex = 10;
            // 
            // cmdCalibration
            // 
            this.cmdCalibration.Location = new System.Drawing.Point(3, 45);
            this.cmdCalibration.Name = "cmdCalibration";
            this.cmdCalibration.Size = new System.Drawing.Size(75, 23);
            this.cmdCalibration.TabIndex = 12;
            this.cmdCalibration.Text = "Calibrate";
            this.cmdCalibration.UseVisualStyleBackColor = true;
            this.cmdCalibration.Click += new System.EventHandler(this.cmdCalibration_Click);
            // 
            // lblSetField
            // 
            this.lblSetField.AutoSize = true;
            this.lblSetField.Location = new System.Drawing.Point(103, 135);
            this.lblSetField.Name = "lblSetField";
            this.lblSetField.Size = new System.Drawing.Size(64, 13);
            this.lblSetField.TabIndex = 14;
            this.lblSetField.Text = "Set field (T):";
            // 
            // nudFieldValue
            // 
            this.nudFieldValue.DecimalPlaces = 3;
            this.nudFieldValue.Location = new System.Drawing.Point(192, 133);
            this.nudFieldValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFieldValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudFieldValue.Name = "nudFieldValue";
            this.nudFieldValue.Size = new System.Drawing.Size(60, 20);
            this.nudFieldValue.TabIndex = 13;
            // 
            // cmdMoveToField
            // 
            this.cmdMoveToField.Location = new System.Drawing.Point(6, 130);
            this.cmdMoveToField.Name = "cmdMoveToField";
            this.cmdMoveToField.Size = new System.Drawing.Size(88, 23);
            this.cmdMoveToField.TabIndex = 15;
            this.cmdMoveToField.Text = "Move to field";
            this.cmdMoveToField.UseVisualStyleBackColor = true;
            this.cmdMoveToField.Click += new System.EventHandler(this.cmdMoveToField_Click);
            // 
            // cmdMovePos
            // 
            this.cmdMovePos.Location = new System.Drawing.Point(6, 101);
            this.cmdMovePos.Name = "cmdMovePos";
            this.cmdMovePos.Size = new System.Drawing.Size(88, 23);
            this.cmdMovePos.TabIndex = 16;
            this.cmdMovePos.Text = "Move to pos";
            this.cmdMovePos.UseVisualStyleBackColor = true;
            this.cmdMovePos.Click += new System.EventHandler(this.cmdMovePos_Click);
            // 
            // lblRampRate
            // 
            this.lblRampRate.AutoSize = true;
            this.lblRampRate.Location = new System.Drawing.Point(103, 161);
            this.lblRampRate.Name = "lblRampRate";
            this.lblRampRate.Size = new System.Drawing.Size(85, 13);
            this.lblRampRate.TabIndex = 18;
            this.lblRampRate.Text = "Ramp rate (T/s):";
            // 
            // nudRampRate
            // 
            this.nudRampRate.DecimalPlaces = 4;
            this.nudRampRate.Location = new System.Drawing.Point(192, 159);
            this.nudRampRate.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRampRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudRampRate.Name = "nudRampRate";
            this.nudRampRate.Size = new System.Drawing.Size(60, 20);
            this.nudRampRate.TabIndex = 17;
            this.nudRampRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // txtSetupFile
            // 
            this.txtSetupFile.Location = new System.Drawing.Point(3, 185);
            this.txtSetupFile.Name = "txtSetupFile";
            this.txtSetupFile.Size = new System.Drawing.Size(249, 20);
            this.txtSetupFile.TabIndex = 19;
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(6, 159);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 20;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmbHallProbe1
            // 
            this.cmbHallProbe1.FormattingEnabled = true;
            this.cmbHallProbe1.Location = new System.Drawing.Point(3, 211);
            this.cmbHallProbe1.Name = "cmbHallProbe1";
            this.cmbHallProbe1.Size = new System.Drawing.Size(121, 21);
            this.cmbHallProbe1.TabIndex = 21;
            this.cmbHallProbe1.SelectedIndexChanged += new System.EventHandler(this.cmbHallProbe1_SelectedIndexChanged);
            // 
            // cmbHallProbe2
            // 
            this.cmbHallProbe2.FormattingEnabled = true;
            this.cmbHallProbe2.Location = new System.Drawing.Point(3, 238);
            this.cmbHallProbe2.Name = "cmbHallProbe2";
            this.cmbHallProbe2.Size = new System.Drawing.Size(121, 21);
            this.cmbHallProbe2.TabIndex = 22;
            // 
            // nudHallProbe1
            // 
            this.nudHallProbe1.DecimalPlaces = 5;
            this.nudHallProbe1.Location = new System.Drawing.Point(130, 211);
            this.nudHallProbe1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudHallProbe1.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudHallProbe1.Name = "nudHallProbe1";
            this.nudHallProbe1.ReadOnly = true;
            this.nudHallProbe1.Size = new System.Drawing.Size(83, 20);
            this.nudHallProbe1.TabIndex = 23;
            // 
            // lblHP1
            // 
            this.lblHP1.AutoSize = true;
            this.lblHP1.Location = new System.Drawing.Point(219, 214);
            this.lblHP1.Name = "lblHP1";
            this.lblHP1.Size = new System.Drawing.Size(14, 13);
            this.lblHP1.TabIndex = 24;
            this.lblHP1.Text = "T";
            // 
            // lblHP2
            // 
            this.lblHP2.AutoSize = true;
            this.lblHP2.Location = new System.Drawing.Point(219, 240);
            this.lblHP2.Name = "lblHP2";
            this.lblHP2.Size = new System.Drawing.Size(14, 13);
            this.lblHP2.TabIndex = 26;
            this.lblHP2.Text = "T";
            // 
            // nudHallProbe2
            // 
            this.nudHallProbe2.DecimalPlaces = 5;
            this.nudHallProbe2.Location = new System.Drawing.Point(130, 237);
            this.nudHallProbe2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudHallProbe2.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudHallProbe2.Name = "nudHallProbe2";
            this.nudHallProbe2.ReadOnly = true;
            this.nudHallProbe2.Size = new System.Drawing.Size(83, 20);
            this.nudHallProbe2.TabIndex = 25;
            // 
            // nudCalibrationRes
            // 
            this.nudCalibrationRes.DecimalPlaces = 3;
            this.nudCalibrationRes.Location = new System.Drawing.Point(6, 73);
            this.nudCalibrationRes.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCalibrationRes.Name = "nudCalibrationRes";
            this.nudCalibrationRes.Size = new System.Drawing.Size(52, 20);
            this.nudCalibrationRes.TabIndex = 27;
            this.nudCalibrationRes.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // lblCalibrationRes
            // 
            this.lblCalibrationRes.AutoSize = true;
            this.lblCalibrationRes.Location = new System.Drawing.Point(64, 75);
            this.lblCalibrationRes.Name = "lblCalibrationRes";
            this.lblCalibrationRes.Size = new System.Drawing.Size(38, 13);
            this.lblCalibrationRes.TabIndex = 28;
            this.lblCalibrationRes.Text = "deg/st";
            // 
            // MagnetDriveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblCalibrationRes);
            this.Controls.Add(this.nudCalibrationRes);
            this.Controls.Add(this.lblHP2);
            this.Controls.Add(this.nudHallProbe2);
            this.Controls.Add(this.lblHP1);
            this.Controls.Add(this.nudHallProbe1);
            this.Controls.Add(this.cmbHallProbe2);
            this.Controls.Add(this.cmbHallProbe1);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.txtSetupFile);
            this.Controls.Add(this.lblRampRate);
            this.Controls.Add(this.nudRampRate);
            this.Controls.Add(this.cmdMovePos);
            this.Controls.Add(this.cmdMoveToField);
            this.Controls.Add(this.lblSetField);
            this.Controls.Add(this.nudFieldValue);
            this.Controls.Add(this.cmdCalibration);
            this.Controls.Add(this.lblSetPos);
            this.Controls.Add(this.nudSetPos);
            this.Controls.Add(this.lblCurrentPos);
            this.Controls.Add(this.nudCurrentPos);
            this.Controls.Add(this.lblAxisID);
            this.Controls.Add(this.nudAxisID);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.nudBaudRate);
            this.Controls.Add(this.lblComPort);
            this.Controls.Add(this.txtComPort);
            this.Controls.Add(this.lblDriveStatus);
            this.Controls.Add(this.cmdInitDrive);
            this.Name = "MagnetDriveControl";
            this.Size = new System.Drawing.Size(261, 264);
            ((System.ComponentModel.ISupportInitialize)(this.nudBaudRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAxisID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRampRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHallProbe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHallProbe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibrationRes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdInitDrive;
        private System.Windows.Forms.Label lblDriveStatus;
        private System.Windows.Forms.TextBox txtComPort;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.NumericUpDown nudBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.NumericUpDown nudAxisID;
        private System.Windows.Forms.Label lblAxisID;
        private System.Windows.Forms.NumericUpDown nudCurrentPos;
        private System.Windows.Forms.Label lblCurrentPos;
        private System.Windows.Forms.Label lblSetPos;
        private System.Windows.Forms.NumericUpDown nudSetPos;
        private System.Windows.Forms.Button cmdCalibration;
        private System.Windows.Forms.Label lblSetField;
        private System.Windows.Forms.NumericUpDown nudFieldValue;
        private System.Windows.Forms.Button cmdMoveToField;
        private System.Windows.Forms.Button cmdMovePos;
        private System.Windows.Forms.Label lblRampRate;
        private System.Windows.Forms.NumericUpDown nudRampRate;
        private System.Windows.Forms.TextBox txtSetupFile;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.ComboBox cmbHallProbe1;
        private System.Windows.Forms.ComboBox cmbHallProbe2;
        private System.Windows.Forms.NumericUpDown nudHallProbe1;
        private System.Windows.Forms.Label lblHP1;
        private System.Windows.Forms.Label lblHP2;
        private System.Windows.Forms.NumericUpDown nudHallProbe2;
        private System.Windows.Forms.NumericUpDown nudCalibrationRes;
        private System.Windows.Forms.Label lblCalibrationRes;
    }
}
