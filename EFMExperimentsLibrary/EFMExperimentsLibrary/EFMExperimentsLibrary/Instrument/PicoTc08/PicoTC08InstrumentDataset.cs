using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{

    public class PicoTC08InstrumentDataset : InstrumentDataset
    {
        private double[,] data;
        private double[,] timestamps;

        private int nPoints = 9;

        public PicoTC08InstrumentDataset()
        {
            currentPos = -1;
            latestRead = 0;
            bs = 1024;
            initArrays();

        }

        public override void AddData(double[,] datIn)
        {
            base.AddData(datIn);
            currentPos++;
            for ( int i = 0; i < nPoints; i++ )
            {
                timestamps[i, currentPos] = datIn[i, 0];
                data[i,currentPos] = datIn[i,1];
            }
        }

        public override double[,] getLatestData()
        {
            double[,] dat = new double[nPoints, 2];
            if (currentPos >= 0)
            {
                for (int i = 0; i < nPoints; i++)
                {
                    dat[i, 0] = timestamps[i, currentPos];
                    dat[i, 1] = data[i, currentPos];
                }
            }
            return dat;
        }

        protected override void initArrays()
        {
            data = new double[nPoints, bs];
            timestamps = new double[nPoints, bs];

            base.initArrays();
        }

        protected override void OnBufferFull(InstrumentDatasetEventArgs e)
        {
            base.OnBufferFull(e);
        }
    }
}
