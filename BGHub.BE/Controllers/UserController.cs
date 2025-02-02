using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
