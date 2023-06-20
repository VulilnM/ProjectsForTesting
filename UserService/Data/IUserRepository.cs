using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepository
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserByUsername(string usrname);
        void RegisterUser(User usr);
    }
}