using BGHub.BE.Models;
using BGHub.Models;
using System;

namespace BGHub.BE.Repositories
{
    public interface IGameRepository
    {
        public IEnumerable<Game> FindAllGames();
        public Game AddGame(GameDTO game);
    }
    public class GameRepository : IGameRepository
    {
        private readonly BGHubDbContext _db;
        public GameRepository(BGHubDbContext dbContext)
        {
            _db = dbContext;
        }
        public IEnumerable<Game> FindAllGames()
        {
            return _db.Games;
        }
        public Game AddGame(GameDTO game)
        {
            var newGame = new Game
            {
                Name = game.Name,
                OwnerId = game.OwnerId,
                BGGId = game.BGGId,
                ImageUrl = game.ImageUrl
            };
            _db.Games.Add(newGame);
            _db.SaveChanges();
            return newGame;
        }
    }
}
