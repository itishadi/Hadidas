using Hadidas.Models;
using Hadidas.Services.UserCRUD.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hadidas.Controllers
{
    public class HadidasController : Controller
    {
        private readonly IUserAddService _userAddService;

        public HadidasController(IUserAddService userAddService)
        {
            _userAddService = userAddService;
        }

        // HTTP GET method for displaying a form
        public IActionResult Index()
        {
            return View();
        }

        // HTTP POST method for adding a user
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _userAddService.AddUser(user); // Calls the AddUser method from UserAddService
                return RedirectToAction("Index"); // Redirects back to the index page
            }

            return View("Index");
        }
    }
}