using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public enum Keithley2700ChannelUnits { Volts, Amps, Ohms, TempK, TempC, NoUnit }
    public enum Keithley2700MeasurementTypes { U, R_TwoPoint, R_FourPoint, TC_E, TC_K, NoType, I }
    
    public class Keithley2700Settings : InstrumentSettings
    {
        
        private double[] reading;
        private Keithley2700ChannelUnits[] units;
        private Keithley2700MeasurementTypes[] measureType;
        private bool[] channelEnabled;
        private double[] sensitivity;
        private double[] maxRange;

        public static double DefaultSensitivity = 0.00001;
        public static double DefaultMaxRange = 1;
        public static double DefaultTriggerDelay = 0.01;

        public double triggerDelay { get; set; }

        public static Keithley2700ChannelUnits DefaultUnit = Keithley2700ChannelUnits.Volts;
        public static Keithley2700MeasurementTypes DefaultType = Keithley2700MeasurementTypes.U;

        public Keithley2700Settings() : base()
        {
            numberOfChannels = 22;
            initializeArrays();
            triggerDelay = DefaultTriggerDelay;
            settingsChanged = true;
        }

        protected override void initializeArrays()
        {
            base.initializeArrays();

            reading = new double[numberOfChannels];
            units = new Keithley2700ChannelUnits[numberOfChannels];
            measureType = new Keithley2700MeasurementTypes[numberOfChannels];
            channelEnabled = new bool[numberOfChannels];
            sensitivity = new double[numberOfChannels];
            maxRange = new double[numberOfChannels];

            for ( int i = 0; i < numberOfChannels; i++ )
            {
                units[i] = DefaultUnit;
                channelEnabled[i] = false;
                sensitivity[i] = DefaultSensitivity;
                maxRange[i] = DefaultMaxRange;
                measureType[i] = DefaultType;
            }
        }

        public double getChannelReading( int chn )
        {
            if ( isValidChannelIndex(chn))
            {
                return reading[chn];
            }
            return 0;
        }

        public Keithley2700ChannelUnits getChannelUnit(int chn)
        {
            if (isValidChannelIndex(chn))
            {
                return units[chn];
            }
            return Keithley2700ChannelUnits.NoUnit;
        }
        public void setChannelUnit(int chn, Keithley2700ChannelUnits un)
        {
            if (isValidChannelIndex(chn))
            {
                units[chn] = un;
                changeSettings();
            }
        }


        public Keithley2700MeasurementTypes getChannelMeasurement( int chn)
        {
            if ( isValidChannelIndex(chn))
            {
                return measureType[chn];
            }
            return Keithley2700MeasurementTypes.NoType;
        }

        public void setChannelMeasurement( int chn, Keithley2700MeasurementTypes type )
        {
            if ( isValidChannelIndex(chn))
            {
                measureType[chn] = type;
                changeSettings();
            }
        }


        public bool getChannelEnabled(int chn) 
        { 
            if ( isValidChannelIndex(chn))
            {
                return channelEnabled[chn];
            }
            return false;
        }

        public void setChannelEnabled( int chn, bool enabled )
        {
            if ( isValidChannelIndex(chn))
            {
                channelEnabled[chn] = enabled;
                changeSettings();
            }
        }

        public double getChannelSensitivity( int chn )
        {
            if ( isValidChannelIndex(chn))
            {
                return sensitivity[chn];
            }
            return DefaultSensitivity;
        }

        public void setChannelSensitivity(int chn, double sens)
        {
            if (isValidChannelIndex(chn))
            {
                sensitivity[chn] = sens;
                changeSettings();
            }
        }

        public double getChannelMaxRange( int chn )
        {
            if ( isValidChannelIndex(chn))
            {
                return maxRange[chn];                
            }
            return DefaultMaxRange;
        }

        public void setChannelMaxRange( int chn, double range)
        {
            if ( isValidChannelIndex(chn))
            {
                maxRange[chn] = range;
                changeSettings();
            }
        }

        public void closeAllChannels()
        {
            for ( int i = 0; i < numberOfChannels; i++ )
            {
                setChannelEnabled(i, false);
            }
        }

    }
}
