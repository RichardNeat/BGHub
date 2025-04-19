using BGHub.BE.Controllers;
using BGHub.BE.Repositories;
using BGHub.BE.Services;
using BGHub.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BGHub.BE.Tests.Events.Controllers
{
    public class Tests
    {
        private EventsController _eventController;
        private Mock<IEventService> _eventService;
        private List<Event> _testEvents;

        [SetUp]
        public void Setup()
        {
            _eventService = new Mock<IEventService>();
            _eventController = new EventsController(_eventService.Object);

            _testEvents = new List<Event>
            {
                new Event { Id = 1, Name = "February 2024", StartDate = new DateTime(2024, 2, 6), EndDate = new DateTime(2024, 2, 10), LocationLink = "The Manor" },
                new Event { Id = 2, Name = "October 2024", StartDate = new DateTime(2024, 10, 27), EndDate = new DateTime(2024, 10, 31), LocationLink = "The Manor" },
                new Event { Id = 3, Name = "February 2025", StartDate = new DateTime(2025, 2, 6), EndDate = new DateTime(2025, 2, 10), LocationLink = "The Manor" }
            };
        }

        [Test]
        public void GetAllEvents_Returns_200_With_All_Events()
        {
            _eventService.Setup(x => x.FindAllEvents()).Returns(_testEvents);
            
            var result = _eventController.GetAllEvents();
            
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(_testEvents));
        }
        [Test]
        public void GetEventById_Returns_200_With_Event()
        {
            var testEvent = _testEvents[0];
            _eventService.Setup(x => x.FindEventById(testEvent.Id)).Returns(testEvent);

            var result = _eventController.GetEventById(testEvent.Id);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(testEvent));
        }
        [Test]
        public void GetEventById_Returns_404_When_Event_Not_Found()
        {
            var testEvent = _testEvents[0];

            _eventService.Setup(x => x.FindEventById(testEvent.Id)).Returns((Event?)null);

            var result = _eventController.GetEventById(testEvent.Id);

            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
            var notFoundResult = result as NotFoundObjectResult;
            Assert.That(notFoundResult?.Value, Is.EqualTo("Event not found"));
        }
    }
}