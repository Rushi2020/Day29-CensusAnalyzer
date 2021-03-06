using Day29_CensusAnalyzer.CustomException;
using Day29_CensusAnalyzer.DTO;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Day29_CensusAnalyzer.StateCensusTest
{
    public class CensusTest
    {
        

        string stateCensusFilePath=@"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCensusData.csv";
        string wrongFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCensusData.csv";
        string wrongTypeFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\WrongIndiaStateCensusData.csv";


        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";
        string stateCodeFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\WrongFileNameIndiaStateCode.csv";
        string wrongStateCodeTypeFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"C:\Users\Rushikesh\source\repos\Day29-CensusAnalyzer\StateCensusTest\Resources\WrongIndiaStateCode.csv";



        CSVAdapterFactory csvAdapter;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        //TC 1.1 Given correct path To ensure number of records matches
        [Test]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(expected, stateRecords.Count);
        }

        //TC 1.2 Given incorrect file should return custom exception - File not found
        [Test]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

    }
}
