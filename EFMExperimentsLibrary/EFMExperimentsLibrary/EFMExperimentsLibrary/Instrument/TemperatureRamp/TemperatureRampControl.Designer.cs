namespace EFMExperimentsLibrary
{
    partial class TemperatureRampControl
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
            this.numTmin = new System.Windows.Forms.NumericUpDown();
            this.numTmax = new System.Windows.Forms.NumericUpDown();
            this.numTRamp = new System.Windows.Forms.NumericUpDown();
            this.lblTmin = new System.Windows.Forms.Label();
            this.lblTmax = new System.Windows.Forms.Label();
            this.lblTRamp = new System.Windows.Forms.Label();
            this.lblTCurrent = new System.Windows.Forms.Label();
            this.numTCurrent = new System.Windows.Forms.NumericUpDown();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUnitTmin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTRamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // numTmin
            // 
            this.numTmin.DecimalPlaces = 2;
            this.numTmin.Location = new System.Drawing.Point(56, 16);
            this.numTmin.Maximum = new decimal(new int[] {
            370,
            0,
            0,
            0});
            this.numTmin.Name = "numTmin";
            this.numTmin.Size = new System.Drawing.Size(69, 20);
            this.numTmin.TabIndex = 0;
            this.numTmin.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numTmax
            // 
            this.numTmax.DecimalPlaces = 2;
            this.numTmax.Location = new System.Drawing.Point(56, 42);
            this.numTmax.Maximum = new decimal(new int[] {
            370,
            0,
            0,
            0});
            this.numTmax.Name = "numTmax";
            this.numTmax.Size = new System.Drawing.Size(69, 20);
            this.numTmax.TabIndex = 1;
            this.numTmax.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numTRamp
            // 
            this.numTRamp.DecimalPlaces = 3;
            this.numTRamp.Location = new System.Drawing.Point(56, 68);
            this.numTRamp.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTRamp.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numTRamp.Name = "numTRamp";
            this.numTRamp.Size = new System.Drawing.Size(69, 20);
            this.numTRamp.TabIndex = 2;
            this.numTRamp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTmin
            // 
            this.lblTmin.AutoSize = true;
            this.lblTmin.Location = new System.Drawing.Point(5, 18);
            this.lblTmin.Name = "lblTmin";
            this.lblTmin.Size = new System.Drawing.Size(33, 13);
            this.lblTmin.TabIndex = 3;
            this.lblTmin.Text = "Tmin:";
            // 
            // lblTmax
            // 
            this.lblTmax.AutoSize = true;
            this.lblTmax.Location = new System.Drawing.Point(5, 44);
            this.lblTmax.Name = "lblTmax";
            this.lblTmax.Size = new System.Drawing.Size(36, 13);
            this.lblTmax.TabIndex = 4;
            this.lblTmax.Text = "Tmax:";
            // 
            // lblTRamp
            // 
            this.lblTRamp.AutoSize = true;
            this.lblTRamp.Location = new System.Drawing.Point(5, 70);
            this.lblTRamp.Name = "lblTRamp";
            this.lblTRamp.Size = new System.Drawing.Size(45, 13);
            this.lblTRamp.TabIndex = 5;
            this.lblTRamp.Text = "TRamp:";
            // 
            // lblTCurrent
            // 
            this.lblTCurrent.AutoSize = true;
            this.lblTCurrent.Location = new System.Drawing.Point(5, 96);
            this.lblTCurrent.Name = "lblTCurrent";
            this.lblTCurrent.Size = new System.Drawing.Size(51, 13);
            this.lblTCurrent.TabIndex = 7;
            this.lblTCurrent.Text = "TCurrent:";
            // 
            // numTCurrent
            // 
            this.numTCurrent.DecimalPlaces = 2;
            this.numTCurrent.Location = new System.Drawing.Point(56, 94);
            this.numTCurrent.Maximum = new decimal(new int[] {
            370,
            0,
            0,
            0});
            this.numTCurrent.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numTCurrent.Name = "numTCurrent";
            this.numTCurrent.ReadOnly = true;
            this.numTCurrent.Size = new System.Drawing.Size(69, 20);
            this.numTCurrent.TabIndex = 6;
            this.numTCurrent.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(50, 120);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(93, 13);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Temperature ramp";
            // 
            // lblUnitTmin
            // 
            this.lblUnitTmin.AutoSize = true;
            this.lblUnitTmin.Location = new System.Drawing.Point(131, 18);
            this.lblUnitTmin.Name = "lblUnitTmin";
            this.lblUnitTmin.Size = new System.Drawing.Size(14, 13);
            this.lblUnitTmin.TabIndex = 10;
            this.lblUnitTmin.Text = "K";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "K";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "K/min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "K";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(50, 149);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // TemperatureRampControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUnitTmin);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lblTCurrent);
            this.Controls.Add(this.numTCurrent);
            this.Controls.Add(this.lblTRamp);
            this.Controls.Add(this.lblTmax);
            this.Controls.Add(this.lblTmin);
            this.Controls.Add(this.numTRamp);
            this.Controls.Add(this.numTmax);
            this.Controls.Add(this.numTmin);
            this.Name = "TemperatureRampControl";
            this.Size = new System.Drawing.Size(169, 179);
            ((System.ComponentModel.ISupportInitialize)(this.numTmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTRamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTCurrent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numTmin;
        private System.Windows.Forms.NumericUpDown numTmax;
        private System.Windows.Forms.NumericUpDown numTRamp;
        private System.Windows.Forms.Label lblTmin;
        private System.Windows.Forms.Label lblTmax;
        private System.Windows.Forms.Label lblTRamp;
        private System.Windows.Forms.Label lblTCurrent;
        private System.Windows.Forms.NumericUpDown numTCurrent;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUnitTmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
    }
}
