using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EFMExperimentsLibrary
{
    public class MHMHallprobe
    {

        
        private int prevLineCount = 0;
        private MHMDataSet data;
        private string filePath = "";
        private string currentFilename = "";
        private string[] header = null;
        
        /**
        Initializes the loader with a given data file
        */
        public MHMHallprobe(string file)
        {
            filePath = file;
            updateReading();
        }
        public MHMDataSet updateReading()
        {
            //get the newest file
            string[] files = Directory.GetFiles(filePath, "*.csv");
            DateTime[] fileWrites = new DateTime[files.Length];
            for ( int i = 0; i < fileWrites.Length; i++ )
            {
                fileWrites[i] = File.GetLastWriteTime(files[i]);
            }
            Array.Sort(fileWrites,files);

            //check if the file is new or whether we are already loading from it
            if( !currentFilename.Equals(files[files.Length-1]))
            {
                //restart the data aquisition, remember the youngest file is the last one
                currentFilename = files[files.Length-1];
                prevLineCount = 0;
                data = new MHMDataSet();
            }

            
            //check if the no. of lines has increased since the last time
            int lineCount = 0;
            
            using (FileStream stream = File.Open(currentFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = null;
                    while ( ( line = reader.ReadLine()) != null )
                    {
                        lineCount++;
                    }
                }
            }

            if (lineCount > prevLineCount)
            {
                    
                data.startAddingData();
                int curLine = 0;
                try
                {
                    using (FileStream stream = File.Open(currentFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                //check of the header has been found (the file is not new if the header is already here)
                                if (prevLineCount == 0)
                                {
                                    //find the header
                                    if (String.Equals("DATA", line))
                                    {
                                        line = reader.ReadLine();
                                        curLine++;
                                        string[] pieces = line.Split(';');
                                        header = pieces;
                                        prevLineCount = curLine;
                                    }            
                                    
                                }
                                else
                                {
                                    //add new data lines to the buffer                                    
                                    if (curLine > prevLineCount)
                                    {
                                        string[] pieces = line.Split(';');
                                        data.addDataPoint(Convert.ToDouble(pieces[4]), Convert.ToDouble(pieces[5]), Convert.ToDouble(pieces[6]) , Convert.ToInt32(pieces[0]), Convert.ToInt32(pieces[1]), Convert.ToInt32(pieces[2]), Convert.ToInt32(pieces[3]), Convert.ToDouble(pieces[7]));
                                    }
                                }
                                curLine++;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(curLine - prevLineCount);
                prevLineCount = curLine;
                
                return data.stopAddingData();
            }
            else
            {
                return null;
            }
        }


    }
    public enum HallprobeDataArrayIndices { Bx, By, Bz, Bnorm, temperature, time }
    public class MHMDataSet : InstrumentDataset
    {
        private static int defSize = 1000000;

        public double[] Bx { get; private set; }
        public double[] By { get; private set; }
        public double[] Bz { get; private set; }
        public double[] Bnorm { get; private set; }
        public double[] T { get; private set; }
        public DateTime[] timestamp { get; private set; }

        //current index of the data set
        private int index = 0;

        private DateTime startTime;
        private bool startTimeSet = false;
        public MHMDataSet()
        {
            initData(defSize);
            
        }
        public MHMDataSet(int size)
        {
            initData(size);
        }
        public MHMDataSet( int size, DateTime st )
        {
            initData(size);
            startTime = st;
            startTimeSet = true;
        }

        public void initData( int size )
        {
            Bx = new double[size];
            By = new double[size];
            Bz = new double[size];
            Bnorm = new double[size];
            T = new double[size];
            timestamp = new DateTime[size];
            index = 0;
            
        }

        /**
         * Called when a new data stream is coming in
         * */
        public void startAddingData()
        {
            initData(defSize);
        }
        /**
         * Copies the most recent data aquisition
         * */
        public MHMDataSet stopAddingData()
        {
            if (index > 1)
            {
                MHMDataSet d = new MHMDataSet(index - 1, startTime);

                for (int i = 0; i < index - 1; i++)
                {
                    d.addDataPoint(Bx[i], By[i], Bz[i], Bnorm[i], timestamp[i], T[i]);
                }

                return d;
            }
            else
            {
                return null;
            }
        }

        /**
            * Should throw an exception if the buffer is full. Decision needs to made: Should the buffer empty and start over or should the oldest point be thrown out?
            * */
        public void addDataPoint(double Bx_, double By_, double Bz_, int h, int m, int s, int msec, double T_)
        {
            if (index >= Bx.Length)
            {
                throw new Exception();
            }
            else
            {
                //calculate the field norm
                double Bnorm_ = Math.Sqrt(Bx_ * Bx_ + By_ * By_ + Bz_ * Bz_);

                Bx[index] = Bx_;
                By[index] = By_;
                Bz[index] = Bz_;
                Bnorm[index] = Bnorm_;
                T[index] = T_;
                timestamp[index] = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, s, msec);
                if (!startTimeSet)
                {
                    startTime = timestamp[index];
                    startTimeSet = true;
                }
                index++;
            }

        }    

        private void addDataPoint( double Bx_, double By_, double Bz_, double Bnorm_, DateTime timestamp_, double T_)
        {
            Bx[index] = Bx_;
            By[index] = By_;
            Bz[index] = Bz_;
            Bnorm[index] = Bnorm_;
            T[index] = T_;
            timestamp[index] = timestamp_;
            index++;
        }

        public override double[,] getLatestData()
        {
            double[,] dat = new double[6,Bx.Length] ;

            for (int i = 0; i < Bx.Length; i++)
            {
                dat[(int)HallprobeDataArrayIndices.Bx, i] = Bx[i];
                dat[(int)HallprobeDataArrayIndices.By, i] = By[i];
                dat[(int)HallprobeDataArrayIndices.Bz, i] = Bz[i];
                dat[(int)HallprobeDataArrayIndices.Bnorm, i] = Bnorm[i];
                dat[(int)HallprobeDataArrayIndices.temperature, i] = T[i];
                dat[(int)HallprobeDataArrayIndices.time, i] = (timestamp[i] - startTime).Ticks / TimeSpan.TicksPerSecond;
            }
            return dat;
        }

    }
}
