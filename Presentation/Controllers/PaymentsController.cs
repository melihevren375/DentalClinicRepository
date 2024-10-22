using Entities.DataTransferObjects.PaymentDtos;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers;

[ApiController]
[Route("api/Payments")]
[ServiceFilter(typeof(LogFilterAttribute))]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet("GetPaymentsAsync")]
    [HttpCacheValidation(MustRevalidate = true)]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetPaymentsAsync([FromQuery] PaymentParams paymentParams)
    {
        var results = await _paymentService.GetPayments(paymentParams);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.metaData));
        return Ok(results);
    }

    [HttpDelete("DeletePaymentAsync/{id:Guid}")]
    public async Task<IActionResult> DeletePaymentAsync([FromRoute(Name = "id")] Guid id)
    {
        await _paymentService.DeletePaymentAsync(id, true);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("UpdatePaymentAsync/{id:Guid}")]
    public async Task<IActionResult> UpdatePaymentAsync([FromRoute(Name = "id")] Guid id, [FromBody] PaymentDtoForUpdate paymentDtoForUpdate)
    {
        await _paymentService.UpdatePaymentAsync(id, true, paymentDtoForUpdate);
        return NoContent();
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost("CreatePaymentAsync")]
    public async Task<IActionResult> CreatePaymentAsync([FromBody] PaymentDtoForInsertion paymentDtoForInsertion)
    {
        await _paymentService.CreatePaymentAsync(paymentDtoForInsertion);
        return StatusCode(201, paymentDtoForInsertion);
    }
}
