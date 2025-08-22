using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Configurator.Application.Services;
using Vehicle_Configurator.Domain.Entities;


namespace Vehicle_Configurator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailInvoiceController : ControllerBase
    {
        private readonly InvoiceGenerationService _invoiceService;
        private readonly PdfService _pdfService;  // Your PDF generation service
        private readonly EmailService _emailService;        // Your email sending service

        public EmailInvoiceController(
            InvoiceGenerationService invoiceService,
            PdfService pdfService,
            EmailService emailService)
        {
            _invoiceService = invoiceService;
            _pdfService = pdfService;
            _emailService = emailService;
        }

        [HttpPost("send-email/{invoiceId}")]
        public async Task<IActionResult> SendInvoiceEmail(int invoiceId, [FromBody] InvoiceEmailRequest request)
        {
            // Get logged-in user email from claims
            Console.WriteLine("the invoice id is"+invoiceId);
            try
            {

                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(userEmail))
                    return Unauthorized("User email not found.");

                // Load invoice data from DB (you need to implement this method)
                var invoice = await _invoiceService.GetInvoiceById(invoiceId);
                if (invoice == null)
                    return NotFound("Invoice not found.");
                // Load invoice details (with component names and prices)
                var details = await _invoiceService.GetInvoiceDetailsWithPrices(invoiceId,request.Quantity,request.UnitPrice,request.Tax,request.Segment, request.Manufacturer, request.Email,request.Model);
               
                // Generate HTML for invoice
                var html = _invoiceService.GenerateInvoiceHtml(invoice, details);

                // Generate PDF bytes from HTML
                var pdfBytes = _pdfService.GenerateInvoicePdf(html);

                // Send email with PDF attached
                var success = await _emailService.SendEmailWithAttachment(
                    userEmail,
                    $"Invoice #{invoiceId}",
                    "Please find attached your invoice.",
                    pdfBytes,
                    "invoice.pdf");

                if (!success)
                    return StatusCode(500, "Failed to send email.");

                return Ok("Invoice emailed successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception somewhere accessible, e.g., Console or ILogger
                Console.WriteLine($"Email sending failed: {ex}");
                return StatusCode(500, "Internal server error");
            }

        }

    }
}
