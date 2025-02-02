using Microsoft.AspNetCore.Mvc;

namespace BGHub.BE.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
