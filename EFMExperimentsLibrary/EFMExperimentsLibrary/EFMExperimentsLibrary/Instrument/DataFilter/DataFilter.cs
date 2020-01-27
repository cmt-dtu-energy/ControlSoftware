using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace EFMExperimentsLibrary
{
    public partial class DataFilter : UserControl
    {
        private static int nFilters = 10;
        public enum EFMExperimentFilters { None, PeltierDifference, HallProbeSignal, PeltierStability, MagneticFieldNorm};

        public event EventHandler<ReadingsUpdateEventArgs> FilterReadingsUpdate;

        public event EventHandler<DataSourceNamesEventsArgs> FilterNamesChanged;

        private delegate void FilterData(ReadingsUpdateEventArgs e);

        private DataFilterSettings settings;

        private int curStabilityPos = 0;
        //upper limit on how many data points to use for the stability measure
        private const int nStabilityMax = 100;

        private volatile double[] stabilityDataBuffer;
        
        private static string settingsFile = "dataFilterSettings.xml";
        public DataFilter( )
        {
            InitializeComponent();
            stabilityDataBuffer = new double[20];

        }
        /**
         * Called externally when the data name convention is changed or initialized
         * */
        public void dataNamesUpdate(object sender, DataSourceNamesEventsArgs e)
        {
            cmbChannelA.Items.Clear();
            cmbChannelB.Items.Clear();

            for (int i = 0; i < e.sourceDataNames.Length; i++)
            {
                cmbChannelA.Items.Add(e.sourceDataNames[i]);
                cmbChannelB.Items.Add(e.sourceDataNames[i]);
            }
            initSettings();
        }

        /**
        * Called when the Keithley or other data acquisition has new data
        * */
        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            object[] dat = new object[1];
            dat[0] = e;
            BeginInvoke(new FilterData(filterData), dat);
        }


        private void filterData( ReadingsUpdateEventArgs e )
        {
            double [,] data = e.readings;
            //init the amended data set, i.e. the raw data concatenated with the results of the filtering
            double[,] datOut = new double[data.GetLength(0) + nFilters, 2];
            //copy the raw data
            for ( int i = 0; i < data.GetLength(0); i++ )
            {
                datOut[i, 0] = data[i, 0];
                datOut[i, 1] = data[i, 1];
            }

            //now do the filtering
            EFMExperimentFilters[] filters = (EFMExperimentFilters[])settings.transformation.ToArray(typeof(int));
            int[] chnA = (int[])settings.channelA.ToArray(typeof(int));
            int[] chnB = (int[])settings.channelB.ToArray(typeof(int));
            string[] names_arr = (string[])settings.names.ToArray(typeof(string));
            double[] K1 = (double[])settings.K1_vals.ToArray(typeof(double));
            double[] K2 = (double[])settings.K2_vals.ToArray(typeof(double));
            double[] K3 = (double[])settings.K3_vals.ToArray(typeof(double));
            for ( int i = 0; i < nFilters; i++ )
            {
                int index = i+data.GetLength(0);
                switch (filters[i] )
                {
                    case EFMExperimentFilters.HallProbeSignal:
                        //transfer the time of the channel
                        datOut[index, 0] = data[chnA[i], 0];
                        //filter the data point
                        double scale = K1[i];
                        double offset = K2[i];
                        double nom_current = K3[i];
                        double voltage = data[chnA[i], 1];
                        double current = data[chnB[i], 1];
                        datOut[index, 1] =  1/scale * (voltage * nom_current / current + offset );
                        break;
                    case EFMExperimentFilters.PeltierDifference:
                        //transfer the time
                        datOut[index, 0] = 0.5 * (data[chnA[i], 0] + data[chnB[i], 0]);
                        //Subtract the two peltier signals
                        datOut[index, 1] = data[chnA[i], 1] - data[chnB[i], 1];
                        break;
                    case EFMExperimentFilters.PeltierStability:
                        datOut[index, 0] = data[chnA[i], 0];
                        if ( curStabilityPos >= stabilityDataBuffer.Length )
                        {
                            curStabilityPos = 0;
                        }
                        //use the peltier difference as the variable to check for stability
                        stabilityDataBuffer[curStabilityPos] = data[chnA[i], 1] - data[chnB[i], 1];
                        //increment the position counter
                        curStabilityPos++;
                        double mean = 0;
                        double std = 0;
                        if (curStabilityPos > 0)
                        {
                            for (int j = 0; j < stabilityDataBuffer.Length; j++)
                            {
                                mean += stabilityDataBuffer[j];
                            }
                            mean = mean / (stabilityDataBuffer.Length - 1);

                            for ( int j = 0; j < stabilityDataBuffer.Length; j++ )
                            {
                                std += Math.Pow((stabilityDataBuffer[j] - mean), 2);
                            }
                            std = Math.Sqrt(std/(curStabilityPos+1));
                            //stability = Math.Abs(std / mean);
                            datOut[index,1] = std;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (FilterReadingsUpdate != null)
            {                
                e.readings = datOut;             
                FilterReadingsUpdate(this, e);
            }

        }

        private void initSettings()
        {
            string[] transfNames = Enum.GetNames(typeof(EFMExperimentFilters));
            cmbChannelID.Items.Clear();
            cmbTransformation.Items.Clear();
            for ( int i = 0; i < transfNames.Length; i++ )
            {
                cmbTransformation.Items.Add(transfNames[i]);
            }
            for ( int i = 0; i < nFilters; i ++ )
            {
                cmbChannelID.Items.Add("Filter no. " + Convert.ToString(i));
            }
            loadSettings();       
            //create the settings array if nothing was loaded from the settings file
            if (settings.names == null)
            {
                settings = new DataFilterSettings(nFilters);
            }
            
            cmbChannelID.SelectedIndex = 0;

            fireUpdateEvent();

        }

        private void fireUpdateEvent()
        {
            if (FilterNamesChanged != null)
            {
                DataSourceNamesEventsArgs e = new DataSourceNamesEventsArgs();
                e.sourceDataNames = getDataNames();
                
                FilterNamesChanged(this, e);
            }
        }

        public string[] getDataNames()
        {
            string[] dataNames = new string[cmbChannelA.Items.Count + cmbChannelID.Items.Count];
            if (settings.names != null)
            {
                for (int i = 0; i < cmbChannelA.Items.Count; i++)
                {
                    dataNames[i] = (string)(cmbChannelA.Items[i]);
                }
                string[] names = (string[])settings.names.ToArray(typeof(string));
                for (int i = cmbChannelA.Items.Count; i < dataNames.Length; i++)
                {
                    dataNames[i] = names[i - cmbChannelA.Items.Count];
                }
            }
            return dataNames;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            int index = cmbChannelID.SelectedIndex;

            settings.channelA[index] = cmbChannelA.SelectedIndex;
            settings.channelB[index] = cmbChannelB.SelectedIndex;
            settings.K1_vals[index] = (double)nudK1.Value;
            settings.K2_vals[index] = (double)nudK2.Value;
            settings.K3_vals[index] = (double)nudK3.Value;
            settings.transformation[index] = cmbTransformation.SelectedIndex;
            settings.names[index] = txtName.Text;

            SerializeData.SerializeObject<DataFilterSettings>( settings, settingsFile);

            if ( cmbTransformation.SelectedIndex == (int)EFMExperimentFilters.PeltierStability )
            {
                if (nudK1.Value >= 1 && nudK1.Value <= nStabilityMax)
                {
                    //copy the old data
                    double[] tmp = new double[stabilityDataBuffer.Length];
                    for (int i = 0; i < stabilityDataBuffer.Length; i++)
                        tmp[i] = stabilityDataBuffer[i];

                    int nDataPoints = Convert.ToInt32(nudK1.Value);

                    stabilityDataBuffer = new double[nDataPoints];
                    int cntStart = tmp.Length - Math.Min(tmp.Length, nDataPoints);
                    int cntEnd = Math.Min(tmp.Length, nDataPoints);

                    for (int i = cntStart; i < cntEnd; i++)
                        stabilityDataBuffer[i - cntStart] = tmp[i];

                    curStabilityPos = cntEnd;
                }
            }


            fireUpdateEvent();
        }

        private void loadSettings()
        {

            settings = SerializeData.DeSerializeObject<DataFilterSettings>(settingsFile);

        }

        private void cmbChannelID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update the settings displayed
            if (settings.channelA != null)
            {
                int[] cmbA_arr = (int[])settings.channelA.ToArray(typeof(int));
                int[] cmbB_arr = (int[])settings.channelB.ToArray(typeof(int));
                string[] txtName_arr = (string[])settings.names.ToArray(typeof(string));
                double[] K1_arr = (double[])settings.K1_vals.ToArray(typeof(double));
                double[] K2_arr = (double[])settings.K2_vals.ToArray(typeof(double));
                double[] K3_arr = (double[])settings.K3_vals.ToArray(typeof(double));
                EFMExperimentFilters[] transf_arr = (EFMExperimentFilters[])settings.transformation.ToArray(typeof(int));

                int ind = cmbChannelID.SelectedIndex;

                cmbChannelA.SelectedIndex = cmbA_arr[ind];
                cmbChannelB.SelectedIndex = cmbB_arr[ind];
                cmbTransformation.SelectedIndex = (int)transf_arr[ind];

                txtName.Text = txtName_arr[ind];
                nudK1.Value = (decimal)K1_arr[ind];
                nudK2.Value = (decimal)K2_arr[ind];
                nudK3.Value = (decimal)K3_arr[ind];
            }
        }

    }

}
