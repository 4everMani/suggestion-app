using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Dtos;
using SuggestionApp.Utilities.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.BusinessLogic.Mappers
{
    public class BasicSuggestionMapper: MapperBase<BasicSuggestionModel, BasicSuggestionDTO>
    {

        public override BasicSuggestionDTO MapToDto(BasicSuggestionModel model)
        {
            var dto = new BasicSuggestionDTO
            {
                Id = model.Id,
                Suggestion = model.Suggestion,
            };

            return dto;
        }

        public override BasicSuggestionModel MapToModel(BasicSuggestionDTO dto)
        {
            var model = new BasicSuggestionModel
            {
                Id = dto.Id,
                Suggestion = dto.Suggestion,
            };

            return model;
        }
    }
}
