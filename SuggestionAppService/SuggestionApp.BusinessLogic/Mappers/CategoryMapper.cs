using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Dtos;
using SuggestionApp.Utilities.Mapper;

namespace SuggestionApp.BusinessLogic.Mappers
{
    public class CategoryMapper : MapperBase<CategoryModel, CategoryDTO>
    {
        public override CategoryDTO MapToDto(CategoryModel model)
        {
            var dto = new CategoryDTO
            {
                Id = model.Id,
                CategoryDescription = model.CategoryDescription,
                CategoryName = model.CategoryName,
            };
            return dto;
        }

        public override CategoryModel MapToModel(CategoryDTO dto)
        {
           var model = new CategoryModel 
           { 
               Id = dto.Id, 
               CategoryDescription = dto.CategoryDescription, 
               CategoryName = dto.CategoryName 
           };
            return model;
        }
    }
}
