using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Infrastructure.Repositories;

namespace Vehicle_Configurator.Application.Services
{
    public class SegmentService : ISegmentRepository
    {
        private readonly AppDbContext _context;

        public SegmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Segment>>> GetAll()
        {
            var result = await _context.Segment.ToListAsync();
            return result;
        }

        public async Task<ActionResult<Segment>> GetById(int id)
        {
            var result = await _context.Segment.FindAsync(id);
            return result;
        }

        public async Task Add(Segment segment)
        {
            await _context.Segment.AddAsync(segment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Segment segment)
        {
            _context.Segment.Update(segment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Segment.FindAsync(id);
            if (entity != null)
            {
                _context.Segment.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
