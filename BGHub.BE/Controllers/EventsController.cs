using BGHub.Models;
using BGHub.BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _eventService.FindAllEvents();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var targetEvent = _eventService.FindEventById(id);
            if (targetEvent == null)
            {
                return NotFound("Event not found");
            }
            else
            {
                return Ok(targetEvent);
            }
        }
    }
}
