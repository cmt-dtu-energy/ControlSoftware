using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFMExperimentsLibrary;
namespace FreezeCasterGUI_v10
{
    public partial class Form1 : Form
    {
        private TemperatureWatch tempSafety;
                
        public Form1()
        {
            InitializeComponent();

            tempSafety = new TemperatureWatch(Properties.Settings.Default.MaxTemperature);

            pidCurrent.relay = relayCurrent;

            pidCurrent.psuInterface = psuCP400;

            relayCurrent.USBRelayControl_Load();

            GPIBPSUDriverInstrumentSettings setts = new GPIBPSUDriverInstrumentSettings("GPIB0::11::INSTR");
            setts.outputEnabledChan1 = false;
            setts.outputEnabledChan2 = false;
            CPX400SPPSUDriver drv_cpx = new CPX400SPPSUDriver(setts);
            drv_cpx.SaveSettingsHandler += Instek_SaveSettingsHandler;
            psuCP400.initializeInstrument(drv_cpx, "CP400SP PSU");

          
            pidCurrent.psuInterface = psuCP400;
            pidCurrent.setTitle("Peltier controller");
            pidCurrent.setDefaultPSUPort(Properties.Settings.Default.PIDPeltierPSUPort);
            pidCurrent.setDefaultReadingPort(Properties.Settings.Default.PIDPeltierReadingsPort);
            pidCurrent.setMaxVoltage(Properties.Settings.Default.PIDPeltierMaxVoltage);
            pidCurrent.setMaxCurrent(Properties.Settings.Default.PIDPeltierMaxCurrent);
            pidCurrent.relay = relayCurrent;


            tempRampCtrl.pid_Tset = pidCurrent;
            temperatureProf.pid_Tset = pidCurrent;
            
            ke2700.ReadingsUpdate += pidCurrent.readingsUpdate;
            ke2700.ReadingsUpdate += grphTemp.readingsUpdate;
            
            ke2700.ReadingsUpdate += tempSafety.readingsUpdate;
            
            ke2700.KeithleySourceNamesChanged += grphTemp.dataNamesUpdate;

            temperatureProf.TemperatureSetPointChanged += ke2700.setTemperatureUpdated;


            /*dataFilter.FilterReadingsUpdate += grphHallprobes.readingsUpdate;
            dataFilter.FilterReadingsUpdate += grphPeltier.readingsUpdate;
            dataFilter.FilterReadingsUpdate += peltStab.readingsUpdate;
            dataFilter.FilterReadingsUpdate += magDrive.readingsUpdate;
            dataFilter.FilterReadingsUpdate += expFlow.readingsUpdate;

            dataFilter.FilterNamesChanged += grphHallprobes.dataNamesUpdate;
            dataFilter.FilterNamesChanged += grphPeltier.dataNamesUpdate;
            dataFilter.FilterNamesChanged += peltStab.dataNamesUpdate;
            dataFilter.FilterNamesChanged += magDrive.dataNamesUpdate;
            dataFilter.FilterNamesChanged += expFlow.dataNamesUpdate;
            */
            grphTemp.setPlotName("Temperature");

            outputFile.OutputFilenameChanged += ke2700.userfilenameChanged;
            outputFile.OutputFilenameChanged += temperatureProf.userfilenameChanged;
            outputFile.loadSettings();

            //tempSafety.SafetyCloseInstrument += psuCP400.safetyCloseInstrument;



        }
        private int nThreadsToWaitFor = 0;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            //make sure that the instruments finish their threads before their destructors are invoked
            ke2700.InstrumentFinished += ke2700_InstrumentFinished;
            nThreadsToWaitFor += ke2700.closeK2700Instrument();

            psuCP400.InstrumentFinished += psuInstek_InstrumentFinished;
            nThreadsToWaitFor += psuCP400.closeUnit();


            if (nThreadsToWaitFor > 0)
                e.Cancel = true;
            else
                e.Cancel = false;

            base.OnFormClosing(e);

        }

        private void psuInstek_InstrumentFinished(object sender, EventArgs e)
        {
            decrementWaitForThread();
        }

        private void ke2700_InstrumentFinished(object sender, EventArgs e)
        {
            decrementWaitForThread();
        }

        void picoTc08Control_InstrumentFinished(object sender, EventArgs e)
        {
            decrementWaitForThread();
        }

        private void decrementWaitForThread()
        {
            nThreadsToWaitFor--;
            if (nThreadsToWaitFor <= 0)
                Close();
        }



        private void Instek_SaveSettingsHandler(object sender, PSUSaveSettingsEventArgs e)
        {
           

        }
    }
}
