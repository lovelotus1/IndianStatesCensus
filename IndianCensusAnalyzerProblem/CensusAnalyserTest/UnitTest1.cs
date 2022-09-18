using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusAnalyser.DTO;
using static IndianStateCensusAnalyser.CensusAnalyser;
using IndianStateCensusAnalyser;

namespace IndianStateCensusAnalyserTests
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\IndiaStateCode.csv";

        static string wrongHeaderIndianStateCensusFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\WrongIndiaStateCode.csv";
        static string wrongDelimiterIndianStateCensusFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\DelimiterIndiaStateCode.csv";

        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenFileWithWrongHeaders_ShouldReturn_IncorrectDataHeaderException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
        [Test]
        public void GivenStateCodeWithWrongHeader_ShouldReturn_CustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
        [Test]
        public void GivenCensusDataWithWrongDelimiter_ShouldReturn_WrongDelimiterException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenStateCodeWithWrongDelimiter_ShouldReturn_WrongDelimiterException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
    }
}