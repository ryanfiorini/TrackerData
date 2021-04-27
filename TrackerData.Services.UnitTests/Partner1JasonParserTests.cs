using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrackerData.Services.JsonParsersStrategy;

namespace TrackerData.Services.UnitTests
{
    [TestClass]
    public class Partner1JasonParserTests
    {
        [TestMethod]
        public void ParseJsonFile_WhenPartner1IsPassed_ShouldParseFile()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileSuccessPartner1.json";
            var parser = new Partner1JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
            Assert.AreEqual("Partner1", parser.PartnerName);
            Assert.AreEqual(2, trackerlist.Count);

            Assert.AreEqual(81.5, trackerlist[0].AvgHumidity);
            Assert.AreEqual(23.149999999999995, trackerlist[0].AvgTemp);
            Assert.AreEqual(3, trackerlist[0].HumidityCount);
            Assert.AreEqual(3, trackerlist[0].TempCount);

            Assert.AreEqual(82.5, trackerlist[1].AvgHumidity);
            Assert.AreEqual(24.149999999999995, trackerlist[1].AvgTemp);
            Assert.AreEqual(3, trackerlist[1].HumidityCount);
            Assert.AreEqual(3, trackerlist[1].TempCount);
        }

        [TestMethod]
        public void ParseJsonFile_WhenPartner1IsPassed_ShouldParseFileWithZeros()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileFailNullSensorsPartner1.json";
            var parser = new Partner1JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
            Assert.AreEqual("Partner1", parser.PartnerName);
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
        public void ParseJsonFile_WhenPartner2JsonIsPassedToParser1_ShouldThrowException()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileSuccessPartner2.json";
            var parser = new Partner1JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad Json File Passed In")]
        public void ParseJsonFile_WhenJsonMissingPartnerNamePassedIn_ShouldThrowException()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileFailMissingPartnerNamePartner1.json";
            var parser = new Partner1JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad Json File Passed In")]
        public void ParseJsonFile_WhenJsonMissingTrackersPassedIn_ShouldThrowException()
        {
            // Arrange
            const string fileName = "TestFiles//TestFileFailMissingTrackersPartner1.json";
            var parser = new Partner1JasonParser();


            // Act
            var trackerlist = parser.ParseJsonFile(fileName);


            // Assert
        }
    }
}
