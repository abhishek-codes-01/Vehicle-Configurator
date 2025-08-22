using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDetailController : ControllerBase
    {
        private readonly IVehicleDetailRepository _vehicleDetailRepository;

        public VehicleDetailController(IVehicleDetailRepository vehicleDetailRepository)
        {
            _vehicleDetailRepository = vehicleDetailRepository;
        }

        // GET: api/vehicledetail/by-component/{componentId}
        [HttpGet("by-component/{componentId}")]
        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetByComponentId(int componentId)
        {
            var detailsResult = await _vehicleDetailRepository.GetByComponentId(componentId);
            var details = detailsResult.Value;

            if (details == null || !details.Any())
                return NotFound();

            return Ok(details);
        }

        // GET: api/vehicledetail/by-model/{modelId}
        [HttpGet("by-model/{modelId}")]
        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetByModelId(int modelId)
        {
            var detailsResult = await _vehicleDetailRepository.GetByModelId(modelId);
            var details = detailsResult.Value;

            if (details == null || !details.Any())
                return NotFound();

            return Ok(details);
        }
    }
}
