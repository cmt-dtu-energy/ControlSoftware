using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
namespace EFMExperimentsLibrary
{
    public class DSCDataSaver : InstrumentDataSaver
    {
        public DSCDataSaver( string file, string[] header, DateTime ts ) : base(file, "DSC", header, ts)
        {
            
        }

        protected override void initFile(string file, string[] header)
        {
            
            base.initFile(file, header);

            string[] vals = new string[header.Length * 2];
            form = "";
            for (int i = 0; i < header.Length; i++)
            {
                form += "{" + (2 * i).ToString() + ",15} ";
                form += "{" + (2 * i + 1).ToString() + ",15} ";

                
                vals[2 * i] = "Time";
                vals[2 * i + 1] = header[i];
            }            

            //write the header of the file
            cinfo = new CultureInfo("en-US");
            string output = "%" + String.Format(cinfo, form, vals);
            output += Environment.NewLine;
            //if (Directory.Exists(filenameData))
                File.WriteAllText(filenameData, output);

        }

        

        public void writeLine( double[,] dat)
        {
            string output = "";

            for (int i = 0; i < dat.GetLength(0); i++ )
            {
                output += String.Format(cinfo, "{0,15} {1,15} ", dat[i, 0], dat[i, 1]);
            }
            

            output += Environment.NewLine;
            //if (Directory.Exists(filenameData))
                File.AppendAllText(filenameData, output);
        }
    }
}
