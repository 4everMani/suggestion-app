using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.BusinessLogic.Domain
{
    public class CategoryProvider
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
    }
}
