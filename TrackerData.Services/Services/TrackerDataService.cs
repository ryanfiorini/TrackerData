using System;
using System.Collections.Generic;
using TrackerData.Services.Enums;
using TrackerData.Services.JsonParsersStrategy;
using TrackerData.Services.Models;

namespace TrackerData.Services.Services
{
    public class TrackerDataService : ITrackerDataService
    {
        private readonly IJsonParserFactory _jsonParserFactory;

        public TrackerDataService(IJsonParserFactory jsonParserFactory)
        {
            _jsonParserFactory = jsonParserFactory;
        }

        public List<TrackerDataModel> GetTrackerData()
        {
            var parser = _jsonParserFactory.CreateJsonParser(ParserType.Partner1);
            var trackerList1 = parser.ParseJsonFile("Data//TrackerDataFoo1.json");
            if (trackerList1 == null)
            {
                throw new Exception("Parse TrackerDataFoo1.json Failed");
            }

            parser = _jsonParserFactory.CreateJsonParser(ParserType.Partner2);
            var trackerList2 = parser.ParseJsonFile("Data//TrackerDataFoo2.json");
            if (trackerList2 == null)
            {
                throw new Exception("Parse TrackerDataFoo2.json Failed");
            }

            trackerList1.AddRange(trackerList2);

            return trackerList1;
        }
    }
}
