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
    public class SgMfgMasterService : ISgMfgMasterRepository
    {
        private readonly AppDbContext _context;

        public SgMfgMasterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturersBySegmentId(int segmentId)
        {
            var result = await (
                from s in _context.SgMfgMaster
                join m in _context.Manufacturer on s.MfgId equals m.MfgId
                where s.SegId == segmentId
                select m
            ).ToListAsync();

            return result;
        }
    }
}
