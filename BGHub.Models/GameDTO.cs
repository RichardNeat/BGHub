namespace BGHub.Models
{
    public class GameDTO
    {
        public string Name { get; set; } = "";
        public int OwnerId { get; set; }
        public int BGGId { get; set; }
        public string ImageUrl { get; set; } = "";
    }
}
