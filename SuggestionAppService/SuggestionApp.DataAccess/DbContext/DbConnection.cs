using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.DbContext
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _config;

        private readonly IMongoDatabase _db;

        private string _connectionId = "MongoDB";

        public string DbName { get; private set; }

        public string CategoryCollectionName { get; private set; } = "categories";

        public string StatusCollectionName { get; private set; } = "statuses";

        public string UserCollectionName { get; private set; } = "users";

        public string SuggestionCollectionName { get; private set; } = "suggestions";

        public MongoClient Client { get; private set; }

        public IMongoCollection<CategoryDTO> CategoryCollection { get; private set; }
        public IMongoCollection<StatusDTO> StatusCollection { get; private set; }
        public IMongoCollection<UserDTO> UserCollection { get; private set; }
        public IMongoCollection<SuggestionDTO> SuggestionCollection { get; private set; }

        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);

            CategoryCollection = _db.GetCollection<CategoryDTO>(CategoryCollectionName);
            StatusCollection = _db.GetCollection<StatusDTO>(StatusCollectionName);
            UserCollection = _db.GetCollection<UserDTO>(UserCollectionName);
            SuggestionCollection = _db.GetCollection<SuggestionDTO>(SuggestionCollectionName);
        }
    }
}
