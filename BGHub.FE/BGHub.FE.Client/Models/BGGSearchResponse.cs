using System.Text.Json.Serialization;

namespace BGHub.FE.Client.Models
{
    public class BGGSearchResponse
    {
        [JsonPropertyName("boardgames")]
        public Boardgames Boardgames { get; set; }
    }
    public class Boardgames
    {
        [JsonPropertyName("boardgame")]
        public List<Boardgame> Boardgame { get; set; }
    }
    public class Boardgame
    {
        [JsonPropertyName("name")]
        public Name? Name { get; set; }
        [JsonPropertyName("@objectid")]
        public string BGGId { get; set; }
    }
    public class Name
    {
        [JsonPropertyName("#text")]
        public string GameName { get; set; } = "";
    }
}
