using Hadidas.Data;
using Hadidas.Models;
using Hadidas.Services.UserCRUD.Interface;

namespace Hadidas.Services.UserCRUD
{
    public class UserAddService : IUserAddService
    {
        private readonly ApplicationDbContext _context;

        public UserAddService(ApplicationDbContext context)
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
