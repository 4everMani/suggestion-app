using SuggestionApp.BusinessLogic.Models;

namespace SuggestionApp.BusinessLogic.Domain
{
    public interface IStatusProvider
    {
        Task CreateStatusAsync(StatusModel statusModel);
        Task<List<StatusModel>> GetAllStatusesAsync();
    }
}