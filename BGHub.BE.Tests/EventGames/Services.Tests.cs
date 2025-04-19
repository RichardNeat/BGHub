using BGHub.BE.Repositories;
using BGHub.BE.Services;
using BGHub.Models;
using Moq;

namespace BGHub.BE.Tests.EventGames.Services
{
    public class Tests
    {
        private EventGameService _eventGamesService;
        private Mock<IEventGameRepository> _eventGamesRepository;
        private List<EventGame> _testGames;

        [SetUp]
        public void Setup()
        {
            _eventGamesRepository = new Mock<IEventGameRepository>();
            _eventGamesService = new EventGameService(_eventGamesRepository.Object);
            _testGames = new List<EventGame>
            {
                new EventGame { Id = 1, EventId = 1, GameId = 1 },
                new EventGame { Id = 2, EventId = 1, GameId = 2 },
                new EventGame { Id = 3, EventId = 2, GameId = 2 }
            };
        }

        [Test]
        public void FindAllEventGames_ShouldReturnAllEventGames()
        {
            _eventGamesRepository.Setup(repo => repo.FindAllEventGames()).Returns(_testGames);
            
            var result = _eventGamesService.FindAllEventGames();

            Assert.That(result, Is.EqualTo(_testGames));
        }
        [Test]
        public void InsertGameToEvent_Should_Return_Added_Game()
        {
            var newEventGame = new EventGameDTO { EventId = 1, GameId = 3 };
            var expectedEventGame = new EventGame { Id = 4, EventId = 1, GameId = 3 };

            _eventGamesRepository.Setup(repo => repo.InsertGameToEvent(newEventGame)).Returns(expectedEventGame);

            var result = _eventGamesService.InsertGameToEvent(newEventGame);

            Assert.That(result, Is.EqualTo(expectedEventGame));
        }
        [Test]
        public void RemoveGameFromEvent_Should_Invoke_Repo_Correctly()
        {
            var gameIdToRemove = 1;
            var gameToRemove = _testGames.First(g => g.Id == gameIdToRemove);
            
            _eventGamesService.RemoveGameFromEvent(gameIdToRemove);

            _eventGamesRepository.Verify(repo => repo.RemoveGameFromEvent(gameIdToRemove), Times.Once);
        }
    }
}