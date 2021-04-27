using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;
using TrackerData.Services.JsonParsersStrategy;
using TrackerData.Services.Services;

namespace TrackerData.Services.UnitTests
{
    [TestClass]
    public class TrackerDataServiceTests
    {
        [TestMethod]
        public void CreateJsonParser_WhenAskingForPartner1_ShouldCreateParser()
        {
            // Arrange
            var service = new TrackerDataService(new JsonParserFactory());
            var expectedJson = "[{\"CompanyId\":1,\"CompanyName\":\"Foo1\",\"TrackerId\":1,\"TrackerName\":\"ABC-100\",\"StartDate\":\"2020-08-17T10:30:00\",\"FirstCrumbDtm\":\"2020-08-17T10:35:00\",\"LastCrumbDtm\":\"2020-08-17T10:45:00\",\"TempCount\":3,\"AvgTemp\":23.149999999999995,\"HumidityCount\":3,\"AvgHumidity\":81.5},{\"CompanyId\":1,\"CompanyName\":\"Foo1\",\"TrackerId\":2,\"TrackerName\":\"ABC-200\",\"StartDate\":\"2020-08-18T10:30:00\",\"FirstCrumbDtm\":\"2020-08-18T10:35:00\",\"LastCrumbDtm\":\"2020-08-18T10:45:00\",\"TempCount\":3,\"AvgTemp\":24.149999999999995,\"HumidityCount\":3,\"AvgHumidity\":82.5},{\"CompanyId\":2,\"CompanyName\":\"Foo2\",\"TrackerId\":1,\"TrackerName\":\"XYZ-100\",\"StartDate\":\"2020-08-18T10:30:00\",\"FirstCrumbDtm\":\"2020-08-18T10:35:00\",\"LastCrumbDtm\":\"2020-08-18T10:45:00\",\"TempCount\":3,\"AvgTemp\":33.15,\"HumidityCount\":3,\"AvgHumidity\":91.5},{\"CompanyId\":2,\"CompanyName\":\"Foo2\",\"TrackerId\":2,\"TrackerName\":\"XYZ-200\",\"StartDate\":\"2020-08-19T10:30:00\",\"FirstCrumbDtm\":\"2020-08-19T10:35:00\",\"LastCrumbDtm\":\"2020-08-19T10:45:00\",\"TempCount\":3,\"AvgTemp\":43.15,\"HumidityCount\":3,\"AvgHumidity\":92.5}]";


            // Act
            var trackerlist = service.GetTrackerData();
            var jsonString = JsonSerializer.Serialize(trackerlist);


            // Assert
            Assert.AreEqual(expectedJson, jsonString);

            Assert.AreEqual(4, trackerlist.Count);

            Assert.AreEqual("Foo1", trackerlist[0].CompanyName);
            Assert.AreEqual("Foo1", trackerlist[1].CompanyName);
            Assert.AreEqual("Foo2", trackerlist[2].CompanyName);
            Assert.AreEqual("Foo2", trackerlist[3].CompanyName);

            Assert.AreEqual("ABC-100", trackerlist[0].TrackerName);
            Assert.AreEqual("ABC-200", trackerlist[1].TrackerName);
            Assert.AreEqual("XYZ-100", trackerlist[2].TrackerName);
            Assert.AreEqual("XYZ-200", trackerlist[3].TrackerName);

            // ...
        }

    }
}
