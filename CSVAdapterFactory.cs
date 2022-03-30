﻿using System;
using Day29_CensusAnalyzer.CustomException;
using Day29_CensusAnalyzer.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day29_CensusAnalyzer
{
    internal class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            try
            {
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
                }
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
