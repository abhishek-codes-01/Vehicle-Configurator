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
    public class SgMfgMasterController : ControllerBase
    {
        private readonly ISgMfgMasterRepository _sgMfgMasterRepository;

        public SgMfgMasterController(ISgMfgMasterRepository sgMfgMasterRepository)
        {
            _sgMfgMasterRepository = sgMfgMasterRepository;
        }

        // GET: api/sgmfgmaster/by-segment/{segmentId}
        [HttpGet("by-segment/{segmentId}")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturersBySegmentId(int segmentId)
        {
            var manufacturersResult = await _sgMfgMasterRepository.GetManufacturersBySegmentId(segmentId);
            var manufacturers = manufacturersResult.Value;

            if (manufacturers == null || !manufacturers.Any())
                return NotFound();

            return Ok(manufacturers);
        }
    }
}
