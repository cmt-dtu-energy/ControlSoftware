using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
namespace EFMExperimentsLibrary
{
    public partial class PeltierStability : UserControl, StabilityCtrl
    {
        private double currentStabilityValue;
        public PeltierStability()
        {
            InitializeComponent();            
        }

        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            int index = cmbSeries.SelectedIndex;
            currentStabilityValue = e.readings[index, 1];
            lblStability.Text = currentStabilityValue.ToString("e3");
        }


        public double getStabilityValue()
        {
            return currentStabilityValue;
        }

        public void dataNamesUpdate(object sender, DataSourceNamesEventsArgs e)
        {
            cmbSeries.Items.Clear();
            for (int i = 0; i < e.sourceDataNames.Length; i++)
            {
                cmbSeries.Items.Add(e.sourceDataNames[i]);
                
            }
            cmbSeries.SelectedIndex = 25;
        }

        private void cmbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
