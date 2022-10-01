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
    public class UserMapper: MapperBase<UserModel, UserDTO>
    {

        private readonly BasicSuggestionMapper _basicSuggestionMapper;

        private readonly BasicUserMapper _baiscUserMapper;

        public override UserDTO MapToDto(UserModel model)
        {
            var dto = new UserDTO
            {
                Id = model.Id,
                ObjectIdentifier = model.ObjectIdentifier,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                DisplayName = model.DisplayName,
            };

            return dto;
        }


        public override UserModel MapToModel(UserDTO dto)
        {
            var model = new UserModel
            {
                Id = dto.Id,
                ObjectIdentifier = dto.ObjectIdentifier,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailAddress = dto.EmailAddress,
                DisplayName = dto.DisplayName,
                AuthoredSuggestions = dto.AuthoredSuggestions != null ?
                new List<BasicSuggestionModel>(_basicSuggestionMapper.MapToModel(dto.AuthoredSuggestions)):
                new List<BasicSuggestionModel>(),
                VotedSuggestions = dto.VotedSuggestions != null ? 
                new List<BasicSuggestionModel>(_basicSuggestionMapper.MapToModel(dto.VotedSuggestions)):
                new List<BasicSuggestionModel>(),
            };

            return model;
        }
    }
}
