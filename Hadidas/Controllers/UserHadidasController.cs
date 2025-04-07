using Hadidas.Models;
using Hadidas.Services.UserCRUD.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hadidas.Controllers
{
    public class UserHadidasController : Controller
    {
        private readonly IAddUserService _addUserService;
        private readonly IReadUserService _readUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IDeleteUserService _deleteUserService;

        public UserHadidasController(IAddUserService addUserService, IReadUserService readUserService, IUpdateUserService updateUserService, IDeleteUserService deleteUserService)
        {
            _addUserService = addUserService;
            _readUserService = readUserService;
            _updateUserService = updateUserService;
            _deleteUserService = deleteUserService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult UpdatedUser()
        {
            return View();
        }
        public IActionResult DeleteUser()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult UpdateUser()
        {
            var users = _readUserService.ReadAllUsers();
            return View(users);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _addUserService.AddUser(user);
                return RedirectToAction("Index"); // Redirects back to the index page
            }

            return View("Index");
        }


        [HttpGet]
        public IActionResult ReadUsers()
        {
            var users = _readUserService.ReadAllUsers();

            if (users == null || !users.Any())
            {
                return View("Error");
            }

            return View(users);
        }



        // GET: Visa formuläret med användarens befintliga info
        [HttpGet]
        public IActionResult UpdatedUser(int id)
        {
            var user = _readUserService.ReadAllUsers().FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return View("Error"); // Visa felvy om användaren inte hittas
            }

            return View(user); // Skicka användaren till UpdateUser.cshtml
        }


        [HttpPost]
        public IActionResult UpdatedUser(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _updateUserService.UpdateUser(user); // Uppdatera användaren
                    return RedirectToAction("UpdateUser");    // Tillbaka till listan
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Fel vid uppdatering: {ex.Message}");
                }
            }

            return View(user); // Visa formuläret igen med ev. fel
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var user = _readUserService.ReadAllUsers().FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return View("Error");
            }

            return View(user); // 👈 visar DeleteUser.cshtml med användarens data
        }

        [HttpPost]
        public IActionResult DeleteUserConfirmed(int id)
        {
            _deleteUserService.DeleteUser(id);
            return RedirectToAction("UpdateUser"); // 👈 tillbaka till användarlistan
        }




    }
}