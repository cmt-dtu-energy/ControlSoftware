using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class TemperatureProfileFunctionExponential : TemperatureProfileFunction
    {
        public override string fullName()
        {
            string name = "T(t) = A + B*exp(C*t). " + base.fullName();

            return name;
        }

        public override double functionValue(double t)
        {
            double val = coeffA + coeffB * Math.Exp(coeffC*t);

            return val;
        }

        public override string shortName()
        {
            return "A+B*exp(C*t)";
        }
    }
}
