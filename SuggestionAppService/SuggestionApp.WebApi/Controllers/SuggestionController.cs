using Microsoft.AspNetCore.Mvc;
using SuggestionApp.BusinessLogic.Domain;
using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Dtos;
using SuggestionApp.WebApi.Dtos;

namespace SuggestionApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionProvider _suggestionProvider;

        private readonly SuggestionMapper _suggestionMapper;

        public SuggestionController(ISuggestionProvider suggestionProvider, SuggestionMapper suggestionMapper)
        {
            _suggestionProvider = suggestionProvider;
            _suggestionMapper = suggestionMapper;
        }

        [HttpPost]
        public async Task CreateSuggestion(SuggestionDTO suggestion)
        {
            var input = _suggestionMapper.MapToModel(suggestion);
            await _suggestionProvider.CreateSuggestionAsync(input);
        }

        [HttpGet("GetAllApprovedSuggestions")]
        public async Task<List<SuggestionDTO>> GetAllApprovedSuggestionsAsync()
        {
            var output = await _suggestionProvider.GetAllApprovedSuggestionsAsync();
            return new List<SuggestionDTO>(_suggestionMapper.MapToDto(output));
        }

        [HttpGet("GetAllRejectedSuggestions")]
        public async Task<List<SuggestionDTO>> GetAllRejectedSuggestions()
        {
            var output = await _suggestionProvider.GetAllRejectedSuggestionsAsync();
            return new List<SuggestionDTO>(_suggestionMapper.MapToDto(output));
        }

        [HttpGet]
        public async Task<List<SuggestionDTO>> GetAllSuggestionsAsync()
        {
            var output = await _suggestionProvider.GetAllSuggestionsAsync();
            return new List<SuggestionDTO>(_suggestionMapper.MapToDto(output));
        }

        [HttpGet("GetAllSuggestionsWaitingForApproval")]
        public async Task<List<SuggestionDTO>> GetAllSuggestionsWaitingForApproval()
        {
            var output = await _suggestionProvider.GetAllSuggestionsWaitingForApprovalAsync();
            return new List<SuggestionDTO>(_suggestionMapper.MapToDto(output));
        }

        [HttpGet("{id}")]
        public async Task<SuggestionDTO> GetSuggestion(string id)
        {
            var output = await _suggestionProvider.GetSuggestionAsync(id);
            return _suggestionMapper.MapToDto(output);
        }

        [HttpPut]
        public async Task UpdateSuggestion(SuggestionDTO suggestion)
        {
            var input = _suggestionMapper.MapToModel(suggestion);
            await _suggestionProvider.UpdateSuggestionAsync(input);
        }

        [HttpPost("UpvoteSuggestion")]
        public async Task UpvoteSuggestion(UpvoteInputDTO inputDTO)
        {
            await _suggestionProvider.UpvoteSuggestionAsync(inputDTO.SuggestionId, inputDTO.UserId);
        }


    }
}
