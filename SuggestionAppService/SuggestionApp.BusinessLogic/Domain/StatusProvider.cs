using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Repositories;

namespace SuggestionApp.BusinessLogic.Domain
{
    public class StatusProvider : IStatusProvider
    {
        private readonly IStatusRepo _statusRepo;

        private readonly StatusMapper _statusMapper;

        public StatusProvider(IStatusRepo statusRepo, StatusMapper statusMapper)
        {
            _statusRepo = statusRepo;
            _statusMapper = statusMapper;
        }

        public async Task<List<StatusModel>> GetAllStatusesAsync()
        {
            var output = await _statusRepo.GetAllStatuses();

            return new List<StatusModel>(_statusMapper.MapToModel(output));
        }

        public async Task CreateStatusAsync(StatusModel statusModel)
        {
            var inputDto = _statusMapper.MapToDto(statusModel);
            await _statusRepo.CreateStatus(inputDto);
        }
    }
}
