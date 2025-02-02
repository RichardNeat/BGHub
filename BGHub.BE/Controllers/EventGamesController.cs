using BGHub.BE.Models;
using BGHub.BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EventGamesController : ControllerBase
    {
        private readonly IEventGameService _eventGameService;
        public EventGamesController(IEventGameService eventService)
        {
            _eventGameService = eventService;
        }
        [HttpPost]
        public IActionResult PostGameToEvent(EventGameDTO eventGame)
        {
            var result = _eventGameService.InsertGameToEvent(eventGame);
            return CreatedAtAction(nameof(PostGameToEvent), result);
        }
    }
}
