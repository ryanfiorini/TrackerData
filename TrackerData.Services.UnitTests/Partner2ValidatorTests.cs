using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TrackerData.Services.Models;
using TrackerData.Services.Validators;

namespace TrackerData.Services.UnitTests
{
    [TestClass]
    public class Partner2ValidatorTests
    {
        [TestMethod]
        public void Partner2Validator_WhenPasingValidCompany_ShouldReturnTrue()
        {
            // Arrange
            var partnerData = new Partner2()
            {
                Company = "Ryan's Company"
            };


            // Act
            var isValid = Partner2Validator.HasValidCompany(partnerData);


            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Partner2Validator_WhenPasingValidDevices_ShouldReturnTrue()
        {
            // Arrange
            var partnerData = new Partner2()
            {
                Devices = new List<Device>()
            };


            // Act
            var isValid = Partner2Validator.HasValidDevices(partnerData);


            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Partner2Validator_WhenPasingInvalidCompany_ShouldReturnFalse()
        {
            // Arrange
            var partnerData = new Partner2()
            {
                Company = ""
            };


            // Act
            var isValid = Partner2Validator.HasValidCompany(partnerData);


            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Partner2Validator_WhenPasingInvalidDevices_ShouldReturnFalse()
        {
            // Arrange
            var partnerData = new Partner2();


            // Act
            var isValid = Partner2Validator.HasValidDevices(partnerData);


            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
