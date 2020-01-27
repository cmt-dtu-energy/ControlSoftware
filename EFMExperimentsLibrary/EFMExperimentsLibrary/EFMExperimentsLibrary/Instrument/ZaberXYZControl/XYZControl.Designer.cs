namespace EFMExperimentsLibrary
{
    partial class XYZControl
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

            if ( zaberPort != null )
                zaberPort.Close();
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblComPort = new System.Windows.Forms.Label();
            this.cmdMoveX = new System.Windows.Forms.Button();
            this.cmdMoveY = new System.Windows.Forms.Button();
            this.cmdMoveZ = new System.Windows.Forms.Button();
            this.txtMoveX = new System.Windows.Forms.TextBox();
            this.txtMoveY = new System.Windows.Forms.TextBox();
            this.txtMoveZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblXPos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.txtZPos = new System.Windows.Forms.TextBox();
            this.cmdOpenComPort = new System.Windows.Forms.Button();
            this.txtCOMPort = new System.Windows.Forms.TextBox();
            this.cmdYIncr = new System.Windows.Forms.Button();
            this.cmdYDecr = new System.Windows.Forms.Button();
            this.cmdXDecr = new System.Windows.Forms.Button();
            this.cmdXIncr = new System.Windows.Forms.Button();
            this.cmdZIncr = new System.Windows.Forms.Button();
            this.cmdZDecr = new System.Windows.Forms.Button();
            this.txtXIncr = new System.Windows.Forms.TextBox();
            this.txtYIncr = new System.Windows.Forms.TextBox();
            this.txtZIncr = new System.Windows.Forms.TextBox();
            this.lblXIncr = new System.Windows.Forms.Label();
            this.lblYIncr = new System.Windows.Forms.Label();
            this.lblZIncr = new System.Windows.Forms.Label();
            this.cmdHome = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.txtStartX = new System.Windows.Forms.TextBox();
            this.txtEndX = new System.Windows.Forms.TextBox();
            this.txtStartY = new System.Windows.Forms.TextBox();
            this.txtEndY = new System.Windows.Forms.TextBox();
            this.lblStartX = new System.Windows.Forms.Label();
            this.lblStartY = new System.Windows.Forms.Label();
            this.lblEndY = new System.Windows.Forms.Label();
            this.lblEndX = new System.Windows.Forms.Label();
            this.cmdStartPoint = new System.Windows.Forms.Button();
            this.cmdEndPoint = new System.Windows.Forms.Button();
            this.txtCurrentLoad = new System.Windows.Forms.TextBox();
            this.lblCurrentLoad = new System.Windows.Forms.Label();
            this.txtGotoLoad = new System.Windows.Forms.TextBox();
            this.lblGotoLoad = new System.Windows.Forms.Label();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmbLoadPort = new System.Windows.Forms.ComboBox();
            this.lblLoadPort = new System.Windows.Forms.Label();
            this.cmbSelectLoadCellExcitation = new System.Windows.Forms.ComboBox();
            this.lblLoadCellExcitationChannel = new System.Windows.Forms.Label();
            this.lblLoadIndicator = new System.Windows.Forms.Label();
            this.lblInitialized = new System.Windows.Forms.Label();
            this.txtIncrementX = new System.Windows.Forms.TextBox();
            this.lblNPointsX = new System.Windows.Forms.Label();
            this.lblNPointsY = new System.Windows.Forms.Label();
            this.txtIncrementY = new System.Windows.Forms.TextBox();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.txtTotalPoints = new System.Windows.Forms.TextBox();
            this.cmdGoToStartPoint = new System.Windows.Forms.Button();
            this.cmdGoToEndPoint = new System.Windows.Forms.Button();
            this.cmdgotoLoad = new System.Windows.Forms.Button();
            this.tempscan = new System.Windows.Forms.Button();
            this.numberOfPointsX = new System.Windows.Forms.TextBox();
            this.numberOfPointsY = new System.Windows.Forms.TextBox();
            this.lblnumberOfPointsX = new System.Windows.Forms.Label();
            this.lblnumberOfPointsY = new System.Windows.Forms.Label();
            this.abortscan = new System.Windows.Forms.Button();
            this.txttotalpointsmeasured = new System.Windows.Forms.TextBox();
            this.lblTotalPointsMeasured = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblScanState = new System.Windows.Forms.Label();
            this.cmdTareLoad = new System.Windows.Forms.Button();
            this.nudLoadIncrement = new System.Windows.Forms.NumericUpDown();
            this.lblLoadIncr = new System.Windows.Forms.Label();
            this.cmdResetError = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoadIncrement)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(19, 43);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(52, 13);
            this.lblComPort.TabIndex = 1;
            this.lblComPort.Text = "COM port";
            // 
            // cmdMoveX
            // 
            this.cmdMoveX.Location = new System.Drawing.Point(22, 122);
            this.cmdMoveX.Name = "cmdMoveX";
            this.cmdMoveX.Size = new System.Drawing.Size(55, 26);
            this.cmdMoveX.TabIndex = 3;
            this.cmdMoveX.Text = "Move X";
            this.cmdMoveX.UseVisualStyleBackColor = true;
            this.cmdMoveX.Click += new System.EventHandler(this.cmdMoveX_Click);
            // 
            // cmdMoveY
            // 
            this.cmdMoveY.Location = new System.Drawing.Point(23, 154);
            this.cmdMoveY.Name = "cmdMoveY";
            this.cmdMoveY.Size = new System.Drawing.Size(54, 26);
            this.cmdMoveY.TabIndex = 4;
            this.cmdMoveY.Text = "Move Y";
            this.cmdMoveY.UseVisualStyleBackColor = true;
            this.cmdMoveY.Click += new System.EventHandler(this.cmdMoveY_Click);
            // 
            // cmdMoveZ
            // 
            this.cmdMoveZ.Location = new System.Drawing.Point(23, 186);
            this.cmdMoveZ.Name = "cmdMoveZ";
            this.cmdMoveZ.Size = new System.Drawing.Size(54, 26);
            this.cmdMoveZ.TabIndex = 5;
            this.cmdMoveZ.Text = "Move Z";
            this.cmdMoveZ.UseVisualStyleBackColor = true;
            this.cmdMoveZ.Click += new System.EventHandler(this.cmdMoveZ_Click);
            // 
            // txtMoveX
            // 
            this.txtMoveX.Location = new System.Drawing.Point(107, 124);
            this.txtMoveX.Name = "txtMoveX";
            this.txtMoveX.Size = new System.Drawing.Size(75, 20);
            this.txtMoveX.TabIndex = 6;
            this.txtMoveX.TextChanged += new System.EventHandler(this.txtMoveX_TextChanged);
            // 
            // txtMoveY
            // 
            this.txtMoveY.Location = new System.Drawing.Point(107, 160);
            this.txtMoveY.Name = "txtMoveY";
            this.txtMoveY.Size = new System.Drawing.Size(75, 20);
            this.txtMoveY.TabIndex = 7;
            // 
            // txtMoveZ
            // 
            this.txtMoveZ.Location = new System.Drawing.Point(107, 192);
            this.txtMoveZ.Name = "txtMoveZ";
            this.txtMoveZ.Size = new System.Drawing.Size(75, 20);
            this.txtMoveZ.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Units are in mm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(32, 306);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(45, 13);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "No error";
            // 
            // lblXPos
            // 
            this.lblXPos.AutoSize = true;
            this.lblXPos.Location = new System.Drawing.Point(5, 227);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(71, 13);
            this.lblXPos.TabIndex = 12;
            this.lblXPos.Text = "Current X pos";
            this.lblXPos.Click += new System.EventHandler(this.lblXPos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Current Y pos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Current Z pos";
            // 
            // txtXPos
            // 
            this.txtXPos.Location = new System.Drawing.Point(107, 227);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.ReadOnly = true;
            this.txtXPos.Size = new System.Drawing.Size(91, 20);
            this.txtXPos.TabIndex = 15;
            this.txtXPos.TextChanged += new System.EventHandler(this.txtXPos_TextChanged);
            // 
            // txtYPos
            // 
            this.txtYPos.Location = new System.Drawing.Point(106, 253);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.ReadOnly = true;
            this.txtYPos.Size = new System.Drawing.Size(91, 20);
            this.txtYPos.TabIndex = 16;
            // 
            // txtZPos
            // 
            this.txtZPos.Location = new System.Drawing.Point(106, 279);
            this.txtZPos.Name = "txtZPos";
            this.txtZPos.ReadOnly = true;
            this.txtZPos.Size = new System.Drawing.Size(91, 20);
            this.txtZPos.TabIndex = 17;
            // 
            // cmdOpenComPort
            // 
            this.cmdOpenComPort.Location = new System.Drawing.Point(19, 63);
            this.cmdOpenComPort.Name = "cmdOpenComPort";
            this.cmdOpenComPort.Size = new System.Drawing.Size(90, 22);
            this.cmdOpenComPort.TabIndex = 18;
            this.cmdOpenComPort.Text = "Open COM port";
            this.cmdOpenComPort.UseVisualStyleBackColor = true;
            this.cmdOpenComPort.Click += new System.EventHandler(this.cmdOpenComPort_Click);
            // 
            // txtCOMPort
            // 
            this.txtCOMPort.Location = new System.Drawing.Point(116, 40);
            this.txtCOMPort.Name = "txtCOMPort";
            this.txtCOMPort.Size = new System.Drawing.Size(101, 20);
            this.txtCOMPort.TabIndex = 19;
            this.txtCOMPort.Text = "COM5";
            // 
            // cmdYIncr
            // 
            this.cmdYIncr.Location = new System.Drawing.Point(275, 89);
            this.cmdYIncr.Name = "cmdYIncr";
            this.cmdYIncr.Size = new System.Drawing.Size(72, 23);
            this.cmdYIncr.TabIndex = 20;
            this.cmdYIncr.Text = "Y forward";
            this.cmdYIncr.UseVisualStyleBackColor = true;
            this.cmdYIncr.Click += new System.EventHandler(this.cmdYIncr_Click);
            // 
            // cmdYDecr
            // 
            this.cmdYDecr.Location = new System.Drawing.Point(275, 126);
            this.cmdYDecr.Name = "cmdYDecr";
            this.cmdYDecr.Size = new System.Drawing.Size(72, 23);
            this.cmdYDecr.TabIndex = 21;
            this.cmdYDecr.Text = "Y backward";
            this.cmdYDecr.UseVisualStyleBackColor = true;
            this.cmdYDecr.Click += new System.EventHandler(this.cmdYDecr_Click);
            // 
            // cmdXDecr
            // 
            this.cmdXDecr.Location = new System.Drawing.Point(215, 108);
            this.cmdXDecr.Name = "cmdXDecr";
            this.cmdXDecr.Size = new System.Drawing.Size(54, 23);
            this.cmdXDecr.TabIndex = 22;
            this.cmdXDecr.Text = "X left";
            this.cmdXDecr.UseVisualStyleBackColor = true;
            this.cmdXDecr.Click += new System.EventHandler(this.cmdXDecr_Click);
            // 
            // cmdXIncr
            // 
            this.cmdXIncr.Location = new System.Drawing.Point(353, 108);
            this.cmdXIncr.Name = "cmdXIncr";
            this.cmdXIncr.Size = new System.Drawing.Size(54, 23);
            this.cmdXIncr.TabIndex = 23;
            this.cmdXIncr.Text = "X right";
            this.cmdXIncr.UseVisualStyleBackColor = true;
            this.cmdXIncr.Click += new System.EventHandler(this.cmdXIncr_Click);
            // 
            // cmdZIncr
            // 
            this.cmdZIncr.Location = new System.Drawing.Point(275, 163);
            this.cmdZIncr.Name = "cmdZIncr";
            this.cmdZIncr.Size = new System.Drawing.Size(72, 23);
            this.cmdZIncr.TabIndex = 24;
            this.cmdZIncr.Text = "Z up";
            this.cmdZIncr.UseVisualStyleBackColor = true;
            this.cmdZIncr.Click += new System.EventHandler(this.cmdZIncr_Click);
            // 
            // cmdZDecr
            // 
            this.cmdZDecr.Location = new System.Drawing.Point(275, 192);
            this.cmdZDecr.Name = "cmdZDecr";
            this.cmdZDecr.Size = new System.Drawing.Size(72, 23);
            this.cmdZDecr.TabIndex = 25;
            this.cmdZDecr.Text = "Z down";
            this.cmdZDecr.UseVisualStyleBackColor = true;
            this.cmdZDecr.Click += new System.EventHandler(this.cmdZDecr_Click);
            // 
            // txtXIncr
            // 
            this.txtXIncr.Location = new System.Drawing.Point(275, 224);
            this.txtXIncr.Name = "txtXIncr";
            this.txtXIncr.Size = new System.Drawing.Size(77, 20);
            this.txtXIncr.TabIndex = 26;
            this.txtXIncr.Text = "1";
            this.txtXIncr.TextChanged += new System.EventHandler(this.txtXIncr_TextChanged);
            // 
            // txtYIncr
            // 
            this.txtYIncr.Location = new System.Drawing.Point(275, 254);
            this.txtYIncr.Name = "txtYIncr";
            this.txtYIncr.Size = new System.Drawing.Size(77, 20);
            this.txtYIncr.TabIndex = 27;
            this.txtYIncr.Text = "1";
            this.txtYIncr.TextChanged += new System.EventHandler(this.txtYIncr_TextChanged);
            // 
            // txtZIncr
            // 
            this.txtZIncr.Location = new System.Drawing.Point(275, 283);
            this.txtZIncr.Name = "txtZIncr";
            this.txtZIncr.Size = new System.Drawing.Size(77, 20);
            this.txtZIncr.TabIndex = 28;
            this.txtZIncr.Text = "1";
            this.txtZIncr.TextChanged += new System.EventHandler(this.txtZIncr_TextChanged);
            // 
            // lblXIncr
            // 
            this.lblXIncr.AutoSize = true;
            this.lblXIncr.Location = new System.Drawing.Point(206, 227);
            this.lblXIncr.Name = "lblXIncr";
            this.lblXIncr.Size = new System.Drawing.Size(63, 13);
            this.lblXIncr.TabIndex = 29;
            this.lblXIncr.Text = "X increment";
            // 
            // lblYIncr
            // 
            this.lblYIncr.AutoSize = true;
            this.lblYIncr.Location = new System.Drawing.Point(206, 257);
            this.lblYIncr.Name = "lblYIncr";
            this.lblYIncr.Size = new System.Drawing.Size(63, 13);
            this.lblYIncr.TabIndex = 30;
            this.lblYIncr.Text = "Y increment";
            // 
            // lblZIncr
            // 
            this.lblZIncr.AutoSize = true;
            this.lblZIncr.Location = new System.Drawing.Point(206, 286);
            this.lblZIncr.Name = "lblZIncr";
            this.lblZIncr.Size = new System.Drawing.Size(63, 13);
            this.lblZIncr.TabIndex = 31;
            this.lblZIncr.Text = "Z increment";
            this.lblZIncr.Click += new System.EventHandler(this.lblZIncr_Click);
            // 
            // cmdHome
            // 
            this.cmdHome.Location = new System.Drawing.Point(290, 66);
            this.cmdHome.Name = "cmdHome";
            this.cmdHome.Size = new System.Drawing.Size(69, 22);
            this.cmdHome.TabIndex = 32;
            this.cmdHome.Text = "Home axes";
            this.cmdHome.UseVisualStyleBackColor = true;
            this.cmdHome.Click += new System.EventHandler(this.cmdHome_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(150, 9);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(184, 25);
            this.lblState.TabIndex = 33;
            this.lblState.Text = "Current state: idle";
            this.lblState.Click += new System.EventHandler(this.lblState_Click);
            // 
            // txtStartX
            // 
            this.txtStartX.Location = new System.Drawing.Point(257, 338);
            this.txtStartX.Margin = new System.Windows.Forms.Padding(2);
            this.txtStartX.Name = "txtStartX";
            this.txtStartX.ReadOnly = true;
            this.txtStartX.Size = new System.Drawing.Size(77, 20);
            this.txtStartX.TabIndex = 34;
            this.txtStartX.TextChanged += new System.EventHandler(this.txtStartX_TextChanged);
            // 
            // txtEndX
            // 
            this.txtEndX.Location = new System.Drawing.Point(257, 383);
            this.txtEndX.Margin = new System.Windows.Forms.Padding(2);
            this.txtEndX.Name = "txtEndX";
            this.txtEndX.ReadOnly = true;
            this.txtEndX.Size = new System.Drawing.Size(77, 20);
            this.txtEndX.TabIndex = 35;
            // 
            // txtStartY
            // 
            this.txtStartY.Location = new System.Drawing.Point(257, 360);
            this.txtStartY.Margin = new System.Windows.Forms.Padding(2);
            this.txtStartY.Name = "txtStartY";
            this.txtStartY.ReadOnly = true;
            this.txtStartY.Size = new System.Drawing.Size(77, 20);
            this.txtStartY.TabIndex = 36;
            this.txtStartY.TextChanged += new System.EventHandler(this.txtStartY_TextChanged);
            // 
            // txtEndY
            // 
            this.txtEndY.Location = new System.Drawing.Point(257, 407);
            this.txtEndY.Margin = new System.Windows.Forms.Padding(2);
            this.txtEndY.Name = "txtEndY";
            this.txtEndY.ReadOnly = true;
            this.txtEndY.Size = new System.Drawing.Size(77, 20);
            this.txtEndY.TabIndex = 37;
            // 
            // lblStartX
            // 
            this.lblStartX.AutoSize = true;
            this.lblStartX.Location = new System.Drawing.Point(212, 341);
            this.lblStartX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartX.Name = "lblStartX";
            this.lblStartX.Size = new System.Drawing.Size(39, 13);
            this.lblStartX.TabIndex = 38;
            this.lblStartX.Text = "Start X";
            this.lblStartX.Click += new System.EventHandler(this.lblStartX_Click);
            // 
            // lblStartY
            // 
            this.lblStartY.AutoSize = true;
            this.lblStartY.Location = new System.Drawing.Point(212, 363);
            this.lblStartY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartY.Name = "lblStartY";
            this.lblStartY.Size = new System.Drawing.Size(39, 13);
            this.lblStartY.TabIndex = 39;
            this.lblStartY.Text = "Start Y";
            // 
            // lblEndY
            // 
            this.lblEndY.AutoSize = true;
            this.lblEndY.Location = new System.Drawing.Point(217, 410);
            this.lblEndY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndY.Name = "lblEndY";
            this.lblEndY.Size = new System.Drawing.Size(36, 13);
            this.lblEndY.TabIndex = 41;
            this.lblEndY.Text = "End Y";
            // 
            // lblEndX
            // 
            this.lblEndX.AutoSize = true;
            this.lblEndX.Location = new System.Drawing.Point(217, 389);
            this.lblEndX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndX.Name = "lblEndX";
            this.lblEndX.Size = new System.Drawing.Size(36, 13);
            this.lblEndX.TabIndex = 40;
            this.lblEndX.Text = "End X";
            // 
            // cmdStartPoint
            // 
            this.cmdStartPoint.Location = new System.Drawing.Point(241, 431);
            this.cmdStartPoint.Margin = new System.Windows.Forms.Padding(2);
            this.cmdStartPoint.Name = "cmdStartPoint";
            this.cmdStartPoint.Size = new System.Drawing.Size(88, 32);
            this.cmdStartPoint.TabIndex = 42;
            this.cmdStartPoint.Text = "Set start point";
            this.cmdStartPoint.UseVisualStyleBackColor = true;
            this.cmdStartPoint.Click += new System.EventHandler(this.cmdStartPoint_Click);
            // 
            // cmdEndPoint
            // 
            this.cmdEndPoint.Location = new System.Drawing.Point(355, 431);
            this.cmdEndPoint.Margin = new System.Windows.Forms.Padding(2);
            this.cmdEndPoint.Name = "cmdEndPoint";
            this.cmdEndPoint.Size = new System.Drawing.Size(88, 32);
            this.cmdEndPoint.TabIndex = 43;
            this.cmdEndPoint.Text = "Set end point";
            this.cmdEndPoint.UseVisualStyleBackColor = true;
            this.cmdEndPoint.Click += new System.EventHandler(this.cmdEndPoint_Click);
            // 
            // txtCurrentLoad
            // 
            this.txtCurrentLoad.Location = new System.Drawing.Point(101, 338);
            this.txtCurrentLoad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrentLoad.Name = "txtCurrentLoad";
            this.txtCurrentLoad.ReadOnly = true;
            this.txtCurrentLoad.Size = new System.Drawing.Size(99, 20);
            this.txtCurrentLoad.TabIndex = 44;
            this.txtCurrentLoad.TextChanged += new System.EventHandler(this.txtCurrentLoad_TextChanged);
            // 
            // lblCurrentLoad
            // 
            this.lblCurrentLoad.AutoSize = true;
            this.lblCurrentLoad.Location = new System.Drawing.Point(5, 341);
            this.lblCurrentLoad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentLoad.Name = "lblCurrentLoad";
            this.lblCurrentLoad.Size = new System.Drawing.Size(81, 13);
            this.lblCurrentLoad.TabIndex = 45;
            this.lblCurrentLoad.Text = "Current load (N)";
            // 
            // txtGotoLoad
            // 
            this.txtGotoLoad.Location = new System.Drawing.Point(101, 360);
            this.txtGotoLoad.Margin = new System.Windows.Forms.Padding(2);
            this.txtGotoLoad.Name = "txtGotoLoad";
            this.txtGotoLoad.ReadOnly = true;
            this.txtGotoLoad.Size = new System.Drawing.Size(99, 20);
            this.txtGotoLoad.TabIndex = 46;
            this.txtGotoLoad.TextChanged += new System.EventHandler(this.txtGotoLoad_TextChanged);
            // 
            // lblGotoLoad
            // 
            this.lblGotoLoad.AutoSize = true;
            this.lblGotoLoad.Location = new System.Drawing.Point(16, 363);
            this.lblGotoLoad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGotoLoad.Name = "lblGotoLoad";
            this.lblGotoLoad.Size = new System.Drawing.Size(70, 13);
            this.lblGotoLoad.TabIndex = 47;
            this.lblGotoLoad.Text = "Goto load (N)";
            this.lblGotoLoad.Click += new System.EventHandler(this.lblGotoLoad_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(98, 384);
            this.cmdLoad.Margin = new System.Windows.Forms.Padding(2);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(100, 23);
            this.cmdLoad.TabIndex = 48;
            this.cmdLoad.Text = "Set load";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmbLoadPort
            // 
            this.cmbLoadPort.FormattingEnabled = true;
            this.cmbLoadPort.Location = new System.Drawing.Point(123, 459);
            this.cmbLoadPort.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLoadPort.Name = "cmbLoadPort";
            this.cmbLoadPort.Size = new System.Drawing.Size(100, 21);
            this.cmbLoadPort.TabIndex = 49;
            this.cmbLoadPort.Text = "Select load port";
            this.cmbLoadPort.SelectedIndexChanged += new System.EventHandler(this.cmbLoadPort_SelectedIndexChanged);
            // 
            // lblLoadPort
            // 
            this.lblLoadPort.AutoSize = true;
            this.lblLoadPort.Location = new System.Drawing.Point(5, 462);
            this.lblLoadPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoadPort.Name = "lblLoadPort";
            this.lblLoadPort.Size = new System.Drawing.Size(81, 13);
            this.lblLoadPort.TabIndex = 50;
            this.lblLoadPort.Text = "Select load port";
            // 
            // cmbSelectLoadCellExcitation
            // 
            this.cmbSelectLoadCellExcitation.FormattingEnabled = true;
            this.cmbSelectLoadCellExcitation.Location = new System.Drawing.Point(123, 484);
            this.cmbSelectLoadCellExcitation.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSelectLoadCellExcitation.Name = "cmbSelectLoadCellExcitation";
            this.cmbSelectLoadCellExcitation.Size = new System.Drawing.Size(94, 21);
            this.cmbSelectLoadCellExcitation.TabIndex = 51;
            this.cmbSelectLoadCellExcitation.Text = "Select load cell excitation channel";
            this.cmbSelectLoadCellExcitation.SelectedIndexChanged += new System.EventHandler(this.cmbSelectLoadCellExcitation_SelectedIndexChanged);
            // 
            // lblLoadCellExcitationChannel
            // 
            this.lblLoadCellExcitationChannel.AutoSize = true;
            this.lblLoadCellExcitationChannel.Location = new System.Drawing.Point(5, 487);
            this.lblLoadCellExcitationChannel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoadCellExcitationChannel.Name = "lblLoadCellExcitationChannel";
            this.lblLoadCellExcitationChannel.Size = new System.Drawing.Size(113, 13);
            this.lblLoadCellExcitationChannel.TabIndex = 52;
            this.lblLoadCellExcitationChannel.Text = "Cell excitation channel";
            // 
            // lblLoadIndicator
            // 
            this.lblLoadIndicator.AutoSize = true;
            this.lblLoadIndicator.Location = new System.Drawing.Point(356, 141);
            this.lblLoadIndicator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoadIndicator.Name = "lblLoadIndicator";
            this.lblLoadIndicator.Size = new System.Drawing.Size(107, 13);
            this.lblLoadIndicator.TabIndex = 53;
            this.lblLoadIndicator.Text = "Probe is not touching";
            // 
            // lblInitialized
            // 
            this.lblInitialized.AutoSize = true;
            this.lblInitialized.Location = new System.Drawing.Point(115, 68);
            this.lblInitialized.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInitialized.Name = "lblInitialized";
            this.lblInitialized.Size = new System.Drawing.Size(69, 13);
            this.lblInitialized.TabIndex = 54;
            this.lblInitialized.Text = "Not initialized";
            // 
            // txtIncrementX
            // 
            this.txtIncrementX.Location = new System.Drawing.Point(422, 338);
            this.txtIncrementX.Margin = new System.Windows.Forms.Padding(2);
            this.txtIncrementX.Name = "txtIncrementX";
            this.txtIncrementX.ReadOnly = true;
            this.txtIncrementX.Size = new System.Drawing.Size(56, 20);
            this.txtIncrementX.TabIndex = 55;
            this.txtIncrementX.TextChanged += new System.EventHandler(this.txtIncrementX_TextChanged);
            // 
            // lblNPointsX
            // 
            this.lblNPointsX.AutoSize = true;
            this.lblNPointsX.Location = new System.Drawing.Point(355, 341);
            this.lblNPointsX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNPointsX.Name = "lblNPointsX";
            this.lblNPointsX.Size = new System.Drawing.Size(64, 13);
            this.lblNPointsX.TabIndex = 56;
            this.lblNPointsX.Text = "X Increment";
            this.lblNPointsX.Click += new System.EventHandler(this.lblIncrementX_Click);
            // 
            // lblNPointsY
            // 
            this.lblNPointsY.AutoSize = true;
            this.lblNPointsY.Location = new System.Drawing.Point(355, 363);
            this.lblNPointsY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNPointsY.Name = "lblNPointsY";
            this.lblNPointsY.Size = new System.Drawing.Size(63, 13);
            this.lblNPointsY.TabIndex = 58;
            this.lblNPointsY.Text = "Y increment";
            this.lblNPointsY.Click += new System.EventHandler(this.lblIncrementY_Click);
            // 
            // txtIncrementY
            // 
            this.txtIncrementY.Location = new System.Drawing.Point(422, 360);
            this.txtIncrementY.Margin = new System.Windows.Forms.Padding(2);
            this.txtIncrementY.Name = "txtIncrementY";
            this.txtIncrementY.ReadOnly = true;
            this.txtIncrementY.Size = new System.Drawing.Size(56, 20);
            this.txtIncrementY.TabIndex = 57;
            this.txtIncrementY.TextChanged += new System.EventHandler(this.txtIncrementY_TextChanged);
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.AutoSize = true;
            this.lblTotalPoints.Location = new System.Drawing.Point(365, 386);
            this.lblTotalPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(48, 13);
            this.lblTotalPoints.TabIndex = 60;
            this.lblTotalPoints.Text = "Total pts";
            this.lblTotalPoints.Click += new System.EventHandler(this.lblTotalPoints_Click);
            // 
            // txtTotalPoints
            // 
            this.txtTotalPoints.Location = new System.Drawing.Point(422, 383);
            this.txtTotalPoints.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalPoints.Name = "txtTotalPoints";
            this.txtTotalPoints.ReadOnly = true;
            this.txtTotalPoints.Size = new System.Drawing.Size(56, 20);
            this.txtTotalPoints.TabIndex = 59;
            this.txtTotalPoints.TextChanged += new System.EventHandler(this.txtTotalPoints_TextChanged);
            // 
            // cmdGoToStartPoint
            // 
            this.cmdGoToStartPoint.Location = new System.Drawing.Point(241, 468);
            this.cmdGoToStartPoint.Name = "cmdGoToStartPoint";
            this.cmdGoToStartPoint.Size = new System.Drawing.Size(108, 23);
            this.cmdGoToStartPoint.TabIndex = 61;
            this.cmdGoToStartPoint.Text = "Go to start point";
            this.cmdGoToStartPoint.UseVisualStyleBackColor = true;
            this.cmdGoToStartPoint.Click += new System.EventHandler(this.cmdgotoStartPoint_Click);
            // 
            // cmdGoToEndPoint
            // 
            this.cmdGoToEndPoint.Location = new System.Drawing.Point(355, 468);
            this.cmdGoToEndPoint.Name = "cmdGoToEndPoint";
            this.cmdGoToEndPoint.Size = new System.Drawing.Size(108, 23);
            this.cmdGoToEndPoint.TabIndex = 62;
            this.cmdGoToEndPoint.Text = "Go to end point";
            this.cmdGoToEndPoint.UseVisualStyleBackColor = true;
            this.cmdGoToEndPoint.Click += new System.EventHandler(this.cmdGoToEndPoint_Click);
            // 
            // cmdgotoLoad
            // 
            this.cmdgotoLoad.Location = new System.Drawing.Point(98, 412);
            this.cmdgotoLoad.Name = "cmdgotoLoad";
            this.cmdgotoLoad.Size = new System.Drawing.Size(103, 36);
            this.cmdgotoLoad.TabIndex = 63;
            this.cmdgotoLoad.Text = "Go to load (establish contact)";
            this.cmdgotoLoad.UseVisualStyleBackColor = true;
            this.cmdgotoLoad.Click += new System.EventHandler(this.cmdgotoLoad_Click);
            // 
            // tempscan
            // 
            this.tempscan.Location = new System.Drawing.Point(254, 504);
            this.tempscan.Name = "tempscan";
            this.tempscan.Size = new System.Drawing.Size(75, 23);
            this.tempscan.TabIndex = 65;
            this.tempscan.Text = "Temp scan\r\n";
            this.tempscan.UseVisualStyleBackColor = true;
            this.tempscan.Click += new System.EventHandler(this.tempscan_Click);
            // 
            // numberOfPointsX
            // 
            this.numberOfPointsX.Location = new System.Drawing.Point(438, 224);
            this.numberOfPointsX.Name = "numberOfPointsX";
            this.numberOfPointsX.Size = new System.Drawing.Size(25, 20);
            this.numberOfPointsX.TabIndex = 66;
            this.numberOfPointsX.TextChanged += new System.EventHandler(this.numberOfPointsX_TextChanged);
            // 
            // numberOfPointsY
            // 
            this.numberOfPointsY.Location = new System.Drawing.Point(438, 253);
            this.numberOfPointsY.Name = "numberOfPointsY";
            this.numberOfPointsY.Size = new System.Drawing.Size(25, 20);
            this.numberOfPointsY.TabIndex = 67;
            this.numberOfPointsY.TextChanged += new System.EventHandler(this.numberOfPointsY_TextChanged);
            // 
            // lblnumberOfPointsX
            // 
            this.lblnumberOfPointsX.AutoSize = true;
            this.lblnumberOfPointsX.Location = new System.Drawing.Point(377, 227);
            this.lblnumberOfPointsX.Name = "lblnumberOfPointsX";
            this.lblnumberOfPointsX.Size = new System.Drawing.Size(55, 13);
            this.lblnumberOfPointsX.TabIndex = 68;
            this.lblnumberOfPointsX.Text = "# points X";
            this.lblnumberOfPointsX.Click += new System.EventHandler(this.lblnumberOfPointsX_Click);
            // 
            // lblnumberOfPointsY
            // 
            this.lblnumberOfPointsY.AutoSize = true;
            this.lblnumberOfPointsY.Location = new System.Drawing.Point(377, 256);
            this.lblnumberOfPointsY.Name = "lblnumberOfPointsY";
            this.lblnumberOfPointsY.Size = new System.Drawing.Size(55, 13);
            this.lblnumberOfPointsY.TabIndex = 69;
            this.lblnumberOfPointsY.Text = "# points Y";
            this.lblnumberOfPointsY.Click += new System.EventHandler(this.lblnumberOfPointsY_Click);
            // 
            // abortscan
            // 
            this.abortscan.Location = new System.Drawing.Point(364, 504);
            this.abortscan.Name = "abortscan";
            this.abortscan.Size = new System.Drawing.Size(75, 23);
            this.abortscan.TabIndex = 70;
            this.abortscan.Text = "Abort scan";
            this.abortscan.UseVisualStyleBackColor = true;
            this.abortscan.Click += new System.EventHandler(this.abortscan_Click);
            // 
            // txttotalpointsmeasured
            // 
            this.txttotalpointsmeasured.Location = new System.Drawing.Point(422, 407);
            this.txttotalpointsmeasured.Margin = new System.Windows.Forms.Padding(2);
            this.txttotalpointsmeasured.Name = "txttotalpointsmeasured";
            this.txttotalpointsmeasured.ReadOnly = true;
            this.txttotalpointsmeasured.Size = new System.Drawing.Size(56, 20);
            this.txttotalpointsmeasured.TabIndex = 71;
            this.txttotalpointsmeasured.TextChanged += new System.EventHandler(this.txttotalpointsmeasured_TextChanged);
            // 
            // lblTotalPointsMeasured
            // 
            this.lblTotalPointsMeasured.AutoSize = true;
            this.lblTotalPointsMeasured.Location = new System.Drawing.Point(334, 410);
            this.lblTotalPointsMeasured.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPointsMeasured.Name = "lblTotalPointsMeasured";
            this.lblTotalPointsMeasured.Size = new System.Drawing.Size(85, 13);
            this.lblTotalPointsMeasured.TabIndex = 72;
            this.lblTotalPointsMeasured.Text = "Points measured";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 28);
            this.label4.TabIndex = 73;
            this.label4.Text = "Stage Control";
            // 
            // lblScanState
            // 
            this.lblScanState.AutoSize = true;
            this.lblScanState.Location = new System.Drawing.Point(361, 164);
            this.lblScanState.Name = "lblScanState";
            this.lblScanState.Size = new System.Drawing.Size(58, 13);
            this.lblScanState.TabIndex = 74;
            this.lblScanState.Text = "Scan state";
            // 
            // cmdTareLoad
            // 
            this.cmdTareLoad.Location = new System.Drawing.Point(17, 384);
            this.cmdTareLoad.Name = "cmdTareLoad";
            this.cmdTareLoad.Size = new System.Drawing.Size(68, 23);
            this.cmdTareLoad.TabIndex = 75;
            this.cmdTareLoad.Text = "Zero";
            this.cmdTareLoad.UseVisualStyleBackColor = true;
            this.cmdTareLoad.Click += new System.EventHandler(this.cmdTareLoad_Click);
            // 
            // nudLoadIncrement
            // 
            this.nudLoadIncrement.DecimalPlaces = 3;
            this.nudLoadIncrement.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLoadIncrement.Location = new System.Drawing.Point(12, 433);
            this.nudLoadIncrement.Name = "nudLoadIncrement";
            this.nudLoadIncrement.Size = new System.Drawing.Size(73, 20);
            this.nudLoadIncrement.TabIndex = 76;
            this.nudLoadIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // lblLoadIncr
            // 
            this.lblLoadIncr.AutoSize = true;
            this.lblLoadIncr.Location = new System.Drawing.Point(9, 414);
            this.lblLoadIncr.Name = "lblLoadIncr";
            this.lblLoadIncr.Size = new System.Drawing.Size(73, 13);
            this.lblLoadIncr.TabIndex = 77;
            this.lblLoadIncr.Text = "Goto load incr";
            // 
            // cmdResetError
            // 
            this.cmdResetError.Location = new System.Drawing.Point(215, 66);
            this.cmdResetError.Name = "cmdResetError";
            this.cmdResetError.Size = new System.Drawing.Size(69, 21);
            this.cmdResetError.TabIndex = 78;
            this.cmdResetError.Text = "Reset error";
            this.cmdResetError.UseVisualStyleBackColor = true;
            this.cmdResetError.Click += new System.EventHandler(this.cmdResetError_Click);
            // 
            // XYZControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmdResetError);
            this.Controls.Add(this.lblLoadIncr);
            this.Controls.Add(this.nudLoadIncrement);
            this.Controls.Add(this.cmdTareLoad);
            this.Controls.Add(this.lblScanState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalPointsMeasured);
            this.Controls.Add(this.txttotalpointsmeasured);
            this.Controls.Add(this.abortscan);
            this.Controls.Add(this.lblnumberOfPointsY);
            this.Controls.Add(this.lblnumberOfPointsX);
            this.Controls.Add(this.numberOfPointsY);
            this.Controls.Add(this.numberOfPointsX);
            this.Controls.Add(this.tempscan);
            this.Controls.Add(this.cmdgotoLoad);
            this.Controls.Add(this.cmdGoToEndPoint);
            this.Controls.Add(this.cmdGoToStartPoint);
            this.Controls.Add(this.lblTotalPoints);
            this.Controls.Add(this.txtTotalPoints);
            this.Controls.Add(this.lblNPointsY);
            this.Controls.Add(this.txtIncrementY);
            this.Controls.Add(this.lblNPointsX);
            this.Controls.Add(this.txtIncrementX);
            this.Controls.Add(this.lblInitialized);
            this.Controls.Add(this.lblLoadIndicator);
            this.Controls.Add(this.lblLoadCellExcitationChannel);
            this.Controls.Add(this.cmbSelectLoadCellExcitation);
            this.Controls.Add(this.lblLoadPort);
            this.Controls.Add(this.cmbLoadPort);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.lblGotoLoad);
            this.Controls.Add(this.txtGotoLoad);
            this.Controls.Add(this.lblCurrentLoad);
            this.Controls.Add(this.txtCurrentLoad);
            this.Controls.Add(this.cmdEndPoint);
            this.Controls.Add(this.cmdStartPoint);
            this.Controls.Add(this.lblEndY);
            this.Controls.Add(this.lblEndX);
            this.Controls.Add(this.lblStartY);
            this.Controls.Add(this.lblStartX);
            this.Controls.Add(this.txtEndY);
            this.Controls.Add(this.txtStartY);
            this.Controls.Add(this.txtEndX);
            this.Controls.Add(this.txtStartX);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.cmdHome);
            this.Controls.Add(this.lblZIncr);
            this.Controls.Add(this.lblYIncr);
            this.Controls.Add(this.lblXIncr);
            this.Controls.Add(this.txtZIncr);
            this.Controls.Add(this.txtYIncr);
            this.Controls.Add(this.txtXIncr);
            this.Controls.Add(this.cmdZDecr);
            this.Controls.Add(this.cmdZIncr);
            this.Controls.Add(this.cmdXIncr);
            this.Controls.Add(this.cmdXDecr);
            this.Controls.Add(this.cmdYDecr);
            this.Controls.Add(this.cmdYIncr);
            this.Controls.Add(this.txtCOMPort);
            this.Controls.Add(this.cmdOpenComPort);
            this.Controls.Add(this.txtZPos);
            this.Controls.Add(this.txtYPos);
            this.Controls.Add(this.txtXPos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblXPos);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMoveZ);
            this.Controls.Add(this.txtMoveY);
            this.Controls.Add(this.txtMoveX);
            this.Controls.Add(this.cmdMoveZ);
            this.Controls.Add(this.cmdMoveY);
            this.Controls.Add(this.cmdMoveX);
            this.Controls.Add(this.lblComPort);
            this.Name = "XYZControl";
            this.Size = new System.Drawing.Size(480, 536);
            this.Load += new System.EventHandler(this.XYZControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLoadIncrement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.Button cmdMoveX;
        private System.Windows.Forms.Button cmdMoveY;
        private System.Windows.Forms.Button cmdMoveZ;
        private System.Windows.Forms.TextBox txtMoveX;
        private System.Windows.Forms.TextBox txtMoveY;
        private System.Windows.Forms.TextBox txtMoveZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.TextBox txtZPos;
        private System.Windows.Forms.Button cmdOpenComPort;
        private System.Windows.Forms.TextBox txtCOMPort;
        private System.Windows.Forms.Button cmdYIncr;
        private System.Windows.Forms.Button cmdYDecr;
        private System.Windows.Forms.Button cmdXDecr;
        private System.Windows.Forms.Button cmdXIncr;
        private System.Windows.Forms.Button cmdZIncr;
        private System.Windows.Forms.Button cmdZDecr;
        private System.Windows.Forms.TextBox txtXIncr;
        private System.Windows.Forms.TextBox txtYIncr;
        private System.Windows.Forms.TextBox txtZIncr;
        private System.Windows.Forms.Label lblXIncr;
        private System.Windows.Forms.Label lblYIncr;
        private System.Windows.Forms.Label lblZIncr;
        private System.Windows.Forms.Button cmdHome;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtStartX;
        private System.Windows.Forms.TextBox txtEndX;
        private System.Windows.Forms.TextBox txtStartY;
        private System.Windows.Forms.TextBox txtEndY;
        private System.Windows.Forms.Label lblStartX;
        private System.Windows.Forms.Label lblStartY;
        private System.Windows.Forms.Label lblEndY;
        private System.Windows.Forms.Label lblEndX;
        private System.Windows.Forms.Button cmdStartPoint;
        private System.Windows.Forms.Button cmdEndPoint;
        private System.Windows.Forms.TextBox txtCurrentLoad;
        private System.Windows.Forms.Label lblCurrentLoad;
        private System.Windows.Forms.TextBox txtGotoLoad;
        private System.Windows.Forms.Label lblGotoLoad;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.ComboBox cmbLoadPort;
        private System.Windows.Forms.Label lblLoadPort;
        private System.Windows.Forms.ComboBox cmbSelectLoadCellExcitation;
        private System.Windows.Forms.Label lblLoadCellExcitationChannel;
        private System.Windows.Forms.Label lblLoadIndicator;
        private System.Windows.Forms.Label lblInitialized;
        private System.Windows.Forms.TextBox txtIncrementX;
        private System.Windows.Forms.Label lblNPointsX;
        private System.Windows.Forms.Label lblNPointsY;
        private System.Windows.Forms.TextBox txtIncrementY;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.TextBox txtTotalPoints;
        private System.Windows.Forms.Button cmdGoToStartPoint;
        private System.Windows.Forms.Button cmdGoToEndPoint;
        private System.Windows.Forms.Button cmdgotoLoad;
        private System.Windows.Forms.Button tempscan;
        private System.Windows.Forms.TextBox numberOfPointsX;
        private System.Windows.Forms.TextBox numberOfPointsY;
        private System.Windows.Forms.Label lblnumberOfPointsX;
        private System.Windows.Forms.Label lblnumberOfPointsY;
        private System.Windows.Forms.Button abortscan;
        private System.Windows.Forms.TextBox txttotalpointsmeasured;
        private System.Windows.Forms.Label lblTotalPointsMeasured;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblScanState;
        private System.Windows.Forms.Button cmdTareLoad;
        private System.Windows.Forms.NumericUpDown nudLoadIncrement;
        private System.Windows.Forms.Label lblLoadIncr;
        private System.Windows.Forms.Button cmdResetError;
    }
}
