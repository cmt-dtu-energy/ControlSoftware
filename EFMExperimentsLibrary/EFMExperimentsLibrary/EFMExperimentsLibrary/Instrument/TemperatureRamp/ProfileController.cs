using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class ProfileController
    {
        private List<TemperatureProfileFunction> temperatureProfilesList = new List<TemperatureProfileFunction>();

        public event EventHandler<TemperatureProfileEventArgs> TemperatureProfileUpdated;

        public ProfileController()
        {

        }

        /**
         * Returns a list of the available profiles
         */
        public List<TemperatureProfileFunction> availableProfiles()
        {
            List<TemperatureProfileFunction> lst = new List<TemperatureProfileFunction>();

            TemperatureProfileFunctionExponential expFunc = new TemperatureProfileFunctionExponential();
            TemperatureProfileFunctionPoly2 linFunc = new TemperatureProfileFunctionPoly2();
            lst.Add(expFunc);
            lst.Add(linFunc);

            return lst;
        }
        /**
         * Adds a profile to the current list of profiles based on the index matching the availableProfiles() method
         * */
        public void addProfileFunction( int index, double cA, double cB, double cC, double deltaTime )
        {
            List<TemperatureProfileFunction> availProf = availableProfiles();

            if ( checkIndex( index, availProf ) )
            {
                //make new object with the given profile and parameters
                TemperatureProfileFunction prof = availProf.ElementAt(index);
                prof.coeffA = cA;
                prof.coeffB = cB;
                prof.coeffC = cC;
                prof.setDeltaTime(deltaTime);

                //add the allowed profile to the list
                temperatureProfilesList.Add(prof);
                //fire event that the list has changed
                OnUpdatedList();
            }
        }
        /**
         * Stiches the total profile together based on the current profile list
         * */
        public double[,] getTotalProfile()
        {
            //time between points on the temperature graph
            double dt = 0.1;

            //first find the total time needed
            double t_tot = 0;
            for ( int i = 0; i < temperatureProfilesList.Count(); i++ )
            {
                t_tot += temperatureProfilesList[i].getDeltaTime();
            }

            //make time interval array for all profiles
            double[] timeInterval = new double[temperatureProfilesList.Count()+1];
            timeInterval[0] = 0;
            for ( int i = 1; i < timeInterval.Length; i++)
            {
                timeInterval[i] = timeInterval[i - 1] + temperatureProfilesList[i - 1].getDeltaTime();
            }

            //make time and temperature array
            int nt = (int)Math.Ceiling(t_tot / dt);

            double[,] retval = new double[nt,2];
            //initial temperature
            retval[0, 1] = temperatureProfilesList[0].functionValue(0);
            for ( int i = 1; i < nt; i++ )
            {
                //time
                double t = retval[i - 1, 0] + dt;
                retval[i, 0] = t;
                //temperature
                int fctIndex = 0;
                double offset = 0;
                for ( int j = 0; j < timeInterval.Length-1; j++ )
                {
                    offset += timeInterval[j];
                    if ( timeInterval[j] <= t && t < timeInterval[j+1] )
                    {
                        fctIndex = j;
                        break;
                    }
                }
                //Note that the time is offset with all previous profiles' deltaTimes
                //In order to ensure that each profile is started at time = 0 so that
                //the coefficients are not a function of the order of the profiles and their
                //respective timing.
                retval[i, 1] = temperatureProfilesList[fctIndex].functionValue(t-offset);
            }

            return retval;
        }

        public List<TemperatureProfileFunction> getCurrentProfileList()
        {
            return temperatureProfilesList;
        }

        /**
         * Removes the function at the specified index
         * */
        public void removeProfileFunction( int index )
        {
            if ( checkIndex(index, temperatureProfilesList ) )
            {
                temperatureProfilesList.RemoveAt(index);
                OnUpdatedList();
            }
        }
        /**
         * Moves the item with index up (if index > 0 )
         * */
        public void moveItemUp( int index )
        {
            if ( index > 0 && index < temperatureProfilesList.Count() )
            {
                TemperatureProfileFunction itemA = temperatureProfilesList[index-1];
                temperatureProfilesList[index-1] = temperatureProfilesList[index];
                temperatureProfilesList[index] = itemA;
                OnUpdatedList();
            }
        }


        /**
        * Moves the item with index down (if index >= 0 and index < count-1)
        * */
        public void moveItemDown(int index)
        {
            if (index >= 0 && index < temperatureProfilesList.Count()-1)
            {
                TemperatureProfileFunction itemA = temperatureProfilesList[index];
                temperatureProfilesList[index] = temperatureProfilesList[index+1];
                temperatureProfilesList[index+1] = itemA;
                OnUpdatedList();
            }
        }


        private bool checkIndex(int index, List<TemperatureProfileFunction> lst )
        {
            if (index >= 0 && index < lst.Count())
                return true;
            else
                return false;
        }

        private void OnUpdatedList()
        {
            EventHandler<TemperatureProfileEventArgs> handler = TemperatureProfileUpdated;
            if (handler != null)
            {
                TemperatureProfileEventArgs e = new TemperatureProfileEventArgs();
                e.lst = temperatureProfilesList;
                handler(this, e);
            }
        }
        
    }
    public class TemperatureProfileEventArgs : EventArgs
    {
        public List<TemperatureProfileFunction> lst;
    }
}
