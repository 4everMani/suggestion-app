using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Repositories;

namespace SuggestionApp.BusinessLogic.Domain
{
    public class UserProvider
    {
        private readonly IUserRepo _userRepo;

        private readonly UserMapper _userMapper;

        public UserProvider(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task CreateUserAsync(UserModel user)
        {
            var input = MockedData.UserSampleData();
            var inputDto = _userMapper.MapToDto(input);
            await _userRepo.CreateUser(inputDto);
        }

        public async Task<UserModel> GetUserFromAuthenticationAsync(string identifier)
        {
            var output = await _userRepo.GetUserFromAuthentication(identifier);

            return _userMapper.MapToModel(output);
        }
    }
}
