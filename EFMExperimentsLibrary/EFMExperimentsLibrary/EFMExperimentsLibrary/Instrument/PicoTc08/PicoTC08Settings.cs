using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMExperimentsLibrary
{
    public class PicoTC08Settings
    {
        public const int nChannels = 9;
        private TempUnit[] tempUnits;
        private char[] channelTypeChar;
        private ChannelType[] channelType;
        public bool settingsChanged { get; set; }
        
        public enum ChannelType
        {
            B, E, J, K, N, R, S, T, NotEnabled
        }
        public PicoTC08Settings()
        {
            tempUnits = new TempUnit[nChannels];
            channelTypeChar = new char[nChannels];
            channelType = new ChannelType[nChannels];

            for ( int i = 0; i < nChannels; i++ )
            {
                //default settings
                tempUnits[i] = TempUnit.USBTC08_UNITS_KELVIN;

                channelTypeChar[i] = 'K';
                channelType[i] = ChannelType.K;
            }
            settingsChanged = true;
        }

        public void setTempUnit( int chn, TempUnit un )
        {
            if ( chn >= 0 && chn < nChannels )
            {
                tempUnits[chn] = un;
            }
        }

        public TempUnit getTempUnit( int chn )
        {
            if ( chn >= 0 && chn < nChannels)
            {
                return tempUnits[chn];
            }
            return TempUnit.USBTC08_UNITS_KELVIN;
        }

        public ChannelType getChannelType( int chn )
        {
            if ( chn >= 0 && chn < nChannels )
            {
                return channelType[chn];
            }
            return ChannelType.NotEnabled;
        }

        public char getChannelTypeChar(int chn)
        {
            if (chn >= 0 && chn < nChannels)
            {
                return channelTypeChar[chn];
            }
            return ' ';
        }

        public void setChannelType( int chn, ChannelType type )
        {
            if ( chn >= 0 && chn < nChannels )
            {
                char tp = ' ';
                switch ( type )
                {
                    case ChannelType.B:
                        tp = 'B';
                        break;
                    case ChannelType.E:
                        tp = 'E';
                        break;
                    case ChannelType.J:
                        tp = 'J';
                        break;
                    case ChannelType.K:
                        tp = 'K';
                        break;
                    case ChannelType.N:
                        tp = 'N';
                        break;
                    case ChannelType.NotEnabled:
                        tp = ' ';
                        break;
                    case ChannelType.R:
                        tp = 'R';
                        break;
                    case ChannelType.S:
                        tp = 'S';
                        break;
                    case ChannelType.T:
                        tp = 'T';
                        break;
                }
                channelTypeChar[chn] = tp;
                channelType[chn] = type;
                settingsChanged = true;
            }
            
        }
    }
}
