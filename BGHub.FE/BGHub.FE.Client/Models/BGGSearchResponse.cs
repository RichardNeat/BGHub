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
        [JsonPropertyName("@objectid")]
        public string BGGId { get; set; }
        [JsonPropertyName("name")]
        public Name? Name { get; set; }
        [JsonPropertyName("yearpublished")]
        public string YearPublished { get; set; }
    }
    public class Name
    {
        [JsonPropertyName("#text")]
        public string GameName { get; set; } = "";
    }
}
