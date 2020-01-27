using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
namespace EFMExperimentsLibrary
{
    
    public partial class GraphXYPlot : UserControl
    {        

        private DataTable graphDat = new DataTable();

        private string settingsFile;

        private int enabledIndex, initializedIndex, seriesNameIndex, seriesNumberIndex;

        private delegate void UpdateSeries(double [,] readings);

        private string plotName;
        public GraphXYPlot()
        {
            InitializeComponent();

            settingsFile = this.Name + "_settings.xml";
            
            
            //initialize the series combo button
            cmbSeries.SelectedIndexChanged += cmbSeries_SelectedIndexChanged;

            //initialize the enabled check box
            chkEnabled.CheckedChanged += chkEnabled_CheckedChanged;
        }

        public void setPlotName(String name )
        {
            plotName = name;
            settingsFile = plotName + "_settings.xml";
            lblPlotName.Text = plotName;
        }

        public string getPlotName()
        {
            return plotName;
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            int index = cmbSeries.SelectedIndex;
            if ( chkEnabled.Checked != (bool)(graphDat.Rows[index][enabledIndex]) )
            {
                //only then should anything occur
                if ( chkEnabled.Checked )
                {
                    //Then either a new series should be added to the plot or a currently inactive series should start plotting again
                    if ( !(bool)(graphDat.Rows[index][initializedIndex])  )
                    {
                        graphDat.Rows[index][initializedIndex] = true;
                        graphDat.Rows[index][seriesNumberIndex] = chrtPlot.Series.Count;
                        //add the new series to the plot
                        updateChartSeries((String)(graphDat.Rows[index][seriesNameIndex]));
                        
                    }                   
                    //and set the state of the currently selected index to true
                    graphDat.Rows[index][enabledIndex] = true;
                }
                else
                {
                    graphDat.Rows[index][enabledIndex] = false;
                }
                graphDat.WriteXml(settingsFile);
            }
            
        }

        private void updateChartSeries( String name )
        {
            chrtPlot.Series.Add( name );
            chrtPlot.Series[chrtPlot.Series.Count - 1].ChartType = SeriesChartType.StepLine;
            chrtPlot.Series[chrtPlot.Series.Count - 1].MarkerStyle = MarkerStyle.Circle;
            chrtPlot.Series[chrtPlot.Series.Count - 1].MarkerSize = 10;
        }

        private void cmbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbSeries.SelectedIndex;
            if (graphDat.Rows.Count > index)
            {
                bool enabled = (bool)(graphDat.Rows[index][enabledIndex]);
                chkEnabled.Checked = enabled;
            }
        }

        private void initValues()
        {
            graphDat.Clear();
            graphDat.Columns.Clear();
            graphDat.Rows.Clear();
            graphDat.Columns.Add("Enabled", typeof(bool));
            graphDat.Columns.Add("Initialized", typeof(bool));
            graphDat.Columns.Add("SeriesName", typeof(String));
            graphDat.Columns.Add("SeriesNumber", typeof(int));
            enabledIndex = graphDat.Columns.IndexOf("Enabled");
            initializedIndex = graphDat.Columns.IndexOf("Initialized");
            seriesNameIndex = graphDat.Columns.IndexOf("SeriesName");
            seriesNumberIndex = graphDat.Columns.IndexOf("SeriesNumber");


            chrtPlot.Series.Clear();
            graphDat.TableName = "GraphData";
            bool dataLoaded = false;
            //if the settings file exist then load the settings
            if ( File.Exists(settingsFile) )
            {
                try
                {
                    graphDat.ReadXml(settingsFile);
                    for (int i = 0; i < graphDat.Rows.Count; i++)
                    {
                        if ((bool)graphDat.Rows[i][initializedIndex])
                        {
                            graphDat.Rows[i][seriesNumberIndex] = chrtPlot.Series.Count;
                            updateChartSeries((String)(graphDat.Rows[i][seriesNameIndex]));
                        }
                        graphDat.Rows[i][seriesNameIndex] = cmbSeries.Items[i];
                     
                    }
                    dataLoaded = true;
                }
                catch ( Exception ex )
                {
                    
                }
                
                
            }
            if ( !dataLoaded )
            {               
               
                for ( int i = 0; i < cmbSeries.Items.Count; i++ )
                {
                    graphDat.Rows.Add(false, false, cmbSeries.Items[i].ToString(), -1 );                    
                }

                graphDat.WriteXml(settingsFile);
            }
            cmbSeries.SelectedIndex = 0;
            
        }

        private void updateSeries( double[,] readings)
        {
            for ( int i = 0; i < graphDat.Rows.Count; i++ )
            {
                if ( (bool)(graphDat.Rows[i][enabledIndex]))
                {
                    try
                    {
                        if (!double.IsNaN(readings[i, 1]) && readings[i, 1] > -1e10 && readings[i, 1] < 1e10)
                        {
                            chrtPlot.Series[(int)(graphDat.Rows[i][seriesNumberIndex])].Points.AddXY(readings[i, 0], readings[i, 1]);
                            String curName = chrtPlot.Series[(int)(graphDat.Rows[i][seriesNumberIndex])].Name;
                            String newName = (String)graphDat.Rows[i][seriesNameIndex];

                            if ( curName != newName)
                            {
                                chrtPlot.Series[(int)(graphDat.Rows[i][seriesNumberIndex])].Name = newName;
                            }
                        }
                    }
                    catch ( OverflowException ex )
                    { }
                }
            }
        }
        
        /**
         * Called when the Keithley or other data acquisition has new data
         * */
        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            object[] dat = new object[1];
            dat[0] = e.readings;
            BeginInvoke(new UpdateSeries(updateSeries),dat);
        }

        public void dataNamesUpdate(object sender, DataSourceNamesEventsArgs e)
        {
            cmbSeries.Items.Clear();
            for ( int i = 0; i < e.sourceDataNames.Length; i++ )
            {
                cmbSeries.Items.Add(e.sourceDataNames[i]);                
            }
            initValues();
        }

        private void numYMax_ValueChanged(object sender, EventArgs e)
        {
            chrtPlot.ChartAreas[0].AxisY.Maximum = (double)numYMax.Value;
        }

        private void nudMinY_ValueChanged(object sender, EventArgs e)
        {
            chrtPlot.ChartAreas[0].AxisY.Minimum = (double)numYMin.Value;
        }

        private void chrtPlot_Click(object sender, EventArgs e)
        {

        }


    }
}
