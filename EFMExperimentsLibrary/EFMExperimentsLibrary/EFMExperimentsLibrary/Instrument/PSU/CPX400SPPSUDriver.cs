using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Globalization;
using NationalInstruments.Visa;
namespace EFMExperimentsLibrary
{
    /**
     * Class that encapsulates a connection to an ISOTech PSU
     * and implements its functionality
     * */
    public class CPX400SPPSUDriver : AbstractPSUDriver
    {
        //private SerialSession mbSession;
        private GpibSession mbSession;
        
        private double[] currentSet_buffer = new double[2];
        private double[] voltageSet_buffer = new double[2];

        private double[] previousCurrent = new double[2];
        private double[] previousVoltage = new double[2];

        private bool outEnabled = false;
        public CPX400SPPSUDriver(GPIBPSUDriverInstrumentSettings setts)
        {
            driverSettings = setts;
        }
        /**
         * 
         * */
        ~CPX400SPPSUDriver()
        {
            if (mbSession != null)
            {
                mbSession.Dispose();
            }            
        }

        /**
         * Tries to open the GPIB port and sets flags depending on succes or not
         * */
        override public bool openInstrument( )
        {
            
            bool retval = false;
            using (var rmSession = new ResourceManager())
            {
                try
                {
                    GPIBPSUDriverInstrumentSettings setts = (GPIBPSUDriverInstrumentSettings)driverSettings;
                    /* mbSession = (SerialSession)rmSession.Open(setts.address);
                     mbSession.BaudRate = 9600;
                     mbSession.DataBits = 8;
                     mbSession.FlowControl = Ivi.Visa.SerialFlowControlModes.None;
                     mbSession.Parity = Ivi.Visa.SerialParity.None;
                     mbSession.StopBits = Ivi.Visa.SerialStopBitsMode.One;
                     */
                    mbSession = (GpibSession)rmSession.Open(setts.address);
                    

                    retval = true;
                    initialized = true;
                }
                catch (InvalidCastException)
                {                    
                }
                catch (Exception exp)
                {                 
                }
                
            }
             
            return retval;
        }

        
        /**
         * closes the instrument
         * */
        override public void closeInstrument()
        {
            if ( mbSession != null)
                mbSession.Dispose();
        }
        /**
         * Send a command to the unit on the COM port
         * */
        private void sendCommand( string command)
        {
            if ( mbSession != null )
            {
                mbSession.RawIO.Write(command + "\n");
            }
        }
        /**
         * Interpret the command and return the proper string 
         * PSUIOValues indicates the type of action requested
         * int chn the channel number
         * double value the optional output value
         * represenation for the PSU 
         * */
        private string getCmd( PSUIOValues val, int chn, double value )
        {
            string cmd = "";
            switch (val)
            {
                case PSUIOValues.CurrentSet:
                    cmd = "I1?";
                    break;
                case PSUIOValues.SetCurrent:
                    cmd = "I1 "  + value.ToString(CultureInfo.InvariantCulture);
                    break;
                case PSUIOValues.VoltageSet:
                    cmd = "V1?";
                    break;
                case PSUIOValues.SetVoltage:
                    cmd = "V1 " + value.ToString(CultureInfo.InvariantCulture);
                    break;
                case PSUIOValues.CurrentOut:
                    cmd = "I1O?";
                    break;
                case PSUIOValues.VoltageOut:
                    cmd = "V1O?";
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
            if ( validateChannel(chn) && mbSession != null )
            {
                string command = getCmd(val, chn, 0);
                mbSession.RawIO.Write(command + "\n");
                Thread.Sleep(100);
                string retString = mbSession.RawIO.ReadString();
                try
                {
                    //The format of the output is "V 1 VAL" (V is for voltage; if a current is returned then V->I)                    
                    retval = Convert.ToDouble(retString.Substring(3), CultureInfo.InvariantCulture);
                }
                catch(FormatException ex)
                {

                }
                catch( OverflowException ex)
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
                string command = getCmd(field,chn,value);
                
                sendCommand(command);
            }
        }

        /**
         * Ensures a correct channel is attempted to be used
         * */
        private bool validateChannel( int chn)
        {
            if (chn != 0)
                return false;
            return true;
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
            return 20;//amps
        }
        public override double getMaxVoltage()
        {
            return 28;//volts
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
                    sendCommand("OP1 0");
                    outEnabled = false;
                }
                else
                {                    
                    if (!outEnabled)
                    {                        
                        sendCommand("OP1 1");
                        outEnabled = true;
                    }
                }
            }
        }

        public override void setTrackingMode(AbstractPSUTrackingMode mode)
        {

        }
       
    }
    
}

