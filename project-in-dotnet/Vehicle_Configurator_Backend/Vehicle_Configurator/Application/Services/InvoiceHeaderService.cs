using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Infrastructure.Repositories;

namespace Vehicle_Configurator.Application.Services
{
    public class InvoiceHeaderService : IInvoiceHeaderRepository
    {
        private readonly AppDbContext _context;

        public InvoiceHeaderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<InvoiceHeader>> GetByModelId(int modelId)
        {
            var result = await _context.InvoiceHeader
                .FirstOrDefaultAsync(i => i.ModelId == modelId);

            return result;
        }

        public async Task<ActionResult<InvoiceHeader>> GetById(int invoiceHeaderId)
        {
            var result = await _context.InvoiceHeader
                .FirstOrDefaultAsync(i => i.InvId == invoiceHeaderId);

            return result;
        }

        public async Task<InvoiceHeader> Save(InvoiceHeader invoiceHeader)
        {
            if (invoiceHeader == null)
                return null;

            // If new (no ID), add it
            if (invoiceHeader.InvId == 0)  // assuming InvId is PK, auto-generated
            {
                _context.InvoiceHeader.Add(invoiceHeader);
            }
            else
            {
                // For existing invoice header, update the entity state
                _context.InvoiceHeader.Update(invoiceHeader);
            }

            var result = await _context.SaveChangesAsync();
            return result > 0 ? invoiceHeader : null;
        }

    }
}
