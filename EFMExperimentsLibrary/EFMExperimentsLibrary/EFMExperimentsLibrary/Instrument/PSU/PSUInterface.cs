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
    public interface psuRetrieveReading
    {
        double getCurrentReading(int chan);
        double getVoltageReading(int chan);
    }

    public interface psuSetOutput
    {
        void setCurrent(int chan, double cur);
        void setVoltage(int chan, double vol);
        void setEnabled(int chan, bool enabled);
        double getMaxVoltage();
        double getMaxCurrent();
    }
   
    public partial class PSUInterface : UserControl, psuRetrieveReading, psuSetOutput 
    {
        public PSUInterface()
        {
            InitializeComponent();
            foreach ( AbstractPSUTrackingMode val in Enum.GetValues(typeof(AbstractPSUTrackingMode)))
            {
               cmbPSUMode.Items.Add( val );
            }
            cmbPSUMode.SelectedItem = AbstractPSUTrackingMode.Parallel;
            
        }

        public event EventHandler<PSUChangedUpdateEventArgs> SettingsChangedUpdate;

        public event EventHandler InstrumentFinished;

        private PSUInstrument psuInstrument;

        private string[] instrumentStateStrings = { "Unit finished", "Unit initialized" };

        private enum InstrumentStates { Finished, Initialized };

        public delegate void UpdateLabelAsync(Label lbl, string txt);
        public delegate void UpdateTextBoxAsync(TextBox txtBox, string txt);

        public void initializeInstrument(AbstractPSUDriver drv, string title)
        {
            psuInstrument = new PSUInstrument(drv);
            lblTItle.Text = title;

            psuInstrument.InstrumentFinished += new EventHandler(psuFinished);
            psuInstrument.InstrumentInitialized += new EventHandler(psuInitialized);
            psuInstrument.InstrumentErrorUpdate += new EventHandler<InstrumentMessageEventArgs>(psuErrorUpdate);
            psuInstrument.SaveData += psu_SaveData;
        }


        void psu_SaveData(object sender, InstrumentDatasetEventArgs e)
        {
            PSUDataset dat = (PSUDataset)(e.dataSet);
            double[,] data = dat.getLatestData();

            updateField(txtChannel1CurrentGet, (data[(int)PSUDataArrayIndices.CurrentChan1, 0]).ToString());
            updateField(txtChannel2CurrentGet, (data[(int)PSUDataArrayIndices.CurrentChan2, 0]).ToString());

            updateField(txtChannel1VoltageGet, (data[(int)PSUDataArrayIndices.VoltageChan1, 0]).ToString());
            updateField(txtChannel2VoltageGet, (data[(int)PSUDataArrayIndices.VoltageChan2, 0]).ToString());

            if (SettingsChangedUpdate != null)
            {
                PSUChangedUpdateEventArgs args = new PSUChangedUpdateEventArgs();
                args.settingsChanged = true;
                SettingsChangedUpdate(this, args);
            }
        }

        public void initializePSU()
        {
            psuInstrument.settings.setChannelName(0, "chn1");
            psuInstrument.settings.setChannelName(1, "chn2");

            psuInstrument.settings.setChannelStatus(0, false);
            psuInstrument.settings.setChannelStatus(1, false);



            psuInstrument.initializeInstrument();
        }
        private void cmdInitialize_Click(object sender, EventArgs e)
        {
            initializePSU();
        }

        private void cmdGetUnitName_Click(object sender, EventArgs e)
        {


        }

        private void cmdCloseUnit_Click(object sender, EventArgs e)
        {
            closeUnit();
        }
        /**
         * Returns 1 if the thread is still alive. Else returns 0
         * */
        public int closeUnit()
        {
            if (psuInstrument.closeInstrument())
                return 1;
            else
                return 0;
        }
        public void safetyCloseInstrument(object sender, EventArgs e)
        {
            closeUnit();
        }

        private string getInstrumentState(InstrumentStates s)
        {
            if ((int)s >= 0 && (int)s < instrumentStateStrings.Length)
            {
                return instrumentStateStrings[(int)s];
            }
            else
                return "Undefined state";
        }

        private void psuFinished(object sender, EventArgs e)
        {
            lblInstrumentState.Text = getInstrumentState(InstrumentStates.Finished);
            if (InstrumentFinished != null)
                InstrumentFinished(sender, e);
        }

        private void psuInitialized(object sender, EventArgs e)
        {
            lblInstrumentState.Text = getInstrumentState(InstrumentStates.Initialized);
        }

        private void psuErrorUpdate(object sender, InstrumentMessageEventArgs e)
        {
            updateField(lblErrorMessage, e.message);
        }

        private void updateField(Label lbl, string val)
        {
            object[] args = new object[2];
            args[0] = lbl;
            args[1] = val;
            BeginInvoke(new UpdateLabelAsync(UpdateLabel), args);
        }

        private void updateField(TextBox txt, string val)
        {
            object[] args = new object[2];
            args[0] = txt;
            args[1] = val;
            BeginInvoke(new UpdateTextBoxAsync(UpdateTextbox), args);
        }

        private void UpdateLabel(Label lbl, string txt)
        {
            lbl.Text = txt;
        }

        private void UpdateTextbox(TextBox txtBox, string txt)
        {
            txtBox.Text = txt;
        }

        private void updateInstrumentState()
        {

        }

        private void cmdGetDeviceError_Click(object sender, EventArgs e)
        {

        }

        private void cmdChannel1SetValues_Click(object sender, EventArgs e)
        {
            updateChannelValues(0);
        }

        private void updateChannelValues(int channel)
        {
            double cur = 0;
            double vol = 0;

            try
            {
                if (channel == 0)
                {
                    cur = Convert.ToDouble(txtChannel1CurrentSet.Text);
                    vol = Convert.ToDouble(txtChannel1VoltageSet.Text);
                }
                else if (channel == 1)
                {
                    cur = Convert.ToDouble(txtChannel2CurrentSet.Text);
                    vol = Convert.ToDouble(txtChannel2VoltageSet.Text);
                }
            }
            catch (Exception ex)
            {
            }

            psuInstrument.settings.setChannelValues(channel, cur, vol);
        }

        private void txtResourceName_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkChannel1Enable_CheckedChanged(object sender, EventArgs e)
        {
            setChannelStatus(0, chkChannel1Enable.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            setChannelStatus(1, chkChannel2Enable.Checked);
        }

        private void cmdChannel2SetValues_Click(object sender, EventArgs e)
        {
            updateChannelValues(1);
        }

        private void setChannelStatus(int chn, bool enabled)
        {
            if (chn == 0 || chn == 1)
            {
                psuInstrument.settings.setChannelStatus(chn, enabled);
                if (chn == 0)
                    chkChannel1Enable.Checked = enabled;
                if (chn == 1)
                    chkChannel2Enable.Checked = enabled;
            }

        }

        public double getCurrentReading(int chan)
        {
            double retVal = 0;
            try
            {
                if (chan == 0)
                    retVal = Convert.ToDouble(txtChannel1CurrentGet.Text);
                else if (chan == 1)
                    retVal = Convert.ToDouble(txtChannel2CurrentGet.Text);
            }
            catch (FormatException ex)
            {
            }
            return retVal;
        }

        public double getVoltageReading(int chan)
        {
            double retVal = 0;
            try
            {
                if (chan == 0)
                    retVal = Convert.ToDouble(txtChannel1VoltageGet.Text);
                else if (chan == 1)
                    retVal = Convert.ToDouble(txtChannel2VoltageGet.Text);
            }
            catch (FormatException ex)
            {

            }

            return retVal;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void psuSetOutput.setCurrent(int chan, double cur)
        {
            double maxCur = psuInstrument.getMaxCurrent();
            if (cur > maxCur)
                cur = maxCur;
            else if (cur < 0)
                cur = 0;
            if (chan == 0)
            {
                txtChannel1CurrentSet.Text = cur.ToString();
                updateChannelValues(0);
            }
            else if (chan == 1)
            {
                txtChannel2CurrentSet.Text = cur.ToString();
                updateChannelValues(1);
            }
            else
            {
                //invalid channel, maybe throw an exception?
            }
        }

        void psuSetOutput.setVoltage(int chan, double vol)
        {
            if (chan == 0)
            {
                txtChannel1VoltageSet.Text = vol.ToString();
                updateChannelValues(0);
            }
            else if (chan == 1)
            {
                txtChannel2VoltageSet.Text = vol.ToString();
                updateChannelValues(1);
            }
            else
            {
                //invalid channel, maybe throw an exception?
            }
        }

        void psuSetOutput.setEnabled(int chan, bool enabled)
        {

            setChannelStatus(chan, enabled);
        }
        double psuSetOutput.getMaxCurrent()
        {
            return psuInstrument.getMaxCurrent();
        }
        double psuSetOutput.getMaxVoltage()
        {
            return psuInstrument.getMaxVoltage();
        }

        private void txtChannel1CurrentGet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChannel1VoltageSet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChannel1CurrentSet_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPSUMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbstractPSUTrackingMode mode = (AbstractPSUTrackingMode)cmbPSUMode.SelectedItem;
            if ( psuInstrument != null )
                psuInstrument.settings.setTrackingMode(mode);
        }
    }
    public class PSUChangedUpdateEventArgs : EventArgs
    {
        public bool settingsChanged;
    }
}
