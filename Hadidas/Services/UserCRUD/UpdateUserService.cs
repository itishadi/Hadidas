using Hadidas.Models;
using Hadidas.Data;
using Hadidas.Services.UserCRUD.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hadidas.Services.UserCRUD
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UpdateUser(User user)
        {
            // Hitta användaren i databasen med hjälp av deras ID
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser != null)
            {
                // Uppdatera användarens fält
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                // Spara ändringarna
                _context.SaveChanges();
            }
            else
            {
                // Om användaren inte finns kan du logga eller kasta ett undantag
                throw new Exception("User not found");
            }
        }
    }
}
