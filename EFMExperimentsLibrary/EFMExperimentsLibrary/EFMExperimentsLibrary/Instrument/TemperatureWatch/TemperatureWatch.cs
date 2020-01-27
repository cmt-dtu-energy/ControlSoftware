using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class TemperatureWatch
    {
        public event EventHandler SafetyCloseInstrument;

        public double temperatureLimit { get; set; }

        public TemperatureWatch(double limit)
        {
            temperatureLimit = limit;
        }

        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            //check all temperature readings if they are above the accepted limit
            for (int i = 0; i < e.chanEnabled.Length; i++)
            {
                switch (e.measurementTypes[i])
                {
                    case Keithley2700MeasurementTypes.TC_E:
                    case Keithley2700MeasurementTypes.TC_K:
                    case Keithley2700MeasurementTypes.R_FourPoint:
                    case Keithley2700MeasurementTypes.R_TwoPoint:

                        double val = e.readings[i, 1];
                        if (!Double.IsInfinity(val) && !Double.IsNaN(val) && val > temperatureLimit)
                        {
                            onCloseInstruments();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void onCloseInstruments()
        {
            EventHandler handler = SafetyCloseInstrument;

            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }


}
