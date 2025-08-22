using DinkToPdf.Contracts;
using DinkToPdf;
using System;
using System.IO; // Needed for AssemblyLoadContext

namespace Vehicle_Configurator.Application.Services
{
    // This is the missing class
    

    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(AppContext.BaseDirectory, "libwkhtmltox.dll"));
            _converter = converter;
        }

        public byte[] GenerateInvoicePdf(string htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" },
                    }
                }
            };

            return _converter.Convert(doc);
        }
    }
}
