namespace EFMExperimentsLibrary
{
    partial class PSUInterface
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
            this.cmdInitialize = new System.Windows.Forms.Button();
            this.cmdCloseUnit = new System.Windows.Forms.Button();
            this.lblInstrumentState = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.grpBoxChannel1 = new System.Windows.Forms.GroupBox();
            this.cmdChannel1SetValues = new System.Windows.Forms.Button();
            this.lblChannel1CurrentSet = new System.Windows.Forms.Label();
            this.lblChannel1VoltageSet = new System.Windows.Forms.Label();
            this.txtChannel1CurrentSet = new System.Windows.Forms.TextBox();
            this.txtChannel1VoltageSet = new System.Windows.Forms.TextBox();
            this.lblChannel1Get = new System.Windows.Forms.Label();
            this.chkChannel1Enable = new System.Windows.Forms.CheckBox();
            this.lblChannel1Current = new System.Windows.Forms.Label();
            this.lblChannel1Voltage = new System.Windows.Forms.Label();
            this.txtChannel1CurrentGet = new System.Windows.Forms.TextBox();
            this.txtChannel1VoltageGet = new System.Windows.Forms.TextBox();
            this.keithleyPSULogger = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdChannel2SetValues = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChannel2CurrentSet = new System.Windows.Forms.TextBox();
            this.txtChannel2VoltageSet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkChannel2Enable = new System.Windows.Forms.CheckBox();
            this.lblChannel2CurrentGet = new System.Windows.Forms.Label();
            this.lblChannel2VoltageGet = new System.Windows.Forms.Label();
            this.txtChannel2CurrentGet = new System.Windows.Forms.TextBox();
            this.txtChannel2VoltageGet = new System.Windows.Forms.TextBox();
            this.lblTItle = new System.Windows.Forms.Label();
            this.cmbPSUMode = new System.Windows.Forms.ComboBox();
            this.grpBoxChannel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdInitialize
            // 
            this.cmdInitialize.Location = new System.Drawing.Point(13, 49);
            this.cmdInitialize.Name = "cmdInitialize";
            this.cmdInitialize.Size = new System.Drawing.Size(188, 25);
            this.cmdInitialize.TabIndex = 2;
            this.cmdInitialize.Text = "Initialize PSU";
            this.cmdInitialize.UseVisualStyleBackColor = true;
            this.cmdInitialize.Click += new System.EventHandler(this.cmdInitialize_Click);
            // 
            // cmdCloseUnit
            // 
            this.cmdCloseUnit.Location = new System.Drawing.Point(240, 49);
            this.cmdCloseUnit.Name = "cmdCloseUnit";
            this.cmdCloseUnit.Size = new System.Drawing.Size(145, 21);
            this.cmdCloseUnit.TabIndex = 6;
            this.cmdCloseUnit.Text = "Close unit";
            this.cmdCloseUnit.UseVisualStyleBackColor = true;
            this.cmdCloseUnit.Click += new System.EventHandler(this.cmdCloseUnit_Click);
            // 
            // lblInstrumentState
            // 
            this.lblInstrumentState.AutoSize = true;
            this.lblInstrumentState.Location = new System.Drawing.Point(178, 30);
            this.lblInstrumentState.Name = "lblInstrumentState";
            this.lblInstrumentState.Size = new System.Drawing.Size(77, 13);
            this.lblInstrumentState.TabIndex = 7;
            this.lblInstrumentState.Text = "State: disabled";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Location = new System.Drawing.Point(178, 10);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(45, 13);
            this.lblErrorMessage.TabIndex = 8;
            this.lblErrorMessage.Text = "No error";
            // 
            // grpBoxChannel1
            // 
            this.grpBoxChannel1.Controls.Add(this.cmdChannel1SetValues);
            this.grpBoxChannel1.Controls.Add(this.lblChannel1CurrentSet);
            this.grpBoxChannel1.Controls.Add(this.lblChannel1VoltageSet);
            this.grpBoxChannel1.Controls.Add(this.txtChannel1CurrentSet);
            this.grpBoxChannel1.Controls.Add(this.txtChannel1VoltageSet);
            this.grpBoxChannel1.Controls.Add(this.lblChannel1Get);
            this.grpBoxChannel1.Controls.Add(this.chkChannel1Enable);
            this.grpBoxChannel1.Controls.Add(this.lblChannel1Current);
            this.grpBoxChannel1.Controls.Add(this.lblChannel1Voltage);
            this.grpBoxChannel1.Controls.Add(this.txtChannel1CurrentGet);
            this.grpBoxChannel1.Controls.Add(this.txtChannel1VoltageGet);
            this.grpBoxChannel1.Location = new System.Drawing.Point(13, 80);
            this.grpBoxChannel1.Name = "grpBoxChannel1";
            this.grpBoxChannel1.Size = new System.Drawing.Size(188, 230);
            this.grpBoxChannel1.TabIndex = 15;
            this.grpBoxChannel1.TabStop = false;
            this.grpBoxChannel1.Text = "Channel 1";
            // 
            // cmdChannel1SetValues
            // 
            this.cmdChannel1SetValues.Location = new System.Drawing.Point(66, 200);
            this.cmdChannel1SetValues.Name = "cmdChannel1SetValues";
            this.cmdChannel1SetValues.Size = new System.Drawing.Size(98, 30);
            this.cmdChannel1SetValues.TabIndex = 10;
            this.cmdChannel1SetValues.Text = "Set values";
            this.cmdChannel1SetValues.UseVisualStyleBackColor = true;
            this.cmdChannel1SetValues.Click += new System.EventHandler(this.cmdChannel1SetValues_Click);
            // 
            // lblChannel1CurrentSet
            // 
            this.lblChannel1CurrentSet.AutoSize = true;
            this.lblChannel1CurrentSet.Location = new System.Drawing.Point(10, 170);
            this.lblChannel1CurrentSet.Name = "lblChannel1CurrentSet";
            this.lblChannel1CurrentSet.Size = new System.Drawing.Size(41, 13);
            this.lblChannel1CurrentSet.TabIndex = 9;
            this.lblChannel1CurrentSet.Text = "Current";
            // 
            // lblChannel1VoltageSet
            // 
            this.lblChannel1VoltageSet.AutoSize = true;
            this.lblChannel1VoltageSet.Location = new System.Drawing.Point(10, 131);
            this.lblChannel1VoltageSet.Name = "lblChannel1VoltageSet";
            this.lblChannel1VoltageSet.Size = new System.Drawing.Size(43, 13);
            this.lblChannel1VoltageSet.TabIndex = 8;
            this.lblChannel1VoltageSet.Text = "Voltage";
            // 
            // txtChannel1CurrentSet
            // 
            this.txtChannel1CurrentSet.Location = new System.Drawing.Point(66, 167);
            this.txtChannel1CurrentSet.Name = "txtChannel1CurrentSet";
            this.txtChannel1CurrentSet.Size = new System.Drawing.Size(102, 20);
            this.txtChannel1CurrentSet.TabIndex = 7;
            this.txtChannel1CurrentSet.Text = "1";
            this.txtChannel1CurrentSet.TextChanged += new System.EventHandler(this.txtChannel1CurrentSet_TextChanged);
            // 
            // txtChannel1VoltageSet
            // 
            this.txtChannel1VoltageSet.Location = new System.Drawing.Point(67, 128);
            this.txtChannel1VoltageSet.Name = "txtChannel1VoltageSet";
            this.txtChannel1VoltageSet.Size = new System.Drawing.Size(102, 20);
            this.txtChannel1VoltageSet.TabIndex = 6;
            this.txtChannel1VoltageSet.Text = "10";
            this.txtChannel1VoltageSet.TextChanged += new System.EventHandler(this.txtChannel1VoltageSet_TextChanged);
            // 
            // lblChannel1Get
            // 
            this.lblChannel1Get.AutoSize = true;
            this.lblChannel1Get.Location = new System.Drawing.Point(9, 16);
            this.lblChannel1Get.Name = "lblChannel1Get";
            this.lblChannel1Get.Size = new System.Drawing.Size(24, 13);
            this.lblChannel1Get.TabIndex = 5;
            this.lblChannel1Get.Text = "Get";
            // 
            // chkChannel1Enable
            // 
            this.chkChannel1Enable.AutoSize = true;
            this.chkChannel1Enable.Location = new System.Drawing.Point(66, 98);
            this.chkChannel1Enable.Name = "chkChannel1Enable";
            this.chkChannel1Enable.Size = new System.Drawing.Size(65, 17);
            this.chkChannel1Enable.TabIndex = 4;
            this.chkChannel1Enable.Text = "Enabled";
            this.chkChannel1Enable.UseVisualStyleBackColor = true;
            this.chkChannel1Enable.CheckedChanged += new System.EventHandler(this.chkChannel1Enable_CheckedChanged);
            // 
            // lblChannel1Current
            // 
            this.lblChannel1Current.AutoSize = true;
            this.lblChannel1Current.Location = new System.Drawing.Point(9, 66);
            this.lblChannel1Current.Name = "lblChannel1Current";
            this.lblChannel1Current.Size = new System.Drawing.Size(41, 13);
            this.lblChannel1Current.TabIndex = 3;
            this.lblChannel1Current.Text = "Current";
            // 
            // lblChannel1Voltage
            // 
            this.lblChannel1Voltage.AutoSize = true;
            this.lblChannel1Voltage.Location = new System.Drawing.Point(9, 32);
            this.lblChannel1Voltage.Name = "lblChannel1Voltage";
            this.lblChannel1Voltage.Size = new System.Drawing.Size(43, 13);
            this.lblChannel1Voltage.TabIndex = 2;
            this.lblChannel1Voltage.Text = "Voltage";
            // 
            // txtChannel1CurrentGet
            // 
            this.txtChannel1CurrentGet.Location = new System.Drawing.Point(66, 63);
            this.txtChannel1CurrentGet.Name = "txtChannel1CurrentGet";
            this.txtChannel1CurrentGet.ReadOnly = true;
            this.txtChannel1CurrentGet.Size = new System.Drawing.Size(106, 20);
            this.txtChannel1CurrentGet.TabIndex = 1;
            this.txtChannel1CurrentGet.TextChanged += new System.EventHandler(this.txtChannel1CurrentGet_TextChanged);
            // 
            // txtChannel1VoltageGet
            // 
            this.txtChannel1VoltageGet.Location = new System.Drawing.Point(66, 29);
            this.txtChannel1VoltageGet.Name = "txtChannel1VoltageGet";
            this.txtChannel1VoltageGet.ReadOnly = true;
            this.txtChannel1VoltageGet.Size = new System.Drawing.Size(106, 20);
            this.txtChannel1VoltageGet.TabIndex = 0;
            // 
            // keithleyPSULogger
            // 
            this.keithleyPSULogger.WorkerReportsProgress = true;
            this.keithleyPSULogger.WorkerSupportsCancellation = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdChannel2SetValues);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtChannel2CurrentSet);
            this.groupBox1.Controls.Add(this.txtChannel2VoltageSet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkChannel2Enable);
            this.groupBox1.Controls.Add(this.lblChannel2CurrentGet);
            this.groupBox1.Controls.Add(this.lblChannel2VoltageGet);
            this.groupBox1.Controls.Add(this.txtChannel2CurrentGet);
            this.groupBox1.Controls.Add(this.txtChannel2VoltageGet);
            this.groupBox1.Location = new System.Drawing.Point(207, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 230);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel 2";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmdChannel2SetValues
            // 
            this.cmdChannel2SetValues.Location = new System.Drawing.Point(63, 200);
            this.cmdChannel2SetValues.Name = "cmdChannel2SetValues";
            this.cmdChannel2SetValues.Size = new System.Drawing.Size(98, 30);
            this.cmdChannel2SetValues.TabIndex = 10;
            this.cmdChannel2SetValues.Text = "Set values";
            this.cmdChannel2SetValues.UseVisualStyleBackColor = true;
            this.cmdChannel2SetValues.Click += new System.EventHandler(this.cmdChannel2SetValues_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Voltage";
            // 
            // txtChannel2CurrentSet
            // 
            this.txtChannel2CurrentSet.Location = new System.Drawing.Point(63, 167);
            this.txtChannel2CurrentSet.Name = "txtChannel2CurrentSet";
            this.txtChannel2CurrentSet.Size = new System.Drawing.Size(102, 20);
            this.txtChannel2CurrentSet.TabIndex = 7;
            // 
            // txtChannel2VoltageSet
            // 
            this.txtChannel2VoltageSet.Location = new System.Drawing.Point(64, 128);
            this.txtChannel2VoltageSet.Name = "txtChannel2VoltageSet";
            this.txtChannel2VoltageSet.Size = new System.Drawing.Size(102, 20);
            this.txtChannel2VoltageSet.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Get";
            // 
            // chkChannel2Enable
            // 
            this.chkChannel2Enable.AutoSize = true;
            this.chkChannel2Enable.Location = new System.Drawing.Point(63, 98);
            this.chkChannel2Enable.Name = "chkChannel2Enable";
            this.chkChannel2Enable.Size = new System.Drawing.Size(65, 17);
            this.chkChannel2Enable.TabIndex = 4;
            this.chkChannel2Enable.Text = "Enabled";
            this.chkChannel2Enable.UseVisualStyleBackColor = true;
            this.chkChannel2Enable.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblChannel2CurrentGet
            // 
            this.lblChannel2CurrentGet.AutoSize = true;
            this.lblChannel2CurrentGet.Location = new System.Drawing.Point(6, 66);
            this.lblChannel2CurrentGet.Name = "lblChannel2CurrentGet";
            this.lblChannel2CurrentGet.Size = new System.Drawing.Size(41, 13);
            this.lblChannel2CurrentGet.TabIndex = 3;
            this.lblChannel2CurrentGet.Text = "Current";
            // 
            // lblChannel2VoltageGet
            // 
            this.lblChannel2VoltageGet.AutoSize = true;
            this.lblChannel2VoltageGet.Location = new System.Drawing.Point(6, 32);
            this.lblChannel2VoltageGet.Name = "lblChannel2VoltageGet";
            this.lblChannel2VoltageGet.Size = new System.Drawing.Size(43, 13);
            this.lblChannel2VoltageGet.TabIndex = 2;
            this.lblChannel2VoltageGet.Text = "Voltage";
            // 
            // txtChannel2CurrentGet
            // 
            this.txtChannel2CurrentGet.Location = new System.Drawing.Point(63, 63);
            this.txtChannel2CurrentGet.Name = "txtChannel2CurrentGet";
            this.txtChannel2CurrentGet.ReadOnly = true;
            this.txtChannel2CurrentGet.Size = new System.Drawing.Size(106, 20);
            this.txtChannel2CurrentGet.TabIndex = 1;
            // 
            // txtChannel2VoltageGet
            // 
            this.txtChannel2VoltageGet.Location = new System.Drawing.Point(63, 29);
            this.txtChannel2VoltageGet.Name = "txtChannel2VoltageGet";
            this.txtChannel2VoltageGet.ReadOnly = true;
            this.txtChannel2VoltageGet.Size = new System.Drawing.Size(106, 20);
            this.txtChannel2VoltageGet.TabIndex = 0;
            // 
            // lblTItle
            // 
            this.lblTItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTItle.Location = new System.Drawing.Point(9, 10);
            this.lblTItle.Name = "lblTItle";
            this.lblTItle.Size = new System.Drawing.Size(140, 28);
            this.lblTItle.TabIndex = 18;
            this.lblTItle.Text = "PSU Control";
            // 
            // cmbPSUMode
            // 
            this.cmbPSUMode.FormattingEnabled = true;
            this.cmbPSUMode.Location = new System.Drawing.Point(264, 22);
            this.cmbPSUMode.Name = "cmbPSUMode";
            this.cmbPSUMode.Size = new System.Drawing.Size(121, 21);
            this.cmbPSUMode.TabIndex = 19;
            this.cmbPSUMode.SelectedIndexChanged += new System.EventHandler(this.cmbPSUMode_SelectedIndexChanged);
            // 
            // PSUInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmbPSUMode);
            this.Controls.Add(this.lblTItle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxChannel1);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.lblInstrumentState);
            this.Controls.Add(this.cmdCloseUnit);
            this.Controls.Add(this.cmdInitialize);
            this.Name = "PSUInterface";
            this.Size = new System.Drawing.Size(395, 315);
            this.grpBoxChannel1.ResumeLayout(false);
            this.grpBoxChannel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         private System.Windows.Forms.Button cmdInitialize;
        private System.Windows.Forms.Button cmdCloseUnit;
        private System.Windows.Forms.Label lblInstrumentState;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpBoxChannel1;
        private System.Windows.Forms.Label lblChannel1Current;
        private System.Windows.Forms.Label lblChannel1Voltage;
        private System.Windows.Forms.TextBox txtChannel1CurrentGet;
        private System.Windows.Forms.TextBox txtChannel1VoltageGet;
        private System.Windows.Forms.CheckBox chkChannel1Enable;
        private System.Windows.Forms.Button cmdChannel1SetValues;
        private System.Windows.Forms.Label lblChannel1CurrentSet;
        private System.Windows.Forms.Label lblChannel1VoltageSet;
        private System.Windows.Forms.TextBox txtChannel1CurrentSet;
        private System.Windows.Forms.TextBox txtChannel1VoltageSet;
        private System.Windows.Forms.Label lblChannel1Get;
        private System.ComponentModel.BackgroundWorker keithleyPSULogger;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdChannel2SetValues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChannel2CurrentSet;
        private System.Windows.Forms.TextBox txtChannel2VoltageSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkChannel2Enable;
        private System.Windows.Forms.Label lblChannel2CurrentGet;
        private System.Windows.Forms.Label lblChannel2VoltageGet;
        private System.Windows.Forms.TextBox txtChannel2CurrentGet;
        private System.Windows.Forms.TextBox txtChannel2VoltageGet;
        private System.Windows.Forms.Label lblTItle;
        private System.Windows.Forms.ComboBox cmbPSUMode;    
    }
}
