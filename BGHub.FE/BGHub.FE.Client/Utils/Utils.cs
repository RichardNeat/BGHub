using BGHub.FE.Client.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace BGHub.FE.Client.Utils
{
    public class Utils
    {
        public static string ConvertXmlToJson(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            string json = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);

            return json;
        }
        public static string ConvertJsonToUniformData(string jsonString)
        {
            string pattern1 = @"""name"":\s""([^""""]+"")";
            string replacement1 = @"""name"": { ""#text"": ""$1 }";

            string formattedJson1 = Regex.Replace(jsonString, pattern1, replacement1);

            string pattern2 = @"""boardgame"":\s{\s*""@objectid"":\s""(\d+)"",\s*""name"":\s*\{\s*""@primary"":\s*""true"",\s*""#text"":\s*""([^""]+)""\s*\},\s*""yearpublished"":\s""(\d+)""\s*}";
            string replacement2 = @"""boardgame"": [{""@objectid"": ""$1"", ""name"": {""@primary"": ""true"", ""#text"": ""$2"" }, ""yearpublished"": ""$3"" }]";

            string formattedJson2 = Regex.Replace(formattedJson1, pattern2, replacement2);

            return formattedJson2;
        }
    }
}
