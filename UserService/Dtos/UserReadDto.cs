using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserReadDto
    {
        public string UserName { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
}