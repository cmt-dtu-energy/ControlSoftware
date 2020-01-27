using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EFMExperimentsLibrary
{
    public class PSUInstrument : Instrument
    {
        private AbstractPSUDriver psuDriver;
                
        public PSUSettings settings { get; set; }

        private PSUDataset dataSet = new PSUDataset();

        private const int maxBufsize = 1000000;

        public PSUInstrument(AbstractPSUDriver drv) : base()
        {
            psuDriver = drv;
            
            settings = new PSUSettings();

            dataSet.buffsize( maxBufsize );
            //dataSet.BufferFull += dataSet_BufferFull;
        }

        private void dataSet_BufferFull(object sender, InstrumentDatasetEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        /**
         * Specific implementation of handling the initialization of the PSU
         * */
        public override void initializeInstrument()
        {                        
            base.initializeInstrument();
        }

        protected override void initializeAsync()
        {            
            base.initializeAsync();
            if ( psuDriver.openInstrument() )
            {
                updateSettings();
            }            
        }

        /**
         * Get the latest data from the Keithley 2220 PSU
         * */
        protected override InstrumentDataset getInstrumentData()
        {
            PSUDataset dat = new PSUDataset();
            if (psuDriver.initialized)
            {
                double[,] vals = new double[5,1];


                vals[(int)PSUDataArrayIndices.CurrentChan1, 0] = psuDriver.getOutCurrent(0);

                vals[(int)PSUDataArrayIndices.CurrentChan2, 0] = psuDriver.getOutCurrent(1);

                vals[(int)PSUDataArrayIndices.VoltageChan1, 0] = psuDriver.getOutVoltage(0);

                vals[(int)PSUDataArrayIndices.VoltageChan2, 0] = psuDriver.getOutVoltage(0);

                //Convert from 100 nanoseconds to seconds
                vals[(int)PSUDataArrayIndices.Time,0] = DateTime.Now.Ticks * 1e-7;
                
                dat.AddData(vals);

                return dat;
            }
            else
            {
                return null;
            }
             
        }

        /**
         * Updates the device settings. For the PSU this means:
         * -Which (if any) of the two channels are open?
         * -The voltage and current for each of the two channels
         * This method is called from the worker thread only
         * */
        protected override void updateSettings()    
        {
            base.updateSettings();            
            if ( psuDriver != null && psuDriver.initialized && settings.settingsChanged )
            {
                psuDriver.setCurrent(0, settings.getChannelCurrent(0));
                psuDriver.setVoltage(0, settings.getChannelVoltage(0));
                psuDriver.setOutput(0, settings.getChannelStatus(0));

                
                psuDriver.setCurrent(1, settings.getChannelCurrent(1));
                psuDriver.setVoltage(1, settings.getChannelVoltage(1));
                psuDriver.setOutput(1, settings.getChannelStatus(1));

                psuDriver.setTrackingMode(settings.getTrackingMode());
                
                settings.settingsChanged = false;
            }
        }


        /**
         * Stores the data that was just received from the PSU
         * */
        protected override void storeData(InstrumentDataset data)
        {
            base.storeData(data);
            try
            {
                dataSet.AddData(data.getLatestData());
            }
            catch (Exception ex)
            {

            }
        }

        /**
         * Decides whether the saver-object should process the data
         * based on the settings (how often to save compared to how often data is retrieved from the device)
         * */
        protected override void updateEvents()
        {            
            //Todo
            //Call the data saver(s) like this
            InstrumentDatasetEventArgs datEvent = new InstrumentDatasetEventArgs();
            
            datEvent.dataSet = new PSUDataset();
            datEvent.dataSet.AddData(dataSet.getLatestData());
            
            OnSaveData(datEvent);
            
        }

        protected override void updateErrors()
        {            
            base.updateErrors();
            
            /*driver.Utility.ErrorQuery(ref code, ref mess);
            
            if ( code != currentError || mess.CompareTo(currentErrorMessage) != 0)
            {
                SeebeckMessageEventArgs e = new SeebeckMessageEventArgs();
                e.message = mess;
                
                OnInstrumentErrorUpdate(e);
                currentError = code;
                currentErrorMessage = mess;

            }*/
        }

        /**
         * Returns the latest data set (for one set of measurements,
         * i.e. two values of the current and two values of the voltage)
         * */
        public override InstrumentDataset getLatestData()
        {
            return base.getLatestData();
            //Todo
        }
        /**
         * Returns the max current the PSU can output
         * */
        public double getMaxCurrent()
        {
            return psuDriver.getMaxCurrent();
        }
        /**
         * Returns the max voltage the PSU can deliver
         * */
        public double getMaxVoltage()
        {
            return psuDriver.getMaxVoltage();
        }

        /**
         * Called when the worker thread has finished with the instrument
         * */
        protected override void instrumentFinished()
        {
            base.instrumentFinished();
            settings.setChannelValues(0, 0, 0);
            settings.setChannelValues(1, 0, 0);
            settings.setChannelStatus(0, false);
            settings.setChannelStatus(1, false);
            updateSettings();
            psuDriver.closeInstrument();
            OnInstrumentFinished(new EventArgs());
        }
    }
}
