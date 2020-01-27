namespace EFMExperimentsLibrary
{
    partial class KE2700Control
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
            this.cmdStart = new System.Windows.Forms.Button();
            this.dgvKeithley2700 = new System.Windows.Forms.DataGridView();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdStop = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.MaxRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeithley2700)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(451, 536);
            this.cmdStart.Margin = new System.Windows.Forms.Padding(2);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(95, 24);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Start Keithley";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dgvKeithley2700
            // 
            this.dgvKeithley2700.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeithley2700.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChannelName,
            this.Time,
            this.Reading,
            this.Type,
            this.Enabled,
            this.MaxRange});
            this.dgvKeithley2700.Location = new System.Drawing.Point(-1, 69);
            this.dgvKeithley2700.Margin = new System.Windows.Forms.Padding(2);
            this.dgvKeithley2700.Name = "dgvKeithley2700";
            this.dgvKeithley2700.RowTemplate.Height = 24;
            this.dgvKeithley2700.Size = new System.Drawing.Size(646, 467);
            this.dgvKeithley2700.TabIndex = 2;
            this.dgvKeithley2700.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKeithley2700_CellContentClick);
            // 
            // ChannelName
            // 
            this.ChannelName.HeaderText = "Name";
            this.ChannelName.Name = "ChannelName";
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Reading
            // 
            this.Reading.HeaderText = "Reading";
            this.Reading.Name = "Reading";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Enabled
            // 
            this.Enabled.HeaderText = "Enabled";
            this.Enabled.Name = "Enabled";
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(550, 536);
            this.cmdStop.Margin = new System.Windows.Forms.Padding(2);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(95, 24);
            this.cmdStop.TabIndex = 4;
            this.cmdStop.Text = "Stop Keithley";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(3, 540);
            this.txtFilename.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(444, 20);
            this.txtFilename.TabIndex = 5;
            // 
            // MaxRange
            // 
            this.MaxRange.HeaderText = "Max. range";
            this.MaxRange.Name = "MaxRange";
            // 
            // KE2700Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.dgvKeithley2700);
            this.Controls.Add(this.cmdStart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "KE2700Control";
            this.Size = new System.Drawing.Size(647, 566);
            this.Load += new System.EventHandler(this.KE2700Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeithley2700)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.DataGridView dgvKeithley2700;
        private System.Windows.Forms.Button cmdStop;

        private KeithleySetupControl k2700Setup = new KeithleySetupControl();
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enabled;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxRange;
    }
}
