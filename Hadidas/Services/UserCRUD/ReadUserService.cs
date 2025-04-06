using Hadidas.Data;
using Hadidas.Models;
using Hadidas.Services.UserCRUD.Interface;

namespace Hadidas.Services.UserCRUD
{
    public class ReadUserService : IReadUserService
    {
        private readonly ApplicationDbContext _context;
        public ReadUserService(ApplicationDbContext context)
        {
              _context = context;
        }

        public List<User> ReadAllUsers()
        {
            // Kontrollera att du får data från databasen
            return _context.Users.ToList();
        }


    }
}
