using Hadidas.Data;
using Hadidas.Services.UserCRUD.Interface;

namespace Hadidas.Services.UserCRUD
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
