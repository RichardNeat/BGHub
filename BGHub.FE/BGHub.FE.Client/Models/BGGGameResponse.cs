using System.Text.Json.Serialization;

namespace BGHub.FE.Client.Models
{
    public class BGGGameResponse
    {
        [JsonPropertyName("boardgames")]
        public BoardGamesResponse BoardGamesResponse { get; set; }
    }
    public class BoardGamesResponse
    {
        [JsonPropertyName("boardgame")]
        public BoardGameResponse BoardGameResponse { get; set; }
    }
    public class BoardGameResponse
    {
        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }
    }
}
