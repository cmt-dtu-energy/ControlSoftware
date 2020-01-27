using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
namespace EFMExperimentsLibrary
{
    public class InstrumentDataSaver
    {
        protected string filenameData,filenameCoords;

        protected CultureInfo cinfo;

        private int maxIndent = 1000;

        protected string form = "";

        protected int currentPoint = 0;

        protected DateTime timeStamp;

        public InstrumentDataSaver( string name, string[] header, DateTime ts )
        {
            initializeFileName(name, "", header);
            timeStamp = ts;
        }
        public InstrumentDataSaver(string name, string identifier, string[] header, DateTime ts)
        {
            initializeFileName(name, identifier, header);
            timeStamp = ts;
        }

        private void initializeFileName(string name, string identifier, string[] header)
        {
            //create a datasaver object with a new file name based on the date, string name and some indentation in order to make it unique.

            DateTime dt = DateTime.Now;
            string dateStr = dt.ToString("yyyyMMdd");

            string path = Directory.GetParent(name).FullName;
            string mainName = Path.GetFileName(name);


            for (int i = 0; i < maxIndent; i++)
            {

                string t = path + "\\" + dateStr + mainName + "_" + identifier + "_" + i.ToString();

                if (!File.Exists(t+ "_data.txt"))
                {
                    initFile(t, header);
                    break;
                }
            }
        }

        public virtual void writeCoordinates(double x, double y, double z, double load, string[] sArr)
        {            

            currentPoint++;

            string output = String.Format(cinfo, "{0,16} {1,16} {2,16} {3,16} {4,15}", currentPoint,x, y, z, load);

            output += Environment.NewLine;

            //if (Directory.Exists(filenameCoords))
                File.AppendAllText(filenameCoords, output);

            
        }
        

        protected virtual void initFile( string file, string[] header )
        {
            filenameData = file + "_data.txt";
            filenameCoords = file + "_coords.txt";

            string output = "% " + String.Format(cinfo, "{0,16} {1,16} {2,16} {3,15} {4,15}", "Point nr.", "X [mm]", "Y [mm]", "Z [mm]", "Load [N]");

            output += Environment.NewLine;

            if ( Directory.Exists( filenameCoords ) )
                File.AppendAllText(filenameCoords, output);

        }

        
        public string getFilenameData()
        {
            return filenameData;
        }
        public string getFilenameCoords()
        {
            return filenameCoords;
        }
        

    }
    
}
