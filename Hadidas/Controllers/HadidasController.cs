using Microsoft.AspNetCore.Mvc;

namespace Hadidas.Controllers
{
    public class HadidasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
