namespace BGHub.Models
{
    public class EventGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
