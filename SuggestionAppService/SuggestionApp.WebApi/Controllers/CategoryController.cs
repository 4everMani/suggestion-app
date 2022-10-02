using Microsoft.AspNetCore.Mvc;
using SuggestionApp.BusinessLogic.Domain;
using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryProvider _categoryProvider;

        private readonly CategoryMapper _categoryMapper;

        public CategoryController(ICategoryProvider categoryProvider, CategoryMapper categoryMapper)
        {
            _categoryProvider = categoryProvider;
            _categoryMapper = categoryMapper;
        }

        [HttpPost]
        public async Task CreateCategoryAsync(CategoryDTO category)
        {
            var inputModel = _categoryMapper.MapToModel(category);

            await _categoryProvider.CreateCategory(inputModel);
        }

        [HttpGet]
        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var output = await _categoryProvider.GetAllCategoriesAsync();
            return new List<CategoryDTO>(_categoryMapper.MapToDto(output));
        }

    }
}
