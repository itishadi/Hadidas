using Hadidas.Models;
using Hadidas.Services.UserCRUD.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hadidas.Controllers
{
    public class HadidasController : Controller
    {
        private readonly IAddUserService _addUserService;
        private readonly IReadUserService _readUserService;

        public HadidasController(IAddUserService addUserService, IReadUserService readUserService)
        {
            _addUserService = addUserService;
            _readUserService = readUserService;
        }

        // HTTP GET method for displaying a form
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View(); // Returns AddUser.cshtml view for adding a new user
        }
        public IActionResult ReadUser()
        {
            return View(); // Returns AddUser.cshtml view for adding a new user
        }

        // HTTP POST method for adding a user
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _addUserService.AddUser(user); // Calls the AddUser method from UserAddService
                return RedirectToAction("Index"); // Redirects back to the index page
            }

            return View("Index");
        }


        [HttpGet]
        public IActionResult ReadUsers()
        {
            var users = _readUserService.ReadAllUsers(); // Hämtar alla användare

            if (users == null || !users.Any()) // Kontrollera om det finns några användare
            {
                return View("Error"); // Om inga användare finns, visa ett fel
            }

            return View("ReadUsers", users); // Returnerar vyn med användardata
        }



    }
}