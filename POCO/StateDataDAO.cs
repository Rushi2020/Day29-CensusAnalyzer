using System;
using System.Collections.Generic;
using System.Text;

namespace Day29_CensusAnalyzer.POCO
{
    public class StateDataDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        // Parameterized Constructor Initializes a new instance of the class.
        public StateDataDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}