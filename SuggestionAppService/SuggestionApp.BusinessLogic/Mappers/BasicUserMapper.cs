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
    public class BasicUserMapper : MapperBase<BasicUserModel, BasicUserDTO>
    {
        public override BasicUserDTO MapToDto(BasicUserModel model)
        {
            var dto = new BasicUserDTO
            {
                Id = model.Id,
                DisplayName = model.DisplayName,    
            };
            return dto;
        }

        public override BasicUserModel MapToModel(BasicUserDTO dto)
        {
            var model = new BasicUserModel
            {
                Id = dto.Id,
                DisplayName = dto.DisplayName,
            };
            return model;
        }
    }
}
