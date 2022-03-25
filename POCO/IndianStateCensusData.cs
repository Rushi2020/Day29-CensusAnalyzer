using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day29_CensusAnalyzer.POCO
{
    internal class IndianStateCensusData
    {
        public string State { get; set; }
        public long Population { get; set; }
        public long AreaInSqKm { get; set; }
        public long DensityPerSqKm { get; set; }
    }
}
