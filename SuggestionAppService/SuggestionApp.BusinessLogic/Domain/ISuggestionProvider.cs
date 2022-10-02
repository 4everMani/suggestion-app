using SuggestionApp.BusinessLogic.Models;

namespace SuggestionApp.BusinessLogic.Domain
{
    public interface ISuggestionProvider
    {
        Task CreateSuggestionAsync(SuggestionModel suggestion);
        Task<List<SuggestionModel>> GetAllApprovedSuggestionsAsync();
        Task<List<SuggestionModel>> GetAllRejectedSuggestionsAsync();
        Task<List<SuggestionModel>> GetAllSuggestionsAsync();
        Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApprovalAsync();
        Task<SuggestionModel> GetSuggestionAsync(string id);
        Task UpdateSuggestionAsync(SuggestionModel suggestion);
        Task UpvoteSuggestionAsync(string suggestionId, string userId);
    }
}