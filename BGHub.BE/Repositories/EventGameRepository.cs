using BGHub.BE.Models;
using BGHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BGHub.BE.Repositories
{
    public interface IEventGameRepository
    {
        public IEnumerable<EventGame> FindAllEventGames();
        public EventGame InsertGameToEvent(EventGameDTO eventGame);
        public void RemoveGameFromEvent(int id);
    }
    public class EventGameRepository : IEventGameRepository
    {
        private readonly BGHubDbContext _db;
        public EventGameRepository(BGHubDbContext dbContext)
        {
            _db = dbContext;
        }
        public EventGame InsertGameToEvent(EventGameDTO eventGame)
        {
            var newEventGame = new EventGame
            {
                EventId = eventGame.EventId,
                GameId = eventGame.GameId,
            };

            _db.EventGames.Add(newEventGame);
            _db.SaveChanges();

            var eventGameWithDetails = _db.EventGames
               .Include(eg => eg.Game)
               .ThenInclude(eg => eg.Owner)
               .Select(eg => new EventGame
               {
                   Id = eg.Id,
                   EventId = eg.EventId,
                   GameId = eg.Game.Id,
                   Game = new Game
                   {
                       Id = eg.Game.Id,
                       Name = eg.Game.Name,
                       OwnerId = eg.Game.OwnerId,
                       Owner = new User
                       {
                           Id = eg.Game.OwnerId,
                           Name = eg.Game.Owner.Name,
                           BGGUsername = eg.Game.Owner.BGGUsername
                       },
                       BGGId = eg.Game.BGGId,
                       ImageUrl = eg.Game.ImageUrl
                   }
               })
               .FirstOrDefault(eg => eg.Id == newEventGame.Id);

            return eventGameWithDetails;
        }
        public void RemoveGameFromEvent(int id)
        {
            var gameToRemove = _db.EventGames.FirstOrDefault(eg => eg.Id == id);
            _db.EventGames.Remove(gameToRemove);
            _db.SaveChanges();
        }
        public IEnumerable<EventGame>FindAllEventGames()
        {
            return _db.EventGames;
        }
    }
}
