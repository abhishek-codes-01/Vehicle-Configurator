using Microsoft.EntityFrameworkCore;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Domain.DTOs;
using Vehicle_Configurator.Infrastructure.Repositories;

public class InvoiceGenerationService
{
    private readonly AppDbContext _context;

    public InvoiceGenerationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<InvoiceHeader> GetInvoiceById(int invoiceId)
    {
        return await _context.InvoiceHeader
            .FirstOrDefaultAsync(i => i.InvId == invoiceId);
    }

    public async Task<List<InvoiceDetailViewModel>> GetInvoiceDetailsWithPrices(int invoiceId,int qty,double price, double tax, string segment, string manufacturer,string email,string model)
    {
        var modelId = await _context.InvoiceHeader
                            .Where(i => i.InvId == invoiceId)
                            .Select(i => i.ModelId)
                            .FirstOrDefaultAsync();

        var invoiceDetails = await _context.InvoiceDetail
            .Where(d => d.InvId == invoiceId)
            .ToListAsync();

        var components = await _context.Component.ToListAsync();

        var altComponents = await _context.AlternateComponentMaster
            .Where(a => a.ModelId == modelId)
            .ToListAsync();

        var result = new List<InvoiceDetailViewModel>();

        foreach (var detail in invoiceDetails)
        {
            // Try to find in alternate components first
            var altComp = altComponents.FirstOrDefault(a => a.AltCompId == detail.CompId);
            if (altComp != null)
            {
                var altCompName = components.FirstOrDefault(c => c.CompId == altComp.AltCompId)?.CompName ?? "Unknown Component";
                result.Add(new InvoiceDetailViewModel
                {
                    ComponentName = altCompName,
                    Price = altComp.DeltaPrice,
                    Quantity = qty,
                    UnitPrice = price,
                    Tax = tax,
                    Segment = segment,
                    Manufacturer = manufacturer,
                    Email=email,
                    Model = model
                });
                continue;
            }

            // Otherwise treat as base component
            var baseCompName = components.FirstOrDefault(c => c.CompId == detail.CompId)?.CompName ?? "Unknown Component";
            result.Add(new InvoiceDetailViewModel
            {
                ComponentName = baseCompName,
                Price = 0.0,
                Quantity = qty,
                UnitPrice = price,
                Tax = tax,
                Segment=segment,
                Manufacturer=manufacturer,
                Email=email,
                Model=model
                //Email = email,    
            });
        }

        return result;
    }



    public string GenerateInvoiceHtml(InvoiceHeader invoice, List<InvoiceDetailViewModel> details)
    {
        return $@"
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; }}
        table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }}
        th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
        th {{ background-color: #f2f2f2; }}
        h1 {{ color: #333; }}
        p {{ font-size: 14px; }}
    </style>
</head>
<body>
    <h1>Invoice #{invoice.InvId}</h1>
    <p><strong>Customer:</strong> {invoice.CustomerDetail}</p>
    <p><strong>Email:</strong> {details[0].Email}</p>
    <p><strong>Date:</strong> {invoice.InvDate:dd-MM-yyyy}</p>
    <p><strong>Model:</strong> {details[0].Model}</p>
    <p><strong>Segment:</strong> {details[0].Segment}</p>
    <p><strong>Manufacturer:</strong> {details[0].Manufacturer}</p>
    <table>
        <thead>
            <tr>
                <th>Component</th>
                <th>Price($)</th>
            </tr>
        </thead>
        <tbody>
            {string.Join("", details.Select(d =>
                    $"<tr>" +
                    $"<td>{d.ComponentName}</td>" +
                    $"<td>{d.Price}</td>" +
                    $"</tr>"
                ))}
        </tbody>
    </table>
    
    <p><strong>Quantity:</strong> {details[0].Quantity} 
    <p><strong>Unit Price:</strong> $ {details[0].UnitPrice:F2} 
    <p><strong>Tax:</strong> $ {details[0].Tax:F2}
    <p>
    <strong>Total:</strong> $ {invoice.TotalAmt:F2}
    </p>
    
</body>
</html>";
    }

}
