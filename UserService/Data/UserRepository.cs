using UserService.Models;

namespace UserService.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            else
                return _context.Users.FirstOrDefault(p => p.UserId == id);
        }

        public void RegisterUser(User usr)
        {
            if (usr == null)
                throw new ArgumentNullException(nameof(usr));
            else
                _context.Users.Add(usr);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }

}