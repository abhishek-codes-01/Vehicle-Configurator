using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Configurator.Application.Services;

namespace Vehicle_Configurator.API.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly PdfService _pdfService;

        public TestController(PdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet]
        public IActionResult Get() => Ok("PdfService injected successfully.");
    }

}
