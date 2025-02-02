using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
