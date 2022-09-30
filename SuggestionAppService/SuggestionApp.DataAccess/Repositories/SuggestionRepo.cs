using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using SuggestionApp.DataAccess.DbContext;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public class SuggestionRepo : ISuggestionRepo
    {
        private readonly IDbConnection _db;
        private readonly IUserRepo _userRepo;
        private readonly IMemoryCache _cache;
        private readonly IMongoCollection<SuggestionDTO> _suggestions;
        private const string CacheName = "SuggestionData";

        public SuggestionRepo(IDbConnection db, IUserRepo userRepo, IMemoryCache cache)
        {
            _db = db;
            _userRepo = userRepo;
            _cache = cache;
            _suggestions = db.SuggestionCollection;
        }

        public async Task<List<SuggestionDTO>> GetAllSuggestions()
        {
            var output = _cache.Get<List<SuggestionDTO>>(CacheName);
            if (output is null)
            {
                var result = await _suggestions.FindAsync(suggestion => suggestion.Archived == false);
                output = result.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
            }
            return output;
        }

        public async Task<List<SuggestionDTO>> GetAllApprovedSuggestions()
        {
            var output = await GetAllSuggestions();
            return output.Where(suggestion => suggestion.ApprovedForRelease).ToList();
        }

        public async Task<SuggestionDTO> GetSuggestion(string id)
        {
            var result = await _suggestions.FindAsync(suggestion => suggestion.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<List<SuggestionDTO>> GetAllSuggestionsWaitingForApproval()
        {
            var output = await GetAllSuggestions();
            return output.Where(suggestion =>
                                suggestion.ApprovedForRelease == false &&
                                suggestion.Rejected == false).ToList();
        }

        public async Task UpdateSuggestion(SuggestionDTO suggestion)
        {
            await _suggestions.ReplaceOneAsync(suggestion => suggestion.Id == suggestion.Id, suggestion);
            _cache.Remove(CacheName);
        }

        public async Task UpvoteSuggestion(string suggestionId, string userId)
        {
            var client = _db.Client;

            using var session = await client.StartSessionAsync(); // this will insure that upvote and user activity either done compltely or failed completly
            session.StartTransaction();
            try
            {
                var db = client.GetDatabase(_db.DbName); // We are creating new db instance becuase we are in transction and we should not use our actual _db
                var suggestionsInTransaction = db.GetCollection<SuggestionDTO>(_db.SuggestionCollectionName);
                var suggestion = (await suggestionsInTransaction.FindAsync(suggestion => suggestion.Id == suggestionId)).First();

                bool isUpvote = suggestion.UserVotes.Add(userId);
                if (isUpvote == false)
                {
                    suggestion.UserVotes.Remove(userId);
                }

                await suggestionsInTransaction.ReplaceOneAsync(s => s.Id == suggestionId, suggestion);

                var usersInTransaction = db.GetCollection<UserDTO>(_db.UserCollectionName);
                var user = await _userRepo.GetUser(suggestion.Author.Id);

                if (isUpvote)
                {
                    user.VotedSuggestions.Add(new BasicSuggestionDTO(suggestion));
                }
                else
                {
                    var suggestionToRemove = user.VotedSuggestions.Where(s => s.Id == suggestionId).First();
                    user.VotedSuggestions.Remove(suggestionToRemove);
                }
                await usersInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

                await session.CommitTransactionAsync();

                _cache.Remove(CacheName);
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

        public async Task CreateSuggestion(SuggestionDTO suggestion)
        {
            var client = _db.Client;

            using var session = await client.StartSessionAsync(); // this will insure that upvote and user activity either done compltely or failed completly
            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DbName); // We are creating new db instance becuase we are in transction and we should not use our actual _db
                var suggestionsInTransaction = db.GetCollection<SuggestionDTO>(_db.SuggestionCollectionName);
                await suggestionsInTransaction.InsertOneAsync(suggestion);

                var usersInTransaction = db.GetCollection<UserDTO>(_db.UserCollectionName);
                var user = await _userRepo.GetUser(suggestion.Author.Id);
                user.AuthoredSuggestions.Add(new BasicSuggestionDTO(suggestion));
                await usersInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

        public async Task<List<SuggestionDTO>> GetAllRejectedSuggestions()
        {
            var output = await GetAllSuggestions();
            return output.Where(suggestion => suggestion.ApprovedForRelease == true).ToList();
        }
    }
}
