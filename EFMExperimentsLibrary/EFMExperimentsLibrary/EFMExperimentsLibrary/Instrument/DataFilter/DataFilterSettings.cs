using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace EFMExperimentsLibrary
{
    public struct DataFilterSettings
    {
        public DataFilterSettings(int n)
        {
            string[] tmp = new string[n];
            for (int i = 0; i < n; i++)
                tmp[i] = "";

            names = new ArrayList(tmp);
            K1_vals = new ArrayList(new double[n]);
            K2_vals = new ArrayList(new double[n]);
            K3_vals = new ArrayList(new double[n]);
            channelID = new ArrayList(new int[n]);
            transformation = new ArrayList(new int[n]);
            channelA = new ArrayList(new int[n]);
            channelB = new ArrayList(new int[n]);
        }
        public ArrayList names;
        public ArrayList K1_vals;
        public ArrayList K2_vals;
        public ArrayList K3_vals;
        public ArrayList channelID;
        public ArrayList transformation;
        public ArrayList channelA;
        public ArrayList channelB;
    }
}
