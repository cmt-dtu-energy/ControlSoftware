using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class InstrumentSettings
    {

        protected volatile string[] channelName;

        public volatile bool settingsChanged;

        public volatile bool freezeSettings;

        protected volatile int numberOfChannels;

        protected volatile bool[] channelOpen;

        public InstrumentSettings()
        {
            settingsChanged = true;
        }

        protected virtual void initializeArrays()
        {
            if (numberOfChannels <= 0)
                numberOfChannels = 1;

            channelName = new string[numberOfChannels];
            for (int i = 0; i < channelName.Length; i++ )            
                channelName[i] = "ch1";

            
            channelOpen = new bool[numberOfChannels];

            settingsChanged = true;
        }

        /**
         * Sets the given channel to be open or closed.
         * */
        public void setChannelStatus( int chn, bool open)
        {
            if (isValidChannelIndex(chn))
            {
                if (channelOpen[chn] != open)
                {
                    channelOpen[chn] = open;
                    changeSettings();
                }
            }
        }

        public void setChannelName( int chn, string name )
        {
            if ( isValidChannelIndex(chn))
            {
                if ( channelName[chn].CompareTo(name) != 0 )
                {
                    channelName[chn] = name;

                    changeSettings();
                }
            }
        }

        public bool getChannelStatus( int chn )
        {
            if ( isValidChannelIndex(chn))
            {
                return channelOpen[chn];
            }
            else
            {
                return false;
            }
        }

        protected bool isValidChannelIndex( int chn )
        {
            if ( chn < numberOfChannels && chn >= 0)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }



        public int getNumberOfChannels()
        {
            return numberOfChannels;
        }

        public bool[] getChannelsStatus ()
        {
            return channelOpen;
        }

        public string[] getChannelNames()
        {
            return channelName;
        }

        protected void changeSettings()
        {
            if (!freezeSettings)
                settingsChanged = true;
        }

    }
}
