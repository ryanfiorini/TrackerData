using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using TrackerData.Services.JsonParsersStrategy;
using TrackerData.Services.Services;

namespace TrackerDataApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tracker Data Start");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<ITrackerDataService, TrackerDataService>()
                .AddSingleton<IJsonParserFactory, JsonParserFactory>()
                .BuildServiceProvider();

            var trackerDataService = serviceProvider.GetService<ITrackerDataService>();
            var trackerlist = trackerDataService.GetTrackerData();

            Console.WriteLine($"Total Trackers: {trackerlist.Count}");
            var jsonString = JsonSerializer.Serialize(trackerlist);
            Console.WriteLine($"Tracker Data: {jsonString}");
        }
    }
}
