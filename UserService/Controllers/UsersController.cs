using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;
using UserService.Profiles;

namespace UserService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // wrap in try catch
        // eksplicitno deklarisi error code za svaki use case (errors)
        // objasni rezultat svake potencijalne akcije 
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetUsers()
        {
            Console.WriteLine("--> Getting users...");

            var userItem = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItem));
        }

        // eksplicitno definisi tip podataka za rute/metode 
        // async/await
        [HttpGet("{usrname}", Name = "GetUserByUsername")]
        public ActionResult<UserReadDto> GetUserByUsername(string usrname)
        {
            var userItem = _repository.GetUserByUsername(usrname);

            if (userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreatePlatform(UserCreateDto userCreateDto)
        {
            // map json to repo model - (obj)
            var userModel = _mapper.Map<User>(userCreateDto);
           
            _repository.RegisterUser(userModel);
            // ne pozivati repo direktno is kontrolera
            _repository.SaveChanges();
             Console.WriteLine("Registered new user:" + userModel.UserName + " succesfully!");
                 
            // map from app db to dto
            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            // routes user to newly created resource
            return CreatedAtRoute(nameof(GetUserByUsername), new { usrname = userReadDto.UserName }, userReadDto);
        }
    }
}