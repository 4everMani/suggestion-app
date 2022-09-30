using MongoDB.Driver;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.DbContext
{
    public interface IDbConnection
    {
        IMongoCollection<CategoryDTO> CategoryCollection { get; }
        string CategoryCollectionName { get; }
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<StatusDTO> StatusCollection { get; }
        string StatusCollectionName { get; }
        IMongoCollection<SuggestionDTO> SuggestionCollection { get; }
        string SuggestionCollectionName { get; }
        IMongoCollection<UserDTO> UserCollection { get; }
        string UserCollectionName { get; }
    }
}