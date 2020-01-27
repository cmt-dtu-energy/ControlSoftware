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
    public partial class PIDControl : UserControl, PIDControl_Tset
    {
        public PIDControl()
        {
            InitializeComponent();

            chkEnabled.CheckedChanged += chkEnabled_CheckedChanged;

            error = 1e6;
            prev_t = 0;
            //kaspar: this code should be made more generic so that it is not tied to a specific implementation (in this case a Keithley2700)
            for (int i=0; i < 20; i++ )
            {
                cmbKeithleyPort.Items.Add("Port nr. " + i.ToString());
            }
            cmbKeithleyPort.SelectedIndex = 1;
            for ( int i = 0; i < 2; i++)
            {
                cmbPSUPort.Items.Add("PSU port nr. " + i.ToString());
            }
            cmbPSUPort.SelectedIndex = 0;

        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (psuInterface != null)
            {
                int psuPort = cmbPSUPort.SelectedIndex;
                double vol = Math.Min((double)nudMaxVoltage.Value, psuInterface.getMaxVoltage());

                psuInterface.setVoltage(psuPort, vol);
            }
        }

        private void PIDControl_Load(object sender, EventArgs e)
        {

        }
        private double PV;
        private double error;
        private double preError;
        private double integral;
        private double derivative;
        private double prev_t;

        private bool temperatureGaugeEnabled = true;
        public psuSetOutput psuInterface;

        public CurrentRelay relay = null;
        
        
        private void lblSetTemperature_Click(object sender, EventArgs e)
        {

        }
        /**
         * Event that may be raised by a dynamic temperature gauge (such as the probe). When the probe is not touching, the gauge should be disabled to avoid severe over heating
         * */
     /*   public void temperatureGaugeStateChanged(Object sender, TemperatureGaugeEventArgs e)
        {
            temperatureGaugeEnabled = e.temperatureGaugeEnabled;                
        }
        */
        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            //when getting some data update the PV, the error and thus the output
            if (chkEnabled.Checked && temperatureGaugeEnabled)
            {
                int port = cmbKeithleyPort.SelectedIndex;

                double time = e.readings[port, 0];
                double Tprobe = e.readings[port, 1];

                double output = getOutput(Tprobe, time);

                //if a relay is attached this means the current should be reversed if the sign is negative
                if ( relay != null )
                {
                    if ( output > 0 )
                    {
                        relay.updateState(false);
                    }
                    else
                    {
                        relay.updateState(true);
                    }
                    output = Math.Abs(output);
                }

                if (psuInterface != null)
                {
                    int psuPort = cmbPSUPort.SelectedIndex;
                    psuInterface.setCurrent(psuPort, output);
                    
                    psuInterface.setEnabled(psuPort, true);
                }
            }
            else
            {
                if ( psuInterface != null )
                {
                    int psuPort = cmbPSUPort.SelectedIndex;
                    psuInterface.setEnabled(psuPort,false);
                }
            }
        }

        public void setDefaultPSUPort( int p )
        {
            cmbPSUPort.SelectedIndex = p;
        }
        public void setDefaultReadingPort (int p )
        {
            cmbKeithleyPort.SelectedIndex = p;
        }
        public void setTitle(String s )
        {
            lblTitle.Text = s;
        }
        public void setMaxVoltage(double vol)
        {
            nudMaxVoltage.Value = (decimal)vol;
        }
        public void setMaxCurrent(double cur)
        {
            nudMaxCurrent.Value = (decimal)cur;
        }

        public void setTemperature(double T)
        {
            nudSetTemperature.Value = (decimal)T;
        }

        private double getOutput( double PV_in, double t_in )
        {
            double setpoint = (double)nudSetTemperature.Value;

            double Kp = (double)nudP.Value;
            double Ki = (double)nudI.Value;
            double Kd = (double)nudD.Value;

            double Dt = t_in - prev_t;

            PV = PV_in;

            try
            {
                nudCurrentTemperature.Value = (decimal)PV;

                error = setpoint - PV;

                integral = integral + (error * Dt);

                derivative = (error - preError) / Dt;

                double output = (Kp * error) + (Ki * integral) + (Kd * derivative);
                output = Math.Sign(output) * Math.Min(Math.Abs(output), (double)nudMaxCurrent.Value);
                preError = error;
                prev_t = t_in;

                nudError.Value = (decimal)error;
                nudAmpOut.Value = (decimal)output;
                return output;                
            }
            catch (Exception ex)
            {
                return 0;
            }

            
        }

    }
    
}
