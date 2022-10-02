using SuggestionApp.BusinessLogic.Models;

namespace SuggestionApp.BusinessLogic.Domain
{
    public interface ICategoryProvider
    {
        Task CreateCategory(CategoryModel categoryModel);
        Task<List<CategoryModel>> GetAllCategoriesAsync();
    }
}