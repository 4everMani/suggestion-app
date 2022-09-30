using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.DataAccess.Repositories
{
    public interface IStatusRepo
    {
        Task CreateStatus(StatusDTO status);
        Task<List<StatusDTO>> GetAllStatuses();
    }
}