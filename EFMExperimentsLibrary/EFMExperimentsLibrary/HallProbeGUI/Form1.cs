using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HallProbeGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ke2700.ReadingsUpdate += dataFilter.readingsUpdate;
            ke2700.KeithleySourceNamesChanged += dataFilter.dataNamesUpdate;

            grphHallProbe.setPlotName("Hall probes");
            dataFilter.FilterNamesChanged += grphHallProbe.dataNamesUpdate;
            dataFilter.FilterReadingsUpdate += grphHallProbe.readingsUpdate;

            outFile.OutputFilenameChanged += ke2700.userfilenameChanged;
            outFile.loadSettings();

        }
    }   
}
