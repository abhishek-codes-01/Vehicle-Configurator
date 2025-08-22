using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Infrastructure.Repositories;

namespace Vehicle_Configurator.Application.Services
{
    public class ManufacturerService : IManufacturerRepository
    {
        private readonly AppDbContext _context;

        public ManufacturerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAll()
        {
            var result = await _context.Manufacturer.ToListAsync();
            return result;
        }

        public async Task<ActionResult<Manufacturer>> GetById(int id)
        {
            var result = await _context.Manufacturer.FindAsync(id);
            return result;
        }

        public async Task Add(Manufacturer manufacturer)
        {
            await _context.Manufacturer.AddAsync(manufacturer);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Manufacturer manufacturer)
        {
            _context.Manufacturer.Update(manufacturer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Manufacturer.FindAsync(id);
            if (entity != null)
            {
                _context.Manufacturer.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
