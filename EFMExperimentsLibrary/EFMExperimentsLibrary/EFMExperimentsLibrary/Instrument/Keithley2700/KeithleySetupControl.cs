using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace EFMExperimentsLibrary
{
    public enum ExperimentMode { Idle }//, ContactSeeking, SeebeckMeasurement, ResistanceMeasurement}
    
    public partial class KeithleySetupControl: UserControl
    {
        public event EventHandler<DataSourceNamesEventsArgs> KeithleyDataNamesChanged;
        public static UInt32 numberOfPorts = 22;
        private DataTable[] keithleyData;
        private string[] keithley2700SettingsFile;

        private int colIndexMeasurementType, colIndexUnit, colIndexLabel, colIndexEnabled, colIndexMeasureAlways,colIndexMaxRange;

        public event EventHandler ExperimentModeChangedHandler;

        public KeithleySetupControl()
        {
            InitializeComponent();
            InitializeValues();
            loadSettings(keithley2700SettingsFile[0]);
        }
        public KeithleySetupControl( UInt32 nPorts )
        {
            InitializeComponent();
            
            InitializeValues();
            loadSettings(keithley2700SettingsFile[0]);
        }


        private void loadSettings( string fileName )
        {
            if (File.Exists(fileName))
            {
                int expIndex = cmbMode.SelectedIndex;
                keithleyData[expIndex].Clear();
                keithleyData[expIndex].ReadXml(fileName);
                updateFields(cmbPortNumber.SelectedIndex);
                keithleyNamesEvent();
            }
        }

        public void keithleyNamesEvent()
        {
            if (KeithleyDataNamesChanged != null)
            {
                int expIndex = cmbMode.SelectedIndex;
                DataSourceNamesEventsArgs e = new DataSourceNamesEventsArgs();
                e.sourceDataNames = new string[keithleyData[expIndex].Rows.Count];
                for (int i = 0; i < e.sourceDataNames.Length; i++)
                {
                    e.sourceDataNames[i] = (string)(keithleyData[expIndex].Rows[i][colIndexLabel]);
                }
                KeithleyDataNamesChanged(this, e);
            }
        }

        public string[] getExperimentNames()
        {
            return Enum.GetNames(typeof(ExperimentMode));
        }

        private void InitializeValues( )
        {
            string[] expNames = Enum.GetNames(typeof(ExperimentMode));
            int nExps = expNames.Length;

            //initialize the experiment mode selector box
            for (int i = 0; i < nExps; i++ )            
                cmbMode.Items.Add(expNames[i]);            
                
            cmbMode.SelectedIndex = 0;
            cmbMode.SelectedIndexChanged += cmbMode_SelectedIndexChanged;
            

            //Initialize the port number selector box
            for ( int i = 0; i < numberOfPorts; i++ )
            {
                cmbPortNumber.Items.Add((i+1).ToString("00"));
            }
            cmbPortNumber.SelectedIndexChanged += new EventHandler(cmbPortNumber_SelectedIndexChanged);


            //Initialize the measurement type selector box
            foreach (Keithley2700MeasurementTypes mt in Enum.GetValues(typeof(Keithley2700MeasurementTypes)))
            {
                cmbMeasurementType.Items.Add(mt);
            }
            cmbMeasurementType.SelectedIndexChanged += new EventHandler(cmbMeasurementType_SelectIndexChanged);

            //Initialize the unit selector box
            foreach (Keithley2700ChannelUnits mu in Enum.GetValues(typeof(Keithley2700ChannelUnits)))
            {
                cmbUnit.Items.Add(mu);
            }
            cmbUnit.SelectedIndexChanged += new EventHandler(cmbUnit_SelectedIndexChanged);

            txtDataoutName.TextChanged += new EventHandler(txtDataout_textChanged);

            chkEnabled.CheckedChanged += new EventHandler(chkEnabled_StateChanged);

            

            //Initialize the data table    
            
            keithleyData = new DataTable[nExps];

            keithley2700SettingsFile = new string[nExps];

            for ( int i = 0; i < nExps; i++ )
            {
                keithleyData[i] = new DataTable();
                keithleyData[i].Columns.Add("PortNumber", typeof(int));
                keithleyData[i].Columns.Add("MeasurementType", typeof(Keithley2700MeasurementTypes));
                keithleyData[i].Columns.Add("Unit", typeof(Keithley2700ChannelUnits));
                keithleyData[i].Columns.Add("Label", typeof(string));
                keithleyData[i].Columns.Add("Enabled", typeof(bool));
                keithleyData[i].Columns.Add("MeasureAlways", typeof(bool));
                keithleyData[i].Columns.Add("MaxRange", typeof(double));


                colIndexMeasurementType = keithleyData[i].Columns.IndexOf("MeasurementType");

                colIndexUnit = keithleyData[i].Columns.IndexOf("Unit");

                colIndexLabel = keithleyData[i].Columns.IndexOf("Label");

                colIndexEnabled = keithleyData[i].Columns.IndexOf("Enabled");

                colIndexMeasureAlways = keithleyData[i].Columns.IndexOf("MeasureAlways");

                colIndexMaxRange = keithleyData[i].Columns.IndexOf("MaxRange");

                for ( int j = 0; j < numberOfPorts; j++ )
                {
                    keithleyData[i].Rows.Add(j + 1, Keithley2700MeasurementTypes.U, Keithley2700ChannelUnits.Volts, "Port " + (j + 1).ToString(), false, false,1.0);
                }

                keithleyData[i].TableName = "Keithley2700Settings_" + expNames[i];
                
                keithley2700SettingsFile[i] = "seebeck_keithley2700_settings_" + expNames[i] + ".xml";
            }
            keithleyNamesEvent();
             cmbPortNumber.SelectedIndex = 0;
             
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int expIndex = cmbMode.SelectedIndex;

            loadSettings(keithley2700SettingsFile[expIndex]);

            if ( ExperimentModeChangedHandler != null )
            {
                ExperimentModeChangedHandler(this, e);
            }
        }

        /**
         * External callable method for changing the measurement mode
         * */
        public void changeSelectedMode(ExperimentMode mode)
        {
            if ( cmbMode.SelectedIndex != (int)mode )
                cmbMode.SelectedIndex = (int)mode;
        }


        public string[] getHeader(int expSel)
        {
            if (expSel >= 0 & expSel < cmbMode.Items.Count)
            {
                string[] ret = new string[keithleyData[expSel].Rows.Count];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = (string)keithleyData[expSel].Rows[i][colIndexLabel];
                }
                return ret;
            }
            return null;
        }

        public DataTable getKeithleyData()
        {
            return keithleyData[cmbMode.SelectedIndex];
        }

        public int getSelectedExperimentMode()
        {
            return cmbMode.SelectedIndex;
        }

        private void cmbPortNumber_SelectedIndexChanged( object sender, EventArgs e )
        {
            int index = cmbPortNumber.SelectedIndex;

            updateFields(index);
            
        }

        private void updateFields( int index )
        {
            if (index >= 0)
            {
                int expIndex = cmbMode.SelectedIndex;
                cmbMeasurementType.SelectedItem = (Keithley2700MeasurementTypes)(keithleyData[expIndex].Rows[index][colIndexMeasurementType]);

                cmbUnit.SelectedItem = (Keithley2700ChannelUnits)(keithleyData[expIndex].Rows[index][colIndexUnit]);

                txtDataoutName.Text = (string)(keithleyData[expIndex].Rows[index][colIndexLabel]);

                chkEnabled.Checked = (bool)(keithleyData[expIndex].Rows[index][colIndexEnabled]);

                
                double k = (double)(keithleyData[expIndex].Rows[index][colIndexMaxRange]);
                nudMaxRange.Value = (decimal)k;
            }
        }

        private void cmbMeasurementType_SelectIndexChanged( object sender, EventArgs e )
        {
            int index = cmbPortNumber.SelectedIndex;

            int expIndex = cmbMode.SelectedIndex;

            keithleyData[expIndex].Rows[index][colIndexMeasurementType] = (Keithley2700MeasurementTypes)(cmbMeasurementType.SelectedItem);
        }

        private void cmbUnit_SelectedIndexChanged( object sender, EventArgs e )
        {
            int index = cmbPortNumber.SelectedIndex;

            int expIndex = cmbMode.SelectedIndex;

            keithleyData[expIndex].Rows[index][colIndexUnit] = (Keithley2700ChannelUnits)(cmbUnit.SelectedItem);
        }

        private void txtDataout_textChanged( object sender, EventArgs e )
        {
            int index = cmbPortNumber.SelectedIndex;

            int expIndex = cmbMode.SelectedIndex;

            keithleyData[expIndex].Rows[index][colIndexLabel] = txtDataoutName.Text;
        }

        private void chkEnabled_StateChanged( object sender, EventArgs e )
        {
            int index = cmbPortNumber.SelectedIndex;

            int expIndex = cmbMode.SelectedIndex;

            keithleyData[expIndex].Rows[index][colIndexEnabled] = chkEnabled.Checked;
        }

        private void chkMeasureAlways_StateChanged(object sender, EventArgs e)
        {
            int index = cmbPortNumber.SelectedIndex;

            int expIndex = cmbMode.SelectedIndex;
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdLoadSettings_Click(object sender, EventArgs e)
        {
            int expIndex = cmbMode.SelectedIndex;

            loadSettings(keithley2700SettingsFile[expIndex]);
            
        }

        private void cmdSaveSettings_Click(object sender, EventArgs e)
        {
            int expIndex = cmbMode.SelectedIndex;

            keithleyData[expIndex].WriteXml(keithley2700SettingsFile[expIndex]);
        }

        private void KeithleySetupControl_Load(object sender, EventArgs e)
        {

        }

        private void cmbPortNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void nudMaxRange_ValueChanged(object sender, EventArgs e)
        {
            int expIndex = cmbMode.SelectedIndex;

            int index = cmbPortNumber.SelectedIndex;

            keithleyData[expIndex].Rows[index][colIndexMaxRange] = nudMaxRange.Value;
        }        
        
    }
    

    public class DataSourceNamesEventsArgs : EventArgs
    {
        public string[] sourceDataNames;
    }
   
}
