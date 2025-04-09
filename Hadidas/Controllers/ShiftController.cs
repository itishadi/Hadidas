using Hadidas.Models;
using Hadidas.Services.ShiftCRUD.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hadidas.Controllers
{
    public class ShiftController : Controller
    {
        private readonly ICreateShiftService _createShiftService;
        public ShiftController(ICreateShiftService createShiftService)
        {
            _createShiftService = createShiftService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateShift()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult CreateShift(Shift shift)
        {
            if (ModelState.IsValid)
            {
                _createShiftService.CreateShift(shift);
                return RedirectToAction("Index");
            }
            return View(shift);
        }


    }
}
