using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace EFMExperimentsLibrary
{
    public partial class TemperatureRampControl : UserControl, SetTemperatureRampCtrl
    {
        private BackgroundWorker bw = new BackgroundWorker();

        private const int ThreadWaitingTime = 100;//ms

        private double Tmin, Tmax, TCurrent, TRamp;

        private delegate void UpdateFieldsAsync();
        private Object thisLock = new Object();

        public PIDControl_Tset pid_Tset { set; get; }

        public TemperatureRampControl()
        {
            InitializeComponent();

            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            
        }

        public void setRamp(double Tmin, double Tmax, double Tramp)
        {
            numTmin.Value = (decimal)Tmin;
            numTmax.Value = (decimal)Tmax;
            numTRamp.Value = (decimal)Tramp;
            startRamp();

        }

        public bool rampFinished()
        {

            if (Math.Sign(numTRamp.Value) > 0)
                return numTCurrent.Value >= numTmax.Value;
            else
                return numTCurrent.Value <= numTmin.Value;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            startRamp();
        }

        private void startRamp()
        {
            //values consistency check
            if (numTmax.Value > numTmin.Value)
            {
                Tmax = (double)numTmax.Value;
                Tmin = (double)numTmin.Value;
                TRamp = (double)numTRamp.Value;

                if (TRamp > 0)
                    TCurrent = Tmin;
                else if (TRamp <= 0)
                    TCurrent = Tmax;


                if (!bw.IsBusy)
                    bw.RunWorkerAsync();
            }
            else
            {
                updateFields();
            }
        }

        private void updateFields()
        {
            numTmax.Value = (decimal)Tmax;
            numTmin.Value = (decimal)Tmin;
            numTRamp.Value = (decimal)TRamp;
            numTCurrent.Value = (decimal)TCurrent;
            if (pid_Tset != null)
                pid_Tset.setTemperature(TCurrent);
        }


        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            long prevTime = DateTime.Now.Ticks;
            
            while (!worker.CancellationPending)
            {
                long tDiff = DateTime.Now.Ticks - prevTime;

                //change the current temperature by an amount proportional to the time elapsed since the previous update
                //DateTime.Now.Ticks returns the amount of time in 100 nanoseconds since 1970 and TRamp has units of C/min, hence the conversions
                lock (thisLock)  
                {  
                    TCurrent = TCurrent + TRamp / 60 * tDiff * 1e-7;   
                }


                //make sure to update the values in the GUI asynchronously
                
                BeginInvoke(new UpdateFieldsAsync(updateFields), null);


                prevTime = DateTime.Now.Ticks;
                Thread.Sleep(ThreadWaitingTime);
                if (TCurrent > Tmax || TCurrent < Tmin)
                    bw.CancelAsync();
            }
            e.Cancel = true;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {

            }

            else if (!(e.Error == null))
            {

            }

            else
            {

            }
            
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if ( !bw.CancellationPending || bw.IsBusy)
                bw.CancelAsync();
            
        }

    }
}
