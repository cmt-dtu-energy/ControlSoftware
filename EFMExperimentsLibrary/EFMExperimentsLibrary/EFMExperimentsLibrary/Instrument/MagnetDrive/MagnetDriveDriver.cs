using System;
using System.Runtime.InteropServices;

namespace EFMExperimentsLibrary
{
  
    public unsafe class MagnetDriveDriver
    {

        public static short initDrive( string comPort, uint baudRate, string setupFile, byte axisID )
        {            
            short retOpen = MagnetDriveDriver.OpenChannel(comPort, 0, 0, baudRate);

            //succesful opening of the channel
            if (retOpen > 0)
            {                
                short setup = MagnetDriveDriver.LoadSetup(setupFile);

                if ( MagnetDriveDriver.SetupAxis(1, setup) != 0 )
                {
                    if (MagnetDriveDriver.SelectAxis(1) != 0)
                    {
                        if (MagnetDriveDriver.DriveInitialisation() == 0)
                        {
                            retOpen = -1;
                        }
                    }
                    else
                    {
                        retOpen = -1;
                    }
                }
                else
                {
                    retOpen = -1;
                }
            }

            return retOpen;
        }

        public struct MagnetMotorSetup
        {
            
            public MagnetMotorSetup( double _tr, int _nlines, double _tslew)
            {
                TR = _tr;
                nLines = _nlines;
                Tslew = _tslew;
            }
            //transmission ratio from motor revolution to magnet rotation
            public double TR;
            //number of encoder lines
            public int nLines;
            //slow sample period
            public double Tslew;
        }

        public static int moveMagnet(double pos, double speed,double acc,  MagnetMotorSetup setup )
        {

            int iuPos = (int) Math.Round( pos * 4 * setup.nLines * setup.TR / ( 2 * Math.PI ) );

            double iuSpeed = speed * 4 * setup.nLines * setup.TR * setup.Tslew / ( 2 * Math.PI );

            double iuAcc = acc * 4 * setup.nLines * setup.TR * setup.Tslew * setup.Tslew / ( 2 * Math.PI );

            return MoveAbsolute( iuPos, iuSpeed, iuAcc, 1, 0 );
        }

        public static double getMotorPosition(MagnetMotorSetup setup)
        {
            int val = 0;
            //kaki+floe: needs update with specific names given a specific config
            //for the magnet drive position is (apparently) Target_Position	
            string name = "Target_Position";
            GetLongVariable( name, ref val );

            double retVal = val * 2 * Math.PI / (4 * setup.nLines * setup.TR);
            return retVal;
        }

        [DllImport("TML_lib.dll", EntryPoint = "_TS_OpenChannel@16", SetLastError = true,
       CharSet = CharSet.Ansi, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern short OpenChannel(string name, byte type, byte hostID, uint baudRate);


        [DllImport("TML_lib.dll", EntryPoint = "_TS_LoadSetup@4", SetLastError = true,
       CharSet = CharSet.Ansi, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern short LoadSetup(string path);

        [DllImport("TML_lib.dll", EntryPoint = "_TS_SetupAxis@8", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]        
        public static extern int SetupAxis(byte axisID, short index);

        [DllImport("TML_lib.dll", EntryPoint = "_TS_SelectAxis@4", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int SelectAxis(byte axisID);

        [DllImport("TML_lib.dll", EntryPoint = "_TS_DriveInitialisation@0", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int DriveInitialisation();

        [DllImport("TML_lib.dll", EntryPoint = "_TS_Power@4", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int Power(short enabled);

        [DllImport("TML_lib.dll", EntryPoint = "_TS_CloseChannel@4", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseChannel(short enabled);

        [DllImport("TML_lib.dll", EntryPoint = "_TS_MoveAbsolute@28", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int MoveAbsolute(int pos, double speed, double acc, short moveMoment, short refBase);

        [DllImport("TML_lib.dll", EntryPoint = "_TS_GetIntVariable@8", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int GetIntVariable( string name, ref short value );

        [DllImport("TML_lib.dll", EntryPoint = "_TS_GetLongVariable@8", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int GetLongVariable(string name, ref int value);

        [DllImport("TML_lib.dll", EntryPoint = "_TS_Reset@0", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int Reset();

        [DllImport("TML_lib.dll", EntryPoint = "_TS_ResetFault@0", SetLastError = true,
       CharSet = CharSet.Ansi, ExactSpelling = true,
       CallingConvention = CallingConvention.StdCall)]
        public static extern int ResetFault();
    }
}
