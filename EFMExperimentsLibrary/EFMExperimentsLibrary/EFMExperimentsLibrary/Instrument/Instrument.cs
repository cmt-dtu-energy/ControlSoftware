using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace EFMExperimentsLibrary
{
    /**
     * This class is the parent for all instrument handlers.
     * It implements data collection asynchronously as well as callback
     * events for saving data
     * 
     **/
    public class Instrument
    {       
        //Handlers for when to save data
        public event EventHandler<InstrumentDatasetEventArgs> SaveData;

        //Handler to change events of the instrument (such as close or init)
        public event EventHandler InstrumentFinished, InstrumentInitialized;

        //Event handler for updates on errors
        public event EventHandler<InstrumentMessageEventArgs> InstrumentErrorUpdate;

        //Public variables
        public string instrumentIdentifier { get; set; }


        //Private variables
        //private ExperimentControl ExperimentControlCallback = new ExperimentControl();
        private BackgroundWorker bw = new BackgroundWorker();

        protected int threadWaitTime = 3000;

        //Constructor
        public Instrument()
        {
            
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        /**
         * 
         * Overriding classes should do specific instrument initialization and then call this method
         * */
        public virtual void initializeInstrument()
        {
            //First make sure to update the settings of the device (which channels to log etc.)
            updateSettings();
            //When succesfully initialized start the logger thread
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
            if ( InstrumentInitialized != null )
                InstrumentInitialized(this, new EventArgs());
        }
        /**
         * returns true if the thread is canceling. False if it is already set to cancel
         * */
        public bool closeInstrument()
        {
            if (bw.CancellationPending || !bw.IsBusy)
                return false;

            bw.CancelAsync();
            return true;
        }

        

        /**
         * Called when the logger thread starts
         * */
        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            initializeAsync();
            while (!worker.CancellationPending)
            {
                //Get data from the instrument
                InstrumentDataset currentData = getInstrumentData();
                
                //save this data into the software data buffer
                storeData(currentData);
                //update events
                updateEvents();

                //Update any errors
                updateErrors();

                //update the settings if necessary
                updateSettings();

                Thread.Sleep(500);
            
            }
            e.Cancel = true;
        }

        protected virtual void initializeAsync()
        {

        }

        /**
         * Should implement the hardware/instrument specific data retrieval
         * and return it in a InstrumentDataset object
         * */
        protected virtual InstrumentDataset getInstrumentData()
        {
            return null;
        }
        /**
         * Should implement saving the current data from the instrument to the software buffer
         * */
        protected virtual void storeData(InstrumentDataset data)
        {

        }

        /**
         * Updates save events
         * */
        protected virtual void updateEvents()
        {

        }

        protected virtual void updateErrors()
        {

        }

        protected virtual void instrumentFinished()
        {
            if (InstrumentFinished != null)
                InstrumentFinished(this, new EventArgs());
        }

        /**
         * updates the device settings - should be overridden by the implementers
         * */
        protected virtual void updateSettings()
        {

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {

            }

            else if (!(e.Error == null))
            {

            }

            else
            {

            }
            instrumentFinished();
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        /**
         * Returns the latest data set for the relevant instrument
         * Should be overridden by any subclass
         * */
        public virtual InstrumentDataset getLatestData()
        {
            return new InstrumentDataset();
        }

        protected void OnSaveData(InstrumentDatasetEventArgs e)
        {
            EventHandler<InstrumentDatasetEventArgs> handler = SaveData;
            if (handler != null)
            {                                
                handler(this, e);
            }
        }
        

        protected void OnInstrumentFinished(EventArgs e)
        {
            if (InstrumentFinished != null)
            {
                InstrumentFinished(this, e);
            }
        }

        protected void OnInstrumentInitialized(EventArgs e)
        {
            if (InstrumentInitialized != null)
            {
                InstrumentInitialized(this, e);
            }
        }

        protected void OnInstrumentErrorUpdate(InstrumentMessageEventArgs e)
        {
            if (InstrumentErrorUpdate != null)
            {
                InstrumentErrorUpdate(this, e);
            }
        }
        
    }
    public class InstrumentDatasetEventArgs : EventArgs
    {
        public InstrumentDataset dataSet { get; set; }
    }
    public class InstrumentMessageEventArgs : EventArgs
    {
        public string message { get; set; }
    }
}
