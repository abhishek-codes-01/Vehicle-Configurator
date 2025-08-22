using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IInvoiceHeaderRepository
    {
        Task<ActionResult<InvoiceHeader>> GetByModelId(int modelId);
        Task<ActionResult<InvoiceHeader>> GetById(int invoiceHeaderId);
        Task<InvoiceHeader> Save(InvoiceHeader invoiceHeader);

    }
}
