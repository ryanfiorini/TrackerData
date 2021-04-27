using System.Collections.Generic;
using TrackerData.Services.Models;

namespace TrackerData.Services.JsonParsersStrategy
{
    public interface IJsonParser
    {
        List<TrackerDataModel> ParseJsonFile(string fileName);
        public string PartnerName{ get; }
    }
}
