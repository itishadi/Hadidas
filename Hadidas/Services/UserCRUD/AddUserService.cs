using Hadidas.Data;
using Hadidas.Models;
using Hadidas.Services.UserCRUD.Interface;

namespace Hadidas.Services.UserCRUD
{
    public class AddUserService : IAddUserService
    {
        private readonly ApplicationDbContext _context;

        public AddUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
