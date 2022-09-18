using System;
using System.Collections.Generic;
using IndianStateCensusAnalyser.DTO;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Indian State Census Analyser");
            string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
            string indianStateCensusFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\IndiaStateCensusData.csv";
            string indianStateCodeFilePath = @"C:\Users\Admin\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyserTests\CSVFiles\IndiaStateCode.csv";

            CensusAnalyser censusAnalyser;
            Dictionary<string, CensusDTO> totalRecord;
            Dictionary<string, CensusDTO> stateRecord;
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Console.WriteLine(totalRecord.Count);
            Console.WriteLine(stateRecord.Count);
        }
    }
}
