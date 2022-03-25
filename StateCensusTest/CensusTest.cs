using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Day29_CensusAnalyzer.StateCensusTest
{
    public class CensusTest
    {
        ISCodeLoad iSCodeLoad;

        string stateCensusFilePath=@"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCensusData.csv";
        string wrongFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCensusData.csv";
        string wrongTypeFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\WrongIndiaStateCensusData.csv";



        [SetUp]
        public void Setup()
        {
            iSCodeLoad = new ISCodeLoad();
        }

        [Test]
        public void GivenStateCensusDataRightFilePath()
        {
            int expectedRecords = 29;
            int result = iSCodeLoad.LoadData(stateCensusFilePath);
            Assert.AreEqual(expectedRecords, result);
        }

    }
}
