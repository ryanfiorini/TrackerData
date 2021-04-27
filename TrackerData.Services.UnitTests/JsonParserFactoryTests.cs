using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackerData.Services.Enums;
using TrackerData.Services.JsonParsersStrategy;

namespace TrackerData.Services.UnitTests
{
    [TestClass]
    public class JsonParserFactoryTests
    {
        [TestMethod]
        public void CreateJsonParser_WhenAskingForPartner1_ShouldCreateParser()
        {
            // Arrange
            var factory = new JsonParserFactory();


            // Act
            var parser = factory.CreateJsonParser(ParserType.Partner1);


            // Assert
            Assert.AreEqual("Partner1", parser.PartnerName);
        }

        [TestMethod]
        public void CreateJsonParser_WhenAskingForPartner2_ShouldCreateParser()
        {
            // Arrange
            var factory = new JsonParserFactory();


            // Act
            var parser = factory.CreateJsonParser(ParserType.Partner2);


            // Assert
            Assert.AreEqual("Partner2", parser.PartnerName);
        }
    }
}
