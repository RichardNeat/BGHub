using BGHub.BE.Repositories;
using BGHub.Models;

namespace BGHub.BE.Services
{
    public interface IGameService
    {
        public IEnumerable<Game> FindAllGames();
        public Game AddGame(GameDTO game);
    }
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IEnumerable<Game> FindAllGames()
        {
            return _gameRepository.FindAllGames();
        }
        public Game AddGame(GameDTO game)
        {
            return _gameRepository.AddGame(game);
        }
    }
}
