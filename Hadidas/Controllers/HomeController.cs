using Microsoft.AspNetCore.Mvc;

namespace Hadidas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
