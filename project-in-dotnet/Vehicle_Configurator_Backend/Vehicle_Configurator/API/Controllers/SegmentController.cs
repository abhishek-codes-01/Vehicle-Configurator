using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentRepository _segmentRepository;

        public SegmentController(ISegmentRepository segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        // GET: api/segment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Segment>>> GetAll()
        {
            var segmentsResult = await _segmentRepository.GetAll();
            return Ok(segmentsResult.Value);
        }

        // GET: api/segment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Segment>> GetById(int id)
        {
            var segmentResult = await _segmentRepository.GetById(id);
            var segment = segmentResult.Value;

            if (segment == null)
                return NotFound();

            return Ok(segment);
        }

        // POST: api/segment
        [HttpPost]
        public async Task<ActionResult> Create(Segment segment)
        {
            await _segmentRepository.Add(segment);
            return CreatedAtAction(nameof(GetById), new { id = segment.SegId }, segment);
        }

        // PUT: api/segment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Segment segment)
        {
            if (id != segment.SegId)
                return BadRequest();

            await _segmentRepository.Update(segment);
            return NoContent();
        }

        // DELETE: api/segment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _segmentRepository.Delete(id);
            return NoContent();
        }
    }
}
