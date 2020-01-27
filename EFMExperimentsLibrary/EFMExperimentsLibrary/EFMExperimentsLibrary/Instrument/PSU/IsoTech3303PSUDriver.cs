using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Globalization;
namespace EFMExperimentsLibrary
{
    /**
     * Class that encapsulates a connection to an ISOTech PSU
     * and implements its functionality
     * */
    public class IsoTech3303PSUDriver : AbstractPSUDriver
    {

        public enum IsoTech3303PSU_Errors{MnemonicTooLong,InvalidCharacter,MissingParameter,OutOfRange,CmdNotAllowed,UndefHeader,NoError}

              

        private static int readTimeout = 2000;//ms
        private static int writeTimeout = 2000;//ms
        private SerialPort serialPort = null;

        private volatile bool dataReceived = false;
        private string dataIn = "";
        private volatile string dataStringReceived = "";

        private double[] currentSet_buffer = new double[2];
        private double[] voltageSet_buffer = new double[2];

        private double[] previousCurrent = new double[2];
        private double[] previousVoltage = new double[2];

        private bool outEnabled = false;
        public IsoTech3303PSUDriver(IsoTech3303PSUDriverInstrumentSettings setts)
        {
            driverSettings = setts;
        }
        public IsoTech3303PSUDriver()
        {

        }
        /**
         * 
         * */
        ~IsoTech3303PSUDriver()
        {
            if ( serialPort != null )
            {
                serialPort.Close();
            }
        }

        /**
         * Tries to open the COM port and sets flags depending on succes or not
         * */
        override public bool openInstrument( )
        {
            if (serialPort == null)
            {
                try
                {
                    serialPort = new SerialPort(((IsoTech3303PSUDriverInstrumentSettings)driverSettings).comPort, ((IsoTech3303PSUDriverInstrumentSettings)driverSettings).baudRate,
                        ((IsoTech3303PSUDriverInstrumentSettings)driverSettings).parity, ((IsoTech3303PSUDriverInstrumentSettings)driverSettings).dataBits, ((IsoTech3303PSUDriverInstrumentSettings)driverSettings).stopBits);
                    serialPort.ReadTimeout = readTimeout;
                    serialPort.WriteTimeout = writeTimeout;
                    serialPort.DataReceived += serialPort_DataReceived;

                    setInitialSettings();
                    
                }
                catch (IOException ex)
                {
                    return false;
                }
                serialPort.Open();
                initialized = true;
                return true;
            }
            return false;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            SerialPort port = (SerialPort)sender;
            String s = port.ReadExisting();
            if ( s.Contains("\r") )
            {                
                dataStringReceived = dataIn;
                dataIn = "";
                dataReceived = true;
            }
            else
            {
                dataIn += s;
                dataReceived = false;
            }
        }

        /**
         * closes the instrument
         * */
        override public void closeInstrument()
        {
            if (serialPort != null)
            {
                saveSettings();
                sendCommand("OUT0");
                sendCommand("LOCAL");
                outEnabled = false;
                currentSet_buffer[0] = 0;
                currentSet_buffer[1] = 0;
                voltageSet_buffer[0] = 0;
                voltageSet_buffer[1] = 0;
                serialPort.Close();
                serialPort = null;
                initialized = false;
            }
        }
        /**
         * Send a command to the unit on the COM port
         * */
        private void sendCommand( string command)
        {
            if ( serialPort != null )
            {
                try
                {
                    command += serialPort.NewLine;
                    serialPort.Write(command);
                    command = "";
                }
                catch ( InvalidOperationException ex )
                {

                }
                catch ( ArgumentNullException ex )
                {

                }
                catch ( TimeoutException ex )
                {

                }
            }
        }
        /**
         * Interpret the command and return the proper string 
         * represenation for the PSU 
         * */
        private string getCmd( PSUIOValues val )
        {
            string cmd = "";
            switch (val)
            {
                case PSUIOValues.CurrentSet:
                case PSUIOValues.SetCurrent:


                    cmd = "ISET";
                    break;
                case PSUIOValues.VoltageSet:
                case PSUIOValues.SetVoltage:
                    cmd = "VSET";
                    break;
                case PSUIOValues.CurrentOut:
                    cmd = "IOUT";
                    break;
                case PSUIOValues.VoltageOut:
                    cmd = "VOUT";
                    break;
                default:
                    break;
            }
            return cmd;
        }
        /**
         * Get the specified value from the PSU
         * */
        private double getValue( int chn, PSUIOValues val )
        {
            double retval = 0;
            if (validateChannel(chn) )
            {                
                string cmd = getCmd(val);
                //remember to add one since the PSU assumes channel 1 and 2, i.e. is index-1 based
                string command = cmd + (chn+1).ToString() + "?";
                //flag the datareceived to be false so the eventhandler will start picking up data
                dataReceived = false;
                dataStringReceived = "";
                //send the command to the PSU
                sendCommand(command);
                
                //set values for the wait loop
                int ti_max = 200;
                int ti = 0;
                while ( !dataReceived && ti < ti_max )
                {
                    Thread.Sleep(1);
                    ti++;
                }
                //convert the received string to a useful number
                string s = dataStringReceived; ;
                try
                {
                    string subStr = dataStringReceived.Substring(0, dataStringReceived.Length - 1);
                    
                    retval = Double.Parse(subStr,CultureInfo.InvariantCulture);
                }
                catch ( Exception ex )
                {

                }
            }
            
            return retval;
        }

        /**
         * Returns true if the new value requested is different from the previous value
         * Return false if not
         * */
        private bool newValue( int chn, double value, PSUIOValues field )
        {
            bool retval = false;

            switch( field )
            {
                case PSUIOValues.SetCurrent:
                    if ( previousCurrent[chn] != value )
                    {
                        retval = true;
                        previousCurrent[chn] = value;                        
                    }
                    break;
                case PSUIOValues.SetVoltage:
                    if (previousVoltage[chn] != value)
                    {
                        retval = true;
                        previousVoltage[chn] = value;
                        
                    }
                    break;
                default:
                    break;
            }

            return retval;
        }

        /**
         * Set a value (e.g. current)
         * */
        private void setValue( int chn, double value, PSUIOValues field )
        {
            if (validateChannel(chn) ) //&& newValue(chn,value,field))
            {
                string cmd = getCmd(field);

                

                string command = cmd + (chn+1).ToString(CultureInfo.InvariantCulture) + ":" + value.ToString(CultureInfo.InvariantCulture);

                sendCommand(command);
            }
        }

        /**
         * Ensures a correct channel is attempted to be used
         * */
        private bool validateChannel( int chn)
        {
            if (chn < 0 || chn > 1)
                return false;
            return true;
        }

        /**
         * Set the tracking mode (independent, series or parallel)
         * */
        override public void setTrackingMode( AbstractPSUTrackingMode mode )
        {
            string cmd = "TRACK";
            switch ( mode )
            {
                case AbstractPSUTrackingMode.Independent:
                    cmd += "0";
                    break;
                case AbstractPSUTrackingMode.Series:
                    cmd += "1";
                    break;
                case AbstractPSUTrackingMode.Parallel:
                    cmd += "2";
                    break;
            }
            sendCommand(cmd);
        }

        /**
         * Sets the current (cur) on channel (chn)
         * */
        override public void setCurrent(int chn, double cur)
        {
            setValue(chn, cur, PSUIOValues.SetCurrent);                            
        }

        /**
         * Returns the set current
         * */
        override public double getSetCurrent( int chn)
        {
            return getValue(chn, PSUIOValues.CurrentSet);            
        }

        /**
         * Returns the actual current 
         * */
        override public double getOutCurrent( int chn )
        {
            return getValue(chn, PSUIOValues.CurrentOut);
        }

        /**
         * Sets the voltage (vol) on channel (chn)
         * */
        override public void setVoltage( int chn, double vol)
        {
            setValue(chn, vol, PSUIOValues.SetVoltage);
        }

        /**
         * Returns the set voltage
         * */
        override public double getSetVoltage(int chn)
        {
            return getValue(chn, PSUIOValues.VoltageSet);
        }

        /**
         * Returns the actual voltage
         * */
        override public double getOutVoltage(int chn)
        {
            return getValue(chn, PSUIOValues.VoltageOut);
        }

        public override double getMaxCurrent()
        {
            return 3;//amps
        }
        public override double getMaxVoltage()
        {
            return 30;//volts
        }

        /**
         * Sets whether the PSU outputs (enabled = true) or not (enabled = false)
         * This PSU only supports out on/off on both channels simultaneously
         * So we need to set the current and voltage to zero on the
         * requested channel when output = false is requested.
         * */
        override public void setOutput( int chn, bool enabled)
        {
            if (validateChannel(chn))
            {
                if (!enabled)
                {
                    currentSet_buffer[chn] = getSetCurrent(chn);
                    voltageSet_buffer[chn] = getSetVoltage(chn);

                    setCurrent(chn, 0);
                    setVoltage(chn, 0);
                }
                else
                {                    
                    if (!outEnabled)
                    {
                        setCurrent(chn, currentSet_buffer[chn]);
                        setVoltage(chn, voltageSet_buffer[chn]);
                        sendCommand("OUT1");
                        outEnabled = true;
                    }
                }
            }
        }

        
       
    }
    public class IsoTech3303PSUDriverInstrumentSettings : AbstractPSUDriverInstrumentSettings
    {
        public string comPort{get; protected set;}
        public int baudRate{get; protected set;}
        public Parity parity{get; protected set;}
        public int dataBits{get; protected set;}
        public StopBits stopBits{get; protected set;}
        public IsoTech3303PSUDriverInstrumentSettings( string port, int baud, Parity par, int dBits, StopBits sBits )
        {
            comPort = port;
            baudRate = baud;
            parity = par;
            dataBits = dBits;
            stopBits = sBits;
        }
    }
}

