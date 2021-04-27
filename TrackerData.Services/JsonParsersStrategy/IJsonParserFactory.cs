using TrackerData.Services.Enums;

namespace TrackerData.Services.JsonParsersStrategy
{
    public interface IJsonParserFactory
    {
        IJsonParser CreateJsonParser(ParserType parserType);
    }
}