using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFMExperimentsLibrary
{
    public partial class PicoTc08Control : UserControl
    {
        private PicoTC08Instrument picoInstrument;
        private PicoTc08DataSaver dataSaver;
        private CheckBox[] chkEnabled;
        private ComboBox[] cmbType;
        public event EventHandler InstrumentFinished;
        public event EventHandler<ReadingsUpdateEventArgs> ReadingsUpdate;
        public delegate void UpdateDataGridAsync(DataGridView dgv, double[,] dat );
        public PicoTc08Control()
        {
            InitializeComponent();
            String[] str = new String[2];
            str[0] = "temp1";
            str[1] = "temp2";
            dataSaver = new PicoTc08DataSaver( "test", str , DateTime.Now);

            picoInstrument = new PicoTC08Instrument();
            picoInstrument.settings.setChannelType(1, PicoTC08Settings.ChannelType.K);
            picoInstrument.settings.setTempUnit(1, TempUnit.USBTC08_UNITS_KELVIN);
            picoInstrument.SaveData += picoInstrument_SaveData;            ;
            picoInstrument.InstrumentFinished += picoTc08_InstrumentFinished;
            initializeControls();
        }

        public void initializePicoControl()
        {
            picoInstrument.initializeInstrument();
            initializeDataView();
            
        }

        public int closePicoTc08Control()
        {                    
            if ( picoInstrument != null)
            {                
                if ( picoInstrument.closeInstrument())
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }        
        }

        public void picoTc08_InstrumentFinished(object sender, EventArgs e)
        {
            if (InstrumentFinished != null)
                InstrumentFinished(sender, e);
        }

        private void initializeControls()
        {
            int x0 = 250;
            int y0 = 48;
            int w = 100;
            int h = 17;

            chkEnabled = new CheckBox[PicoTC08Settings.nChannels-1];

            cmbType = new ComboBox[PicoTC08Settings.nChannels - 1];

            for (int i = 0; i < PicoTC08Settings.nChannels-1; i++)
            {
                chkEnabled[i] = new CheckBox();
                chkEnabled[i].AutoSize = true;
                chkEnabled[i].Location = new System.Drawing.Point(x0 + i*w, y0);
                chkEnabled[i].Name = "chkEnabled" + Convert.ToString(i);
                chkEnabled[i].Size = new System.Drawing.Size(w, h);
                chkEnabled[i].TabIndex = i+1;
                chkEnabled[i].Text = "Tc" + Convert.ToString(i+1) + " enabled";
                chkEnabled[i].UseVisualStyleBackColor = true;
                chkEnabled[i].Visible = true;
                chkEnabled[i].Checked = true;
                chkEnabled[i].CheckedChanged += chkEnabled_CheckedChanged;

                Controls.Add(chkEnabled[i]);

                cmbType[i] = new ComboBox();
                cmbType[i].FormattingEnabled = true;
                cmbType[i].Location = new System.Drawing.Point(x0+i*w, y0-h-10);
                cmbType[i].Name = "combType" + Convert.ToString(i+1);
                cmbType[i].Size = new System.Drawing.Size(w, h);
                cmbType[i].TabIndex = PicoTC08Settings.nChannels + i;
                
                foreach ( var field in typeof(PicoTC08Settings.ChannelType).GetFields())
                {
                    cmbType[i].Items.Add(field);
                }
                cmbType[i].SelectedIndex = 4;
                cmbType[i].SelectedIndexChanged += cmbType_SelectedIndexChanged;
                Controls.Add(cmbType[i]);

            }

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            for ( int i = 0; i < cmbType.Length; i++ )
            {
                picoInstrument.settings.setChannelType(i + 1, (PicoTC08Settings.ChannelType)cmbType[i].SelectedItem);
            }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            for ( int i = 0; i < chkEnabled.Length; i++ )
            {
                if (!chkEnabled[i].Checked)
                    picoInstrument.settings.setChannelType(i + 1, PicoTC08Settings.ChannelType.NotEnabled);
                else
                    picoInstrument.settings.setChannelType(i + 1, PicoTC08Settings.ChannelType.K);
            }
            
        }
        private void initializeDataView()
        {
            
            datGrdPico.ColumnCount = 10;
            datGrdPico.ColumnHeadersVisible = true;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            datGrdPico.Columns[0].Name = "Time [s]";
            datGrdPico.Columns[1].Name = "Cold junction [K]";

            for (int i = 0; i < 8; i++ )
                datGrdPico.Columns[i+2].Name = "Tc " + Convert.ToString(i+1);
        }

        private void picoInstrument_SaveData(object sender, InstrumentDatasetEventArgs e)
        {

            double[,] dat = e.dataSet.getLatestData();

            object[] args = new object[2];
            args[0] = datGrdPico;
            args[1] = dat;

            if (ReadingsUpdate != null)
            {
                ReadingsUpdateEventArgs ex = new ReadingsUpdateEventArgs();
                ex.readings = dat;
                //e.measurementTypes = getMeasurementTypes();
                //e.names = getMeasurementNames();
                //e.chanEnabled = getMeasurementChanEnabled();
                ReadingsUpdate(this, ex);
            }


            BeginInvoke(new UpdateDataGridAsync(updateDataGridView), args);
        }

        private void updateDataGridView( DataGridView datGrd, double[,] dat )
        {   
            datGrd.Rows[0].Cells[0].Value = dat[0, 0];
            
            for ( int i = 1; i < 10; i++ )
            {
                datGrdPico.Rows[0].Cells[i].Value = dat[i-1, 1];
            }
            dataSaver.writeLine(dat);

        }

        private void PicoTc08Control_Load(object sender, EventArgs e)
        {

        }
    }
    
}
