using BGHub.BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.FindAllUsers());
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.FindUserById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else 
            {
                return NotFound("User not found");
            }
        }
    }
}
