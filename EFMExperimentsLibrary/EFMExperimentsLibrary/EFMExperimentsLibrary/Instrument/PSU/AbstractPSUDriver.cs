using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public enum AbstractPSUTrackingMode { Independent, Series, Parallel };
    public enum PSUIOValues { SetCurrent, CurrentSet, CurrentOut, SetVoltage, VoltageSet, VoltageOut }
    abstract public class AbstractPSUDriver
    {
        
        
        abstract public void setCurrent(int chn, double value);
        abstract public void setVoltage(int chn, double value);

        abstract public double getSetCurrent(int chn);
        abstract public double getSetVoltage(int chn);

        abstract public double getOutCurrent(int chn);
        abstract public double getOutVoltage(int chn);

        abstract public void setOutput(int chn, bool enabled);


        abstract public void setTrackingMode( AbstractPSUTrackingMode mode );

        //abstract public void setMaxCurrent(double val);
        //abstract public void setMaxVoltage(double val);
        abstract public double getMaxCurrent();
        abstract public double getMaxVoltage();

        abstract public bool openInstrument();

        abstract public void closeInstrument();

        public bool initialized { get; protected set; }

        protected AbstractPSUDriverInstrumentSettings driverSettings;

        public void setInitialSettings()
        {
            setCurrent(0, driverSettings.setCurrentChan1);
            setVoltage(0, driverSettings.setVoltageChan1);
            setOutput(0, driverSettings.outputEnabledChan1);

            setCurrent(1, driverSettings.setCurrentChan2);
            setVoltage(1, driverSettings.setVoltageChan2);
            setOutput(1, driverSettings.outputEnabledChan2);
        }

        public event EventHandler<PSUSaveSettingsEventArgs> SaveSettingsHandler;

        protected void saveSettings( )
        {
            if ( SaveSettingsHandler != null)
            {
                PSUSaveSettingsEventArgs e = new PSUSaveSettingsEventArgs();

                e.currentChan1 = getSetCurrent(0);
                e.currentChan2 = getSetCurrent(1);

                e.voltageChan1 = getSetVoltage(0);
                e.voltageChan2 = getSetVoltage(1);

                e.outputEnabledChan1 = false;
                e.outputEnabledChan2 = false;

                SaveSettingsHandler(this, e);
            }
        }    
    }

    public class PSUSaveSettingsEventArgs : EventArgs
    {
        public double currentChan1 { get; set; }
        public double currentChan2 { get; set; }

        public double voltageChan1 { get; set; }
        public double voltageChan2 { get; set; }

        public bool outputEnabledChan1 { get; set; }
        public bool outputEnabledChan2 { get; set; }
    }

    abstract public class AbstractPSUDriverInstrumentSettings
    {
        public double setVoltageChan1 { get; set; }
        public double setCurrentChan1 { get; set; }        
        public bool outputEnabledChan1 { get; set; }

        
        public double setCurrentChan2 { get; set; }
        public double setVoltageChan2 { get; set; }
        public bool outputEnabledChan2 { get; set; }
    }
}
