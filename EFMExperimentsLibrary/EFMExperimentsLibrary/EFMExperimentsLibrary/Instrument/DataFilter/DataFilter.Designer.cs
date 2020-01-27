namespace EFMExperimentsLibrary
{
    public partial class DataFilter
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
            this.cmbChannelID = new System.Windows.Forms.ComboBox();
            this.cmbTransformation = new System.Windows.Forms.ComboBox();
            this.lblChannelID = new System.Windows.Forms.Label();
            this.lblTransformation = new System.Windows.Forms.Label();
            this.lblChannelA = new System.Windows.Forms.Label();
            this.lblChannelB = new System.Windows.Forms.Label();
            this.cmbChannelB = new System.Windows.Forms.ComboBox();
            this.cmbChannelA = new System.Windows.Forms.ComboBox();
            this.lblK1 = new System.Windows.Forms.Label();
            this.nudK1 = new System.Windows.Forms.NumericUpDown();
            this.nudK2 = new System.Windows.Forms.NumericUpDown();
            this.lblK2 = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.nudK3 = new System.Windows.Forms.NumericUpDown();
            this.lblK3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudK1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK3)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbChannelID
            // 
            this.cmbChannelID.FormattingEnabled = true;
            this.cmbChannelID.Location = new System.Drawing.Point(3, 16);
            this.cmbChannelID.Name = "cmbChannelID";
            this.cmbChannelID.Size = new System.Drawing.Size(121, 21);
            this.cmbChannelID.TabIndex = 0;
            this.cmbChannelID.SelectedIndexChanged += new System.EventHandler(this.cmbChannelID_SelectedIndexChanged);
            // 
            // cmbTransformation
            // 
            this.cmbTransformation.FormattingEnabled = true;
            this.cmbTransformation.Location = new System.Drawing.Point(130, 16);
            this.cmbTransformation.Name = "cmbTransformation";
            this.cmbTransformation.Size = new System.Drawing.Size(121, 21);
            this.cmbTransformation.TabIndex = 1;
            // 
            // lblChannelID
            // 
            this.lblChannelID.AutoSize = true;
            this.lblChannelID.Location = new System.Drawing.Point(3, 0);
            this.lblChannelID.Name = "lblChannelID";
            this.lblChannelID.Size = new System.Drawing.Size(63, 13);
            this.lblChannelID.TabIndex = 2;
            this.lblChannelID.Text = "Channel ID:";
            // 
            // lblTransformation
            // 
            this.lblTransformation.AutoSize = true;
            this.lblTransformation.Location = new System.Drawing.Point(128, 0);
            this.lblTransformation.Name = "lblTransformation";
            this.lblTransformation.Size = new System.Drawing.Size(80, 13);
            this.lblTransformation.TabIndex = 3;
            this.lblTransformation.Text = "Transformation:";
            // 
            // lblChannelA
            // 
            this.lblChannelA.AutoSize = true;
            this.lblChannelA.Location = new System.Drawing.Point(3, 40);
            this.lblChannelA.Name = "lblChannelA";
            this.lblChannelA.Size = new System.Drawing.Size(59, 13);
            this.lblChannelA.TabIndex = 4;
            this.lblChannelA.Text = "Channel A:";
            // 
            // lblChannelB
            // 
            this.lblChannelB.AutoSize = true;
            this.lblChannelB.Location = new System.Drawing.Point(128, 40);
            this.lblChannelB.Name = "lblChannelB";
            this.lblChannelB.Size = new System.Drawing.Size(59, 13);
            this.lblChannelB.TabIndex = 5;
            this.lblChannelB.Text = "Channel B:";
            // 
            // cmbChannelB
            // 
            this.cmbChannelB.FormattingEnabled = true;
            this.cmbChannelB.Location = new System.Drawing.Point(131, 56);
            this.cmbChannelB.Name = "cmbChannelB";
            this.cmbChannelB.Size = new System.Drawing.Size(121, 21);
            this.cmbChannelB.TabIndex = 7;
            // 
            // cmbChannelA
            // 
            this.cmbChannelA.FormattingEnabled = true;
            this.cmbChannelA.Location = new System.Drawing.Point(4, 56);
            this.cmbChannelA.Name = "cmbChannelA";
            this.cmbChannelA.Size = new System.Drawing.Size(121, 21);
            this.cmbChannelA.TabIndex = 6;
            // 
            // lblK1
            // 
            this.lblK1.AutoSize = true;
            this.lblK1.Location = new System.Drawing.Point(7, 85);
            this.lblK1.Name = "lblK1";
            this.lblK1.Size = new System.Drawing.Size(23, 13);
            this.lblK1.TabIndex = 8;
            this.lblK1.Text = "K1:";
            // 
            // nudK1
            // 
            this.nudK1.DecimalPlaces = 6;
            this.nudK1.Location = new System.Drawing.Point(6, 101);
            this.nudK1.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudK1.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.nudK1.Name = "nudK1";
            this.nudK1.Size = new System.Drawing.Size(125, 20);
            this.nudK1.TabIndex = 9;
            // 
            // nudK2
            // 
            this.nudK2.DecimalPlaces = 6;
            this.nudK2.Location = new System.Drawing.Point(137, 101);
            this.nudK2.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudK2.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.nudK2.Name = "nudK2";
            this.nudK2.Size = new System.Drawing.Size(125, 20);
            this.nudK2.TabIndex = 11;
            // 
            // lblK2
            // 
            this.lblK2.AutoSize = true;
            this.lblK2.Location = new System.Drawing.Point(134, 85);
            this.lblK2.Name = "lblK2";
            this.lblK2.Size = new System.Drawing.Size(23, 13);
            this.lblK2.TabIndex = 10;
            this.lblK2.Text = "K2:";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(258, 52);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(70, 26);
            this.cmdUpdate.TabIndex = 14;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(257, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(126, 20);
            this.txtName.TabIndex = 15;
            this.txtName.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(255, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name:";
            // 
            // nudK3
            // 
            this.nudK3.DecimalPlaces = 6;
            this.nudK3.Location = new System.Drawing.Point(268, 101);
            this.nudK3.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudK3.Minimum = new decimal(new int[] {
            -727379968,
            232,
            0,
            -2147483648});
            this.nudK3.Name = "nudK3";
            this.nudK3.Size = new System.Drawing.Size(125, 20);
            this.nudK3.TabIndex = 18;
            // 
            // lblK3
            // 
            this.lblK3.AutoSize = true;
            this.lblK3.Location = new System.Drawing.Point(270, 85);
            this.lblK3.Name = "lblK3";
            this.lblK3.Size = new System.Drawing.Size(23, 13);
            this.lblK3.TabIndex = 17;
            this.lblK3.Text = "K3:";
            // 
            // DataFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nudK3);
            this.Controls.Add(this.lblK3);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.nudK2);
            this.Controls.Add(this.lblK2);
            this.Controls.Add(this.nudK1);
            this.Controls.Add(this.lblK1);
            this.Controls.Add(this.cmbChannelB);
            this.Controls.Add(this.cmbChannelA);
            this.Controls.Add(this.lblChannelB);
            this.Controls.Add(this.lblChannelA);
            this.Controls.Add(this.lblTransformation);
            this.Controls.Add(this.lblChannelID);
            this.Controls.Add(this.cmbTransformation);
            this.Controls.Add(this.cmbChannelID);
            this.Name = "DataFilter";
            this.Size = new System.Drawing.Size(400, 130);
            ((System.ComponentModel.ISupportInitialize)(this.nudK1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudK3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChannelID;
        private System.Windows.Forms.ComboBox cmbTransformation;
        private System.Windows.Forms.Label lblChannelID;
        private System.Windows.Forms.Label lblTransformation;
        private System.Windows.Forms.Label lblChannelA;
        private System.Windows.Forms.Label lblChannelB;
        private System.Windows.Forms.ComboBox cmbChannelB;
        private System.Windows.Forms.ComboBox cmbChannelA;
        private System.Windows.Forms.Label lblK1;
        private System.Windows.Forms.NumericUpDown nudK1;
        private System.Windows.Forms.NumericUpDown nudK2;
        private System.Windows.Forms.Label lblK2;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.NumericUpDown nudK3;
        private System.Windows.Forms.Label lblK3;
    }
}
