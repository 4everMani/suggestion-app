using Microsoft.AspNetCore.Mvc;
using SuggestionApp.BusinessLogic.Domain;
using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.WebApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusProvider _statusProvider;

        private readonly StatusMapper _statusMapper;

        public StatusController(IStatusProvider statusProvider, StatusMapper statusMapper)
        {
            _statusProvider = statusProvider;
            _statusMapper = statusMapper;
        }

        [HttpPost]
        public async Task CreateStatusAsync(StatusDTO status)
        {
            var inputModel = _statusMapper.MapToModel(status);

            await _statusProvider.CreateStatusAsync(inputModel);
        }

        [HttpGet]
        public async Task<List<StatusDTO>> GetAllStatusesAsync()
        {
            var output = await _statusProvider.GetAllStatusesAsync();
            return new List<StatusDTO>(_statusMapper.MapToDto(output));
        }
    }
}
