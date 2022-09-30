using MongoDB.Driver;
using SuggestionApp.DataAccess.DbContext;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly IMongoCollection<UserDTO> _users;

        public UserRepo(IDbConnection db)
        {
            _users = db.UserCollection;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var results = await _users.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<UserDTO> GetUser(string id)
        {
            var user = await _users.FindAsync(user => user.Id == id);
            return user.FirstOrDefault();
        }

        public async Task<UserDTO> GetUserFromAuthentication(string objectId)
        {
            var user = await _users.FindAsync(user => user.ObjectIdentifier == objectId);
            return user.FirstOrDefault();
        }

        public Task CreateUser(UserDTO user)
        {
            return _users.InsertOneAsync(user);
        }

        public Task UpdateUser(UserDTO user)
        {
            var filter = Builders<UserDTO>.Filter.Eq("Id", user.Id);
            return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }
    }
}
