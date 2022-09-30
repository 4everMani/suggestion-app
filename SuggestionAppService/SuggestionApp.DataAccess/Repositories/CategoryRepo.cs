using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using SuggestionApp.DataAccess.DbContext;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IMongoCollection<CategoryDTO> _categories;
        private readonly IMemoryCache _cache;
        private const string CacheName = "CategoryData";
        public CategoryRepo(IDbConnection db, IMemoryCache cache)
        {
            _categories = db.CategoryCollection;
            _cache = cache;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var output = _cache.Get<List<CategoryDTO>>(CacheName);

            if (output is null)
            {
                var results = await _categories.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }

        public Task CreateCategory(CategoryDTO category)
        {
            return _categories.InsertOneAsync(category);
        }
    }
}
