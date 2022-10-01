using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Dtos;
using SuggestionApp.Utilities.Mapper;

namespace SuggestionApp.BusinessLogic.Mappers
{
    public class StatusMapper : MapperBase<StatusModel, StatusDTO>
    {
        public override StatusDTO MapToDto(StatusModel model)
        {
            return new StatusDTO
            {
                Id = model.Id,
                StatusDescription = model.StatusDescription,
                StatusName = model.StatusName,
            };
        }

        public override StatusModel MapToModel(StatusDTO dto)
        {
            return new StatusModel
            {
                Id = dto.Id,
                StatusName = dto.StatusName,
                StatusDescription = dto.StatusDescription,
            };
        }
    }
}
