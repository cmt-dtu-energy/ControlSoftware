using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMTHallProbeScanner
{
    public partial class CMTHallprobeScanner : Form
    {
        public CMTHallprobeScanner()
        {
            InitializeComponent();
            hallprobeControl1.setDatafile(hallprobeControl1.getMHMDataFolder());
            outputFileControl1.OutputFilenameChanged += hallprobeControl1.OutputFilenameChanged;
            outputFileControl1.loadSettings();
            xyzStagev21.xyzPointReached += hallprobeControl1.xyzPointReached;
            hallprobeControl1.measurementsCompleted += xyzStagev21.measurementsCompleted;
            
        }

        private void xyzStagev21_Load(object sender, EventArgs e)
        {

        }
    }
}
