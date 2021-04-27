using System;
using System.Collections.Generic;
using TrackerData.Services.Enums;

namespace TrackerData.Services.JsonParsersStrategy
{
    public class JsonParserFactory : IJsonParserFactory
    {
        private readonly IReadOnlyDictionary<ParserType, IJsonParser> _parsers
            = new Dictionary<ParserType, IJsonParser>
            {
                { ParserType.Partner1, new Partner1JasonParser() },
                { ParserType.Partner2, new Partner2JasonParser() }
            };

        public IJsonParser CreateJsonParser(ParserType parserType)
        {
            IJsonParser parser = _parsers.GetValueOrDefault(parserType);

            if (parser == null)
            {
                throw new Exception("Parser Not Found!");
            }

            return parser;
        }
    }
}
