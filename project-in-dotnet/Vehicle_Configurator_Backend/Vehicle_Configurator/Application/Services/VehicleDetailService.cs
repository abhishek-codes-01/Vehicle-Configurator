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
    public class VehicleDetailService : IVehicleDetailRepository
    {
        private readonly AppDbContext _context;

        public VehicleDetailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetByComponentId(int componentId)
        {
            var details = await _context.VehicleDetail
                .Where(v => v.CompId == componentId)
                .ToListAsync();

            return details;
        }

        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetByModelId(int modelId)
        {
            var details = await _context.VehicleDetail
                .Where(v => v.ModelId == modelId)
                .ToListAsync();

            return details;
        }
    }
}
