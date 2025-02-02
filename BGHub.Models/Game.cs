namespace BGHub.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int BGGId { get; set; }
        public string ImageUrl { get; set; }
        public List<EventGame> Events { get; set; }
    }
}
