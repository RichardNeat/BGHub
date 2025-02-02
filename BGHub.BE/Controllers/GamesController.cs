using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
