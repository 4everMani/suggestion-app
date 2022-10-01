using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Dtos;
using SuggestionApp.Utilities.Mapper;

namespace SuggestionApp.BusinessLogic.Mappers
{
    public class SuggestionMapper : MapperBase<SuggestionModel, SuggestionDTO>
    {
        private readonly BasicUserMapper _basicUserMapper;

        private readonly CategoryMapper _categoryMapper;

        private readonly StatusMapper _statusMapper;

        public override SuggestionDTO MapToDto(SuggestionModel model)
        {
            return new SuggestionDTO
            {
                Id = model.Id,
                ApprovedForRelease = model.ApprovedForRelease,
                Archived = model.Archived,
                Author = model.Author != null ? _basicUserMapper.MapToDto(model.Author) : null,
                Category = _categoryMapper.MapToDto(model.Category),
                DateCreated = model.DateCreated,
                Description = model.Description,
                OwnerNotes = model.OwnerNotes,
                Rejected = model.Rejected,
                Suggestion = model.Suggestion,
                SuggestionStatus = model.Suggestion != null ? _statusMapper.MapToDto(model.SuggestionStatus) : null,
                UserVotes = new HashSet<string>(model.UserVotes),
            };
        }

        public override SuggestionModel MapToModel(SuggestionDTO dto)
        {
            return new SuggestionModel
            {
                Id = dto.Id,
                ApprovedForRelease = dto.ApprovedForRelease,
                Archived = dto.Archived,
                Author = dto.Author != null ? _basicUserMapper.MapToModel(dto.Author) : null,
                Category = _categoryMapper.MapToModel(dto.Category),
                DateCreated = dto.DateCreated,
                Description = dto.Description,
                OwnerNotes = dto.OwnerNotes,
                Rejected = dto.Rejected,
                Suggestion = dto.Suggestion,
                SuggestionStatus = dto.Suggestion != null ? _statusMapper.MapToModel(dto.SuggestionStatus) : null,
                UserVotes = new HashSet<string>(dto.UserVotes),
            };
        }
    }
}
