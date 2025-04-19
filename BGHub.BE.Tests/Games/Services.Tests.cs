using BGHub.BE.Repositories;
using BGHub.BE.Services;
using BGHub.Models;
using Moq;

namespace BGHub.BE.Tests.Games.Services
{
    public class Tests
    {
        private GameService _gameService;
        private Mock<IGameRepository> _gameRepository;
        private List<Game> _games;

        [SetUp]
        public void Setup()
        {
            _gameRepository = new Mock<IGameRepository>();
            _gameService = new GameService(_gameRepository.Object);
            _games = new List<Game>
            {
                new Game { Id = 1, Name = "Game 1" },
                new Game { Id = 2, Name = "Game 2" }
            };
        }

        [Test]
        public void FindAllGames_ReturnsAllGames()
        {
            _gameRepository.Setup(repo => repo.FindAllGames()).Returns(_games);

            var result = _gameService.FindAllGames();
            
            Assert.That(result, Is.EquivalentTo(_games));
        }
        [Test]
        public void AddGame_Returns_New_Game()
        {
            var newGame = new GameDTO { Name = "New Game", OwnerId = 1, BGGId = 123, ImageUrl = "http://example.com/image.jpg" };
            var addedGame = new Game { Id = 3, Name = "New Game", OwnerId = 1, BGGId = 123, ImageUrl = "http://example.com/image.jpg" };

            _gameRepository.Setup(repo => repo.AddGame(newGame)).Returns(addedGame);

            var result = _gameService.AddGame(newGame);

            Assert.That(result, Is.EqualTo(addedGame));
        }
    }
}