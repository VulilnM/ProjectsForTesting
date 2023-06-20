using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepository
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void RegisterUser(User usr);
    }
}