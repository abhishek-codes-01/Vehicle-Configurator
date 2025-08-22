    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Vehicle_Configurator.Application.Interfaces;
    using Vehicle_Configurator.Domain.Entities;

    namespace Vehicle_Configurator.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ModelController : ControllerBase
        {
            private readonly IModelRepository _modelRepository;

            public ModelController(IModelRepository modelRepository)
            {
                _modelRepository = modelRepository;
            }

            // GET: api/model
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Model>>> GetAll()
            {
                var modelsResult = await _modelRepository.GetAll();
                return Ok(modelsResult.Value);
            }

            // GET: api/model/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<Model>> GetById(int id)
            {
                var modelResult = await _modelRepository.GetById(id);
                var model = modelResult.Value;

                if (model == null)
                    return NotFound();

                return Ok(model);
            }

            // GET: api/model/by-manufacturer/{manufacturerId}
            [HttpGet("by-manufacturer/{manufacturerId}")]
            public async Task<ActionResult<IEnumerable<Model>>> GetByManufacturerId(int manufacturerId)
            {
                var modelsResult = await _modelRepository.GetByManufacturerId(manufacturerId);
                return Ok(modelsResult.Value);
            }

            // GET: api/model/by-segment/{segmentId}
            [HttpGet("by-segment/{segmentId}")]
            public async Task<ActionResult<IEnumerable<Model>>> GetBySegmentId(int segmentId)
            {
                var modelsResult = await _modelRepository.GetBySegmentId(segmentId);
                return Ok(modelsResult.Value);
            }

            // GET: api/model/by-segment/{segmentId}/manufacturer/{manufacturerId}
            [HttpGet("by-segment/{segmentId}/manufacturer/{manufacturerId}")]
            public async Task<ActionResult<IEnumerable<Model>>> GetBySegmentAndManufacturerId(int segmentId, int manufacturerId)
            {
                var modelsResult = await _modelRepository.GetBySegmentAndManufacturerId(segmentId, manufacturerId);
                return Ok(modelsResult.Value);
            }

            // POST: api/model
            [HttpPost]
            public async Task<ActionResult> Create(Model model)
            {
                await _modelRepository.Add(model);
                return CreatedAtAction(nameof(GetById), new { id = model.ModelId }, model);
            }

            // PUT: api/model/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Model model)
            {
                if (id != model.ModelId)
                    return BadRequest();

                await _modelRepository.Update(model);
                return NoContent();
            }

            // DELETE: api/model/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _modelRepository.Delete(id);
                return NoContent();
            }
        }
    }
