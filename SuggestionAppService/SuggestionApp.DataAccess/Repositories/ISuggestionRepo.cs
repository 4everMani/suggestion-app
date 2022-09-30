using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public interface ISuggestionRepo
    {
        Task CreateSuggestion(SuggestionDTO suggestion);
        Task<List<SuggestionDTO>> GetAllApprovedSuggestions();
        Task<List<SuggestionDTO>> GetAllRejectedSuggestions();
        Task<List<SuggestionDTO>> GetAllSuggestions();
        Task<List<SuggestionDTO>> GetAllSuggestionsWaitingForApproval();
        Task<SuggestionDTO> GetSuggestion(string id);
        Task UpdateSuggestion(SuggestionDTO suggestion);
        Task UpvoteSuggestion(string suggestionId, string userId);
    }
}