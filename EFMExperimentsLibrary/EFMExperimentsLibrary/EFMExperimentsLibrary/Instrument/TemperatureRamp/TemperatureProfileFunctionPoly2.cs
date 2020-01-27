using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class TemperatureProfileFunctionPoly2 : TemperatureProfileFunction
    {
        public override string fullName()
        {
            string name = "T(t) = A + B*t + C * t^2. " + base.fullName();

            return name;
        }

        public override double functionValue(double t)
        {
            double val = coeffA + coeffB * t + coeffC * t*t;

            return val;
        }

        public override string shortName()
        {
            return "A+B*t+C*t^2";
        }
    }
}
