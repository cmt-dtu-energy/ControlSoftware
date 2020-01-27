using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFMExperimentsLibrary
{
    public partial class HallprobeControl : UserControl
    {
        private HallProbeInstrument hallprobe;

        public delegate void UpdateGUIAsync( double[] mean, double[] stdev);
        public delegate void SaveData(double[,] raw, double[] mean, double[] stdev);

        //data savers. One for all the raw data, one for the "processed" data
        private HallprobeDataSaver datasaverRaw;
        private HallprobeDataSaver datasaverProcessed;


        public EventHandler measurementsCompleted;

        public HallprobeControl()
        {
            InitializeComponent();
            
            txtMHMFileFolder.Leave += TxtMHMFileFolder_Leave;
            txtMHMFileFolder.KeyUp += TxtMHMFileFolder_KeyUp;

            nudMaxPlotPts.Leave += NudMaxPlotPts_Leave;
            nudMaxPlotPts.KeyUp += NudMaxPlotPts_KeyUp;
            initPlotValsArray();
        }

        private void NudMaxPlotPts_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter)
            {
                initPlotValsArray();
            }
        }

        private void NudMaxPlotPts_Leave(object sender, EventArgs e)
        {
            initPlotValsArray();
        }

        private void initPlotValsArray()
        {
            int newLength = (int)nudMaxPlotPts.Value;
            if (plotValues == null)
            {
                plotValues = new double[newLength, 4];
                plotValIndex = 0;
            }
            else
            {
                if (plotValues.Length != newLength)
                {
                    plotValues = new double[newLength, 4];
                    plotValIndex = 0;
                }
            }
        }


        private void TxtMHMFileFolder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                updateMHMFolder();
        }

        private void TxtMHMFileFolder_Leave(object sender, EventArgs e)
        {
            updateMHMFolder();
        }
        private void updateMHMFolder()
        {
            setDatafile(txtMHMFileFolder.Text);
        }

        /**
         * Called when the xyz stage is at a new point
         * */
        public void xyzPointReached(object sender, XYZEventArgs evt )
        {
            //record the current point
            datasaverRaw.writeCoordinates(evt.curPoint.x, evt.curPoint.y, evt.curPoint.z, 0, null);
            datasaverProcessed.writeCoordinates(evt.curPoint.x, evt.curPoint.y, evt.curPoint.z, 0, null);
            //count the no. of data aquisitions before allowing the xyz stage to continue
            nMeasurements = 0;
        }
        private int nMeasurements = 0;
        /**
         * Listener for the data saver files
         * */
        public void OutputFilenameChanged(object sender, EFMExperimentsLibrary.OutputFileNameChangedEventArgs e)
        {
            //initialize the data savers (or re-initialize them if the outfiles were changed)
            datasaverRaw = new HallprobeDataSaver(e.outputDirectory+e.filename + "_raw_",itemString,DateTime.Now);

            string[] headerProc = new string[itemString.Length * 2];
            for (int i = 0; i < itemString.Length; i++)
            {
                headerProc[2*i] = itemString[i];
                headerProc[2*i+1] = "stdev";
            }
            datasaverProcessed = new HallprobeDataSaver(e.outputDirectory + e.filename + "_processed_", headerProc, DateTime.Now);
        }

        public void setDatafile( string file )
        {
            hallprobe = new HallProbeInstrument(file);
            hallprobe.initializeInstrument();
            hallprobe.SaveData += Hallprobe_SaveData;

            DataSourceNamesEventsArgs args = new DataSourceNamesEventsArgs();
            args.sourceDataNames = new string[4];
            args.sourceDataNames[0] = "Bx";
            args.sourceDataNames[1] = "By";
            args.sourceDataNames[2] = "Bz";
            args.sourceDataNames[3] = "Bnorm";
            graphXYPlot1.dataNamesUpdate(null, args);
        }
        private double[,] plotValues;
        private int plotValIndex = 0;
        private void Hallprobe_SaveData(object sender, InstrumentDatasetEventArgs e)
        {
            double[,] dat = e.dataSet.getLatestData();
            if (dat != null)
            {
                //find the mean and stdev values
                double[] meanVals = new double[dat.GetLength(0)];
                double[] stdevVals = new double[dat.GetLength(0)];
                MathFunctions.getMeanStdev(dat, ref meanVals, ref stdevVals);

                object[] args = new object[2];
                args[0] = meanVals;
                args[1] = stdevVals;

                BeginInvoke(new UpdateGUIAsync(updateGUIAsync), args);

                args = new object[3];
                args[0] = dat;
                args[1] = meanVals;
                args[2] = stdevVals;

                BeginInvoke(new SaveData(saveData), args);
            }
        }
        private static string[] itemString = { "Bx", "By", "Bz", "Bnorm", "Temperature", "Time" };
        private string fieldUnits = "T";
        private string tempUnits = "K";
        private string timeUnits = "ms";
        private void updateGUIAsync( double[] meanVals, double[] stdevVals )
        {
            txtBx.Text = meanVals[(int)HallprobeDataArrayIndices.Bx].ToString();
            txtBy.Text = meanVals[(int)HallprobeDataArrayIndices.By].ToString();
            txtBz.Text = meanVals[(int)HallprobeDataArrayIndices.Bz].ToString();
            txtBnorm.Text = meanVals[(int)HallprobeDataArrayIndices.Bnorm].ToString();
            txtT.Text = meanVals[(int)HallprobeDataArrayIndices.temperature].ToString();
            txtTime.Text = (meanVals[(int)HallprobeDataArrayIndices.time]).ToString();

            txtBxPM.Text = stdevVals[(int)HallprobeDataArrayIndices.Bx].ToString();
            txtByPM.Text = stdevVals[(int)HallprobeDataArrayIndices.By].ToString();
            txtBzPM.Text = stdevVals[(int)HallprobeDataArrayIndices.Bz].ToString();
            txtBnormPM.Text = stdevVals[(int)HallprobeDataArrayIndices.Bnorm].ToString();
            txtTPM.Text = stdevVals[(int)HallprobeDataArrayIndices.temperature].ToString();


        }

        private void saveData( double [,] rawData, double[] meanVals, double[] stdevVals )
        {

            if (plotValIndex >= plotValues.GetLength(0))
            {
                plotValIndex = 0;
            }
            for ( int i = 0; i < plotValues.GetLength(1); i++ )
            {
                plotValues[plotValIndex, i] = meanVals[i];             
            }
            ReadingsUpdateEventArgs evt = new ReadingsUpdateEventArgs();

            double[,] dat = new double[4, 2];
            for ( int i = 0; i< 4; i++ )
            {
                dat[i, 0] = meanVals[5];
                dat[i, 1] = meanVals[i];
            }
            evt.readings = dat;
            graphXYPlot1.readingsUpdate(null, evt);

            plotValIndex++;



            nMeasurements++;
            nudCurrentMeasurement.Value = (decimal)nMeasurements;
            datasaverRaw.writeRaw(rawData);
            datasaverProcessed.writeProcessed(meanVals, stdevVals);
            if ( nMeasurements >= (int)nudNMea.Value )
            {
                //fire the event that the no. of data points has been reached
                if (measurementsCompleted != null )
                {
                    measurementsCompleted(this, null);
                }
            }
        }

        public string getMHMDataFolder()
        {
            return txtMHMFileFolder.Text;
        }

        private void txtMHMFileFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void nudMaxPlotPts_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
