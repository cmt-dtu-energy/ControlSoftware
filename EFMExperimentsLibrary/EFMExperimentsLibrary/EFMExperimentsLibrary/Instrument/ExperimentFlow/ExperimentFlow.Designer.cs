namespace EFMExperimentsLibrary
{
    partial class ExperimentFlow
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
            this.lblTminDSC = new System.Windows.Forms.Label();
            this.lblTmaxDSC = new System.Windows.Forms.Label();
            this.lblTrate = new System.Windows.Forms.Label();
            this.nudTminDSC = new System.Windows.Forms.NumericUpDown();
            this.nudTmaxDSC = new System.Windows.Forms.NumericUpDown();
            this.nudTrate = new System.Windows.Forms.NumericUpDown();
            this.lblAppliedField = new System.Windows.Forms.Label();
            this.nudAppliedField = new System.Windows.Forms.NumericUpDown();
            this.cmdAddDSCExperiment = new System.Windows.Forms.Button();
            this.cmdAddDeltaSExperiment = new System.Windows.Forms.Button();
            this.nudHminDeltaS = new System.Windows.Forms.NumericUpDown();
            this.lblMinFieldDeltaS = new System.Windows.Forms.Label();
            this.nudTstepDeltaS = new System.Windows.Forms.NumericUpDown();
            this.nudTmaxDeltaS = new System.Windows.Forms.NumericUpDown();
            this.nudTminDeltaS = new System.Windows.Forms.NumericUpDown();
            this.lblTStepDeltaS = new System.Windows.Forms.Label();
            this.lblTmaxDeltaS = new System.Windows.Forms.Label();
            this.lblTminDeltaS = new System.Windows.Forms.Label();
            this.grpDSCExperiment = new System.Windows.Forms.GroupBox();
            this.grpDeltaS = new System.Windows.Forms.GroupBox();
            this.nudFieldRampRate = new System.Windows.Forms.NumericUpDown();
            this.lblFieldRate = new System.Windows.Forms.Label();
            this.nudFieldStepDeltaS = new System.Windows.Forms.NumericUpDown();
            this.lblFieldStepDeltaS = new System.Windows.Forms.Label();
            this.nudTResetDeltaS = new System.Windows.Forms.NumericUpDown();
            this.chkResetDeltaS = new System.Windows.Forms.CheckBox();
            this.nudHmaxDeltaS = new System.Windows.Forms.NumericUpDown();
            this.lblMaxFieldDeltaS = new System.Windows.Forms.Label();
            this.lstExperiments = new System.Windows.Forms.ListView();
            this.lblStabilizeCriterium = new System.Windows.Forms.Label();
            this.nudStabilization = new System.Windows.Forms.NumericUpDown();
            this.cmdStart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdRemoveExperiemnt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTminDSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTmaxDSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAppliedField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHminDeltaS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTstepDeltaS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTmaxDeltaS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTminDeltaS)).BeginInit();
            this.grpDSCExperiment.SuspendLayout();
            this.grpDeltaS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldRampRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldStepDeltaS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTResetDeltaS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmaxDeltaS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStabilization)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTminDSC
            // 
            this.lblTminDSC.AutoSize = true;
            this.lblTminDSC.Location = new System.Drawing.Point(4, 16);
            this.lblTminDSC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTminDSC.Name = "lblTminDSC";
            this.lblTminDSC.Size = new System.Drawing.Size(49, 13);
            this.lblTminDSC.TabIndex = 0;
            this.lblTminDSC.Text = "Tmin (K):";
            // 
            // lblTmaxDSC
            // 
            this.lblTmaxDSC.AutoSize = true;
            this.lblTmaxDSC.Location = new System.Drawing.Point(4, 39);
            this.lblTmaxDSC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTmaxDSC.Name = "lblTmaxDSC";
            this.lblTmaxDSC.Size = new System.Drawing.Size(52, 13);
            this.lblTmaxDSC.TabIndex = 1;
            this.lblTmaxDSC.Text = "Tmax (K):";
            // 
            // lblTrate
            // 
            this.lblTrate.AutoSize = true;
            this.lblTrate.Location = new System.Drawing.Point(4, 62);
            this.lblTrate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrate.Name = "lblTrate";
            this.lblTrate.Size = new System.Drawing.Size(99, 13);
            this.lblTrate.TabIndex = 2;
            this.lblTrate.Text = "Ramp rate (K/min.):";
            // 
            // nudTminDSC
            // 
            this.nudTminDSC.DecimalPlaces = 2;
            this.nudTminDSC.Location = new System.Drawing.Point(109, 15);
            this.nudTminDSC.Margin = new System.Windows.Forms.Padding(2);
            this.nudTminDSC.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudTminDSC.Name = "nudTminDSC";
            this.nudTminDSC.Size = new System.Drawing.Size(90, 20);
            this.nudTminDSC.TabIndex = 3;
            this.nudTminDSC.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // nudTmaxDSC
            // 
            this.nudTmaxDSC.DecimalPlaces = 2;
            this.nudTmaxDSC.Location = new System.Drawing.Point(109, 37);
            this.nudTmaxDSC.Margin = new System.Windows.Forms.Padding(2);
            this.nudTmaxDSC.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudTmaxDSC.Name = "nudTmaxDSC";
            this.nudTmaxDSC.Size = new System.Drawing.Size(90, 20);
            this.nudTmaxDSC.TabIndex = 4;
            this.nudTmaxDSC.Value = new decimal(new int[] {
            330,
            0,
            0,
            0});
            // 
            // nudTrate
            // 
            this.nudTrate.DecimalPlaces = 3;
            this.nudTrate.Location = new System.Drawing.Point(109, 60);
            this.nudTrate.Margin = new System.Windows.Forms.Padding(2);
            this.nudTrate.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTrate.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nudTrate.Name = "nudTrate";
            this.nudTrate.Size = new System.Drawing.Size(90, 20);
            this.nudTrate.TabIndex = 5;
            this.nudTrate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAppliedField
            // 
            this.lblAppliedField.AutoSize = true;
            this.lblAppliedField.Location = new System.Drawing.Point(4, 84);
            this.lblAppliedField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppliedField.Name = "lblAppliedField";
            this.lblAppliedField.Size = new System.Drawing.Size(83, 13);
            this.lblAppliedField.TabIndex = 6;
            this.lblAppliedField.Text = "Applied field (T):";
            // 
            // nudAppliedField
            // 
            this.nudAppliedField.DecimalPlaces = 3;
            this.nudAppliedField.Location = new System.Drawing.Point(109, 83);
            this.nudAppliedField.Margin = new System.Windows.Forms.Padding(2);
            this.nudAppliedField.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudAppliedField.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudAppliedField.Name = "nudAppliedField";
            this.nudAppliedField.Size = new System.Drawing.Size(90, 20);
            this.nudAppliedField.TabIndex = 7;
            // 
            // cmdAddDSCExperiment
            // 
            this.cmdAddDSCExperiment.Location = new System.Drawing.Point(87, 106);
            this.cmdAddDSCExperiment.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAddDSCExperiment.Name = "cmdAddDSCExperiment";
            this.cmdAddDSCExperiment.Size = new System.Drawing.Size(112, 19);
            this.cmdAddDSCExperiment.TabIndex = 8;
            this.cmdAddDSCExperiment.Text = "Add DSC Experiment";
            this.cmdAddDSCExperiment.UseVisualStyleBackColor = true;
            this.cmdAddDSCExperiment.Click += new System.EventHandler(this.cmdAddDSCExperiment_Click);
            // 
            // cmdAddDeltaSExperiment
            // 
            this.cmdAddDeltaSExperiment.Location = new System.Drawing.Point(79, 196);
            this.cmdAddDeltaSExperiment.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAddDeltaSExperiment.Name = "cmdAddDeltaSExperiment";
            this.cmdAddDeltaSExperiment.Size = new System.Drawing.Size(120, 19);
            this.cmdAddDeltaSExperiment.TabIndex = 17;
            this.cmdAddDeltaSExperiment.Text = "Add deltaS Experiment";
            this.cmdAddDeltaSExperiment.UseVisualStyleBackColor = true;
            this.cmdAddDeltaSExperiment.Click += new System.EventHandler(this.cmdAddDeltaSExperiment_Click);
            // 
            // nudHminDeltaS
            // 
            this.nudHminDeltaS.DecimalPlaces = 3;
            this.nudHminDeltaS.Location = new System.Drawing.Point(105, 83);
            this.nudHminDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.nudHminDeltaS.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudHminDeltaS.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudHminDeltaS.Name = "nudHminDeltaS";
            this.nudHminDeltaS.Size = new System.Drawing.Size(90, 20);
            this.nudHminDeltaS.TabIndex = 16;
            // 
            // lblMinFieldDeltaS
            // 
            this.lblMinFieldDeltaS.AutoSize = true;
            this.lblMinFieldDeltaS.Location = new System.Drawing.Point(1, 84);
            this.lblMinFieldDeltaS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinFieldDeltaS.Name = "lblMinFieldDeltaS";
            this.lblMinFieldDeltaS.Size = new System.Drawing.Size(65, 13);
            this.lblMinFieldDeltaS.TabIndex = 15;
            this.lblMinFieldDeltaS.Text = "Min field (T):";
            // 
            // nudTstepDeltaS
            // 
            this.nudTstepDeltaS.DecimalPlaces = 2;
            this.nudTstepDeltaS.Location = new System.Drawing.Point(105, 60);
            this.nudTstepDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.nudTstepDeltaS.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTstepDeltaS.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nudTstepDeltaS.Name = "nudTstepDeltaS";
            this.nudTstepDeltaS.Size = new System.Drawing.Size(90, 20);
            this.nudTstepDeltaS.TabIndex = 14;
            this.nudTstepDeltaS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTmaxDeltaS
            // 
            this.nudTmaxDeltaS.DecimalPlaces = 2;
            this.nudTmaxDeltaS.Location = new System.Drawing.Point(105, 37);
            this.nudTmaxDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.nudTmaxDeltaS.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudTmaxDeltaS.Name = "nudTmaxDeltaS";
            this.nudTmaxDeltaS.Size = new System.Drawing.Size(90, 20);
            this.nudTmaxDeltaS.TabIndex = 13;
            this.nudTmaxDeltaS.Value = new decimal(new int[] {
            295,
            0,
            0,
            0});
            // 
            // nudTminDeltaS
            // 
            this.nudTminDeltaS.DecimalPlaces = 2;
            this.nudTminDeltaS.Location = new System.Drawing.Point(105, 15);
            this.nudTminDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.nudTminDeltaS.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudTminDeltaS.Name = "nudTminDeltaS";
            this.nudTminDeltaS.Size = new System.Drawing.Size(90, 20);
            this.nudTminDeltaS.TabIndex = 12;
            this.nudTminDeltaS.Value = new decimal(new int[] {
            290,
            0,
            0,
            0});
            // 
            // lblTStepDeltaS
            // 
            this.lblTStepDeltaS.AutoSize = true;
            this.lblTStepDeltaS.Location = new System.Drawing.Point(1, 62);
            this.lblTStepDeltaS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTStepDeltaS.Name = "lblTStepDeltaS";
            this.lblTStepDeltaS.Size = new System.Drawing.Size(53, 13);
            this.lblTStepDeltaS.TabIndex = 11;
            this.lblTStepDeltaS.Text = "Tstep (K):";
            // 
            // lblTmaxDeltaS
            // 
            this.lblTmaxDeltaS.AutoSize = true;
            this.lblTmaxDeltaS.Location = new System.Drawing.Point(1, 39);
            this.lblTmaxDeltaS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTmaxDeltaS.Name = "lblTmaxDeltaS";
            this.lblTmaxDeltaS.Size = new System.Drawing.Size(52, 13);
            this.lblTmaxDeltaS.TabIndex = 10;
            this.lblTmaxDeltaS.Text = "Tmax (K):";
            // 
            // lblTminDeltaS
            // 
            this.lblTminDeltaS.AutoSize = true;
            this.lblTminDeltaS.Location = new System.Drawing.Point(1, 16);
            this.lblTminDeltaS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTminDeltaS.Name = "lblTminDeltaS";
            this.lblTminDeltaS.Size = new System.Drawing.Size(49, 13);
            this.lblTminDeltaS.TabIndex = 9;
            this.lblTminDeltaS.Text = "Tmin (K):";
            // 
            // grpDSCExperiment
            // 
            this.grpDSCExperiment.Controls.Add(this.lblAppliedField);
            this.grpDSCExperiment.Controls.Add(this.lblTminDSC);
            this.grpDSCExperiment.Controls.Add(this.lblTmaxDSC);
            this.grpDSCExperiment.Controls.Add(this.lblTrate);
            this.grpDSCExperiment.Controls.Add(this.nudTminDSC);
            this.grpDSCExperiment.Controls.Add(this.nudTmaxDSC);
            this.grpDSCExperiment.Controls.Add(this.nudTrate);
            this.grpDSCExperiment.Controls.Add(this.nudAppliedField);
            this.grpDSCExperiment.Controls.Add(this.cmdAddDSCExperiment);
            this.grpDSCExperiment.Location = new System.Drawing.Point(2, 2);
            this.grpDSCExperiment.Margin = new System.Windows.Forms.Padding(2);
            this.grpDSCExperiment.Name = "grpDSCExperiment";
            this.grpDSCExperiment.Padding = new System.Windows.Forms.Padding(2);
            this.grpDSCExperiment.Size = new System.Drawing.Size(210, 127);
            this.grpDSCExperiment.TabIndex = 18;
            this.grpDSCExperiment.TabStop = false;
            this.grpDSCExperiment.Text = "DSC Experiment";
            // 
            // grpDeltaS
            // 
            this.grpDeltaS.Controls.Add(this.nudFieldRampRate);
            this.grpDeltaS.Controls.Add(this.lblFieldRate);
            this.grpDeltaS.Controls.Add(this.nudFieldStepDeltaS);
            this.grpDeltaS.Controls.Add(this.lblFieldStepDeltaS);
            this.grpDeltaS.Controls.Add(this.nudTResetDeltaS);
            this.grpDeltaS.Controls.Add(this.chkResetDeltaS);
            this.grpDeltaS.Controls.Add(this.nudHmaxDeltaS);
            this.grpDeltaS.Controls.Add(this.lblMaxFieldDeltaS);
            this.grpDeltaS.Controls.Add(this.cmdAddDeltaSExperiment);
            this.grpDeltaS.Controls.Add(this.lblTminDeltaS);
            this.grpDeltaS.Controls.Add(this.lblTmaxDeltaS);
            this.grpDeltaS.Controls.Add(this.nudHminDeltaS);
            this.grpDeltaS.Controls.Add(this.lblTStepDeltaS);
            this.grpDeltaS.Controls.Add(this.lblMinFieldDeltaS);
            this.grpDeltaS.Controls.Add(this.nudTminDeltaS);
            this.grpDeltaS.Controls.Add(this.nudTstepDeltaS);
            this.grpDeltaS.Controls.Add(this.nudTmaxDeltaS);
            this.grpDeltaS.Location = new System.Drawing.Point(2, 134);
            this.grpDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.grpDeltaS.Name = "grpDeltaS";
            this.grpDeltaS.Padding = new System.Windows.Forms.Padding(2);
            this.grpDeltaS.Size = new System.Drawing.Size(210, 227);
            this.grpDeltaS.TabIndex = 19;
            this.grpDeltaS.TabStop = false;
            this.grpDeltaS.Text = "DeltaS experiment";
            // 
            // nudFieldRampRate
            // 
            this.nudFieldRampRate.DecimalPlaces = 3;
            this.nudFieldRampRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudFieldRampRate.Location = new System.Drawing.Point(105, 150);
            this.nudFieldRampRate.Margin = new System.Windows.Forms.Padding(2);
            this.nudFieldRampRate.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFieldRampRate.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudFieldRampRate.Name = "nudFieldRampRate";
            this.nudFieldRampRate.Size = new System.Drawing.Size(90, 20);
            this.nudFieldRampRate.TabIndex = 23;
            this.nudFieldRampRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // lblFieldRate
            // 
            this.lblFieldRate.AutoSize = true;
            this.lblFieldRate.Location = new System.Drawing.Point(0, 152);
            this.lblFieldRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFieldRate.Name = "lblFieldRate";
            this.lblFieldRate.Size = new System.Drawing.Size(85, 13);
            this.lblFieldRate.TabIndex = 21;
            this.lblFieldRate.Text = "Ramp rate (T/s):";
            // 
            // nudFieldStepDeltaS
            // 
            this.nudFieldStepDeltaS.DecimalPlaces = 3;
            this.nudFieldStepDeltaS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudFieldStepDeltaS.Location = new System.Drawing.Point(105, 128);
            this.nudFieldStepDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.nudFieldStepDeltaS.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudFieldStepDeltaS.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudFieldStepDeltaS.Name = "nudFieldStepDeltaS";
            this.nudFieldStepDeltaS.Size = new System.Drawing.Size(90, 20);
            this.nudFieldStepDeltaS.TabIndex = 22;
            this.nudFieldStepDeltaS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFieldStepDeltaS
            // 
            this.lblFieldStepDeltaS.AutoSize = true;
            this.lblFieldStepDeltaS.Location = new System.Drawing.Point(1, 129);
            this.lblFieldStepDeltaS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFieldStepDeltaS.Name = "lblFieldStepDeltaS";
            this.lblFieldStepDeltaS.Size = new System.Drawing.Size(71, 13);
            this.lblFieldStepDeltaS.TabIndex = 20;
            this.lblFieldStepDeltaS.Text = "Field step (T):";
            // 
            // nudTResetDeltaS
            // 
            this.nudTResetDeltaS.DecimalPlaces = 2;
            this.nudTResetDeltaS.Location = new System.Drawing.Point(105, 173);
            this.nudTResetDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.nudTResetDeltaS.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudTResetDeltaS.Name = "nudTResetDeltaS";
            this.nudTResetDeltaS.Size = new System.Drawing.Size(90, 20);
            this.nudTResetDeltaS.TabIndex = 21;
            // 
            // chkResetDeltaS
            // 
            this.chkResetDeltaS.AutoSize = true;
            this.chkResetDeltaS.Location = new System.Drawing.Point(0, 174);
            this.chkResetDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.chkResetDeltaS.Name = "chkResetDeltaS";
            this.chkResetDeltaS.Size = new System.Drawing.Size(95, 17);
            this.chkResetDeltaS.TabIndex = 20;
            this.chkResetDeltaS.Text = "Reset at T (K):";
            this.chkResetDeltaS.UseVisualStyleBackColor = true;
            // 
            // nudHmaxDeltaS
            // 
            this.nudHmaxDeltaS.DecimalPlaces = 3;
            this.nudHmaxDeltaS.Location = new System.Drawing.Point(105, 106);
            this.nudHmaxDeltaS.Margin = new System.Windows.Forms.Padding(2);
            this.nudHmaxDeltaS.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudHmaxDeltaS.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudHmaxDeltaS.Name = "nudHmaxDeltaS";
            this.nudHmaxDeltaS.Size = new System.Drawing.Size(90, 20);
            this.nudHmaxDeltaS.TabIndex = 19;
            this.nudHmaxDeltaS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaxFieldDeltaS
            // 
            this.lblMaxFieldDeltaS.AutoSize = true;
            this.lblMaxFieldDeltaS.Location = new System.Drawing.Point(1, 107);
            this.lblMaxFieldDeltaS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxFieldDeltaS.Name = "lblMaxFieldDeltaS";
            this.lblMaxFieldDeltaS.Size = new System.Drawing.Size(68, 13);
            this.lblMaxFieldDeltaS.TabIndex = 18;
            this.lblMaxFieldDeltaS.Text = "Max field (T):";
            // 
            // lstExperiments
            // 
            this.lstExperiments.GridLines = true;
            this.lstExperiments.Location = new System.Drawing.Point(217, 2);
            this.lstExperiments.Margin = new System.Windows.Forms.Padding(2);
            this.lstExperiments.MultiSelect = false;
            this.lstExperiments.Name = "lstExperiments";
            this.lstExperiments.Size = new System.Drawing.Size(257, 328);
            this.lstExperiments.TabIndex = 20;
            this.lstExperiments.UseCompatibleStateImageBehavior = false;
            this.lstExperiments.View = System.Windows.Forms.View.List;
            // 
            // lblStabilizeCriterium
            // 
            this.lblStabilizeCriterium.AutoSize = true;
            this.lblStabilizeCriterium.Location = new System.Drawing.Point(217, 335);
            this.lblStabilizeCriterium.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStabilizeCriterium.Name = "lblStabilizeCriterium";
            this.lblStabilizeCriterium.Size = new System.Drawing.Size(66, 13);
            this.lblStabilizeCriterium.TabIndex = 21;
            this.lblStabilizeCriterium.Text = "Stabilization:";
            // 
            // nudStabilization
            // 
            this.nudStabilization.DecimalPlaces = 8;
            this.nudStabilization.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.nudStabilization.Location = new System.Drawing.Point(287, 333);
            this.nudStabilization.Margin = new System.Windows.Forms.Padding(2);
            this.nudStabilization.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStabilization.Name = "nudStabilization";
            this.nudStabilization.Size = new System.Drawing.Size(90, 20);
            this.nudStabilization.TabIndex = 22;
            this.nudStabilization.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(382, 333);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 23;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 362);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Status";
            // 
            // cmdRemoveExperiemnt
            // 
            this.cmdRemoveExperiemnt.Location = new System.Drawing.Point(217, 362);
            this.cmdRemoveExperiemnt.Name = "cmdRemoveExperiemnt";
            this.cmdRemoveExperiemnt.Size = new System.Drawing.Size(75, 23);
            this.cmdRemoveExperiemnt.TabIndex = 25;
            this.cmdRemoveExperiemnt.Text = "Remove";
            this.cmdRemoveExperiemnt.UseVisualStyleBackColor = true;
            this.cmdRemoveExperiemnt.Click += new System.EventHandler(this.cmdRemoveExperiemnt_Click);
            // 
            // ExperimentFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmdRemoveExperiemnt);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.nudStabilization);
            this.Controls.Add(this.lblStabilizeCriterium);
            this.Controls.Add(this.lstExperiments);
            this.Controls.Add(this.grpDeltaS);
            this.Controls.Add(this.grpDSCExperiment);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ExperimentFlow";
            this.Size = new System.Drawing.Size(475, 394);
            ((System.ComponentModel.ISupportInitialize)(this.nudTminDSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTmaxDSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAppliedField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHminDeltaS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTstepDeltaS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTmaxDeltaS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTminDeltaS)).EndInit();
            this.grpDSCExperiment.ResumeLayout(false);
            this.grpDSCExperiment.PerformLayout();
            this.grpDeltaS.ResumeLayout(false);
            this.grpDeltaS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldRampRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFieldStepDeltaS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTResetDeltaS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmaxDeltaS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStabilization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTminDSC;
        private System.Windows.Forms.Label lblTmaxDSC;
        private System.Windows.Forms.Label lblTrate;
        private System.Windows.Forms.NumericUpDown nudTminDSC;
        private System.Windows.Forms.NumericUpDown nudTmaxDSC;
        private System.Windows.Forms.NumericUpDown nudTrate;
        private System.Windows.Forms.Label lblAppliedField;
        private System.Windows.Forms.NumericUpDown nudAppliedField;
        private System.Windows.Forms.Button cmdAddDSCExperiment;
        private System.Windows.Forms.Button cmdAddDeltaSExperiment;
        private System.Windows.Forms.NumericUpDown nudHminDeltaS;
        private System.Windows.Forms.Label lblMinFieldDeltaS;
        private System.Windows.Forms.NumericUpDown nudTstepDeltaS;
        private System.Windows.Forms.NumericUpDown nudTmaxDeltaS;
        private System.Windows.Forms.NumericUpDown nudTminDeltaS;
        private System.Windows.Forms.Label lblTStepDeltaS;
        private System.Windows.Forms.Label lblTmaxDeltaS;
        private System.Windows.Forms.Label lblTminDeltaS;
        private System.Windows.Forms.GroupBox grpDSCExperiment;
        private System.Windows.Forms.GroupBox grpDeltaS;
        private System.Windows.Forms.NumericUpDown nudHmaxDeltaS;
        private System.Windows.Forms.Label lblMaxFieldDeltaS;
        private System.Windows.Forms.NumericUpDown nudTResetDeltaS;
        private System.Windows.Forms.CheckBox chkResetDeltaS;
        private System.Windows.Forms.NumericUpDown nudFieldStepDeltaS;
        private System.Windows.Forms.Label lblFieldStepDeltaS;
        private System.Windows.Forms.ListView lstExperiments;
        private System.Windows.Forms.NumericUpDown nudFieldRampRate;
        private System.Windows.Forms.Label lblFieldRate;
        private System.Windows.Forms.Label lblStabilizeCriterium;
        private System.Windows.Forms.NumericUpDown nudStabilization;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button cmdRemoveExperiemnt;
    }
}
