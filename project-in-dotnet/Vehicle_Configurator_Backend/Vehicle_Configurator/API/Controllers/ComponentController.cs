using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Application.Services;
using Vehicle_Configurator.Domain.Entities;
using System.Linq;

namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentRepository _componentRepository;

        public ComponentController(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetAll()
        {
            var components = await _componentRepository.GetAllComps();
            if (components == null || !components.Any())
                return NotFound("No components found.");
            return Ok(components);

        }

        // GET: api/component/by-model/{modelId}
        /// <summary>
        /// Retrieves components associated with a specific vehicle model.
        /// </summary>
        /// <param name="modelId">The ID of the vehicle model.</param>
        /// <returns>A list of components for the specified model.</returns>
        [HttpGet("by-model/{modelId}")]
        public async Task<ActionResult<IEnumerable<Component>>> GetByModelId(int modelId)
        {
            var componentsResult = await _componentRepository.GetByModelId(modelId);

            if (componentsResult.Value == null || !componentsResult.Value.Any())
            {
                return NotFound($"No components found for model with ID: {modelId}");
            }

            return Ok(componentsResult.Value);
        }
    }
}
