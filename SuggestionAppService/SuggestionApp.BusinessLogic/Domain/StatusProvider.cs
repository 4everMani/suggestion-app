using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.BusinessLogic.Models;
using SuggestionApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.BusinessLogic.Domain
{
    public  class StatusProvider
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
    }
}
