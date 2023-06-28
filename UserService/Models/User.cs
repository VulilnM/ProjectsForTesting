using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    // Explore IdentityFramework and try to implement 
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
}