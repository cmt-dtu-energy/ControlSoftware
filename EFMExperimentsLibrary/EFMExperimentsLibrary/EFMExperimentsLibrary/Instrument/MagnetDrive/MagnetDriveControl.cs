using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace EFMExperimentsLibrary
{
    public partial class MagnetDriveControl : UserControl, SetFieldControl
    {
        private int driveStatus = 0;
        private short channelHandle = -1;
        private MagnetDriveDriver.MagnetMotorSetup setup;

        private MagnetDriveSettings magSettings;

        private static string settingsFile = "magnetDriveSettings.xml";

        private delegate void HandleData(ReadingsUpdateEventArgs e);

        private double[,] calibration;
        private bool calibrationOngoing = false;
        private int calibrationCnt = 0;
        private double dtheta_calibration = 0;


        private static string calibrationFile = "magnetDriveCalibration";



        public MagnetDriveControl()
        {
            InitializeComponent();

            txtComPort.LostFocus += settingsComponentUpdate;
            nudBaudRate.LostFocus += settingsComponentUpdate;
            nudAxisID.LostFocus += settingsComponentUpdate;
            txtSetupFile.LostFocus += settingsComponentUpdate;
            nudRampRate.LostFocus += settingsComponentUpdate;
            
            txtComPort.KeyUp += settingsComponentKeyUp;
            nudBaudRate.KeyUp += settingsComponentKeyUp;
            nudAxisID.KeyUp += settingsComponentKeyUp;
            txtSetupFile.KeyUp += settingsComponentKeyUp;
            nudRampRate.KeyUp += settingsComponentKeyUp;


            if (File.Exists(settingsFile))
                magSettings = SerializeData.DeSerializeObject<MagnetDriveSettings>(settingsFile);
            else
                magSettings = new MagnetDriveSettings(1);

            if (File.Exists(calibrationFile + "_xvals.xml"))
            {
                double[] calibX = SerializeData.DeSerializeObject<double[]>(calibrationFile + "_xvals.xml");
                double[] calibY = SerializeData.DeSerializeObject<double[]>(calibrationFile + "_yvals.xml");
                calibration = new double[calibX.Length, 2];
                for ( int i = 0; i < calibX.Length; i++ )
                {
                    calibration[i, 0] = calibX[i];
                    calibration[i, 1] = calibY[i];
                }
            }
            else
                calibration = new double[2, 2];

            updateGUI();

            setup = new MagnetDriveDriver.MagnetMotorSetup(magSettings.gearRatio, magSettings.nLines, magSettings.slowLoopTime);
        }
        /**
         * Called from other sources when the names for the data resources update
         * */
        public void dataNamesUpdate(object sender, DataSourceNamesEventsArgs e)
        {
            cmbHallProbe1.Items.Clear();
            cmbHallProbe2.Items.Clear();

            for ( int i = 0; i < e.sourceDataNames.Length; i++ )
            {
                cmbHallProbe1.Items.Add(e.sourceDataNames[i]);
                cmbHallProbe2.Items.Add(e.sourceDataNames[i]);
            }

            cmbHallProbe1.SelectedIndex = 22;
            cmbHallProbe2.SelectedIndex = 23;
        }

        /**
       * Called when the data system pushes new data
       * */
        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            object[] dat = new object[1];
            dat[0] = e;
            BeginInvoke(new HandleData(handleData), dat);
        }

        private void handleData(ReadingsUpdateEventArgs e)
        {
            updateStatus();
            int index1 = cmbHallProbe1.SelectedIndex;
            int index2 = cmbHallProbe2.SelectedIndex;
            if (index1 >= 0 && index2 >= 0)
            {
                double val1 = e.readings[index1, 1];
                if (Double.IsInfinity(val1) || Double.IsNaN(val1))
                    val1 = 0;

                double val2 = e.readings[index2, 1];
                if (Double.IsInfinity(val2) || Double.IsNaN(val2))
                    val2 = 0;
                try
                {
                    nudHallProbe1.Value = (decimal)val1;
                    nudHallProbe2.Value = (decimal)val2;
                }
                catch (Exception ex )
                {

                }
            }

            if ( calibrationOngoing )
            {
                if ( calibrationCnt >= calibration.GetLength(0) )
                {
                    calibrationOngoing = false;
                    //done with the calibration. Save to disk. Work-around since XMLserializer does not support serializing multi-dimensional arrays
                    double[] calibX = new double[calibration.GetLength(0)];
                    double[] calibY = new double[calibration.GetLength(0)];
                    for (int i = 0; i < calibX.Length; i++  )
                    {
                        calibX[i] = calibration[i, 0];
                        calibY[i] = calibration[i, 1];
                    }
                    SerializeData.SerializeObject<double[]>(calibX, calibrationFile + "_xvals.xml");
                    SerializeData.SerializeObject<double[]>(calibY, calibrationFile + "_yvals.xml");
                }
                else
                {
                    //position on the y-axis 
                    calibration[calibrationCnt, 1] = (double)nudCurrentPos.Value;
                    double HP1 = (double)nudHallProbe1.Value;
                    double HP2 = (double)nudHallProbe2.Value;
                    //field value on the x-axis
                    calibration[calibrationCnt, 0] = Math.Sqrt(HP1 * HP1 + HP2 * HP2);
                    nudSetPos.Value = (decimal)(calibration[calibrationCnt, 1] + dtheta_calibration);
                    moveMagnet();
                    calibrationCnt++;
                    Thread.Sleep(500);
                }
            }
        }

        /**
         * Interface to programmatically change the field
         * */
        public void setField(double field, double rampRate)
        {
            if ( field >= (double)nudFieldValue.Minimum && field <= (double)nudFieldValue.Maximum && rampRate >= (double)nudRampRate.Minimum && rampRate <= (double)nudRampRate.Maximum ) 
            {
                nudFieldValue.Value = (decimal)field;
                nudRampRate.Value = (decimal)rampRate;
                moveMagnetToField();
            }
            
        }
        public bool atSetField()
        {
            return true;
        }

        private void settingsComponentUpdate(object sender, EventArgs e)
        {
            magSettings.setupFile = txtSetupFile.Text;
            magSettings.comPort = txtComPort.Text;
            magSettings.baudRate = (uint)nudBaudRate.Value;
            magSettings.axisID = (byte)nudAxisID.Value;
            magSettings.rampRate = (double)nudRampRate.Value;
            magSettings.indexHP1 = cmbHallProbe1.SelectedIndex;
            magSettings.indexHP2 = cmbHallProbe2.SelectedIndex;
            SerializeData.SerializeObject<MagnetDriveSettings>(magSettings, settingsFile);
        }

        private void settingsComponentKeyUp (object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter)
            {
                settingsComponentUpdate(sender, e);
            }
        }

        public int closeInstrument()
        {
            MagnetDriveDriver.CloseChannel(channelHandle);
            MagnetDriveDriver.Power(0);
            SerializeData.SerializeObject<MagnetDriveSettings>(magSettings, settingsFile);
            return 0;
        }

        private void updateGUI()
        {
            txtComPort.Text = magSettings.comPort;
            nudAxisID.Value = magSettings.axisID;
            nudBaudRate.Value = magSettings.baudRate;
            nudRampRate.Value = (decimal)magSettings.rampRate;
            txtSetupFile.Text = magSettings.setupFile;

            if (magSettings.indexHP1 < cmbHallProbe1.SelectedIndex)
                cmbHallProbe1.SelectedIndex = magSettings.indexHP1;

            if (magSettings.indexHP2 < cmbHallProbe2.SelectedIndex)
                cmbHallProbe2.SelectedIndex = magSettings.indexHP2;
        }

        private void cmdInitDrive_Click(object sender, EventArgs e)
        {
            string comPort = txtComPort.Text;
            uint baudRate = (uint)(nudBaudRate.Value);
            string setupFile = txtSetupFile.Text;
            byte axisID = (byte)(nudAxisID.Value);
            string pwd = Directory.GetCurrentDirectory();
            channelHandle = MagnetDriveDriver.initDrive( comPort, baudRate, setupFile, axisID );

            if (channelHandle > 0)
            {
                driveStatus = MagnetDriveDriver.Power(1);
            }
            updateStatus();
        }

        private void updateStatus()
        {
            if (driveStatus == 0)
            {
                lblDriveStatus.Text = "Drive status: off";
            }
            else
            {
                lblDriveStatus.Text = "Drive status: on";
                nudCurrentPos.Value = (decimal)(MagnetDriveDriver.getMotorPosition(setup) * 180 / Math.PI);
            }
        }

        private void moveMagnet()
        {
            //find the speed of the magnet drive (converted from T/s to rad/s)
            double speed_T_s = (double)nudRampRate.Value;

            double maxPos = calibration[calibration.GetLength(0)-1,1];
            double minPos = calibration[0, 1];

            double maxField = calibration[calibration.GetLength(0)-1, 0];
            double minField = calibration[0, 0];

            double speed_deg_s = Math.Abs(speed_T_s * ( maxPos - minPos ) / (maxField - minField));


            int retval = MagnetDriveDriver.moveMagnet((double)nudSetPos.Value*Math.PI/180, speed_deg_s*Math.PI/180, 2, setup);
            updateStatus();
        }

        private void cmdMovePos_Click(object sender, EventArgs e)
        {

            moveMagnet();
            updateStatus();
        }

        private void cmdMoveToField_Click(object sender, EventArgs e)
        {
            moveMagnetToField();
        }

        private void moveMagnetToField()
        {
            //find the position value corresponding to the desired field
            double pos = MathFunctions.interp1(calibration, (double)nudFieldValue.Value);
            try
            {
                //update the value
                nudSetPos.Value = (decimal)pos;
                //move the magnet
                moveMagnet();
                updateStatus();
            }
            catch (Exception ex )
            {

            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            MagnetDriveDriver.Reset();
            //MagnetDriveDriver.ResetFault();
        }

        private void cmbHallProbe1_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingsComponentUpdate( sender, e);
        }

       
        private void cmdCalibration_Click(object sender, EventArgs e)
        {
            //start the auto-calibration procedure
            //move the magnet a little bit for each time data arrives, log the Hall probe measurements and build up a data table with (x,y) = (pos [rad], field [T] ) for later interpolation
            //angle to move each time            
            dtheta_calibration = (double)nudCalibrationRes.Value;

            //number of positions to measure at (going from zero to 2*pi on the motor shaft which is roughly equal to pi/2 on each magnet, i.e. a full cycle from zero to max field
            int nPts = (int)Math.Ceiling(180.0 / Math.PI * Math.PI / (2*dtheta_calibration));
            //calibration array, [n,2] with [,0] being the position and [,1] the corresponding magnetic field
            calibration = new double[nPts, 2];
            calibrationOngoing = true;
            calibrationCnt = 0;
        }

        
    }
}
