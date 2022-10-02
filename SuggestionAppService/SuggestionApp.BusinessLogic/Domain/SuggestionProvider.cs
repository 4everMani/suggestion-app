using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Dtos;
using SuggestionApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.BusinessLogic.Domain
{
    public class SuggestionProvider : ISuggestionProvider
    {
        private readonly ISuggestionRepo _suggestionRepo;

        private readonly SuggestionMapper _suggestionMapper;

        public SuggestionProvider(ISuggestionRepo suggestionRepo, SuggestionMapper suggestionMapper)
        {
            _suggestionRepo = suggestionRepo;
            _suggestionMapper = suggestionMapper;
        }

        public async Task CreateSuggestionAsync(SuggestionModel suggestion)
        {
            var inputDto = _suggestionMapper.MapToDto(suggestion);
            await _suggestionRepo.CreateSuggestion(inputDto);
        }

        public async Task<List<SuggestionModel>> GetAllApprovedSuggestionsAsync()
        {
            var output = await _suggestionRepo.GetAllApprovedSuggestions();
            return new List<SuggestionModel>(_suggestionMapper.MapToModel(output));
        }

        public async Task<List<SuggestionModel>> GetAllRejectedSuggestionsAsync()
        {
            var output = await _suggestionRepo.GetAllRejectedSuggestions();
            return new List<SuggestionModel>(_suggestionMapper.MapToModel(output));
        }

        public async Task<List<SuggestionModel>> GetAllSuggestionsAsync()
        {
            var output = await _suggestionRepo.GetAllSuggestions();
            return new List<SuggestionModel>(_suggestionMapper.MapToModel(output));
        }

        public async Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApprovalAsync()
        {
            var output = await _suggestionRepo.GetAllSuggestionsWaitingForApproval();
            return new List<SuggestionModel>(_suggestionMapper.MapToModel(output));
        }

        public async Task<SuggestionModel> GetSuggestionAsync(string id)
        {
            var output = await _suggestionRepo.GetSuggestion(id);
            return _suggestionMapper.MapToModel(output);
        }

        public async Task UpdateSuggestionAsync(SuggestionModel suggestion)
        {
            var inputDto = _suggestionMapper.MapToDto(suggestion);
            await _suggestionRepo.UpdateSuggestion(inputDto);
        }

        public async Task UpvoteSuggestionAsync(string suggestionId, string userId)
        {
            await _suggestionRepo.UpvoteSuggestion(suggestionId, userId);
        }
    }
}
