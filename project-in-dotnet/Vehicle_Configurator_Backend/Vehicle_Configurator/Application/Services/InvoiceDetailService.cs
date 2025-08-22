using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.DTOs;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Infrastructure.Repositories;

namespace Vehicle_Configurator.Application.Services
{
    public class InvoiceDetailService : IInvoiceDetailRepository
    {
        private readonly AppDbContext _context;

        public InvoiceDetailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetById(int invoiceDetailId)
        {
            var result = await _context.InvoiceDetail
                .Where(i => i.InvDtlId == invoiceDetailId)
                .ToListAsync();

            return result;
        }

        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetByComponentId(int componentId)
        {
            var result = await _context.InvoiceDetail
                .Where(i => i.CompId == componentId)
                .ToListAsync();

            return result;
        }
        public async Task<ActionResult> CreateInvoiceDetails(List<InvoiceDetailDto> invoiceDetails)
        {
            if (invoiceDetails == null || invoiceDetails.Count == 0)
            {
                return new BadRequestResult();
            }

            // Map DTOs to Entities
            var entities = invoiceDetails.Select(dto => new InvoiceDetail
            {
                InvId = dto.InvId,
                CompId = dto.CompId
            }).ToList();

            await _context.InvoiceDetail.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return new OkResult();
        }
        public async Task<List<InvoiceDetailViewModel>> GetInvoiceDetailsWithPrices(int invoiceId)
        {
            var modelId = await _context.InvoiceHeader
                .Where(i => i.InvId == invoiceId)
                .Select(i => i.ModelId)
                .FirstOrDefaultAsync();

            Console.WriteLine($"ModelId for InvoiceId {invoiceId}: {modelId}");

            var invoiceDetails = await _context.InvoiceDetail
                .Where(d => d.InvId == invoiceId)
                .ToListAsync();

            Console.WriteLine($"InvoiceDetails count: {invoiceDetails.Count}");
            foreach (var detail in invoiceDetails)
            {
                Console.WriteLine($"InvoiceDetail - InvDtlId: {detail.InvDtlId}, CompId: {detail.CompId}");
            }

            var components = await _context.Component.ToListAsync();
            Console.WriteLine($"Components count: {components.Count}");
            foreach (var comp in components)
            {
                Console.WriteLine($"Component - CompId: {comp.CompId}, CompName: {comp.CompName}");
            }

            var altComponents = await _context.AlternateComponentMaster
                .Where(a => a.ModelId == modelId)
                .ToListAsync();

            Console.WriteLine($"AlternateComponents count: {altComponents.Count}");
            foreach (var alt in altComponents)
            {
                Console.WriteLine($"AltComp - AltCompId: {alt.AltCompId}, CompId: {alt.CompId}, DeltaPrice: {alt.DeltaPrice}");
            }

            var result = new List<InvoiceDetailViewModel>();

            foreach (var detail in invoiceDetails)
            {
                var baseComp = components.FirstOrDefault(c => c.CompId == detail.CompId);
                if (baseComp != null)
                {
                    result.Add(new InvoiceDetailViewModel
                    {
                        ComponentName = baseComp.CompName,
                        Price = 0.0
                    });
                    continue;
                }

                var altComp = altComponents.FirstOrDefault(a => a.AltCompId == detail.CompId);
                if (altComp != null)
                {
                    var relatedBaseComp = components.FirstOrDefault(c => c.CompId == altComp.CompId);
                    result.Add(new InvoiceDetailViewModel
                    {
                        ComponentName = relatedBaseComp != null
                            ? $"{relatedBaseComp.CompName} (Alternate)"
                            : "Unknown Component",
                        Price = altComp.DeltaPrice
                    });
                    continue;
                }

                result.Add(new InvoiceDetailViewModel
                {
                    ComponentName = "Unknown Component",
                    Price = 0.0
                });
            }

            Console.WriteLine($"Result count: {result.Count}");
            foreach (var r in result)
            {
                Console.WriteLine($"ComponentName: {r.ComponentName}, Price: {r.Price}");
            }

            return result;
        }





    }
}
