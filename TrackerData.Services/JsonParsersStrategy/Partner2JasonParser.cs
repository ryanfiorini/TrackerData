using System;
using System.Collections.Generic;
using System.Linq;
using TrackerData.Services.Models;
using TrackerData.Services.Extensions;
using TrackerData.Services.Validators;

namespace TrackerData.Services.JsonParsersStrategy
{
    public class Partner2JasonParser : JasonParserBase, IJsonParser
    {
        public string PartnerName => "Partner2";
        private const string Tempature = "TEMP";
        private const string Humidty = "HUM";

        public List<TrackerDataModel> ParseJsonFile(string fileName)
        {
            var trackerData = GetPartnerfromFile<Partner2>(fileName);

            if (!Partner2Validator.HasValidCompany(trackerData) || 
                !Partner2Validator.HasValidDevices(trackerData))
            {
                throw new Exception("Bad Json File Passed In");
            }

            var output = new List<TrackerDataModel>();
            foreach (var item in trackerData.Devices)
            {
                var sensorDataDates = GetAllDatesFromDevice(item);
                var firstCrumbDtm = sensorDataDates.Min();
                var lastCrumbDtm = sensorDataDates.Max();

                var tempCount = GetCountByName(item, Tempature);
                var avgTemp = GetAverageByName(item, Tempature);

                var humidityCount = GetCountByName(item, Humidty);
                var avgHumidity = GetAverageByName(item, Humidty);

                var model = new TrackerDataModel()
                {
                    CompanyId = trackerData.CompanyId,
                    CompanyName = trackerData.Company,
                    TrackerId = (item.DeviceID > 0) ? item.DeviceID : null,
                    TrackerName = item.Name,
                    StartDate = item.StartDateTime.ParseDateTimeNull(),
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
        private static List<DateTime?> GetAllDatesFromDevice(Device item)
        {
            var sensorDataDates = new List<DateTime?>();
            foreach (var sensor in item.SensorData)
            {
                AddValidDateFromSensorDataToList(sensorDataDates, sensor.DateTime);
            }

            return sensorDataDates;
        }

        private static void AddValidDateFromSensorDataToList(List<DateTime?> crumbsDates, string dateTime)
        {
            var parsedDateTime = dateTime.ParseDateTimeNull();
            if (parsedDateTime != null)
            {
                crumbsDates.Add(parsedDateTime);
            }
        }

        private int GetCountByName(Device item, string name)
        {
            return item.SensorData?
                .Where(x => x.SensorType == name)
                ?.ToList()
                ?.Count ?? 0;
        }

        private double GetAverageByName(Device item, string name)
        {
            return item.SensorData?
                .Where(x => x.SensorType == name)
                ?.Select(x => x.Value)
                ?.DefaultIfEmpty(0)
                ?.Average() ?? 0;
        }
        #endregion

    }
}
