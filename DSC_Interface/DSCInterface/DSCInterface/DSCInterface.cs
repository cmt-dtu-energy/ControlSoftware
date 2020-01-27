using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFMExperimentsLibrary;
namespace DSCInterface
{
    public partial class DSCInterface : Form
    {
        public DSCInterface()
        {
            InitializeComponent();



            tempSafety = new TemperatureWatch(Properties.Settings.Default.MaxTemperature);
 
            pidCurrent.relay = relayCurrent;

            pidCurrent.psuInterface = psuInstek;

            relayCurrent.USBRelayControl_Load();

            GPIBPSUDriverInstrumentSettings instekSetts = new GPIBPSUDriverInstrumentSettings("GPIB0::8::INSTR");
            instekSetts.outputEnabledChan1 = false;
            instekSetts.outputEnabledChan2 = false;
            InstekPSHPSUDriver drv_instek = new InstekPSHPSUDriver(instekSetts);
            drv_instek.SaveSettingsHandler += Instek_SaveSettingsHandler;
            psuInstek.initializeInstrument(drv_instek, "Instek PSU");
           
           /*

            IsoTech3303PSUDriverInstrumentSettings isotech_setts =
            new IsoTech3303PSUDriverInstrumentSettings(Properties.IsoTechPSUSettings.Default.IsoTechPSUComPort, 
                                                    Properties.IsoTechPSUSettings.Default.IsoTechPSUBaudRate, 
                                                    Properties.IsoTechPSUSettings.Default.IsoTechPSUParity,
                                                    Properties.IsoTechPSUSettings.Default.IsoTechPSUDataBits, 
                                                    Properties.IsoTechPSUSettings.Default.IsoTechPSUStopBits);

            isotech_setts.outputEnabledChan1 = Properties.IsoTechPSUSettings.Default.Chan1Enabled;
            isotech_setts.setCurrentChan1 = Properties.IsoTechPSUSettings.Default.Chan1Current;
            isotech_setts.setVoltageChan1 = Properties.IsoTechPSUSettings.Default.Chan1Voltage;

            isotech_setts.outputEnabledChan2 = Properties.IsoTechPSUSettings.Default.Chan2Enabled;
            isotech_setts.setCurrentChan2 = Properties.IsoTechPSUSettings.Default.Chan2Current;
            isotech_setts.setVoltageChan2 = Properties.IsoTechPSUSettings.Default.Chan2Voltage;

            IsoTech3303PSUDriver drv_iso = new IsoTech3303PSUDriver(isotech_setts);
            drv_iso.SaveSettingsHandler += IsoTech_SaveSettingsHandler;
            psuIsotech.initializeInstrument(drv_iso, "IsoTech PSU");*/



            pidCurrent.psuInterface = psuInstek;
            pidCurrent.setTitle("Peltier controller");
            pidCurrent.setDefaultPSUPort(Properties.Settings.Default.PIDPeltierPSUPort);
            pidCurrent.setDefaultReadingPort(Properties.Settings.Default.PIDPeltierReadingsPort);
            pidCurrent.setMaxVoltage(Properties.Settings.Default.PIDPeltierMaxVoltage);
            pidCurrent.setMaxCurrent(Properties.Settings.Default.PIDPeltierMaxCurrent);
            pidCurrent.relay = relayCurrent;
            

            tempRampCtrl.pid_Tset = pidCurrent;

            ke2700.ReadingsUpdate += pidCurrent.readingsUpdate;
            ke2700.ReadingsUpdate += grphTemp.readingsUpdate;
            //ke2700.ReadingsUpdate += grphHallprobes.readingsUpdate;
            //ke2700.ReadingsUpdate += grphPeltier.readingsUpdate;
            ke2700.ReadingsUpdate += tempSafety.readingsUpdate;
            //ke2700.ReadingsUpdate += peltStab.readingsUpdate;
            ke2700.ReadingsUpdate += dataFilter.readingsUpdate;

            ke2700.KeithleySourceNamesChanged += grphTemp.dataNamesUpdate;
            //ke2700.KeithleySourceNamesChanged += grphHallprobes.dataNamesUpdate;
            //ke2700.KeithleySourceNamesChanged += grphPeltier.dataNamesUpdate;
            //ke2700.KeithleySourceNamesChanged += peltStab.dataNamesUpdate;
            ke2700.KeithleySourceNamesChanged += dataFilter.dataNamesUpdate;

            dataFilter.FilterReadingsUpdate += grphHallprobes.readingsUpdate;
            dataFilter.FilterReadingsUpdate += grphPeltier.readingsUpdate;
            dataFilter.FilterReadingsUpdate += peltStab.readingsUpdate;
            dataFilter.FilterReadingsUpdate += magDrive.readingsUpdate;
            dataFilter.FilterReadingsUpdate += expFlow.readingsUpdate;

            dataFilter.FilterNamesChanged += grphHallprobes.dataNamesUpdate;
            dataFilter.FilterNamesChanged += grphPeltier.dataNamesUpdate;
            dataFilter.FilterNamesChanged += peltStab.dataNamesUpdate;
            dataFilter.FilterNamesChanged += magDrive.dataNamesUpdate;
            dataFilter.FilterNamesChanged += expFlow.dataNamesUpdate;

            grphHallprobes.setPlotName("Hall probe graph");
            grphPeltier.setPlotName("Peltier difference");
            grphTemp.setPlotName("Temperature");

            outfile.OutputFilenameChanged += ke2700.userfilenameChanged;
            outfile.loadSettings();

            tempSafety.SafetyCloseInstrument += psuInstek.safetyCloseInstrument;

            expFlow.rampCtrl = tempRampCtrl;
            expFlow.stabCtrl = peltStab;
            expFlow.fieldCtrl = magDrive;
            expFlow.pidCtrl = pidCurrent;
            expFlow.pathCtrl = outfile;
            
            
            
        }
        private int nThreadsToWaitFor = 0;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            //make sure that the instruments finish their threads before their destructors are invoked
            ke2700.InstrumentFinished += ke2700_InstrumentFinished;
            nThreadsToWaitFor += ke2700.closeK2700Instrument();

            psuInstek.InstrumentFinished += psuInstek_InstrumentFinished;
            nThreadsToWaitFor += psuInstek.closeUnit();
            

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
            Properties.IsoTechPSUSettings.Default.Chan1Current = e.currentChan1;
            Properties.IsoTechPSUSettings.Default.Chan2Current = e.currentChan2;

            Properties.IsoTechPSUSettings.Default.Chan1Voltage = e.voltageChan1;
            Properties.IsoTechPSUSettings.Default.Chan2Voltage = e.voltageChan2;

            Properties.IsoTechPSUSettings.Default.Chan1Enabled = e.outputEnabledChan1;
            Properties.IsoTechPSUSettings.Default.Chan2Enabled = e.outputEnabledChan2;

            Properties.IsoTechPSUSettings.Default.Save();        

        }
    }
}
