using SuggestionApp.BusinessLogic.Models;

namespace SuggestionApp.BusinessLogic.Domain
{
    public interface IUserProvider
    {
        Task CreateUserAsync(UserModel user);
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserById(string id);
        Task<UserModel> GetUserFromAuthenticationAsync(string identifier);
        Task UpdateUser(UserModel user);
    }
}