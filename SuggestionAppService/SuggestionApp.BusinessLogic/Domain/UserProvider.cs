using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Repositories;

namespace SuggestionApp.BusinessLogic.Domain
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepo _userRepo;

        private readonly UserMapper _userMapper;

        public UserProvider(IUserRepo userRepo, UserMapper userMapper)
        {
            _userRepo = userRepo;
            _userMapper = userMapper;
        }

        public async Task CreateUserAsync(UserModel user)
        {
            var inputDto = _userMapper.MapToDto(user);
            await _userRepo.CreateUser(inputDto);
        }

        public async Task<UserModel> GetUserFromAuthenticationAsync(string identifier)
        {
            var output = await _userRepo.GetUserFromAuthentication(identifier);

            return _userMapper.MapToModel(output);
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var output = await _userRepo.GetUsersAsync();

            return new List<UserModel>(_userMapper.MapToModel(output));
        }

        public async Task<UserModel> GetUserById(string id)
        {
            var user = await _userRepo.GetUser(id);

            return _userMapper.MapToModel(user);
        }

        public async Task UpdateUser(UserModel user)
        {
            var inputDto = _userMapper.MapToDto(user);
            await _userRepo.UpdateUser(inputDto);
        }
    }
}
