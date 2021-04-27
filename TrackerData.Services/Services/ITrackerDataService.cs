using System.Collections.Generic;
using TrackerData.Services.Models;

namespace TrackerData.Services.Services
{
    public interface ITrackerDataService
    {
        List<TrackerDataModel> GetTrackerData();
    }
}