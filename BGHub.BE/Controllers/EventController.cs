using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
