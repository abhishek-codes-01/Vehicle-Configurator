using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlternateComponentMasterController : ControllerBase
    {
        private readonly IAlternateComponentMasterRepository _alternateComponentMasterRepository;

        public AlternateComponentMasterController(IAlternateComponentMasterRepository alternateComponentMasterRepository)
        {
            _alternateComponentMasterRepository = alternateComponentMasterRepository;
        }

        // GET: api/alternatecomponentmaster/by-model/{modelId}
        [HttpGet("by-model/{modelId}")]
        public async Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByModelId(int modelId)
        {
            var alternateComponents = await _alternateComponentMasterRepository.GetByModelId(modelId);
            if (alternateComponents.Value == null || !alternateComponents.Value.Any())
            {
                return NotFound($"No alternate components found for model with ID: {modelId}");
            }
            return Ok(alternateComponents.Value);
        }

        // GET: api/alternatecomponentmaster/by-component/{componentId}
        [HttpGet("by-component/{componentId}")]
        public async Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByComponentId(int componentId)
        {
            var alternateComponents = await _alternateComponentMasterRepository.GetByComponentId(componentId);
            if (alternateComponents.Value == null || !alternateComponents.Value.Any())
            {
                return NotFound($"No alternate components found for component with ID: {componentId}");
            }
            return Ok(alternateComponents.Value);
        }

        // GET: api/alternatecomponentmaster/by-model-and-component/{modelId}/{componentId}
        [HttpGet("by-model-and-component/{modelId}/{componentId}")]
        public async Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByModelAndComponentId(int modelId, int componentId)
        {
            var alternateComponents = await _alternateComponentMasterRepository.GetByModelIdAndComponentId(modelId, componentId);
            if (alternateComponents.Value == null || !alternateComponents.Value.Any())
            {
                return NotFound($"No alternate components found for model ID: {modelId} and component ID: {componentId}");
            }
            return Ok(alternateComponents.Value);
        }
    }
}
