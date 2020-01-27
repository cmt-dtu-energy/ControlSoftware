using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace EFMExperimentsLibrary
{
    public partial class OutputFileControl : UserControl,DatasaveFilePath
    {
        public event EventHandler<OutputFileNameChangedEventArgs> OutputFilenameChanged;

        private String settingsFile;
        private DataTable filenames = new DataTable("OutputFilenames");
        public OutputFileControl()
        {
            InitializeComponent();
            settingsFile = this.Name + "_settings.xml";
        }

        public void loadSettings()
        {
            bool settingsLoaded = false;
            filenames.Clear();
            filenames.Columns.Add("OutputDir", typeof(String));
            filenames.Columns.Add("OutputFile", typeof(String));
            if ( File.Exists(settingsFile ) )
            {
                try
                {
                    filenames.ReadXml(settingsFile);
                    settingsLoaded = true;
                }
                catch (Exception ex)
                {

                }
            }
            if ( !settingsLoaded )
            {
                filenames.Rows.Add("c:/dsc/", "default");
                
            }
            txtOutputFolder.Text = (String)filenames.Rows[0][0];
            txtSampleName.Text = (String)filenames.Rows[0][1];
            //called to wake up the listeners and get their respective data savers going
            textChanged();
        }

        public string getPath()
        {
            return txtOutputFolder.Text;
        }
        public string getFilename()
        {
            return txtSampleName.Text;
        }
        private void foldFilePath_HelpRequest(object sender, EventArgs e)
        {

        }

        private void txtOutputFolder_TextChanged(object sender, EventArgs e)
        {
            //textChanged();
        }

        private void txtSampleName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSampleName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textChanged();
            }
        }


        private void textChanged()
        {
            filenames.Rows[0][0] = txtOutputFolder.Text;
            filenames.Rows[0][1] = txtSampleName.Text;
            filenames.WriteXml(settingsFile );
            if (OutputFilenameChanged != null)
            {
                OutputFileNameChangedEventArgs evt = new OutputFileNameChangedEventArgs();
                evt.filename = txtSampleName.Text;
                evt.outputDirectory = txtOutputFolder.Text;
                OutputFilenameChanged(this, evt);
            }
        }
    }

    public class OutputFileNameChangedEventArgs : EventArgs
    {
        public String filename{get;set;}
        public String outputDirectory{get;set;}
    }
}
