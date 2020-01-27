using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFMExperimentsGUITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            magnetDriveControl1.closeInstrument();

            base.OnFormClosing(e);
        }

        private void magnetDriveControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
