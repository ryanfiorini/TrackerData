using System;
using System.Collections.Generic;
using System.Linq;
using TrackerData.Services.Extensions;
using TrackerData.Services.Models;
using TrackerData.Services.Validators;

namespace TrackerData.Services.JsonParsersStrategy
{
    public class Partner1JasonParser : JasonParserBase, IJsonParser
    {
        public string PartnerName => "Partner1";
        private const string Temperature = "Temperature";
        private const string Humidty = "Humidty";

        public List<TrackerDataModel> ParseJsonFile(string fileName)
        {
            var trackerData = GetPartnerfromFile<Partner1>(fileName);

            if (!Partner1Validator.HasValidPartnerName(trackerData) || 
                !Partner1Validator.HasValidTrackers(trackerData))
            {
                throw new Exception("Bad Json File Passed In");
            }

            var output = new List<TrackerDataModel>();
            foreach (var item in trackerData.Trackers)
            {
                var crumbsDates = GetAllDatesFromCrumbs(item);
                var firstCrumbDtm = crumbsDates.Min();
                var lastCrumbDtm = crumbsDates.Max();

                var tempCount = GetCountByName(item, Temperature);
                var avgTemp = GetAverageByName(item, Temperature);

                var humidityCount = GetCountByName(item, Humidty);
                var avgHumidity = GetAverageByName(item, Humidty);

                var model = new TrackerDataModel()
                {
                    CompanyId = trackerData.PartnerId,
                    CompanyName = trackerData.PartnerName,
                    TrackerId = (item.Id > 0) ? item.Id : null,
                    TrackerName = item.Model,
                    StartDate = item.ShipmentStartDtm.ParseDateTimeNull(),
                    FirstCrumbDtm = firstCrumbDtm,
                    LastCrumbDtm = lastCrumbDtm,
                    TempCount = tempCount,
                    AvgTemp = avgTemp,
                    HumidityCount = humidityCount,
                    AvgHumidity = avgHumidity
                };
                output.Add(model);
            }

            return output;
        }

        #region [ Helpers ]
        private static List<DateTime?> GetAllDatesFromCrumbs(Tracker item)
        {
            var crumbsDates = new List<DateTime?>();
            foreach (var sensor in item.Sensors)
            {
                foreach (var crumb in sensor.Crumbs)
                {
                    AddValidDateFromCrumbToList(crumbsDates, crumb);
                }
            }

            return crumbsDates;
        }

        private static void AddValidDateFromCrumbToList(List<DateTime?> crumbsDates, Crumb crumb)
        {
            var parsedDateTime = crumb.CreatedDtm.ParseDateTimeNull();
            if (parsedDateTime != null)
            {
                crumbsDates.Add(parsedDateTime);
            }
        }

        private int GetCountByName(Tracker item, string name)
        {
            return item.Sensors?
                .Where(x => x.Name == name)
                ?.FirstOrDefault()
                ?.Crumbs
                ?.Count ?? 0;
        }

        private double GetAverageByName(Tracker item, string name)
        {
            return item.Sensors?
                .Where(x => x.Name == name)
                ?.FirstOrDefault()
                ?.Crumbs
                ?.Select(x => x.Value)
                ?.DefaultIfEmpty(0)
                ?.Average() ?? 0;
        }
        #endregion
    }
}
