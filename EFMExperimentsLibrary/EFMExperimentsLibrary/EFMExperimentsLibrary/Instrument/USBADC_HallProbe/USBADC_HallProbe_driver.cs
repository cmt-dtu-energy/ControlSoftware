using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace EFMExperimentsLibrary
{
    public unsafe class USBADC_HallProbe_driver
    {
        private int handle;
        private const int maxCur = 10;//mA
        public USBADC_HallProbe_driver()
        {
            int tmp = ads_hallprobe_initUSB();
            //initialize the DAC
            handle = ads_hallprobe_init(0);
            if ( handle > 0 )
            {
                ads_hallprobe_SetRange(1);
            }
            sens[0] = 0.0673;//V/T
            sens[1] = 0.0532;//V/T
            sens[2] = 0.0473;//V/T

            offset[0] = 0.00012;//V
            offset[1] = -0.000065;// V
            offset[2] = 0.00006;//V
        }

        public void setEnabledADC( bool enabled )
        {
            if (handle > 0)
            {
                //find the bit range
                int bitRange = ads_hallprobe_get_dac_res();
                int maxVal = 0;
                if (bitRange == 14)
                    maxVal = 16000;
                else
                    maxVal = 64000;
                
                //find the current range
                int curRange = ads_hallprobe_get_current_range();
                if (enabled)
                {

                    short outCurrent = (short)((double)maxCur / (double)curRange * maxVal);
                    ads_hallprobe_current(outCurrent);

                }
                else
                {
                    ads_hallprobe_current((short)0);
                }
            }
        }

        private double[] sens = new double[3];
        private double[] offset = new double[3];


        public double[] get3AxisValues()
        {
            double[] retval = new double[3];

            retval[0] = ads_hallprobe_get_measurement(2, 4, 0);
            retval[1] = ads_hallprobe_get_measurement(2, 4, 1);
            retval[2] = ads_hallprobe_get_measurement(2, 4, 2);

            //convert to Tesla
            for (int i = 0; i < 3; i++)
                retval[i] = (retval[i] - offset[i]) / sens[i];

            ads_hallprobe_calibration(0, 4, 2);

            return retval;
        }

        [DllImport("ad24usb.dll", EntryPoint = "InitUSB", SetLastError = true,
       CharSet = CharSet.Ansi, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern int ads_hallprobe_initUSB();

        [DllImport("ad24usb.dll", EntryPoint = "InitSelectedAD", SetLastError = true,
          CharSet = CharSet.Ansi, ExactSpelling = true,
          CallingConvention = CallingConvention.StdCall)]
        public static extern int ads_hallprobe_init( int id);

        [DllImport("ad24usb.dll", EntryPoint = "SetRange", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int ads_hallprobe_SetRange(int range);


        [DllImport("ad24usb.dll", EntryPoint = "calibration", SetLastError = true,
                CharSet = CharSet.Ansi, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
        public static extern int ads_hallprobe_calibration(int typ, int range, int resol);

        [DllImport("ad24usb.dll", EntryPoint = "DAC", SetLastError = true,
                CharSet = CharSet.Ansi, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
        public static extern int ads_hallprobe_current(short value);


        [DllImport("ad24usb.dll", EntryPoint = "GetCurrentRange", SetLastError = true,
                CharSet = CharSet.Ansi, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
        public static extern int ads_hallprobe_get_current_range();

        [DllImport("ad24usb.dll", EntryPoint = "GetDACresolution", SetLastError = true,
                CharSet = CharSet.Ansi, ExactSpelling = true,
                CallingConvention = CallingConvention.StdCall)]
        public static extern int ads_hallprobe_get_dac_res();

        [DllImport("ad24usb.dll", EntryPoint = "Adconv", SetLastError = true,
              CharSet = CharSet.Ansi, ExactSpelling = true,
              CallingConvention = CallingConvention.StdCall)]
        public static extern double ads_hallprobe_get_measurement(int resol, int range, int chan);

    }
}
