using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerData.Services.Extensions;

namespace TrackerData.Services.UnitTests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void ParseDateTimeNull_WhenPasingInValidDate_ShouldReturnValidDateObject()
        {
            // Arrange
            var dateString = "08-18-2020 10:30:00";


            // Act
            var dateObject = dateString.ParseDateTimeNull();


            // Assert
            Assert.AreEqual(DateTime.Parse(dateString), dateObject);

        }

        [TestMethod]
        public void ParseDateTimeNull_WhenPasingInNotValidDate_ShouldReturnNull()
        {
            // Arrange
            var dateString = "";


            // Act
            var dateObject = dateString.ParseDateTimeNull();


            // Assert
            Assert.AreEqual(null, dateObject);

        }

        [TestMethod]
        public void ParseDateTimeNull_WhenPasingInNullDate_ShouldReturnNull()
        {
            // Arrange
            string dateString = null;


            // Act
            var dateObject = dateString.ParseDateTimeNull();


            // Assert
            Assert.AreEqual(null, dateObject);

        }

    }
}
