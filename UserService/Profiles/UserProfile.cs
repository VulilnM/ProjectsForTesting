using AutoMapper;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Read Scenario
            // Source        ->    Target
            // fromDb(model) ->    Dto
            CreateMap<User, UserReadDto> ();
            CreateMap<UserCreateDto, User> ();
        }
    }
}