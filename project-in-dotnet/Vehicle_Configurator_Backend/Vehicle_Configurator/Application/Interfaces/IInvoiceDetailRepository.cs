using System.Collections.Generic;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Configurator.Domain.DTOs;
namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        Task<ActionResult<IEnumerable<InvoiceDetail>>> GetById(int invoiceDetailId);
        Task<ActionResult<IEnumerable<InvoiceDetail>>> GetByComponentId(int componentId);
        Task<ActionResult> CreateInvoiceDetails(List<InvoiceDetailDto> invoiceDetails);
        Task<List<InvoiceDetailViewModel>> GetInvoiceDetailsWithPrices(int invoiceId);
    }
}
