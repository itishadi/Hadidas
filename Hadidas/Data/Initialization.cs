using Hadidas.Models;

namespace Hadidas.Data
{
    public static class Initialization
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Lägg till admin-användare
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

            // Lägg till en grupp
            if (!context.Groups.Any())
            {
                context.Groups.Add(new Group
                {
                    GroupName = "Testgruppen"
                });
                context.SaveChanges();
            }

            // Lägg till MessageUser
            if (!context.MessageUsers.Any())
            {
                var group = context.Groups.FirstOrDefault();
                context.MessageUsers.Add(new MessageUser
                {
                    Name = "Testperson",
                    PhoneNumber = "0701234567",
                    GroupId = group?.GroupId
                });
                context.SaveChanges();
            }

            // Lägg till ett testmeddelande
            if (!context.Messages.Any())
            {
                var user = context.MessageUsers.FirstOrDefault();
                context.Messages.Add(new Message
                {
                    Content = "Välkommen till systemet!",
                    SentAt = DateTime.Now,
                    MessageUserId = user?.MessageUserId
                });
                context.SaveChanges();
            }
        }
    }
}
