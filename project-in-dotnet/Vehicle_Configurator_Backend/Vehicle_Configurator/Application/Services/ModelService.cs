using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Infrastructure.Repositories;

namespace Vehicle_Configurator.Application.Services
{
    public class ModelService : IModelRepository
    {
        private readonly AppDbContext _context;

        public ModelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Model>>> GetAll()
        {
            var result = await _context.Model.ToListAsync();
            return result;
        }

        public async Task<ActionResult<Model>> GetById(int id)
        {
            var result = await _context.Model.FindAsync(id);
            return result;
        }

        public async Task<ActionResult<IEnumerable<Model>>> GetByManufacturerId(int manufacturerId)
        {
            var result = await _context.Model
                .Where(m => m.MfgId == manufacturerId)
                .ToListAsync();
            return result;
        }

        public async Task<ActionResult<IEnumerable<Model>>> GetBySegmentId(int segmentId)
        {
            var result = await _context.Model
                .Where(m => m.SegId == segmentId)
                .ToListAsync();
            return result;
        }

        public async Task<ActionResult<IEnumerable<Model>>> GetBySegmentAndManufacturerId(int segmentId, int manufacturerId)
        {
            var result = await _context.Model
                .Where(m => m.SegId == segmentId && m.MfgId == manufacturerId)
                .ToListAsync();
            return result;
        }

        public async Task Add(Model model)
        {
            await _context.Model.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Model model)
        {
            _context.Model.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Model.FindAsync(id);
            if (entity != null)
            {
                _context.Model.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
