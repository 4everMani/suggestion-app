using Microsoft.AspNetCore.Mvc;
using SuggestionApp.BusinessLogic.Domain;
using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserProvider _userProvider;

        private readonly UserMapper _userMapper;

        public UserController(IUserProvider userProvider, UserMapper userMapper)
        {
            _userProvider = userProvider;
            _userMapper = userMapper;
        }

        [HttpPost]
        public async Task CreateUser(UserDTO user)
        {
            var input = _userMapper.MapToModel(user);
            await _userProvider.CreateUserAsync(input);
        }

        [HttpGet("GetUserFromAuthenticationAsync/{identifier}")]
        public async Task<UserDTO> GetUserFromAuthentication(string identifier)
        {
            var output = await _userProvider.GetUserFromAuthenticationAsync(identifier);

            return _userMapper.MapToDto(output);
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var output = await _userProvider.GetAllUsersAsync();

            return new List<UserDTO>(_userMapper.MapToDto(output));
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userProvider.GetUserById(id);

            return _userMapper.MapToDto(user);
        }

        [HttpPut]
        public async Task UpdateUser(UserDTO user)
        {
            var inputDto = _userMapper.MapToModel(user);
            await _userProvider.UpdateUser(inputDto);
        }
    }
}
