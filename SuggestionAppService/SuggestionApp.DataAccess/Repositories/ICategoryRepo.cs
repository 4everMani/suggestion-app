using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public interface ICategoryRepo
    {
        Task CreateCategory(CategoryDTO category);
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
    }
}