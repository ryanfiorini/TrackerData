using System.IO;
using System.Text.Json;

namespace TrackerData.Services.JsonParsersStrategy
{
    public class JasonParserBase
    {

        internal static T GetPartnerfromFile<T>(string fileName)
        {
            var json = GetJsonFromFile(fileName);

            var trackerData = JsonSerializer.Deserialize<T>(json);
            return trackerData;
        }

        internal static string GetJsonFromFile(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }
    }
}