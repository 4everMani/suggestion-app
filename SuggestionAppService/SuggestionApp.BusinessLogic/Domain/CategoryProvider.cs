using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Repositories;

namespace SuggestionApp.BusinessLogic.Domain
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly ICategoryRepo _categoryRepo;

        private readonly CategoryMapper _categoryMapper;

        public CategoryProvider(ICategoryRepo categoryRepo, CategoryMapper categoryMapper)
        {
            _categoryRepo = categoryRepo;
            _categoryMapper = categoryMapper;
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepo.GetAllCategoriesAsync();

            return new List<CategoryModel>(_categoryMapper.MapToModel(categories));
        }

        public async Task CreateCategory(CategoryModel categoryModel)
        {
            var inputDto = _categoryMapper.MapToDto(categoryModel);

            await _categoryRepo.CreateCategory(inputDto);
        }
    }
}
