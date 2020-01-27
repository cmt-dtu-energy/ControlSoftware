using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFMExperimentsLibrary
{
    public partial class ExperimentFlow : UserControl, ExperimentStatusUpdate
    {

        private delegate void UpdateExperiment(ReadingsUpdateEventArgs e);

        private ExperimentController control = new ExperimentController();

        public event EventHandler<ReadingsUpdateEventArgs> experimentReadingsUpdate;

        

        public StabilityCtrl stabCtrl;
        public SetTemperatureRampCtrl rampCtrl;
        public SetFieldControl fieldCtrl;
        public PIDControl_Tset pidCtrl;
        public DatasaveFilePath pathCtrl;

        private string[] header;

        public ExperimentFlow()
        {
            InitializeComponent();
            lstExperiments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            control.experimentUpdate += experimentUpdate;
        }

        public void updateStatusString(string s)
        {
            lblStatus.Text = s;
        }

        public void experimentUpdate(object sender, EFMExperimentUpdateEventArgs e)
        {            
            if ( e.currentExperiment >= 0 )
            {
                lstExperiments.Clear();
                int cnt = 0;
                foreach ( EFMExperiment exp in e.experimentList )
                {                    
                    lstExperiments.Items.Add(exp.experimentDescriptor);
                    if (cnt == e.currentExperiment)
                        lstExperiments.Items[cnt].Selected = true;
                    cnt++;
                }
                
            }
        }

        /**
         * Data from the data collector
         * */
        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            object[] dat = new object[1];
            dat[0] = e;
            BeginInvoke(new UpdateExperiment(updateExperiment), dat);
        }

        public void dataNamesUpdate(object sender, DataSourceNamesEventsArgs e)
        {
            header = e.sourceDataNames;
        }

        private void updateExperiment(ReadingsUpdateEventArgs e)
        {
            if (experimentReadingsUpdate != null)
                experimentReadingsUpdate(this, e);
        }

        /**
         * Add a DSC experiment to the experiment list
         * */
        private void cmdAddDSCExperiment_Click(object sender, EventArgs e)
        {
            //setup the settings first
            EFMExperimentSettingsDSC setts = new EFMExperimentSettingsDSC( (double)nudTminDSC.Value, (double)nudTmaxDSC.Value, 
                                                                           (double)nudTrate.Value, (double)nudAppliedField.Value, (double)nudStabilization.Value );

            EFMExperimentDSC exp = new EFMExperimentDSC(setts,stabCtrl,rampCtrl,fieldCtrl,pidCtrl,pathCtrl,this,header);
            

            
            control.addExperiment(exp);
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            experimentReadingsUpdate += control.readingsUpdate;
            control.experimentRunning = true;
        }

        private void cmdRemoveExperiemnt_Click(object sender, EventArgs e)
        {
            int sel = lstExperiments.SelectedIndices[0];
            if ( sel >= 0 )
                control.removeExperiment(sel);
        }

        private void cmdAddDeltaSExperiment_Click(object sender, EventArgs e)
        {
            EFMExperimentSettingsDeltaS setts = new EFMExperimentSettingsDeltaS((double)nudTminDeltaS.Value, (double)nudTmaxDeltaS.Value, (double)nudTstepDeltaS.Value, (double)nudTResetDeltaS.Value, chkResetDeltaS.Checked,
                                                                                (double)nudHminDeltaS.Value, (double)nudHmaxDeltaS.Value, (double)nudFieldStepDeltaS.Value, (double)nudFieldRampRate.Value, (double)nudStabilization.Value);

            EFMExperimentDeltaS exp = new EFMExperimentDeltaS(setts, stabCtrl, rampCtrl, fieldCtrl, pidCtrl, pathCtrl, this, header);

            control.addExperiment(exp);
        }
    }
}
