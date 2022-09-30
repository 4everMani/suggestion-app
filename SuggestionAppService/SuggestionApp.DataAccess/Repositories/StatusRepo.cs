using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using SuggestionApp.DataAccess.DbContext;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public class StatusRepo : IStatusRepo
    {
        private readonly IMongoCollection<StatusDTO> _statuses;
        private readonly IMemoryCache _cache;
        private const string CacheName = "StatusData";

        public StatusRepo(IDbConnection db, IMemoryCache cache)
        {
            _statuses = db.StatusCollection;
            _cache = cache;
        }

        public async Task<List<StatusDTO>> GetAllStatuses()
        {
            var output = _cache.Get<List<StatusDTO>>(CacheName);
            if (output is null)
            {
                var result = await _statuses.FindAsync(_ => true);
                output = result.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }

        public Task CreateStatus(StatusDTO status)
        {
            return _statuses.InsertOneAsync(status);
        }
    }
}
