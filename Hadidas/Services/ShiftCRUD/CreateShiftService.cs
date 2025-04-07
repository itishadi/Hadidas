using Hadidas.Data;
using Hadidas.Models;
using Hadidas.Services.ShiftCRUD.Interface;

namespace Hadidas.Services.ShiftCRUD
{
    public class CreateShiftService : ICreateShiftService
    {
        private readonly ApplicationDbContext _context;
        public CreateShiftService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateShift(Shift shift) 
        {
            _context.Shifts.Add(shift);
            _context.SaveChanges();
        }

    }
}
