using BGHub.BE.Repositories;
using BGHub.BE.Services;
using BGHub.Models;
using Moq;

namespace BGHub.BE.Tests.Events.Services
{
    public class Tests
    {
        private EventService _eventService;
        private Mock<IEventRepository> _eventRepository;
        private List<Event> _testEvents;

        [SetUp]
        public void Setup()
        {
            _eventRepository = new Mock<IEventRepository>();
            _eventService = new EventService(_eventRepository.Object);

            _testEvents = new List<Event>
            {
                new Event { Id = 1, Name = "February 2024", StartDate = new DateTime(2024, 2, 6), EndDate = new DateTime(2024, 2, 10), LocationLink = "The Manor" },
                new Event { Id = 2, Name = "October 2024", StartDate = new DateTime(2024, 10, 27), EndDate = new DateTime(2024, 10, 31), LocationLink = "The Manor" },
                new Event { Id = 3, Name = "February 2025", StartDate = new DateTime(2025, 2, 6), EndDate = new DateTime(2025, 2, 10), LocationLink = "The Manor" }
            };
        }
        [Test]
        public void FindAllEvents_Should_Return_All_Events()
        {
            _eventRepository.Setup(repo => repo.FindAllEvents())
                .Returns(_testEvents);

            var result = _eventService.FindAllEvents();

            Assert.That(result, Is.EqualTo(_testEvents));
        }
        [Test]
        public void FindEventById_Should_Return_Correct_Event()
        {
            var targetEvent = _testEvents[1];

            _eventRepository.Setup(repo => repo.FindEventById(targetEvent.Id))
                .Returns(targetEvent);

            var result = _eventService.FindEventById(targetEvent.Id);

            Assert.That(result, Is.EqualTo(targetEvent));
        }
        [Test]
        public void FindEventById_Returns_Null_For_Non_Existent_Event_Id()
        {
            int nonExistentEventId = 9999;

            _eventRepository.Setup(repo => repo.FindEventById(nonExistentEventId))
                .Returns((Event?)null);

            var result = _eventService.FindEventById(nonExistentEventId);

            Assert.That(result, Is.Null);
        }
    }
}