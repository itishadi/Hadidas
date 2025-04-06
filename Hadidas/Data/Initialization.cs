using Hadidas.Models;

namespace Hadidas.Data
{
    public static class Initialization
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { FirstName = "Alice", LastName = "Gustafsson", Email = "alice@example.com", Password = "1234" },
                    new User { FirstName = "Bob", LastName = "Johansson", Email = "bob@example.com", Password = "1234" },
                    new User { FirstName = "Charlie", LastName = "Adolfsson", Email = "charlie@example.com", Password = "1234" },
                    new User { FirstName = "Tomas", LastName = "Henriksson", Email = "Tomas@example.com", Password = "1234" }
                );
                context.SaveChanges();
            }
        }
    }
}

