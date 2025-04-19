using BGHub.BE.Controllers;
using BGHub.BE.Services;
using BGHub.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BGHub.BE.Tests.Games.Controllers
{
    public class Tests
    {
        private GamesController _gamesController;
        private Mock<IGameService> _gameService;
        private List<Game> _games;

        [SetUp]
        public void Setup()
        {
            _gameService = new Mock<IGameService>();
            _gamesController = new GamesController(_gameService.Object);
            _games = new List<Game>
            {
                new Game { Id = 1, Name = "Game 1" },
                new Game { Id = 2, Name = "Game 2" }
            };
        }
        [Test]
        public void GetAllGames_Returns_Ok_With_All_Games()
        {
            _gameService.Setup(repo => repo.FindAllGames()).Returns(_games);

            var result = _gamesController.GetAllGames();

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EquivalentTo(_games));
        }
        [Test]
        public void PostGame_Returns_CreatedAtAction_With_New_Game()
        {
            var newGame = new GameDTO { Name = "New Game", OwnerId = 1, BGGId = 123, ImageUrl = "http://example.com/image.jpg" };
            var addedGame = new Game { Id = 3, Name = "New Game", OwnerId = 1, BGGId = 123, ImageUrl = "http://example.com/image.jpg" };

            _gameService.Setup(repo => repo.AddGame(newGame)).Returns(addedGame);

            var result = _gamesController.PostGame(newGame);

            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
            var createdResult = result as CreatedAtActionResult;
            Assert.That(createdResult?.Value, Is.EqualTo(addedGame));
        }
    }
}