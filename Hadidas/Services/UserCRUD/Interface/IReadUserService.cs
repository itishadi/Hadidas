using Hadidas.Models;

namespace Hadidas.Services.UserCRUD.Interface
{
    public interface IReadUserService
    {
       public List<User> ReadAllUsers();
    }
}
