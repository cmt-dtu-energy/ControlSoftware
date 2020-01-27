using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class PSUSettings : InstrumentSettings
    {
        private volatile double[] current;
        private volatile double[] voltage;
        private volatile AbstractPSUTrackingMode trackingMode;
        public PSUSettings()
        {
            //This is a fixed number for the PSU unit
            numberOfChannels = 2;
            initializeArrays();
            trackingMode = AbstractPSUTrackingMode.Independent;
        }

        protected override void initializeArrays()
        {            
            base.initializeArrays();

            current = new double[numberOfChannels];
            voltage = new double[numberOfChannels];
        }

        public void setTrackingMode( AbstractPSUTrackingMode mode )
        {
            if ( mode != trackingMode )
            {
                trackingMode = mode;
                settingsChanged = true;
            }
        }

        public AbstractPSUTrackingMode getTrackingMode()
        {
            return trackingMode;
        }

        public void setChannelValues( int chn, double c, double v)
        {
            if( isValidChannelIndex( chn ) )
            {
                current[(int)chn] = c;
                voltage[(int)chn] = v;
                settingsChanged = true;
            }
        }

        public double getChannelCurrent( int chn )
        {
            if ( isValidChannelIndex( chn))
            {
                return current[(int)chn];
            }
            return 0;
        }
        public double getChannelVoltage(int chn)
        {
            if (isValidChannelIndex(chn))
            {
                return voltage[(int)chn];
            }
            return 0;
        }
    }
}
