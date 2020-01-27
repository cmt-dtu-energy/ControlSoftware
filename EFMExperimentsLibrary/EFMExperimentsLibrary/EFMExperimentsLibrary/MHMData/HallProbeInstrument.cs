using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class HallProbeInstrument : Instrument
    {
        private MHMHallprobe probe;

        public HallProbeInstrument( string file) : base()
        {
            probe = new MHMHallprobe(file);
        }
        public override void initializeInstrument()
        {
            base.initializeInstrument();
        }
        
        protected override void initializeAsync()
        {
            base.initializeAsync();
        
        }

        /**
         * 
         * */
        protected override InstrumentDataset getInstrumentData()
        {
           
            return probe.updateReading();
            

        }

        /**
         *
         * */
        protected override void updateSettings()
        {
            base.updateSettings();
          
        }


        /**
         * Stores the data that was just received from the PSU
         * */
        protected override void storeData(InstrumentDataset data)
        {
            base.storeData(data);
            try
            {
                InstrumentDatasetEventArgs datEvent = new InstrumentDatasetEventArgs();

                datEvent.dataSet = data;

                if (datEvent.dataSet != null)
                    OnSaveData(datEvent);
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
            base.updateEvents();

        }

        protected override void updateErrors()
        {
            base.updateErrors();
            
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
         * Called when the worker thread has finished with the instrument
         * */
        protected override void instrumentFinished()
        {
            base.instrumentFinished();
           
            OnInstrumentFinished(new EventArgs());
        }
    }
}
