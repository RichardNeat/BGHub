using BGHub.BE.Controllers;
using BGHub.BE.Services;
using BGHub.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BGHub.BE.Tests.EventGames.Controllers
{
    public class Tests
    {
        private EventGamesController _eventGamesController;
        private Mock<IEventGameService> _eventGameService;
        private List<EventGame> _testEventGames;

        [SetUp]
        public void Setup()
        {
            _eventGameService = new Mock<IEventGameService>();
            _eventGamesController = new EventGamesController(_eventGameService.Object);
            _testEventGames = new List<EventGame>
            {
                new EventGame { Id = 1, EventId = 1, GameId = 1 },
                new EventGame { Id = 2, EventId = 1, GameId = 2 },
                new EventGame { Id = 3, EventId = 2, GameId = 2 }
            };
        }

        [Test]
        public void GetAllEventGames_Returns_200_With_All_EventGames()
        {
            _eventGameService.Setup(service => service.FindAllEventGames()).Returns(_testEventGames);
            var result = _eventGamesController.GetAllEventGames();

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(_testEventGames));
        }
        [Test]
        public void PostGameToEvent_Returns_201_With_Created_EventGame()
        {
            var newEventGame = new EventGameDTO { EventId = 1, GameId = 3 };
            var createdEventGame = new EventGame { Id = 4, EventId = 1, GameId = 3 };

            _eventGameService.Setup(service => service.InsertGameToEvent(newEventGame)).Returns(createdEventGame);

            var result = _eventGamesController.PostGameToEvent(newEventGame);

            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
            var createdResult = result as CreatedAtActionResult;
            Assert.That(createdResult?.Value, Is.EqualTo(createdEventGame));
        }
        [Test]
        public void DeleteGameFromEvent_Returns_204()
        {
            var gameIdToRemove = 1;

            _eventGamesController.DeleteGameFromEvent(gameIdToRemove);

            _eventGameService.Verify(service => service.RemoveGameFromEvent(gameIdToRemove), Times.Once);

            Assert.That(_eventGamesController.DeleteGameFromEvent(gameIdToRemove), Is.InstanceOf<NoContentResult>());
        }
    }
}