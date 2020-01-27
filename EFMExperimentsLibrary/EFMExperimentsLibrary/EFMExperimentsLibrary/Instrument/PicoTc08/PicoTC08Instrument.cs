using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace EFMExperimentsLibrary
{
    public class PicoTC08Instrument : Instrument
    {
        private short handle = -1;
        private int actual_interval_ms = 0;
        public PicoTC08Settings settings = new PicoTC08Settings();
        PicoTC08InstrumentDataset currentDataset;
        public override void initializeInstrument()
        {
            if (handle < 0)
            {
                handle = Imports.TC08OpenUnit();
                updateSettings();
                //code to report back what the hardware handle is


                if (handle == 0)
                {
                    //return an error or at least make sure the driver is in a safe state

                }
                else
                {
                    //Driver is now ready for action                
                }
                base.initializeInstrument();
            }
        }

        protected override InstrumentDataset getInstrumentData()
        {
            PicoTC08InstrumentDataset dataset = new PicoTC08InstrumentDataset();
            if (handle > 0)
            {
                int buffer_size = 1024;
                float[][] tempBuffer = new float[PicoTC08Settings.nChannels][];
                int[][] times_ms_buffer = new int[PicoTC08Settings.nChannels][];
                short[] overflow = new short[PicoTC08Settings.nChannels];

                int numberOfSamples = 0;


                for (int i = 0; i < PicoTC08Settings.nChannels; i++ )
                {
                    tempBuffer[i] = new float[buffer_size];
                    times_ms_buffer[i] = new int[buffer_size];
                }

                
                for (short i = 0; i < PicoTC08Settings.nChannels; i++)
                {
                    if (settings.getChannelType(i) != PicoTC08Settings.ChannelType.NotEnabled)
                    {
                        int nS = 0;
                        nS = Imports.TC08GetTemp(handle, tempBuffer[i], times_ms_buffer[i], buffer_size,
                                    out overflow[i], i, TempUnit.USBTC08_UNITS_KELVIN, 0);


                        if (nS > numberOfSamples)
                        {
                            numberOfSamples = nS;
                        }
                        else if (nS < 0)
                        {
                            short err = Imports.TC08GetLastError(handle);
                        }
                    }
                }

                System.Text.StringBuilder line = new System.Text.StringBuilder(256);

                Imports.TC08GetFormattedInfo( handle, line, 256);
                Console.WriteLine("{0}", line);
                

                double[,] data = new double[PicoTC08Settings.nChannels, 2];
                for ( int i = 0; i < numberOfSamples; i++ )
                {
                    for (int j = 0; j < PicoTC08Settings.nChannels; j++)
                    {
                        data[j, 0] = times_ms_buffer[j][i];
                        data[j, 1] = tempBuffer[j][i];
                    }
                    dataset.AddData(data);
                }
            }
            Thread.Sleep( actual_interval_ms );
            return dataset;
        }

        protected override void storeData(InstrumentDataset data)
        {
            currentDataset = (PicoTC08InstrumentDataset)data;
            base.storeData(data);
        }

        protected override void updateErrors()
        {
            base.updateErrors();
        }

        protected override void updateEvents()
        {
            base.updateEvents();

            InstrumentDatasetEventArgs datEvent = new InstrumentDatasetEventArgs();

            datEvent.dataSet = new PicoTC08InstrumentDataset();
            datEvent.dataSet.AddData( currentDataset.getLatestData() );

            OnSaveData(datEvent);
        }

        private void SetChannels()
        {
            short channel;
            short ok;

            for (channel = 0; channel < PicoTC08Settings.nChannels; channel++ )
            {
                ok = Imports.TC08SetChannel( handle, channel, settings.getChannelTypeChar(channel));

            }
        }


        protected override void instrumentFinished()
        {
            //make sure to close the handle
            if ( handle > 0)
                Imports.TC08CloseUnit(handle);

            handle = -1;



            base.instrumentFinished();
        }

        protected override void updateSettings()
        {
            if ( settings.settingsChanged )
            {                
                //then set the channel settings
                SetChannels();

                //then start the instrument again
                // Find the time interval
                int interval_ms = Imports.TC08GetMinIntervalMS( handle );

                actual_interval_ms = Imports.TC08Run( handle, interval_ms);

                settings.settingsChanged = false;
            }

            base.updateSettings();
        }

        public override InstrumentDataset getLatestData()
        {
            return base.getLatestData();
        }

        /**
        * Returns 1 if the instrument thread is alive. Else returns 0
        * */
        public int closeKPicoTc08Instrument()
        {
            if ( handle > 0 )
            {                
                if (closeInstrument())
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

    }

    
    
}
