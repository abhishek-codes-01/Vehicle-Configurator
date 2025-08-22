using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;

namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerController(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        // GET: api/manufacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAll()
        {
            var manufacturersResult = await _manufacturerRepository.GetAll();
            return Ok(manufacturersResult.Value);
        }

        // GET: api/manufacturer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetById(int id)
        {
            var manufacturerResult = await _manufacturerRepository.GetById(id);
            var manufacturer = manufacturerResult.Value;

            if (manufacturer == null)
                return NotFound();

            return Ok(manufacturer);
        }

        // POST: api/manufacturer
        [HttpPost]
        public async Task<ActionResult> Create(Manufacturer manufacturer)
        {
            await _manufacturerRepository.Add(manufacturer);
            return CreatedAtAction(nameof(GetById), new { id = manufacturer.MfgId }, manufacturer);
        }

        // PUT: api/manufacturer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.MfgId)
                return BadRequest();

            await _manufacturerRepository.Update(manufacturer);
            return NoContent();
        }

        // DELETE: api/manufacturer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manufacturerRepository.Delete(id);
            return NoContent();
        }
    }
}
