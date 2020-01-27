using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMExperimentsLibrary
{
    public struct MagnetDriveSettings
    {
        public MagnetDriveSettings(int n)
        {
            gearRatio = 4.0;
            nLines = 1024;
            slowLoopTime = 0.0008;
            setupFile = "C:/DSC/EFM_software/EFMExperimentsLibrary/EFMExperimentsLibrary/EFMExperimentsGUITest/bin/x86/Debug/MagnetDrive.t.zip";
            comPort = "COM5";
            baudRate = 115200;
            axisID = 1;

            rampRate = 0.05;

            indexHP1 = 22;
            indexHP2 = 23;
        }
        public double gearRatio;
        public int nLines;
        public double slowLoopTime;

        public string setupFile;

        public string comPort;
        public uint baudRate;
        public byte axisID;

        public double rampRate;

        public int indexHP1;
        public int indexHP2;
    }
}
