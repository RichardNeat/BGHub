using BGHub.Models;
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
        [HttpGet]
        public IActionResult GetAllEventGames()
        {
            return Ok(_eventGameService.FindAllEventGames());
        }
        [HttpPost]
        public IActionResult PostGameToEvent(EventGameDTO eventGame)
        {
            var result = _eventGameService.InsertGameToEvent(eventGame);
            return CreatedAtAction(nameof(PostGameToEvent), result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGameFromEvent(int id)
        {
            _eventGameService.RemoveGameFromEvent(id);
            return NoContent();
        }
    }
}
