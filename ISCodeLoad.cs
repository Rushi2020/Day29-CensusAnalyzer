using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day29_CensusAnalyzer.POCO;
using CsvHelper;
using System.Globalization;

namespace Day29_CensusAnalyzer
{
    public class ISCodeLoad
    {
        List<IndianStateCensusData> indianStateCensusDatas;

        public int LoadData(string filepath, string[] header= null )
        {
            if (File.Exists(filepath))
            {
                string[] censusData = File.ReadAllLines(filepath);
                if (CheckForDelimiter(censusData) == false)
                {
                    throw new ISAException(ISAException.ExceptionType.WRONG_DELIMITER, "File has incorrect delimiter");
                }
                else if (header != null && censusData[0] != header[0])
                {
                    throw new ISAException(ISAException.ExceptionType.WRONG_HEADER, "File has incorrect header");
                }
                else
                {
                    using (StreamReader sr = File.OpenText(filepath))
                    using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                    {
                        indianStateCensusDatas = csvReader.GetRecords<IndianStateCensusData>().ToList();
                    }
                }
            }
        }
        public bool CheckForDelimiter(string[] datas)
        {
            bool delimiterCheck = false;
            foreach (string data in datas.Skip(1))
            {
                if (data.Contains(","))
                {
                    delimiterCheck = true;
                }
                else
                {
                    delimiterCheck = false;
                    break;
                }
            }
            return delimiterCheck;
        }
    }
}
