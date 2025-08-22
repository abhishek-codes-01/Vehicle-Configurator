    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Vehicle_Configurator.Application.Interfaces;
    using Vehicle_Configurator.Domain.Entities;

    namespace Vehicle_Configurator.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class InvoiceHeaderController : ControllerBase
        {
            private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;

            public InvoiceHeaderController(IInvoiceHeaderRepository invoiceHeaderRepository)
            {
                _invoiceHeaderRepository = invoiceHeaderRepository;
            }

            // GET: api/invoiceheader/by-model/{modelId}
            /// <summary>
            /// Retrieves an invoice header by its associated model ID.
            /// </summary>
            /// <param name="modelId">The ID of the vehicle model.</param>
            /// <returns>The invoice header for the specified model, or NotFound if not found.</returns>
            [HttpGet("by-model/{modelId}")]
            public async Task<ActionResult<InvoiceHeader>> GetByModelId(int modelId)
            {
                var invoiceHeaderResult = await _invoiceHeaderRepository.GetByModelId(modelId);
                var invoiceHeader = invoiceHeaderResult.Value;

                if (invoiceHeader == null)
                {
                    return NotFound($"No invoice header found for model with ID: {modelId}");
                }

                return Ok(invoiceHeader);
            }

            // GET: api/invoiceheader/{invoiceHeaderId}
            /// <summary>
            /// Retrieves an invoice header by its unique invoice ID.
            /// </summary>
            /// <param name="invoiceHeaderId">The unique ID of the invoice header.</param>
            /// <returns>The invoice header with the specified ID, or NotFound if not found.</returns>
            [HttpGet("{invoiceHeaderId}")]
            public async Task<ActionResult<InvoiceHeader>> GetById(int invoiceHeaderId)
            {
                var invoiceHeaderResult = await _invoiceHeaderRepository.GetById(invoiceHeaderId);
                var invoiceHeader = invoiceHeaderResult.Value;

                if (invoiceHeader == null)
                {
                    return NotFound($"No invoice header found with ID: {invoiceHeaderId}");
                }

                return Ok(invoiceHeader);
            }


        [HttpPost("save")]
        public async Task<ActionResult<InvoiceHeader>> SaveInvoiceHeader([FromBody] InvoiceHeader invoiceHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedInvoiceHeader = await _invoiceHeaderRepository.Save(invoiceHeader);
            if (savedInvoiceHeader == null)
            {
                return BadRequest("Could not save invoice header");
            }
            return Ok(savedInvoiceHeader);
        }
    

    }
}
