using BGHub.BE.Services;
using BGHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public IActionResult GetAllGames()
        {
            var result = _gameService.FindAllGames();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult PostGame(GameDTO game)
        {
            var result = _gameService.AddGame(game);
            return CreatedAtAction(nameof(PostGame), result);
        }
    }
}
