namespace BGHub.FE.Models
{
    public class BGGResponse
    {
        public Boardgames Boardgames { get; set; }
    }
    public class Boardgames
    {
        public Boardgame Boardgame { get; set; }
    }
    public class Boardgame
    {
        public string Image { get; set; }
    }
}
