using BGHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BGHub.BE.Repositories
{
    public interface IEventRepository
    {
        public IEnumerable<Event> FindAllEvents();
        public Event? FindEventById(int id);
    }
    public class EventRepository : IEventRepository
    {
        private readonly BGHubDbContext _dbContext;
        public EventRepository(BGHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Event> FindAllEvents()
        {
            return _dbContext.Events;
        }
        public Event? FindEventById(int id)
        {
            var targetEvent = _dbContext.Events
                .Include(e => e.Inventory)
                .ThenInclude(eg => eg.Game)
                .ThenInclude(eg => eg.Owner)
                .Select(e => new Event
                {
                    Id = e.Id,
                    Name = e.Name,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    LocationLink = e.LocationLink,
                    Inventory = e.Inventory.Select(eg => new EventGame
                    {
                        Id = eg.Id,
                        Game = new Game
                        {
                            Id = eg.Game.Id,
                            Name = eg.Game.Name,
                            OwnerId = eg.Game.OwnerId,
                            BGGId = eg.Game.BGGId,
                            ImageUrl = eg.Game.ImageUrl,
                            Owner = new User
                            {
                                Id = eg.Game.Owner.Id,
                                Name = eg.Game.Owner.Name,
                                BGGUsername = eg.Game.Owner.BGGUsername
                            }
                        }
                    })
                    .ToList()
                })
                .FirstOrDefault(e => e.Id == id);
            return targetEvent;
        }
    }
}
