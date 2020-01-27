using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{

    public class Keithley2700SeebeckDataset : InstrumentDataset
    {

        //Number of data points (22 channels)
        private int nPoints = 22;

        private double[,] data;
        private double[,] timestamps;

        public Keithley2700SeebeckDataset()
        {
            currentPos = -1;
            latestRead = 0;
            bs = 1;            
            initArrays();
        }

        public override void AddData(double[,] arr)
        {
            base.AddData(arr);

            currentPos++;
            for ( int i = 0; i < nPoints; i++ )
            {
                data[i,currentPos] = arr[i,0];
                timestamps[i,currentPos] = arr[i,1];
            }
        }

        public override double[,] getLatestData()
        {
            double[,] vals = new double[nPoints,2];

            if ( currentPos >= 0)
            {
                for ( int i = 0; i < nPoints; i++ )
                {
                    vals[i,0] = data[i,currentPos];
                    vals[i,1] = timestamps[i,currentPos];
                }
            }

            return vals;
        }


        protected override void initArrays()
        {
            data = new double[nPoints,bs];
            timestamps = new double[nPoints,bs];
        }

        public int getNPoints()
        {
            return nPoints;
        }

    }
}
