namespace EFMExperimentsLibrary
{
    partial class USBRelayControl
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

            this.lblName = new System.Windows.Forms.Label();
            this.lblNameInfo = new System.Windows.Forms.Label();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();

            // 
            // USBRelayControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "USBRelayControl";
            this.Size = new System.Drawing.Size(491, 186);
            
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "USB Relay name:";
            // 
            // lblNameInfo
            // 
            this.lblNameInfo.AutoSize = true;
            this.lblNameInfo.Location = new System.Drawing.Point(100, 0);
            this.lblNameInfo.Name = "lblNameInfo";
            this.lblNameInfo.Size = new System.Drawing.Size(69, 13);
            this.lblNameInfo.TabIndex = 1;
            this.lblNameInfo.Text = "Not initialized";
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Location = new System.Drawing.Point(6, 16);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(80, 17);
            this.chkOpen.TabIndex = 2;
            this.chkOpen.Text = "Relay open";
            this.chkOpen.UseVisualStyleBackColor = true;
            this.chkOpen.CheckedChanged += new System.EventHandler(this.chkOpen_CheckedChanged);
            // 
            // USBRelayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.lblNameInfo);
            this.Controls.Add(this.lblName);
            this.Name = "USBRelayControl";
            this.Size = new System.Drawing.Size(176, 36);            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNameInfo;
        private System.Windows.Forms.CheckBox chkOpen;
    }
}
