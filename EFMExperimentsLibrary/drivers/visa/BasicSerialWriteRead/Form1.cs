using System;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NationalInstruments.VisaNS;
using System.Runtime.InteropServices;

namespace BasicSerialWriteRead
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox VISAResource;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox BaudRate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox DataBits;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Delay;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox Parity;
		private System.Windows.Forms.ListBox FlowControl;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox WriteBuffer;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox ReadBuffer;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox BytesRead;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button Start;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListBox StopBits2;
		private AxCWUIControlsLib.AxCWButton axCWButton1;
		private AxCWUIControlsLib.AxCWButton axCWButton2;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public string myAlias, parity, flowControlText, writeBuffer, readBuffer, stopBits;
		public NationalInstruments.VisaNS.SerialSession mySession;
		public NationalInstruments.VisaNS.FlowControlTypes flowControl;
		public int baudRate, bytesRead;
		public short dataBits;
		private System.Windows.Forms.Label label11;
		public int readDelay;
		


		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.VISAResource = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BaudRate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DataBits = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Delay = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Parity = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.FlowControl = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.WriteBuffer = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ReadBuffer = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.BytesRead = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.Start = new System.Windows.Forms.Button();
			this.axCWButton1 = new AxCWUIControlsLib.AxCWButton();
			this.axCWButton2 = new AxCWUIControlsLib.AxCWButton();
			this.StopBits2 = new System.Windows.Forms.ListBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.axCWButton1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.axCWButton2)).BeginInit();
			this.SuspendLayout();
			// 
			// VISAResource
			// 
			this.VISAResource.Location = new System.Drawing.Point(24, 88);
			this.VISAResource.Name = "VISAResource";
			this.VISAResource.Size = new System.Drawing.Size(176, 21);
			this.VISAResource.TabIndex = 0;
			this.VISAResource.SelectedIndexChanged += new System.EventHandler(this.VISAResource_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "VISA Resource Name";
			// 
			// BaudRate
			// 
			this.BaudRate.Location = new System.Drawing.Point(24, 128);
			this.BaudRate.Name = "BaudRate";
			this.BaudRate.Size = new System.Drawing.Size(176, 20);
			this.BaudRate.TabIndex = 2;
			this.BaudRate.Text = "9600";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Baud Rate";
			// 
			// DataBits
			// 
			this.DataBits.Location = new System.Drawing.Point(24, 168);
			this.DataBits.Name = "DataBits";
			this.DataBits.Size = new System.Drawing.Size(176, 20);
			this.DataBits.TabIndex = 4;
			this.DataBits.Text = "8";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Data Bits";
			// 
			// Delay
			// 
			this.Delay.Location = new System.Drawing.Point(24, 208);
			this.Delay.Name = "Delay";
			this.Delay.Size = new System.Drawing.Size(176, 20);
			this.Delay.TabIndex = 6;
			this.Delay.Text = "500";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(140, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Delay Before Read (ms)";
			// 
			// Parity
			// 
			this.Parity.Items.AddRange(new object[] {
														"None",
														"Odd",
														"Even",
														"Mark",
														"Space"});
			this.Parity.Location = new System.Drawing.Point(24, 248);
			this.Parity.Name = "Parity";
			this.Parity.Size = new System.Drawing.Size(176, 17);
			this.Parity.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 232);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Parity";
			// 
			// FlowControl
			// 
			this.FlowControl.Items.AddRange(new object[] {
															 "None",
															 "XON/XOFF",
															 "RTS/CTS",
															 "DTR/DSR"});
			this.FlowControl.Location = new System.Drawing.Point(24, 288);
			this.FlowControl.Name = "FlowControl";
			this.FlowControl.Size = new System.Drawing.Size(176, 17);
			this.FlowControl.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 272);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 11;
			this.label6.Text = "Flow Control";
			// 
			// WriteBuffer
			// 
			this.WriteBuffer.AutoSize = false;
			this.WriteBuffer.Location = new System.Drawing.Point(256, 88);
			this.WriteBuffer.Name = "WriteBuffer";
			this.WriteBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.WriteBuffer.Size = new System.Drawing.Size(184, 112);
			this.WriteBuffer.TabIndex = 12;
			this.WriteBuffer.Text = "*idn?\\r\\n";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(256, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "String to Write";
			// 
			// ReadBuffer
			// 
			this.ReadBuffer.AutoSize = false;
			this.ReadBuffer.Location = new System.Drawing.Point(256, 232);
			this.ReadBuffer.Name = "ReadBuffer";
			this.ReadBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ReadBuffer.Size = new System.Drawing.Size(184, 112);
			this.ReadBuffer.TabIndex = 14;
			this.ReadBuffer.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(256, 216);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 16);
			this.label8.TabIndex = 15;
			this.label8.Text = "Read String";
			// 
			// BytesRead
			// 
			this.BytesRead.Location = new System.Drawing.Point(24, 368);
			this.BytesRead.Name = "BytesRead";
			this.BytesRead.Size = new System.Drawing.Size(176, 20);
			this.BytesRead.TabIndex = 16;
			this.BytesRead.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(24, 352);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 17;
			this.label9.Text = "Bytes Read";
			// 
			// Start
			// 
			this.Start.Enabled = false;
			this.Start.Location = new System.Drawing.Point(256, 368);
			this.Start.Name = "Start";
			this.Start.Size = new System.Drawing.Size(184, 23);
			this.Start.TabIndex = 18;
			this.Start.Text = "Start";
			this.Start.Click += new System.EventHandler(this.Start_Click);
			// 
			// axCWButton1
			// 
			this.axCWButton1.Location = new System.Drawing.Point(216, 72);
			this.axCWButton1.Name = "axCWButton1";
			this.axCWButton1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCWButton1.OcxState")));
			this.axCWButton1.Size = new System.Drawing.Size(30, 40);
			this.axCWButton1.TabIndex = 19;
			// 
			// axCWButton2
			// 
			this.axCWButton2.Location = new System.Drawing.Point(217, 216);
			this.axCWButton2.Name = "axCWButton2";
			this.axCWButton2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCWButton2.OcxState")));
			this.axCWButton2.Size = new System.Drawing.Size(30, 40);
			this.axCWButton2.TabIndex = 20;
			// 
			// StopBits2
			// 
			this.StopBits2.Items.AddRange(new object[] {
														   "1.0",
														   "1.5",
														   "2.0"});
			this.StopBits2.Location = new System.Drawing.Point(24, 328);
			this.StopBits2.Name = "StopBits2";
			this.StopBits2.Size = new System.Drawing.Size(176, 17);
			this.StopBits2.TabIndex = 21;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 312);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.TabIndex = 22;
			this.label10.Text = "Stop Bits";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(48, 8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(352, 56);
			this.label11.TabIndex = 23;
			this.label11.Text = "Select a VISA Resource Name from the drop down list. Configure the serial port wi" +
				"th the proper settings. Choose whether to read, write or both. Enter a string to" +
				" write to the instrument. Press start to execute the serial communication.";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 406);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.StopBits2);
			this.Controls.Add(this.axCWButton2);
			this.Controls.Add(this.axCWButton1);
			this.Controls.Add(this.Start);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.BytesRead);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.ReadBuffer);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.WriteBuffer);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.FlowControl);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Parity);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Delay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.DataBits);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BaudRate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.VISAResource);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.axCWButton1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.axCWButton2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//Start a new thread to enable the delay function, Thread.Sleep(), between 
			//writing and reading from the port.
			Thread newThread = 
				new Thread(new ThreadStart(ThreadMethod));
			newThread.ApartmentState = ApartmentState.STA;
			newThread.Start();
			Application.Run(new Form1());
		}

		static void ThreadMethod()
		{
			Thread.Sleep(1000);
		}


		private void Start_Click(object sender, System.EventArgs e)
		{
			//Read in the selected values from the panel and configure the serial port accordingly.
			myAlias = VISAResource.SelectedItem.ToString();
			baudRate = int.Parse(BaudRate.Text);
			dataBits = short.Parse(DataBits.Text);
			parity = Parity.Text;
			stopBits = StopBits2.Text;
			readDelay = int.Parse(Delay.Text);
			flowControlText = FlowControl.Text;
			writeBuffer = WriteBuffer.Text;
			try
				{
					//Open a new VISA session by creating an instance of a SerialSession
					//object.
					mySession = new NationalInstruments.VisaNS.SerialSession(myAlias);

					//Configure the VISA session.
					mySession.BaudRate = baudRate;
					mySession.DataBits = dataBits;
					
					//Set the flow control.
					switch(flowControlText)
					{
						case "XON/XOFF":
							mySession.FlowControl = FlowControlTypes.XOnXOff;
							break;

						case "None":
							flowControl = FlowControlTypes.None;
							break;

						case "RTS/CTS":
							flowControl = FlowControlTypes.RtsCts;
							break;

						case "DTR/DSR":
							flowControl = FlowControlTypes.DtrDsr;
							break;
					}
							
					mySession.FlowControl = flowControl;

					//Set the parity.
					switch(parity)
					{
						case "None":
							mySession.Parity = NationalInstruments.VisaNS.Parity.None;
							break;

						case "Even":
							mySession.Parity = NationalInstruments.VisaNS.Parity.Even;
							break;

						case "Odd":
							mySession.Parity = NationalInstruments.VisaNS.Parity.Odd;
							break;

						case "Mark":
							mySession.Parity = NationalInstruments.VisaNS.Parity.Mark;
							break;

						case "Space":
							mySession.Parity = NationalInstruments.VisaNS.Parity.Space;
							break;
					}
					
					//Set the stop bits.
					switch(stopBits)
					{
						case "1.0":
							mySession.StopBits = NationalInstruments.VisaNS.StopBitType.One;
							break;

						case "1.5":
							mySession.StopBits = NationalInstruments.VisaNS.StopBitType.OneAndOneHalf;
							break;

						case "2.0":
							mySession.StopBits = NationalInstruments.VisaNS.StopBitType.Two;
							break;
					}

					//Check if the Write button is set to on or off.
					if (axCWButton1.Value)
						mySession.Write(writeBuffer); //Write the data to the buffer
			
					//Delay between writing and reading.
					Thread.Sleep(readDelay);

					//Check if the Read button is set to on or off.
					if (axCWButton2.Value)
					{
						//Read all available data from the buffer and display it onscreen.
						readBuffer = mySession.ReadString(mySession.AvailableNumber);
						ReadBuffer.Text = readBuffer;
						bytesRead = readBuffer.Length;
						BytesRead.Text = bytesRead.ToString();
					}
				}
				catch (VisaException ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					//Dispose of the SerialSession instance to close the VISA session.
					mySession.Dispose();
				}

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

			string[] resources = ResourceManager.GetLocalManager().FindResources("?*");
			foreach(string s in resources)
			{
				string Alias, resClass, unAlias;
				short intNum;
				NationalInstruments.VisaNS.HardwareInterfaceType hwit;

				//Display all non-GPIB devices.
				if (s.Substring(0,4) != "GPIB")
				{
					//Read in device names and determine their VISA aliases.
					ResourceManager.GetLocalManager().ParseResource(s,out hwit, out intNum, out resClass, out unAlias, out Alias);
					//Add the VISA aliases to the VISA Resource Name combobox.
					//If the resource has no alias, return the full VISA resource name.
					if (Alias == "")
						VISAResource.Items.Add(s);
					else 
						VISAResource.Items.Add(Alias);
				}
			}
			
		}

		private void VISAResource_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Do not allow execution until a VISA resource name has been selected.
			Start.Enabled = true;
		}

	
	}
}
