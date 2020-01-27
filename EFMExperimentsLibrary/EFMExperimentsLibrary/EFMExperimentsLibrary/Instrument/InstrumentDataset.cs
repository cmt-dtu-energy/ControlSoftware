using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    /**
     * Parent class for data sets used in the Instrument environment
     * */
    public class InstrumentDataset
    {

        //This event is raised when the buffer is about to be reset
        public event EventHandler<InstrumentDatasetEventArgs> BufferFull;


        protected int currentPos, latestRead, bs;

        public virtual void AddData(double[,] data)
        {
            if (currentPos >= bs)
            {
                //Make an eventArgs with the current buffer data
                InstrumentDatasetEventArgs e = new InstrumentDatasetEventArgs();
                e.dataSet = this;
                //raise the event that the buffer is being reset
                OnBufferFull(e);
                //Reset the buffer
                initArrays();

                //Reset the position
                currentPos = -1;
                latestRead = 0;
            }
        }
        public virtual void AddData(double[,] data, DateTime[] date)
        {
            
        }
        public virtual double[,] getLatestData()
        {
            return new double[1,1];
        }


        protected virtual void initArrays()
        {

        }

        public int buffsize()
        {
            return bs;
        }

        /**
         * Warning: This method overwrites the current buffers without notification
         * */
        public void buffsize(int s)
        {
            if (s <= 0)
                bs = 1;
            else
                bs = s;

            initArrays();
        }
        protected virtual void OnBufferFull(InstrumentDatasetEventArgs e)
        {
            EventHandler<InstrumentDatasetEventArgs> handler = BufferFull;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        
        protected ArraySegment<double> getArraySlice(double[] arr)
        {
            if (latestRead < currentPos && latestRead < bs)
            {
                int endInd = Math.Min(currentPos, bs);
                ArraySegment<double> seg = new ArraySegment<double>(arr, latestRead, endInd);
                return seg;
            }
            else
            {
                return default(ArraySegment<double>);
            }
        }

    }
}
