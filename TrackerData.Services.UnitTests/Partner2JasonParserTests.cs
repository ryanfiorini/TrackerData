using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrackerData.Services.JsonParsersStrategy;

namespace TrackerData.Services.UnitTests
{
    [TestClass]
    public class Partner2JasonParserTests
    {

        [TestMethod]
        public void ParseJsonFile_WhenPartner2IsPassed_ShouldParseFile()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileSuccessPartner2.json";
            var parser = new Partner2JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
            Assert.AreEqual("Partner2", parser.PartnerName);
            Assert.AreEqual(2, trackerlist.Count);
            Assert.AreEqual(91.5, trackerlist[0].AvgHumidity);
            Assert.AreEqual(33.15, trackerlist[0].AvgTemp);
            Assert.AreEqual(3, trackerlist[0].HumidityCount);
            Assert.AreEqual(3, trackerlist[0].TempCount);

            Assert.AreEqual(92.5, trackerlist[1].AvgHumidity);
            Assert.AreEqual(43.15, trackerlist[1].AvgTemp);
            Assert.AreEqual(3, trackerlist[1].HumidityCount);
            Assert.AreEqual(3, trackerlist[1].TempCount);
        }

        [TestMethod]
        public void ParseJsonFile_WhenPartner2IsPassed_ShouldParseFileWthZeros()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileFailNullSensorDataPartner2.json";
            var parser = new Partner2JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
            Assert.AreEqual("Partner2", parser.PartnerName);
            Assert.AreEqual(2, trackerlist.Count);

            Assert.AreEqual(0, trackerlist[0].AvgHumidity);
            Assert.AreEqual(0, trackerlist[0].AvgTemp);
            Assert.AreEqual(0, trackerlist[0].HumidityCount);
            Assert.AreEqual(0, trackerlist[0].TempCount);

            Assert.AreEqual(0, trackerlist[1].AvgHumidity);
            Assert.AreEqual(0, trackerlist[1].AvgTemp);
            Assert.AreEqual(0, trackerlist[1].HumidityCount);
            Assert.AreEqual(0, trackerlist[1].TempCount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad Json File Passed In")]
        public void ParseJsonFile_WhenPartner1JsonIsPassedToParser2_ShouldThrowException()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileSuccessPartner1.json";
            var parser = new Partner2JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad Json File Passed In")]
        public void ParseJsonFile_WhenJsonMissingCompanyPassedIn_ShouldThrowException()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileFailMissingCompanyPartner2.json";
            var parser = new Partner2JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad Json File Passed In")]
        public void ParseJsonFile_WhenJsonMissingDevicesPassedIn_ShouldThrowException()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileFailMissingDevicesPartner2.json";
            var parser = new Partner2JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
        }
    }
}
