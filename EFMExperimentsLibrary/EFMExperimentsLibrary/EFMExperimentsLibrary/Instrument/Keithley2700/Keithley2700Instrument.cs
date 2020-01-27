using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Keithley.IVI.NET2;

namespace EFMExperimentsLibrary
{
    public class Keithley2700Instrument : Instrument
    {
        private KE2700 ke2700Driver;

        private string device = "GPIB0::16::INSTR";
        private string options = "Simulate=0,RangeCheck=1,QueryInstrStatus=1,Cache=1";


        public Keithley2700Settings settings { get; set; }

        private Keithley2700SeebeckDataset dataSet = new Keithley2700SeebeckDataset();

        private const int maxBufsize = 1000000;

        private int debugCnt;

        public DateTime dtStartTimestamp { get; protected set; }

        public Keithley2700Instrument() : base()
        {
            debugCnt = 0;
            settings = new Keithley2700Settings();
            dataSet.buffsize(maxBufsize);
            dataSet.BufferFull += dataSet_BufferFull;
            threadWaitTime = 0;
        }

        public override void initializeInstrument()
        {            
            ke2700Driver = new KE2700(device, true, true, options);
            string[] dt = convertToKeithleyFormat();
            ke2700Driver.SetString(KE2700Properties.SysDate,"",dt[0]);
            ke2700Driver.SetString(KE2700Properties.SysTime, "", dt[1]);
            base.initializeInstrument();
        }

        private string[] convertToKeithleyFormat()
        {
            string[] ret = new string[2];

            DateTime dt = DateTime.Now;

            string date = dt.ToString("yyyy,MM,dd");

            string time = dt.ToString("HH,mm,ss");

            ret[0] = date;
            ret[1] = time;

            dtStartTimestamp = dt;

            return ret;
        }

        private void dataSet_BufferFull(object sender, InstrumentDatasetEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override InstrumentDataset getInstrumentData()
        {
            Keithley2700SeebeckDataset dat = new Keithley2700SeebeckDataset();

            int nPoints = dat.getNPoints();

            double[,] vals = new double[nPoints,2];


            Int32 maxTime = 5000;
            double[] dataPoints = new double[nPoints];
            Int32 nPts;
            int bytesRead;
            StringBuilder bufStr = new StringBuilder(nPoints * 80);


            ke2700Driver.ReadMultiPoint(maxTime, nPoints, dataPoints, out nPts);
            
                       
            ke2700Driver.FetchBufferData(KE2700Constants.ElementReading | KE2700Constants.ElementChan | KE2700Constants.ElementTstamp, 0, 0, nPoints * 80, bufStr, out bytesRead);
            
            string reading = (bufStr.ToString()).Substring(0, bytesRead);

            string[] values = reading.Split(',');
            
            
            for (int i = 0; i < values.Length; i += 4)
            {
                int chn = Convert.ToInt32(values[i + 3]) -101;
                if (0 <= chn && chn < nPoints)
                {
                    //timestamp
                    vals[chn, 0] = getTimeElapsed(values[i + 2], values[i + 1]);
                    //reading
                    vals[chn, 1] = double.Parse(values[i + 0], CultureInfo.InvariantCulture);
                    
                }                
            }
           
            dat.AddData(vals);

            return dat;

        }

        private double getTimeElapsed(string date, string time)
        {
            string[] dtSplit = date.Split('-');

            int[] date_int = interpretKeithleyDateFormat( dtSplit[2], dtSplit[1], dtSplit[0] );
            
            char[] tSep = new char[2];
            
            tSep[0] = ':';
            tSep[1] = '.';
            string[] tSplit = time.Split(tSep);
            

            int h = Convert.ToInt32(tSplit[0]);
            int m = Convert.ToInt32(tSplit[1]);
            int s = Convert.ToInt32(tSplit[2]);
            int ms = 10 * Convert.ToInt32(tSplit[3]);            

            DateTime dt = new DateTime(date_int[0], date_int[1], date_int[2], h, m, s, ms);

            TimeSpan timeDiff = dt - dtStartTimestamp;


            return timeDiff.TotalSeconds;
        }

        private int[] interpretKeithleyDateFormat( string Y, string M, string D )
        {
            int[] retval = new int[3];

            retval[0] = Convert.ToInt32(Y);
            retval[2] = Convert.ToInt32(D);

            switch( M)
            {
                case "Jan":
                    retval[1] = 1;
                    break;
                case "Feb":
                    retval[1] = 2;
                    break;
                case "Mar":
                    retval[1] = 3;
                    break;
                case "Apr":
                    retval[1] = 4;
                    break;
                case "May":
                    retval[1] = 5;
                    break;
                case "Jun":
                    retval[1] = 6;
                    break;
                case "Jul":
                    retval[1] = 7;
                    break;
                case "Aug":
                    retval[1] = 8;
                    break;
                case "Sep":
                    retval[1] = 9;
                    break;
                case "Oct":
                    retval[1] = 10;
                    break;
                case "Nov":
                    retval[1] = 11;
                    break;
                case "Dec":
                    retval[1] = 12;
                    break;

                default:
                    break;

            }


            return retval;

        }
       
        protected override void updateSettings()
        {            
            base.updateSettings();
            if ( settings.settingsChanged )
            {
                int nChnOpen = 0;
                ke2700Driver.reset();
                string globalList = "";
                for (int i = 0; i < settings.getNumberOfChannels(); i++)
                {
                    if (settings.getChannelEnabled(i))
                    {
                        nChnOpen++;

                        string chnName = "1";
                        if (i + 1 < 10)
                            chnName += "0";
                        chnName += (i + 1).ToString();

                        globalList += chnName + ",";

                        ke2700Driver.SetChannelList(chnName);

                        double sens = settings.getChannelSensitivity(i);
                        double range = settings.getChannelMaxRange(i);

                        int kTUnit = getTemperatureUnit( settings.getChannelUnit(i) );

                        

                        switch (settings.getChannelMeasurement(i))
                        {
                            case Keithley2700MeasurementTypes.U:
                                ke2700Driver.ConfigureMeasurement(KE2700Constants.DcVolts, range, sens);
                                break;

                            case Keithley2700MeasurementTypes.TC_E:
                                ke2700Driver.SetInt32(KE2700Properties.TempUnit, "", kTUnit);

                                //denne linie angiver, at cold junction er TcRefInternal, altså boardets inbyggede temperaturføler
                                //ke2700Driver.ConfigureThermocouple(KE2700Constants.TempTcE, KE2700Constants.TcRefInternal);

                                //denne linie, at vi bruger en ekstern reference
                                ke2700Driver.ConfigureThermocouple(KE2700Constants.TempTcE, KE2700Constants.TcRefInternal);
                                                                

                                ke2700Driver.ConfigureMeasurement(KE2700Constants.Temperature, range, sens);
                                break;

                            case Keithley2700MeasurementTypes.TC_K:
                                
                                ke2700Driver.SetInt32(KE2700Properties.TempUnit, "", kTUnit);                                
                                try
                                {
                                    ke2700Driver.ConfigureMeasurement(KE2700Constants.Temperature, KE2700Constants.AutoRangeOn, sens);
                                }
                                catch(Exception ex )
                                {                                    
                                    string msg = ke2700Driver.GetString(KE2700Properties.ErrorQueueNext, "");
                                }
                                
                                ke2700Driver.ConfigureTransducerType(KE2700Constants.Thermocouple);

                                //denne linie angiver, at cold junction er TcRefInternal, altså boardets inbyggede temperaturføler
                                ke2700Driver.ConfigureThermocouple(KE2700Constants.TempTcK, KE2700Constants.TcRefInternal);

                                //denne linie, at vi bruger en ekstern reference. Default er, at den bruger Pt-100 element forbundet til kanal 101 og 111

                                //ke2700Driver.ConfigureThermocouple(KE2700Constants.TempTcK, KE2700Constants.TcRefExternal);
                                //ke2700Driver.ConfigureThermocouple(KE2700Constants.TempTcK, KE2700Constants.TcRefSimulated);
                                //ke2700Driver.ConfigureSimRefJunction(0.0);


                                
                            
                                
                                break;

                            case Keithley2700MeasurementTypes.R_FourPoint:
                                ke2700Driver.SetInt32(KE2700Properties.TempUnit, "", kTUnit);
                                //ke2700Driver.ConfigureMeasurement(KE2700Constants._4WireRes, range, sens);
                                ke2700Driver.ConfigureMeasurement(KE2700Constants.Temperature, range, sens);
                                ke2700Driver.ConfigureFRTDType(KE2700Constants.TempFrtdPt100);
                                break;

                            case Keithley2700MeasurementTypes.R_TwoPoint:
                                ke2700Driver.ConfigureMeasurement(KE2700Constants._2WireRes, range, sens);
                                break;      
      
                            case Keithley2700MeasurementTypes.I:
                                ke2700Driver.ConfigureMeasurement(KE2700Constants.DcCurrent, range, sens);
                                break;
                            default:
                                break;
                        }
                        ke2700Driver.ConfigureApertureTimeInfo(5, KE2700Constants.PowerLineCycles);
                    }
                }
                if (nChnOpen > 0)
                {
                    globalList = globalList.Substring(0, globalList.Length - 1);

                    ke2700Driver.SetChannelList(globalList);
                    ke2700Driver.ConfigureTrigger(KE2700Constants.Immediate, settings.triggerDelay);
                    ke2700Driver.ConfigureMultiPoint(1, nChnOpen, KE2700Constants.Immediate, 0.0);
                    ke2700Driver.SetInt32(KE2700Properties.BufTimestampType, "", KE2700Constants.TimestampDelta);                 
                }
                settings.settingsChanged = false;
            }
        }

        private int getTemperatureUnit(Keithley2700ChannelUnits unit)
        {
            int kTUnit = KE2700Constants.TempKelvin;            
            if (unit == Keithley2700ChannelUnits.TempC)
                kTUnit = KE2700Constants.TempCelsius;

            return kTUnit;
        }
                


            //ke2700Driver.SetChannelList("110");
            //            ke2700Driver.ConfigureMeasurement(KE2700Constants.Temperature, 100, 0.1);

            //ke2700Driver.SetInt32(KE2700Properties.TempUnit, KE2700Constants.TempCelsius);


            //ke2700Driver.ConfigureTransducerType(KE2700Constants.Thermocouple);

            //ke2700Driver.ConfigureThermocouple(KE2700Constants.TempTcK, KE2700Constants.TcRefInternal);

            //ke2700Driver.ConfigureThermistor(KE2700Constants.TempFrtdPt100);
            //ke2700Driver.SetChannelList("110,120");
            //ke2700Driver.SetInt32(KE2700Properties.BufTimestampType, KE2700Constants.TimestampRtclock);

            //ke2700Driver.ConfigureApertureTimeInfo(1, KE2700Constants.Seconds);

            //    ke2700Driver.ConfigureMonitorChannel("", 0, KE2700Constants.ScanTriggerImm);
            //  ke2700Driver.SetInt32(KE2700Properties.BufElements, KE2700Constants.Element_Reading | KE2700Constants.Element_Channel | KE2700Constants.Element_Tstamp);

            //updateKeithleyReadings();
        

        protected override void storeData(InstrumentDataset data)
        {            
            base.storeData(data);
            dataSet.AddData(data.getLatestData());
        }

        protected override void updateEvents()
        {            
            base.updateEvents();
            /**
             * Decides whether the saver-object should process the data
             * based on the settings (how often to save compared to how often data is retrieved from the device)
             * */
            InstrumentDatasetEventArgs datEvent = new InstrumentDatasetEventArgs();

            datEvent.dataSet = new Keithley2700SeebeckDataset();
            datEvent.dataSet.AddData(dataSet.getLatestData());

            OnSaveData(datEvent);
        }
        
        protected override void updateErrors()
        {
            //throw new NotImplementedException();
            base.updateErrors();
            InstrumentMessageEventArgs evt = new InstrumentMessageEventArgs();
            evt.message = "Reading # " + debugCnt.ToString();            
            OnInstrumentErrorUpdate(evt);
            debugCnt++;
        }

        public override InstrumentDataset getLatestData()
        {            
            return base.getLatestData();
        }
        protected override void instrumentFinished()
        {
            //throw new NotImplementedException();
            base.instrumentFinished();
            OnInstrumentFinished(new EventArgs());
            ke2700Driver.Disable();
            ke2700Driver.Dispose();
        }

        /*
        public void changeThreadWaitTime(int time)
        {
            Global.threadWaittimeGlobal = time;
        }
         * */
    }
}
