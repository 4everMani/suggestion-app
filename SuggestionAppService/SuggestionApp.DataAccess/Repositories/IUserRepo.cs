using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public interface IUserRepo
    {
        Task CreateUser(UserDTO user);
        Task<UserDTO> GetUser(string id);
        Task<UserDTO> GetUserFromAuthentication(string objectId);
        Task<List<UserDTO>> GetUsersAsync();
        Task UpdateUser(UserDTO user);
    }
}