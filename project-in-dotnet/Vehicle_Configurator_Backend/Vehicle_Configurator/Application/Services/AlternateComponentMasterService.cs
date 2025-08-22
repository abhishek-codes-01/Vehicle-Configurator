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
    public class AlternateComponentMasterService : IAlternateComponentMasterRepository
    {
        private readonly AppDbContext _context;

        public AlternateComponentMasterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByModelId(int modelId)
        {
            var result = await _context.AlternateComponentMaster
                .Where(a => a.ModelId == modelId)
                .ToListAsync();
            return result;
        }

        public async Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByComponentId(int componentId)
        {
            var result = await _context.AlternateComponentMaster
                .Where(a => a.CompId == componentId)
                .ToListAsync();
            return result;
        }

        public async Task<ActionResult<IEnumerable<AlternateComponentMaster>>> GetByModelIdAndComponentId(int modelId, int componentId)
        {
            var result = await _context.AlternateComponentMaster
                .Where(a => a.ModelId == modelId && a.CompId == componentId)
                .ToListAsync();
            return result;
        }
    }
}
