using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keithley.IVI.NET2;

namespace EFMExperimentsLibrary
{


    public partial class KE2700Control : UserControl, K2700ControlInterface
    {
        private Keithley2700Instrument ke2700Instr;

        public event EventHandler<ReadingsUpdateEventArgs> ReadingsUpdate;

        public event EventHandler InstrumentFinished;

        public event EventHandler<DataSourceNamesEventsArgs> KeithleySourceNamesChanged;

        public delegate void UpdateTextBoxAsync(TextBox txt, string str);
        public delegate void UpdateDataGridAsync(DataGridView dgv, double[,] dat);
        public delegate void SaveData(double[,] dat);
        public delegate void UpdateSettings();

        public string userFilename { get; set; }

        private string defUserFilename = "test_file";

        public Keithley2700DataSaver[] dataWriter;

        public DataFilter dataFilter;

        public KE2700Control()
        {
            userFilename = defUserFilename;
            InitializeComponent();
            InitializeCustomComponents();
            initializeDataGrid();
        }

        public void userfilenameChanged(object sender, OutputFileNameChangedEventArgs evt)
        {
            userFilename = evt.outputDirectory + evt.filename;
            initializeDataSaver();
        }

        private void InitializeCustomComponents()
        {
            k2700Setup.Location = new System.Drawing.Point(4, 5);
            k2700Setup.Name = "k2700Setup";
            k2700Setup.Size = new System.Drawing.Size(1300, 75);
            k2700Setup.TabIndex = 0;
            Controls.Add(k2700Setup);
            k2700Setup.ExperimentModeChangedHandler += k2700Setup_ExperimentModeChangedHandler;

            k2700Setup.KeithleyDataNamesChanged += k2700Setup_KeithleyDataNamesChanged;

        }

        private void k2700Setup_KeithleyDataNamesChanged(object sender, DataSourceNamesEventsArgs e)
        {
            if (KeithleySourceNamesChanged != null)
            {
                KeithleySourceNamesChanged(sender, e);
            }
        }

        void k2700Setup_ExperimentModeChangedHandler(object sender, EventArgs e)
        {
            BeginInvoke(new UpdateSettings(updateKeithleySettings));
        }

        private void initializeKeithley()
        {
            if (ke2700Instr == null)
            {
                initializeDataSaver();

                ke2700Instr = new Keithley2700Instrument();
                ke2700Instr.InstrumentFinished += ke2700Instr_InstrumentFinished;
                ke2700Instr.InstrumentInitialized += ke2700Instr_InstrumentInitialized;
                ke2700Instr.SaveData += ke2700Instr_SaveData;
                ke2700Instr.InstrumentErrorUpdate += ke2700Instr_InstrumentErrorUpdate;

                updateKeithleySettings();

                ke2700Instr.initializeInstrument();
                k2700Setup.keithleyNamesEvent();
            }

        }

        public DateTime getTimestamp()
        {
            if (ke2700Instr != null)
            {
                return ke2700Instr.dtStartTimestamp;
            }
            return DateTime.Now;
        }
        public void initializeDataSaver()
        {
            string[] expNames = k2700Setup.getExperimentNames();

            dataWriter = new Keithley2700DataSaver[expNames.Length];

            for (int i = 0; i < expNames.Length; i++)
            {
                string outFile = userFilename + "_" + expNames[i];
                dataWriter[i] = new Keithley2700DataSaver(outFile, k2700Setup.getHeader(i), getTimestamp());
            }
        }

        public string[] getHeader()
        {
            return k2700Setup.getHeader(0);
        }

        private void updateKeithleySettings()
        {
            if (ke2700Instr != null)
            {
                DataTable sett = k2700Setup.getKeithleyData();
                ke2700Instr.settings.freezeSettings = true;
                for (int i = 0; i < sett.Rows.Count; i++)
                {
                    int portNr = (int)(sett.Rows[i]["PortNumber"]) - 1;

                    bool enabled = (bool)(sett.Rows[i]["Enabled"]);

                    Keithley2700ChannelUnits unit = (Keithley2700ChannelUnits)sett.Rows[i]["Unit"];

                    Keithley2700MeasurementTypes type = (Keithley2700MeasurementTypes)sett.Rows[i]["MeasurementType"];

                    double range = (double)sett.Rows[i]["MaxRange"];

                    //keithleyData.Columns.Add("Unit", typeof(MeasurementUnit));

                    ke2700Instr.settings.setChannelEnabled(portNr, enabled);

                    ke2700Instr.settings.setChannelUnit(portNr, unit);

                    ke2700Instr.settings.setChannelMeasurement(portNr, type);

                    ke2700Instr.settings.setChannelMaxRange(portNr, range);

                    dgvKeithley2700.Rows[i].Cells["ChannelName"].Value = (string)sett.Rows[i][sett.Columns.IndexOf("Label")];

                    dgvKeithley2700.Rows[i].Cells["Type"].Value = type.ToString();

                    dgvKeithley2700.Rows[i].Cells["Enabled"].Value = (bool)sett.Rows[i][sett.Columns.IndexOf("Enabled")];

                    dgvKeithley2700.Rows[i].Cells["MaxRange"].Value = (double)sett.Rows[i][sett.Columns.IndexOf("MaxRange")];
                }

                ke2700Instr.settings.freezeSettings = false;
                ke2700Instr.settings.settingsChanged = true;

            }
        }

        private void initializeDataGrid()
        {
            for (int i = 0; i < KeithleySetupControl.numberOfPorts - 1; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgvKeithley2700.Rows[0].Clone();

                dgvKeithley2700.Rows.Add(row);
            }
        }


        private void ke2700Instr_SaveData(object sender, InstrumentDatasetEventArgs e)
        {
            double[,] dat = e.dataSet.getLatestData();

            object[] args = new object[2];
            args[0] = dgvKeithley2700;
            args[1] = dat;

            BeginInvoke(new UpdateDataGridAsync(updateDataGridView), args);

            BeginInvoke(new SaveData(saveData), dat);

        }
        private List<double> additionalData = new List<double>();
        public void setTemperatureUpdated(object sender, SetPointChangedEventArgs e)
        {
            additionalData.Clear();
            additionalData.Add(e.T);
        }
        private void saveData(double[,] dat)
        {
            int nExtra = additionalData.Count();
            int n = dat.GetLength(0) + nExtra;
            double[,] dat_out = new double[n, 2];
            for ( int i = 0; i < dat.GetLength(0); i++ )
            {
                dat_out[i, 0] = dat[i, 0];
                dat_out[i, 1] = dat[i, 1];
            }
            //pad the extra data
            for ( int i = dat.GetLength(0); i < n; i++ )
            {
                dat_out[i, 1] = additionalData[i- dat.GetLength(0)];
            }

            //remember to clear the additional data list
            additionalData.Clear();

            int selExp = k2700Setup.getSelectedExperimentMode();
            if (dataWriter != null && dataWriter[selExp] != null)
            {
                if (selExp >= 0 && selExp < dataWriter.Length)
                {
                    dataWriter[selExp].writeLine(dat_out);
                    txtFilename.Text = dataWriter[selExp].getFilenameData();
                }
            }

            if (ReadingsUpdate != null)
            {
                ReadingsUpdateEventArgs e = new ReadingsUpdateEventArgs();
                e.readings = dat;
                e.measurementTypes = getMeasurementTypes();
                e.names = getMeasurementNames();
                e.chanEnabled = getMeasurementChanEnabled();
                ReadingsUpdate(this, e);
            }
        }

        private Keithley2700MeasurementTypes[] getMeasurementTypes()
        {
            Keithley2700MeasurementTypes[] types = new Keithley2700MeasurementTypes[dgvKeithley2700.Rows.Count];
            int i = 0;
            foreach (DataGridViewRow row in dgvKeithley2700.Rows)
            {

                types[i] = (Keithley2700MeasurementTypes)Enum.Parse(typeof(Keithley2700MeasurementTypes), (string)row.Cells["Type"].Value, true);
                i++;
            }
            return types;
        }

        private string[] getMeasurementNames()
        {
            string[] names = new string[dgvKeithley2700.Rows.Count];
            int i = 0;
            foreach (DataGridViewRow row in dgvKeithley2700.Rows)
            {
                names[i] = (string)row.Cells["ChannelName"].Value;
                i++;
            }
            return names;
        }

        private bool[] getMeasurementChanEnabled()
        {
            bool[] enabled = new bool[dgvKeithley2700.Rows.Count];
            int i = 0;
            foreach (DataGridViewRow row in dgvKeithley2700.Rows)
            {
                enabled[i] = (bool)row.Cells["Enabled"].Value;
                i++;
            }
            return enabled;
        }

        private void updateDataGridView(DataGridView dgv, double[,] dat)
        {
            int l = dgv.Rows.Count;
            if (dat.GetLength(0) < l)
                l = dat.GetLength(0);


            for (int i = 0; i < l; i++)
            {
                dgv.Rows[i].Cells["Time"].Value = dat[i, 0];
                dgv.Rows[i].Cells["Reading"].Value = dat[i, 1];
            }
        }

        private void updateField(TextBox txt, string val)
        {
            object[] args = new object[2];
            args[0] = txt;
            args[1] = val;
            BeginInvoke(new UpdateTextBoxAsync(UpdateTextbox), args);
        }

        private void UpdateTextbox(TextBox txt, string str)
        {
            txt.Text = str;
        }


        void ke2700Instr_InstrumentInitialized(object sender, EventArgs e)
        {

        }

        void ke2700Instr_InstrumentFinished(object sender, EventArgs e)
        {
            ke2700Instr = null;
            if (InstrumentFinished != null)
                InstrumentFinished(sender, e);
        }

        void ke2700Instr_InstrumentErrorUpdate(object sender, InstrumentMessageEventArgs e)
        {
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            initializeKeithley();
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            closeK2700Instrument();
        }

        /**
         * Returns 1 if the instrument thread is alive. Else returns 0
         * */
        public int closeK2700Instrument()
        {
            if (ke2700Instr != null)
            {
                ke2700Instr.settings.closeAllChannels();
                if (ke2700Instr.closeInstrument())
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

        private void dgvKeithley2700_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void KE2700Control_Load(object sender, EventArgs e)
        {

        }

        public void changeSelectedMode(ExperimentMode mode)
        {
            k2700Setup.changeSelectedMode(mode);
        }
    }
    public class ReadingsUpdateEventArgs : EventArgs
    {
        public double[,] readings { get; set; }
        public Keithley2700MeasurementTypes[] measurementTypes { get; set; }
        public string[] names { get; set; }

        public bool[] chanEnabled { get; set; }

    }
    public interface K2700ControlInterface
    {
        DateTime getTimestamp();
        void changeSelectedMode(ExperimentMode mode);
    }
}
