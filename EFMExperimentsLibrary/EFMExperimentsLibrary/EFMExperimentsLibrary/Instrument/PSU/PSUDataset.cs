using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public enum PSUDataArrayIndices { CurrentChan1, VoltageChan1, CurrentChan2, VoltageChan2, Time }
    public class PSUDataset : InstrumentDataset
    {
     
        private volatile double[] chan1Current;
        private volatile double[] chan1Voltage;

        private volatile double[] chan2Current;
        private volatile double[] chan2Voltage;

        private volatile double[] timeArray;        
        
        public PSUDataset()
        {
            currentPos = -1;
            latestRead = 0;
            bs = 1;
            initArrays();
        }

        public override void AddData( double[,] arr )
        {
            base.AddData(arr);
            currentPos++;
            chan1Current[currentPos] = arr[(int)PSUDataArrayIndices.CurrentChan1,0];
            chan1Voltage[currentPos] = arr[(int)PSUDataArrayIndices.VoltageChan1,0];

            chan2Current[currentPos] = arr[(int)PSUDataArrayIndices.CurrentChan2,0];
            chan2Voltage[currentPos] = arr[(int)PSUDataArrayIndices.VoltageChan2,0];

            timeArray[currentPos] = arr[(int)PSUDataArrayIndices.Time,0];

        }

        public override double[,] getLatestData()
        {
            double[,] vals = new double[5,1];
            if (currentPos >= 0)
            {
                vals[(int)PSUDataArrayIndices.CurrentChan1,0] = chan1Current[currentPos];
                vals[(int)PSUDataArrayIndices.CurrentChan2,0] = chan2Current[currentPos];
                vals[(int)PSUDataArrayIndices.VoltageChan1,0] = chan1Voltage[currentPos];
                vals[(int)PSUDataArrayIndices.VoltageChan2,0] = chan2Voltage[currentPos];
                vals[(int)PSUDataArrayIndices.Time,0] = timeArray[currentPos];
            }

            return vals;
        }
        
        public PSUSeebeckDataSubset getRemainingData()
        {
            PSUSeebeckDataSubset subset = new PSUSeebeckDataSubset();
            subset.chan1CurrentSubset =  getArraySlice(chan1Current);
            subset.chan2CurrentSubset = getArraySlice(chan2Current);
            
            subset.chan1VoltageSubset = getArraySlice(chan1Voltage);
            subset.chan2VoltageSubset = getArraySlice(chan2Voltage);

            subset.time = getArraySlice(timeArray);

            latestRead = currentPos;

            return subset;
        }
     
        protected override void initArrays()
        {
            chan1Current = new double[bs];
            chan1Voltage = new double[bs];

            chan2Current = new double[bs];
            chan2Voltage = new double[bs];

            timeArray = new double[bs];
            
        }
    }

    public class PSUSeebeckDataSubset
    {
        public ArraySegment<double> chan1CurrentSubset;
        public ArraySegment<double> chan2CurrentSubset;
        public ArraySegment<double> chan1VoltageSubset;
        public ArraySegment<double> chan2VoltageSubset;
        public ArraySegment<double> time;
    }
}
