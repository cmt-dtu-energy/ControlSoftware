using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
namespace EFMExperimentsLibrary
{
    public partial class TemperatureProfiles : UserControl
    {
        private ProfileController controller = new ProfileController();
        private string profileFilename;
        private BackgroundWorker bw = new BackgroundWorker();
        private const int ThreadWaitingTime = 100;//ms
        private delegate void UpdateFieldsAsync( double time, double T);

        public event EventHandler<SetPointChangedEventArgs> TemperatureSetPointChanged;

        public PIDControl_Tset pid_Tset { set; get; }

        public TemperatureProfiles()
        {
            InitializeComponent();


            List<TemperatureProfileFunction> lst = controller.availableProfiles();
            for (int i = 0; i < lst.Count; i++)
            {
                cmbProfile.Items.Add(lst.ElementAt(i).shortName());
            }
            cmbProfile.SelectedIndex = 0;

            controller.TemperatureProfileUpdated += Controller_TemperatureProfileUpdated;

            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }

        private void Controller_TemperatureProfileUpdated(object sender, TemperatureProfileEventArgs e)
        {
            int index = lstProfiles.SelectedIndex;
            lstProfiles.Items.Clear();
            for ( int i = 0; i < e.lst.Count(); i++ )
            {
                lstProfiles.Items.Add(e.lst.ElementAt(i).fullName());
            }
            lstProfiles.SelectedIndex = index;

            chrtTemperatureProfile.Series[0].Points.Clear();
            double[,] prof = controller.getTotalProfile();
            for (int i = 0; i < prof.GetLength(0); i++ )
            {
                chrtTemperatureProfile.Series[0].Points.AddXY(prof[i,0], prof[i,1]);
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            int index = cmbProfile.SelectedIndex;

            double cA = (double)nudCoeffA.Value;
            double cB = (double)nudCoeffB.Value;
            double cC = (double)nudCoeffC.Value;

            double deltaTime = (double)nudTime.Value;

            controller.addProfileFunction(index, cA, cB, cC, deltaTime);
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            int index = lstProfiles.SelectedIndex;
            controller.removeProfileFunction(index);
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            controller.moveItemUp(lstProfiles.SelectedIndex);
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            controller.moveItemDown(lstProfiles.SelectedIndex);
        }

        
        private void cmdStart_Click(object sender, EventArgs e)
        {
            chrtTemperatureProfile.Series[1].Points.Clear();
            //save the profile set to a text file
            
            List<TemperatureProfileFunction> lst = controller.getCurrentProfileList();
            for (int i = 0; i < lst.Count(); i++)
            {
                File.AppendAllText(profileFilename, lst[i].fullName() + Environment.NewLine);
            }
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
            
        }
        /**
         * subscribe to changes in data filename
         * */
        public void userfilenameChanged(object sender, OutputFileNameChangedEventArgs evt)
        {
            profileFilename = evt.outputDirectory + evt.filename;


            DateTime dt = DateTime.Now;
            string dateStr = dt.ToString("yyyyMMdd");

            string path = Directory.GetParent(profileFilename).FullName;
            string mainName = Path.GetFileName(profileFilename);


            for (int i = 0; i < 1000; i++)
            {
                string t = path + "\\" + dateStr + mainName + "_" + "_" + i.ToString();

                if (!File.Exists(t + "_T_profile.txt"))
                {
                    profileFilename = t + "_T_profile.txt";
                    break;
                }
            }
        }

        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            long startTime = DateTime.Now.Ticks;

            //get the profile for the experiment
            double[,] prof = controller.getTotalProfile();
            int nt = prof.GetLength(0);
            while (!worker.CancellationPending)
            {
                long tDiff = (long)(1e-7 * ( DateTime.Now.Ticks - startTime ));

                //get function value, i.e. interpolate
                double T_val = MathFunctions.interp1(prof, tDiff);

                object[] args = new object[2];
                args[0] = tDiff;
                args[1] = T_val;
                //make sure to update the values in the GUI asynchronously
                BeginInvoke(new UpdateFieldsAsync(updateTemperature), args);


                
                Thread.Sleep(ThreadWaitingTime);
                if (tDiff > prof[nt-1,0])
                    bw.CancelAsync();
            }
            e.Cancel = true;
        }

        private void updateTemperature( double time, double T )
        {
            chrtTemperatureProfile.Series[1].Points.AddXY(time, T);

            EventHandler< SetPointChangedEventArgs> handler = TemperatureSetPointChanged;
            if ( handler != null )
            {
                SetPointChangedEventArgs e = new SetPointChangedEventArgs();
                e.T = T;
                handler(this, e);
            }
            if (pid_Tset != null && !Double.IsNaN(T) && T > 0)
                pid_Tset.setTemperature(T);
            
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            if (!bw.CancellationPending || bw.IsBusy)
                bw.CancelAsync();
        }

        private void chrtTemperatureProfile_Click(object sender, EventArgs e)
        {

        }
    }

    public class SetPointChangedEventArgs : EventArgs
    {
        public double T;
    }
}
