namespace BGHub.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Game> Games { get; set; } = new List<Game>();
        public string BGGUsername { get; set; } = "";
    }
}
