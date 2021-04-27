using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TrackerData.Services.Models;
using TrackerData.Services.Validators;

namespace TrackerData.Services.UnitTests
{
    [TestClass]
    public class Partner1ValidatorTests
    {
        [TestMethod]
        public void Partner1Validator_WhenPasingValidPartnerName_ShouldReturnTrue()
        {
            // Arrange
            var partnerData = new Partner1()
            {
                PartnerName = "Ryan's Partner"
            };


            // Act
            var isValid = Partner1Validator.HasValidPartnerName(partnerData);


            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Partner1Validator_WhenPasingValidTrackers_ShouldReturnTrue()
        {
            // Arrange
            var partnerData = new Partner1()
            {
                Trackers = new List<Tracker>()
            };


            // Act
            var isValid = Partner1Validator.HasValidTrackers(partnerData);


            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Partner1Validator_WhenPasingInvalidPartnerName_ShouldReturnFalse()
        {
            // Arrange
            var partnerData = new Partner1()
            {
                PartnerName = ""
            };


            // Act
            var isValid = Partner1Validator.HasValidPartnerName(partnerData);


            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Partner1Validator_WhenPasingInvalidTrackers_ShouldReturnFalse()
        {
            // Arrange
            var partnerData = new Partner1();


            // Act
            var isValid = Partner1Validator.HasValidTrackers(partnerData);


            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
