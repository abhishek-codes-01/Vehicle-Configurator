using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Infrastructure.Repositories;

namespace Vehicle_Configurator.Application.Services
{
    public class ComponentService : IComponentRepository
    {
        private readonly AppDbContext _context;

        public ComponentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Component>> GetAllComps()
        {
            return await _context.Component.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Component>>> GetByModelId(int modelId)
        {
            var result = await (
                from c in _context.Component
                join v in _context.VehicleDetail on c.CompId equals v.CompId
                where v.ModelId == modelId
                select c
            ).ToListAsync();

            return result;
        }
    }
}
