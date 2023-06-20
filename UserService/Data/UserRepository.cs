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

        public User GetUserByUsername(string usrname)
        {
            if (usrname == null)
                throw new ArgumentNullException(nameof(usrname));
            else
                return _context.Users.FirstOrDefault(p => p.UserName == usrname);
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