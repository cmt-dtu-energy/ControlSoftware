using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
namespace EFMExperimentsLibrary
{
    public class HallprobeDataSaver : InstrumentDataSaver
    {

        public HallprobeDataSaver(string file, string[] header, DateTime ts) : base(file, "HP", header, ts)
        {

        }

        protected override void initFile(string file, string[] header)
        {
            base.initFile(file, header);
            string[] vals = new string[header.Length];
            form = "";
            for (int i = 0; i < header.Length; i++)
            {
                form += "{" + i.ToString() + ",15} ";
                
                vals[i] = header[i];
                
            }

            //write the header of the file
            cinfo = new CultureInfo("en-US");
            string output = "%" + String.Format(cinfo, form, vals);
            output += Environment.NewLine;
            //if (Directory.Exists(filenameData))
            File.WriteAllText(filenameData, output);
        }

        public void writeRaw(double[,] dat)
        {
            string output = currentPoint.ToString();

            for (int j = 0; j < dat.GetLength(1); j++)
            {
                for (int i = 0; i < dat.GetLength(0); i++)
                {
                    output += String.Format(cinfo, "    {0,15}", dat[i,j]);
                }

                output += Environment.NewLine;
            }
            //if (Directory.Exists(filenameData))
            File.AppendAllText(filenameData, output);
        }

        public void writeProcessed(double[] mean, double[] stdev)
        {
            string output = currentPoint.ToString();

            
            for (int i = 0; i < mean.Length; i++)
            {
                output += String.Format(cinfo, "    {0,15}  {1,15}", mean[i], stdev[i] );
            }

                output += Environment.NewLine;
            
            //if (Directory.Exists(filenameData))
            File.AppendAllText(filenameData, output);
        }

    }

}
