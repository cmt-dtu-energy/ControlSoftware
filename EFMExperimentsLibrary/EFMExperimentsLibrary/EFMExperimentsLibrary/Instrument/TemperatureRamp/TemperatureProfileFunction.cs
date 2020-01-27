using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class TemperatureProfileFunction
    {
        public double coeffA { get; set; }
        public double coeffB { get; set; }
        public double coeffC { get; set; }

        private double deltaTime;

        public virtual string fullName()
        {
            //should make a string representation of the current profile and return it
            return "A = " + coeffA.ToString() + ", B = " + coeffB.ToString() + ", C = " + coeffC.ToString() + ", deltaTime = " + deltaTime.ToString();
        }

        public virtual string shortName()
        {
            return "default";
        }

        public virtual double functionValue( double t )
        {
            return 0;
        }

        public void setDeltaTime( double t )
        {
            if ( t > 0 )
            {
                deltaTime = t;
            }
        }

        public double getDeltaTime()
        {
            return deltaTime;
        }

    }
}
