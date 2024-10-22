using Entities.DataTransferObjects.InvoiceDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Invoices")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class InvoicesController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoicesController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet("GetInvoicesAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetInvoicesAsync([FromQuery] InvoiceParams invoiceParams)
    {
        var results = await _invoiceService.GetInvoices(invoiceParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeleteInvoiceAsync/{id:Guid}")]
    public async Task<IActionResult> DeleteInvoiceAsync([FromRoute(Name = "id")] Guid id)
    {
        await _invoiceService.DeleteInvoiceAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdateInvoiceAsync/{id:Guid}")]
    public async Task<IActionResult> UpdateInvoiceAsync([FromRoute(Name = "id")] Guid id, [FromBody] InvoiceDtoForUpdate invoiceDtoForUpdate)
    {
        await _invoiceService.UpdateInvoiceAsync(id, true, invoiceDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreateInvoiceAsync")]
    public async Task<IActionResult> CreateInvoiceAsync([FromBody] InvoiceDtoForInsertion invoiceDtoForInsertion)
    {
        await _invoiceService.CreateInvoiceAsync(invoiceDtoForInsertion);
        return StatusCode(201, invoiceDtoForInsertion);
    }
}
