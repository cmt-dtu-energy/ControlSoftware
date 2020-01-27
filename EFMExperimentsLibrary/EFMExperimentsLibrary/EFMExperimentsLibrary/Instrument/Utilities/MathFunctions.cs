using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMExperimentsLibrary
{
    public class MathFunctions
    {

        /**
         * Interpolates all the values specified in input array val with x-values given in table
         * table(:,0) are the x-values and table(:,1) the y-values
         * */
        public static double[] interp1( double[,] table, double[] val )
        {
            double[] retVal = new double[val.Length];

            
            //loop over each required value
            for (int i = 0; i < retVal.Length; i++)
            {
                //find the two points in x surrounding the value
                int ind = -1;
                for (int j = 0; j < table.GetLength(0)-1; j++)
                {
                    if ( table[j,0] <= val[i] && val[i] <= table[j+1,0] )
                    {
                        ind = j;
                        break;
                    }
                }
                if (ind >= 0)
                {
                    //perform the interpolation
                    double t_lin = (val[i] - table[ind,0]) / (table[ind + 1,0] - table[ind,0]);
                    retVal[i] = (1 - t_lin) * table[ind,1] + t_lin * table[ind + 1,1];
                }
                else
                    retVal[i] = double.NaN;
            }
            return retVal;
        }
        /**
         * Interpolates a single value rather than array of values
         * */
        public static double interp1(double[,] table, double val)
        {
            double[] retVal = new double[1];

            double[] tmp = new double[1];
            tmp[0] = val;
            retVal = interp1(table, tmp);
            return retVal[0];
        }
        /**
         * Given the input array val with dims [n,m] the mean [n,1] and stdev [n,1] values are returned
         * */
        public static void getMeanStdev( double[,] val, ref double[] mean, ref double[] stdev )
        {
            
            for (int j = 0; j < val.GetLength(0); j++)
            {
                for (int i = 0; i < val.GetLength(1); i++)
                {
                    mean[j] += val[j,i];
                }
                mean[j] = mean[j] / val.GetLength(1);

                for (int i = 0; i < val.GetLength(1); i++)
                {
                    stdev[j] += (mean[j] - val[j,i]) * (mean[j] - val[j,i]);
                }

                stdev[j] = Math.Sqrt(stdev[j] / val.GetLength(1));
            }
                       

            

        }
    }
}
